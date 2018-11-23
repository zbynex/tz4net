using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for GeneratorForm.
	/// </summary>
	public class GeneratorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GeneratorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorForm));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(552, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Olson Database";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Item #1",
            "Item #2",
            "Item #3",
            "Item #4"});
            this.checkedListBox1.Location = new System.Drawing.Point(16, 72);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(624, 64);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root directory";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "zoneinfo directory";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(552, 20);
            this.textBox2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(576, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "Select...";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(16, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TZ4Net project directory (destination folder for zoneinfo.resources and cldr.reso" +
                "urces files)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 392);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 20);
            this.button3.TabIndex = 7;
            this.button3.Text = "Generate";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 416);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(656, 112);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(24, 20);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(640, 44);
            this.textBox3.TabIndex = 9;
            this.textBox3.TabStop = false;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(16, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(656, 60);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Note:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(32, 256);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(552, 20);
            this.textBox4.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(592, 256);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 20);
            this.button4.TabIndex = 12;
            this.button4.Text = "Select...";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "CLDR supplemental data xml file";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Location = new System.Drawing.Point(16, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(656, 104);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unicode Database";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "CLDR zone log html file";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(576, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 20);
            this.button5.TabIndex = 14;
            this.button5.Text = "Select...";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(16, 72);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(552, 20);
            this.textBox5.TabIndex = 13;
            // 
            // GeneratorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 543);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "GeneratorForm";
            this.ShowInTaskbar = false;
            this.Text = "GeneratorForm";
            this.Load += new System.EventHandler(this.GeneratorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private string GetFolder() 
		{
			FolderPicker folderPicker = null;
			Cursor oldCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			DialogResult res = DialogResult.Cancel;
			try 
			{
				folderPicker = new FolderPicker();
				folderPicker.StartPosition = FormStartPosition.CenterParent;
				res = folderPicker.ShowDialog(this);
			} 
			finally 
			{
				this.Cursor = oldCursor;
			}
			if (res == DialogResult.OK)
			{
				return folderPicker.Info.FullName;
			} 
			else 
			{
				return null;
			}
		}

		private void OnValueChanged(object sender, EventArgs e) 
		{
			this.Text = string.Format("'{0}' resource generator", this.textBox1.Text);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string folder = GetFolder();
			if (folder != null) 
			{
				this.textBox1.Text = folder;
				OnValueChanged(sender, e);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string folder = GetFolder();
			if (folder != null) 
			{
				this.textBox2.Text = folder;
				OnValueChanged(sender, e);
			}
		}

		private void GeneratorForm_Load(object sender, System.EventArgs e)
		{
			this.textBox1.Text = new DirectoryInfo(".\\..\\..\\..\\..\\etc").FullName;
			this.textBox2.Text = new DirectoryInfo(".\\..\\..\\..\\TZ4Net").FullName;
			this.textBox4.Text = new FileInfo(".\\..\\..\\..\\..\\unicode\\cldr\\common\\supplemental\\windowsZones.xml").FullName;
			this.textBox5.Text = new FileInfo(".\\..\\..\\..\\..\\unicode\\cldr\\data\\docs\\design\\formatting\\zone_log.html").FullName;
			OnValueChanged(sender, e);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ZoneInfoResGen.Added += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
			ZoneInfoResGen.Skipped += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
			ZoneInfoResGen.Processed += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Processed);
			ZoneInfoResGen.Generated += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
			CldrInfoResGen.Added += new CldrInfoResGenUpdateHandler(CldrInfoResGen_Added);
			CldrInfoResGen.Generated += new CldrInfoResGenUpdateHandler(CldrInfoResGen_Generated);

			Cursor oldCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			this.button3.Enabled = false;
			this.richTextBox1.Clear();
			try 
			{
				ArrayList zoneinfoDirs = new ArrayList();
				foreach(string zoneinfoSubdir in checkedListBox1.CheckedItems) 
				{
					string zoneinfoDir = string.Format("{0}\\{1}", this.textBox1.Text, zoneinfoSubdir);
					System.Diagnostics.Trace.Assert(Directory.Exists(zoneinfoDir));
					zoneinfoDirs.Add(zoneinfoDir);
				}
				ZoneInfoResGen.Generate((string[])zoneinfoDirs.ToArray(typeof(string)), this.textBox2.Text);
				CldrInfoResGen.Generate(new string[]{this.textBox4.Text, this.textBox5.Text}, this.textBox2.Text);
			} 
			finally 
			{
				this.button3.Enabled = true;
				this.Cursor = oldCursor;
				ZoneInfoResGen.Added -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
				ZoneInfoResGen.Skipped -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
				ZoneInfoResGen.Processed -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Processed);
				ZoneInfoResGen.Generated -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
				CldrInfoResGen.Added -= new CldrInfoResGenUpdateHandler(CldrInfoResGen_Added);
				CldrInfoResGen.Generated -= new CldrInfoResGenUpdateHandler(CldrInfoResGen_Generated);
			}
		}

		private void WriteLine(string text) 
		{ 
			this.richTextBox1.Focus();
			this.richTextBox1.AppendText(string.Format("{0}\n", text));
		}

		private void ZoneInfoResGen_Added(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Added resource: {0} ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
		}

		private void ZoneInfoResGen_Skipped(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Skipped file: {0}. 'TZif' signature not found.", args.FileName));
		}

		private void ZoneInfoResGen_Processed(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Processed directory: {0}.", args.FileName));
		}

		private void ZoneInfoResGen_Generated(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Generated resource file: {0} ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
		}

		private void CldrInfoResGen_Added(object sender, CldrInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Added CLDR file: '{0}'", args.FileName));
		}

		private void CldrInfoResGen_Generated(object sender, CldrInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Generated resource file: '{0}' ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			this.checkedListBox1.Items.Clear();
			button3.Enabled = false;
			DirectoryInfo dirInfo = new DirectoryInfo(this.textBox1.Text);
			if (dirInfo != null) 
			{
				if (dirInfo.Exists) 
				{
					DirectoryInfo[] subdirInfos = dirInfo.GetDirectories();
					foreach(DirectoryInfo subdirInfo in subdirInfos) 
					{
						int index = this.checkedListBox1.Items.Add(subdirInfo.Name);
						if (subdirInfo.Name == ZoneInfo.DefaultDir) 
						{
							this.checkedListBox1.SetItemCheckState(index, CheckState.Checked);
						}
					}
				}
			}
		}

		private void checkedListBox1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			CheckedListBox lBox = sender as CheckedListBox;
			System.Diagnostics.Debug.Assert(lBox != null);
			button3.Enabled = lBox.CheckedIndices.Count > 1 || e.NewValue == CheckState.Checked;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			Cursor oldCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.InitialDirectory = new FileInfo(this.textBox4.Text).DirectoryName;
				openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*" ;
				openFileDialog1.FilterIndex = 1;
				openFileDialog1.RestoreDirectory = true;
				openFileDialog1.CheckFileExists = true;
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					this.textBox4.Text = openFileDialog1.FileName;
				}
			} 
			finally 
			{
				this.Cursor = oldCursor;
			}
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Cursor oldCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			try 
			{
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.InitialDirectory = new FileInfo(this.textBox5.Text).DirectoryName;
				dialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*" ;
				dialog.FilterIndex = 1;
				dialog.RestoreDirectory = true;
				dialog.CheckFileExists = true;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					this.textBox5.Text = dialog.FileName;
				}
			} 
			finally 
			{
				this.Cursor = oldCursor;
			}
		}
	}
}
