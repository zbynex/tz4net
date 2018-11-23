using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for Win32MapForm.
	/// </summary>
	public class Win32MapForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Win32MapForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			PostInitializeComponent() ;
		}

		private static Hashtable CreateRegistryMap()
		{
			Hashtable res = new Hashtable();
			RegistryKey regKey = null;
			
			try 
			{
				regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones");
				Debug.Assert(regKey != null);
				string[] subKeyNames = regKey.GetSubKeyNames();
				foreach (string subKeyName in subKeyNames) 
				{
					RegistryKey subKey = null;
					try 
					{
						subKey = regKey.OpenSubKey(subKeyName);
						Debug.Assert(subKey != null);
						string localWin32Name = (string)subKey.GetValue(@"Display");
						if (localWin32Name != null) 
						{
							res.Add(subKeyName,localWin32Name);
						}
					} 
					finally 
					{
						if (subKey != null) 
						{
							subKey.Close();
						}
					}
				}
			}
			catch (System.Security.SecurityException) 
			{
			}
			finally 
			{
				if (regKey != null) 
				{
					regKey.Close();
				}
			}
			return res;
		}

		private void PostInitializeComponent() 
		{
			Hashtable regMap = CreateRegistryMap();
			Hashtable regNames = new Hashtable();
			foreach(string regId in regMap.Keys) 
			{
				Debug.Assert(regId != null);
				regNames.Add(regId, regMap[regId]);
			}
			ArrayList allWin32Ids = new ArrayList(OlsonTimeZone.AllWin32Ids);
			foreach(string regWin32Id in regNames.Keys) 
			{
				if (!allWin32Ids.Contains(regWin32Id))
				{
					allWin32Ids.Add(regWin32Id);
				}
			}
			allWin32Ids.Sort();
			for(int i = 0; i < allWin32Ids.Count; i++)
			{
				listView1.Items.Add(new ListViewItem(new string[]{(i).ToString("00"), (string)allWin32Ids[i], OlsonTimeZone.GetNameFromWin32Id((string)allWin32Ids[i]), OlsonTimeZone.GetWin32NameFromWin32Id((string)allWin32Ids[i]), (string)regNames[allWin32Ids[i]]}));
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(24, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(664, 16);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "TZ4Net implements Unicode CLDR Win32 time zone mapping. Visit http://www.unicode." +
                "org/cldr for more details.";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(16, 80);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(821, 432);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr";
            this.columnHeader1.Width = 26;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "(CLDR+Registry) Win32 Id";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CLDR Olson Name";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CLDR Win32 Display Name";
            this.columnHeader4.Width = 300;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Registry Win32 Display Name";
            this.columnHeader5.Width = 300;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Explore";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Convert From";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Convert To";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current mapping overview:";
            // 
            // Win32MapForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(852, 543);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Win32MapForm";
            this.Text = "Unicode CLDR\'s Win32 time zone mapping";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private string OlsonName 
		{
			get 
			{
				if (listView1.SelectedIndices.Count > 0) 
				{
					Trace.Assert(listView1.Items[listView1.SelectedIndices[0]].SubItems.Count == 5);
					string olsonName = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
					Trace.Assert(olsonName != null);
					return olsonName;
				}
				return null;
			}
		}

		private void Explore() 
		{
			if (OlsonName != null) 
			{
				MainForm parent = (MainForm)this.MdiParent;
				parent.OpenForm(typeof(ExplorerForm), new object[]{null, OlsonName});
			}
		}

		private void ConvertFrom() 
		{
			if (OlsonName != null) 
			{
				MainForm parent = (MainForm)this.MdiParent;
				parent.OpenForm(typeof(ConverterForm), new object[]{OlsonName, null});
			}
		}

		private void ConvertTo() 
		{
			if (OlsonName != null) 
			{
				MainForm parent = (MainForm)this.MdiParent;
				parent.OpenForm(typeof(ConverterForm), new object[]{null, OlsonName});
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			Explore();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Explore();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			ConvertFrom();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			ConvertTo();
		}
	}
}
