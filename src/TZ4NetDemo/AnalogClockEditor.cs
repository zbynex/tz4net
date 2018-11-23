using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnalogClock
{
	/// <summary>
	/// Summary description for AnalogClockEditor.
	/// </summary>
	public class AnalogClockEditor : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button3 = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button_OK = new System.Windows.Forms.Button();
			this.timeZonePicker1 = new TZ4NetDemo.TimeZonePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(156, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Pause / Resume";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Inner Color";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(296, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "Outer Color";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(256, 128);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(136, 20);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(192, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Caption:";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(13, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(68, 17);
			this.radioButton1.TabIndex = 10;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Standard";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(88, 19);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(64, 17);
			this.radioButton2.TabIndex = 10;
			this.radioButton2.Text = "Classic";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(12, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 47);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Clock Style";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Location = new System.Drawing.Point(12, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(156, 48);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hand Style";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(88, 19);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(56, 17);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.Text = "Sharp";
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(13, 19);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(67, 17);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Uniform";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "All",
														   "Twelve",
														   "Quadric",
														   "None"});
			this.comboBox1.Location = new System.Drawing.Point(61, 168);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(107, 21);
			this.comboBox1.TabIndex = 13;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Ticks:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 40);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Hand Color";
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(192, 64);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "Tick Color";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(296, 40);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(96, 23);
			this.button6.TabIndex = 15;
			this.button6.Text = "Sec. Hand Color";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Items.AddRange(new object[] {
														   "Full",
														   "DayOfMonth",
														   "None"});
			this.comboBox2.Location = new System.Drawing.Point(61, 192);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(107, 21);
			this.comboBox2.TabIndex = 13;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "Date:";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(296, 64);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(96, 23);
			this.button7.TabIndex = 16;
			this.button7.Text = "Text Color";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Items.AddRange(new object[] {
														   "All",
														   "Quadric",
														   "None"});
			this.comboBox3.Location = new System.Drawing.Point(61, 216);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(107, 21);
			this.comboBox3.TabIndex = 17;
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "Numbers:";
			// 
			// button_OK
			// 
			this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_OK.Location = new System.Drawing.Point(320, 216);
			this.button_OK.Name = "button_OK";
			this.button_OK.TabIndex = 19;
			this.button_OK.Text = "OK";
			// 
			// timeZonePicker1
			// 
			this.timeZonePicker1.BackColor = System.Drawing.Color.Silver;
			this.timeZonePicker1.Location = new System.Drawing.Point(256, 104);
			this.timeZonePicker1.Name = "timeZonePicker1";
			this.timeZonePicker1.Size = new System.Drawing.Size(136, 21);
			this.timeZonePicker1.TabIndex = 20;
			this.timeZonePicker1.ZoneDir = "zoneinfo";
			this.timeZonePicker1.ZoneName = "Etc/UTC";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(192, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 16);
			this.label5.TabIndex = 21;
			this.label5.Text = "Timezone:";
			// 
			// AnalogClockEditor
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 253);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.timeZonePicker1);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AnalogClockEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit clock properties";
			this.Load += new System.EventHandler(this.form_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private AnalogClock analogClock1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Button button_OK;
		private TZ4NetDemo.TimeZonePicker timeZonePicker1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;

		private void PostInitializeComponent() 
		{
		}

		public AnalogClockEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			PostInitializeComponent();
		}

		private void PostInitializeComponent(AnalogClock clock) 
		{
			this.analogClock1 = clock;

			this.comboBox1.SelectedIndex = this.comboBox1.FindStringExact(clock.TickStyle.ToString());
			this.comboBox2.SelectedIndex = this.comboBox2.FindStringExact(clock.DateStyle.ToString());
			this.comboBox3.SelectedIndex = this.comboBox3.FindStringExact(clock.NumberStyle.ToString());
			this.textBox1.Text = clock.Caption;
			this.radioButton1.Checked = clock.ClockStyle == AnalogClock.ClockStyles.Standard;
			this.radioButton2.Checked = clock.ClockStyle == AnalogClock.ClockStyles.Classic;
			this.radioButton3.Checked = clock.HandStyle == AnalogClock.HandStyles.Uniform;
			this.radioButton4.Checked = clock.HandStyle == AnalogClock.HandStyles.Sharp;	
			this.timeZonePicker1.ZoneName = clock.Timezone;
			this.timeZonePicker1.ValueChanged += new EventHandler(timeZonePicker1_ValueChanged);
		}

		public AnalogClockEditor(AnalogClock clock)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			PostInitializeComponent(clock);
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

		private void button2_Click(object sender, EventArgs e)
		{
			if (analogClock1.ClockStyle == AnalogClock.ClockStyles.Standard)
				analogClock1.ClockStyle = AnalogClock.ClockStyles.Classic;
			else
				analogClock1.ClockStyle = AnalogClock.ClockStyles.Standard;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			analogClock1.Paused = !analogClock1.Paused;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.InnerColor;
			colorDialog1.ShowDialog();
			analogClock1.InnerColor = colorDialog1.Color;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.OuterColor;
			colorDialog1.ShowDialog();
			analogClock1.OuterColor = colorDialog1.Color;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			analogClock1.Caption = textBox1.Text;
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
				analogClock1.ClockStyle = AnalogClock.ClockStyles.Standard;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
				analogClock1.ClockStyle = AnalogClock.ClockStyles.Classic;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
				analogClock1.HandStyle = AnalogClock.HandStyles.Uniform;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton4.Checked)
				analogClock1.HandStyle = AnalogClock.HandStyles.Sharp;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.HandColor;
			colorDialog1.ShowDialog();
			analogClock1.HandColor = colorDialog1.Color;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.TickColor;
			colorDialog1.ShowDialog();
			analogClock1.TickColor = colorDialog1.Color;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.SecondHandColor;
			colorDialog1.ShowDialog();
			analogClock1.SecondHandColor = colorDialog1.Color;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = analogClock1.TextColor;
			colorDialog1.ShowDialog();
			analogClock1.TextColor = colorDialog1.Color;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBox1.SelectedIndex)
			{
				case 0:
					analogClock1.TickStyle = AnalogClock.TickStyles.All;
					break;
				case 1:
					analogClock1.TickStyle = AnalogClock.TickStyles.Twelve;
					break;
				case 2:
					analogClock1.TickStyle = AnalogClock.TickStyles.Quadric;
					break;
				case 3:
					analogClock1.TickStyle = AnalogClock.TickStyles.None;
					break;

			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBox2.SelectedIndex)
			{
				case 0:
					analogClock1.DateStyle = AnalogClock.DateStyles.Full;
					break;
				case 1:
					analogClock1.DateStyle = AnalogClock.DateStyles.DayOfMonth;
					break;
				case 2:
					analogClock1.DateStyle =  AnalogClock.DateStyles.None;
					break;

			}
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBox3.SelectedIndex)
			{
				case 0:
					analogClock1.NumberStyle = AnalogClock.NumberStyles.All;
					break;
				case 1:
					analogClock1.NumberStyle = AnalogClock.NumberStyles.Quadric;
					break;
				case 2:
					analogClock1.NumberStyle = AnalogClock.NumberStyles.None;
					break;
			}
		}

		private void form_Load(object sender, EventArgs e)
		{
		}

		private void timeZonePicker1_ValueChanged(object sender, EventArgs e)
		{
			analogClock1.Timezone = timeZonePicker1.ZoneName;
			this.textBox1.Text = AnalogClock.GetCaptionFromTimezone(analogClock1.Timezone);
		}
	}
}
