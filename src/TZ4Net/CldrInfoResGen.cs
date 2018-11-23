#region Copyright (c) 2010 Zbigniew Babiej

/* 
 * 
Written by Zbigniew Babiej, zbabiej@yahoo.com.
*/

#endregion

#region Using

using System;
using System.Xml;
using System.IO;
using System.Resources;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Policy;

#endregion

namespace TZ4Net
{
	/// <summary>
	/// Argumens class of <see cref="CldrInfoResGenUpdateHandler"/> delegate.
	/// </summary>
	public class CldrInfoResGenUpdateArgs : System.EventArgs 
	{
		#region Fields

		/// <summary>
		/// Caches the message to be reported to the listeners;
		/// </summary>
		private string fileName;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates the event arguments instance.
		/// </summary>
		/// <param name="fileName">File name the events refers to.</param>
		public CldrInfoResGenUpdateArgs(string fileName) 
		{
			this.fileName = fileName;
		}

		#endregion

		/// <summary>
		/// Gets the message to be reported to the listeners;
		/// </summary>
		public string FileName
		{
			get 
			{
				return fileName;
			}
		}
	}

	/// <summary>
	/// Handler for the Message event of the <see cref="CldrInfoResGen"/> class.
	/// </summary>
	public delegate void CldrInfoResGenUpdateHandler(object sender, CldrInfoResGenUpdateArgs args);

	/// <summary>
	/// Utility class that generates the .NET resource containig CldrInfo files.
	/// </summary>
	public class CldrInfoResGen
	{
		#region Public interface

		/// <summary>
		/// Informs the clients about the generation progress. Fired when new CldrInfo file was added to resources.
		/// </summary>
		public static event  CldrInfoResGenUpdateHandler Added;

		/// <summary>
		/// Informs the clients about the generation progress. Fired after resource file was generated.
		/// </summary>
		public static event  CldrInfoResGenUpdateHandler Generated;

		/// <summary>
		/// Adds specified CLDR files into .NET resource file.
		/// </summary>
		/// <param name="CldrFilePaths">The array of full path names to Unicode CLDR's data files.</param>
		/// <param name="resourceDir">Output directory of the .NET resource file to be generated.</param>
		[FileIOPermission(SecurityAction.Demand)]
		public static void Generate(string[] CldrFilePaths, string resourceDir)
		{
			if (CldrFilePaths == null) 
			{
				throw new ArgumentNullException("CldrFilePaths", "List of CLDR file paths can not be null.");
			}

			foreach(string filePath in CldrFilePaths) 
			{
				if (!File.Exists(filePath))
				{
					throw new ArgumentException(string.Format("CLDR data file does not exist ({0}).", filePath, "CldrFilePaths"));
				}
			}
			
			if (resourceDir == null) 
			{
				throw new ArgumentNullException("resourceDir", "Resource destination directory can not be null");
			}

			string resourceFullPath = string.Format("{0}\\{1}", resourceDir, ResourceFileName);
			ResourceWriter writer = null;
			try 
			{
				writer = new ResourceWriter(resourceFullPath);
				foreach(string filePath in CldrFilePaths) 
				{
					AddFile(filePath, writer);
				}
				writer.Generate();
				writer.Close();
				Debug.Assert(File.Exists(resourceFullPath), "Resource file does not exist.");
				OnGenerated(resourceFullPath);
			} 
			finally
			{
				if (writer != null) 
				{
					writer.Close();
				}
			}
		}

		#endregion

		#region Implementation

		/// <summary>
		/// Gets the resource file name. Name it taken from <see cref="OlsonTimeZone"/> class.
		/// </summary>
		internal static string ResourceFileName
		{
			get 
			{
				return OlsonTimeZone.CldrResourceFileName;
			}
		}

		/// <summary>
		/// Helper method which adds the file supplemental to the resources
		/// </summary>
		/// <param name="fileName">Full path to file.</param>
		/// <param name="writer">Resource writer to add to.</param>
		private static void AddFile(string fileName, ResourceWriter writer)
		{
			FileInfo file = new FileInfo(fileName);
			Debug.Assert(file.Exists);
			FileStream stream = null;
			try 
			{
				stream = file.OpenRead();
				byte[] buf = new byte[stream.Length];
				stream.Position = 0;
				int bytesRead = stream.Read(buf, 0, buf.Length);
				Debug.Assert(bytesRead == buf.Length);
				writer.AddResource(file.Name, buf);
				OnAdded(file.FullName);
			}
			finally 
			{
				if (stream != null) 
				{
					stream.Close();
				}
			}
		}

		/// <summary>
		/// Propagates the message to all listeners about added resources.
		/// </summary>
		/// <param name="fileName">Name of the file which was addded to resources.</param>
		private static void OnAdded(string fileName) 
		{
			if (Added != null) 
			{
				Added(typeof(CldrInfoResGen), new CldrInfoResGenUpdateArgs(fileName));
			}
		}

		/// <summary>
		/// Propagates the message to all listeners about new resource file being generated.
		/// </summary>
		/// <param name="fileName">Name of the newly generated resource file.</param>
		private static void OnGenerated(string fileName) 
		{
			if (Generated != null) 
			{
				Generated(typeof(CldrInfoResGen), new CldrInfoResGenUpdateArgs(fileName));
			}
		}

		#endregion
	}
}
