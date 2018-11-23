using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for ExplorerForm.
	/// </summary>
	public class ExplorerForm : System.Windows.Forms.Form
	{
		private TZ4NetDemo.TimeZonePicker timeZonePicker1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnStart;
		private System.Windows.Forms.ColumnHeader columnEnd;
		private System.Windows.Forms.ColumnHeader columnDelta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnNo;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ListView listView4;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ColumnHeader columnIsDST;
		private TZ4NetDemo.TimeZoneDirPicker timeZoneDirPicker1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox textBox15;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ExplorerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			timeZonePicker1.ZoneName = OlsonTimeZone.CurrentTimeZone.Name;
		}

		public ExplorerForm(string zoneDir, string zoneName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (zoneDir != null) 
			{
				this.timeZoneDirPicker1.ZoneDir = zoneDir;
			}
			if (zoneName != null) 
			{
				this.timeZonePicker1.ZoneName = zoneName;
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnNo = new System.Windows.Forms.ColumnHeader();
            this.columnStart = new System.Windows.Forms.ColumnHeader();
            this.columnEnd = new System.Windows.Forms.ColumnHeader();
            this.columnDelta = new System.Windows.Forms.ColumnHeader();
            this.columnIsDST = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.label8 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.timeZoneDirPicker1 = new TZ4NetDemo.TimeZoneDirPicker();
            this.timeZonePicker1 = new TZ4NetDemo.TimeZonePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNo,
            this.columnStart,
            this.columnEnd,
            this.columnDelta,
            this.columnIsDST});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(256, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(376, 150);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnNo
            // 
            this.columnNo.Text = "Nr";
            this.columnNo.Width = 30;
            // 
            // columnStart
            // 
            this.columnStart.Text = "Start";
            this.columnStart.Width = 116;
            // 
            // columnEnd
            // 
            this.columnEnd.Text = "End";
            this.columnEnd.Width = 116;
            // 
            // columnDelta
            // 
            this.columnDelta.Text = "Delta";
            this.columnDelta.Width = 53;
            // 
            // columnIsDST
            // 
            this.columnIsDST.Text = "DST";
            this.columnIsDST.Width = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(256, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Daylight Changes:";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(8, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 38);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Note:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(24, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(608, 14);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "This form allows to explore the properties of both contained ZoneInfo and contain" +
                "ing OlsonTimeZone instances.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(288, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Time Zone Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(8, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 184);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OlsonTimeZone:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(160, 152);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(88, 20);
            this.textBox13.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Win32 ID:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(16, 112);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(232, 20);
            this.textBox12.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(88, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(68, 20);
            this.textBox5.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Raw Offset:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 152);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(68, 20);
            this.textBox4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Standard Name:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(232, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Daylight Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(232, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(40, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Standard Name:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(40, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Daylight Name:";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(480, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Show All Time Changes";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(162, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 16);
            this.label20.TabIndex = 13;
            this.label20.Text = "Std Abbreviation:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(88, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Current Offset:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.listView4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.listView3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 272);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ZoneInfo:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(552, 240);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(80, 20);
            this.textBox11.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(552, 184);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 17;
            this.label17.Text = "Raw Offset:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(552, 200);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(80, 20);
            this.textBox10.TabIndex = 7;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(360, 240);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(184, 20);
            this.textBox9.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(552, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 11;
            this.label14.Text = "ID:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(552, 160);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(80, 20);
            this.textBox7.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Leap Second Corrections:";
            // 
            // listView4
            // 
            this.listView4.AllowColumnReorder = true;
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader14});
            this.listView4.GridLines = true;
            this.listView4.Location = new System.Drawing.Point(16, 168);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(336, 94);
            this.listView4.TabIndex = 3;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nr";
            this.columnHeader8.Width = 30;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Unix Clock";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "UTC Time";
            this.columnHeader13.Width = 140;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Correction";
            this.columnHeader14.Width = 64;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Rules:";
            // 
            // listView3
            // 
            this.listView3.AllowColumnReorder = true;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(16, 32);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(188, 108);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nr";
            this.columnHeader7.Width = 30;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            this.columnHeader10.Width = 50;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Offset";
            this.columnHeader11.Width = 50;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "DST";
            this.columnHeader12.Width = 37;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(211, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tranzitions:";
            // 
            // listView2
            // 
            this.listView2.AllowColumnReorder = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(210, 32);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(422, 108);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nr";
            this.columnHeader5.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Unix Clock";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "UTC Time";
            this.columnHeader1.Width = 159;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Offset";
            this.columnHeader3.Width = 45;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DST";
            this.columnHeader4.Width = 38;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(552, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "Current Offset:";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(360, 144);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 9;
            this.label21.Text = "Normal Rule:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(360, 160);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(184, 20);
            this.textBox14.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(360, 224);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(160, 16);
            this.label22.TabIndex = 15;
            this.label22.Text = "Nearest DST Rule:";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(360, 184);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 16);
            this.label23.TabIndex = 13;
            this.label23.Text = "Nearest Non-DST Rule:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(360, 200);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(184, 20);
            this.textBox15.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(72, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 16;
            this.label19.Text = "Directory:";
            // 
            // timeZoneDirPicker1
            // 
            this.timeZoneDirPicker1.BackColor = System.Drawing.Color.Silver;
            this.timeZoneDirPicker1.Location = new System.Drawing.Point(128, 48);
            this.timeZoneDirPicker1.Name = "timeZoneDirPicker1";
            this.timeZoneDirPicker1.Size = new System.Drawing.Size(136, 21);
            this.timeZoneDirPicker1.TabIndex = 17;
            this.timeZoneDirPicker1.ZoneDir = "zoneinfo";
            this.timeZoneDirPicker1.ValueChanged += new System.EventHandler(this.timeZoneDirPicker1_ValueChanged);
            // 
            // timeZonePicker1
            // 
            this.timeZonePicker1.BackColor = System.Drawing.Color.Silver;
            this.timeZonePicker1.Location = new System.Drawing.Point(384, 48);
            this.timeZonePicker1.Name = "timeZonePicker1";
            this.timeZonePicker1.Size = new System.Drawing.Size(200, 21);
            this.timeZonePicker1.TabIndex = 18;
            this.timeZonePicker1.ZoneDir = "zoneinfo";
            this.timeZonePicker1.ZoneName = "Etc/UTC";
            this.timeZonePicker1.ValueChanged += new System.EventHandler(this.timeZonePicker1_ValueChanged);
            // 
            // ExplorerForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 543);
            this.Controls.Add(this.timeZoneDirPicker1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.timeZonePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "ExplorerForm";
            this.Tag = "1";
            this.Text = "ExplorerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void timeZonePicker1_ValueChanged(object sender, System.EventArgs args)
		{
			try 
			{
				string zoneName = this.timeZonePicker1.ZoneName;
				string zoneDir = this.timeZonePicker1.ZoneDir;

				this.Text = string.Format("Exploring '{0}' of '{1}'", zoneName, zoneDir);

				this.listView1.Items.Clear();
				this.textBox2.Text = null;
				this.textBox3.Text = null;
				this.textBox4.Text = null;
				this.textBox5.Text = null;
				this.textBox12.Text = null;
				this.textBox13.Text = null;
				this.groupBox1.Enabled = false;

				if (zoneDir == OlsonTimeZone.ZoneInfoDir) 
				{
					this.groupBox1.Enabled = true;

					OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName(zoneName);
					DaylightTime[] times = tz.AllTimeChanges;
					for(int i = 0; i < times.Length; i++)
					{
						if (checkBox1.Checked || !(times[i] is StandardTime)) 
						{
							listView1.Items.Add(new ListViewItem(new string[]{(i).ToString("000"), times[i].Start.ToString("yyyy-MM-dd HH:mm:ss"), times[i].End.ToString("yyyy-MM-dd HH:mm:ss"), times[i].Delta.TotalSeconds.ToString(), times[i] is StandardTime ? false.ToString() : true.ToString()}));
						}
					}
					this.textBox2.Text = tz.DaylightName;
					this.textBox3.Text = tz.StandardName;
					this.textBox4.Text = tz.RawUtcOffset.ToString();
					this.textBox5.Text = tz.GetUtcOffset(tz.ToLocalTime(DateTime.UtcNow)).ToString();
					this.textBox12.Text = tz.Win32Id == null ? "<null>" : tz.Win32Id;
					this.textBox13.Text = tz.StandardAbbreviation;
				} 
				else 
				{
					this.textBox2.Text = null;
					this.textBox3.Text = null;
					this.textBox4.Text = null;
					this.textBox5.Text = null;
					this.textBox12.Text = null;
				}

				listView2.Items.Clear();
				ZoneInfo zi = new ZoneInfo(zoneName, zoneDir);
				long[] clocks = zi.AllTransitionClocks;
				for(int i = 0; i < clocks.Length; i++)
				{
					ZoneInfo.Rule rule = zi.GetTransitionRule(clocks[i]);
					listView2.Items.Add(new ListViewItem(new string[]{(i).ToString("000"), clocks[i].ToString(), zi.GetUtcTime(clocks[i]).ToString(), rule.Name, rule.Offset.ToString(), rule.IsDST.ToString()}));
				}

				this.listView3.Items.Clear();
			
				ZoneInfo.Rule[] rules = zi.AllRules;
				for(int i = 0; i < rules.Length; i++) 
				{
					listView3.Items.Add(new ListViewItem(new string[]{(i).ToString("000"), rules[i].Name, rules[i].Offset.ToString(), rules[i].IsDST.ToString()}));
				}

			
				this.listView4.Items.Clear();
				long[] corrClocks = zi.AllLeapSecondCorrectionClocks;
				for(int i = 0; i < corrClocks.Length; i++)
				{
					listView4.Items.Add(new ListViewItem(new string[]{(i).ToString("000"), corrClocks[i].ToString(), zi.GetUtcTime(corrClocks[i]).ToString(), zi.GetLeapSecondCorrection(corrClocks[i]).ToString()}));
				}

				this.textBox14.Text = zi.NormalRule.ToString();
				this.textBox7.Text = zi.ID;
				this.textBox15.Text = zi.NearestNonDstRule == null ? "<null>" : zi.NearestNonDstRule.ToString();
				this.textBox9.Text = zi.NearestDstRule == null ? "<null>" :zi.NearestDstRule.ToString();
				this.textBox10.Text = zi.RawOffset.ToString();
				DateTime utcNow = System.DateTime.UtcNow;
				ZoneInfo.Time utc = new ZoneInfo.Time(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second);
				ZoneInfo.Time local = zi.GetLocalTime(zi.GetClockFromUtc(utc));
				this.textBox11.Text = zi.GetOffset(local).ToString();
			} 
			catch (ArgumentException e) 
			{
				MessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

			}
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			timeZonePicker1_ValueChanged(checkBox1, new System.EventArgs());
		}

		private void timeZoneDirPicker1_ValueChanged(object sender, System.EventArgs e)
		{
			timeZonePicker1.ZoneDir = timeZoneDirPicker1.ZoneDir;
		}

	}
}
