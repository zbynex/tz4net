using System;
using System.IO;
using NUnit.Framework;
using TZ4Net;

namespace TZ4NetTests
{
	/// <summary>
	/// Tests for ZoneInfoResGen class.
	/// </summary>
	[TestFixture]
	public class CldrInfoResGenFixture
	{
		private static int addedCount;
		private static int generatedCount;

		[SetUp]
		public void Setup()
		{
			CldrInfoResGen.Added += new CldrInfoResGenUpdateHandler(CldrInfoResGen_Added);
			CldrInfoResGen.Generated += new CldrInfoResGenUpdateHandler(CldrInfoResGen_Generated);
		}

		[TearDown]
		public void Teardown() 
		{
			CldrInfoResGen.Added -= new CldrInfoResGenUpdateHandler(CldrInfoResGen_Added);
			CldrInfoResGen.Generated -= new CldrInfoResGenUpdateHandler(CldrInfoResGen_Generated);
		}
		
		[Test]
		public void GenerateResourceFile()
		{
			const string CldrSupplementalFile = @".\..\..\..\..\unicode\cldr\common\supplemental\supplementalData.xml";
			const string CldrZoneLogFile = @".\..\..\..\..\unicode\cldr\data\docs\design\formatting\zone_log.html";
			const string resourceDir = ".";
			addedCount = 0;
			generatedCount = 0;
			CldrInfoResGen.Generate(new string[]{new FileInfo(CldrSupplementalFile).FullName, new FileInfo(CldrZoneLogFile).FullName}, new DirectoryInfo(resourceDir).FullName);
			Assert.IsTrue(addedCount == 2, "No CLDR entries added to resource file.");
			Assert.IsTrue(generatedCount == 1, "CLDR resource file was not generated.");
		}

		private static void CldrInfoResGen_Added(object sender, CldrInfoResGenUpdateArgs args) 
		{
			System.Console.WriteLine(string.Format("Added CLDR file: '{0}'", args.FileName));
			addedCount++;
		}

		private static void CldrInfoResGen_Generated(object sender, CldrInfoResGenUpdateArgs args) 
		{
			System.Console.WriteLine("Generated resource file: '{0}'.", args.FileName);
			generatedCount++;
		}

	}
}