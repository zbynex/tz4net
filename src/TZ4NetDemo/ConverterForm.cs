using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for ConverterForm.
	/// </summary>
	public class ConverterForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.DateTimePicker datePicker1;
		private System.Windows.Forms.DateTimePicker timePicker1;
		private System.Windows.Forms.DateTimePicker datePicker2;
		private System.Windows.Forms.DateTimePicker timePicker2;
		private TZ4NetDemo.TimeZonePicker zonePicker1;
		private TZ4NetDemo.TimeZonePicker zonePicker2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		private bool inUpdate;
		private System.Windows.Forms.TextBox statusBox1;
		private System.Windows.Forms.TextBox statusBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConverterForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			PostInitializeComponent(null, null);
		}

		public ConverterForm(string localZoneName, string destinationZoneName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			PostInitializeComponent(localZoneName, destinationZoneName);
		}

		private void PostInitializeComponent(string localZoneName, string destinationZoneName) 
		{
			datePicker1.Value = DateTime.Now;
			zonePicker1.ZoneDir = OlsonTimeZone.ZoneInfoDir;
			zonePicker2.ZoneDir = OlsonTimeZone.ZoneInfoDir;
			if (localZoneName != null) 
			{
				zonePicker1.ZoneName = localZoneName;
			}
			if (destinationZoneName != null) 
			{
				zonePicker2.ZoneName = destinationZoneName;
			}
			zonePicker1.ValueChanged += new EventHandler(zonePicker1_ValueChanged);
			datePicker1.ValueChanged += new EventHandler(datePicker1_ValueChanged);
			timePicker1.ValueChanged += new EventHandler(timePicker1_ValueChanged);
			zonePicker2.ValueChanged += new EventHandler(zonePicker2_ValueChanged);
			datePicker2.ValueChanged += new EventHandler(datePicker2_ValueChanged);
			timePicker2.ValueChanged += new EventHandler(timePicker2_ValueChanged);
			timePicker1.Value = datePicker1.Value;
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
			this.datePicker1 = new System.Windows.Forms.DateTimePicker();
			this.timePicker1 = new System.Windows.Forms.DateTimePicker();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusBox1 = new System.Windows.Forms.TextBox();
			this.zonePicker1 = new TZ4NetDemo.TimeZonePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.zonePicker2 = new TZ4NetDemo.TimeZonePicker();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.statusBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.datePicker2 = new System.Windows.Forms.DateTimePicker();
			this.timePicker2 = new System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// datePicker1
			// 
			this.datePicker1.CustomFormat = "";
			this.datePicker1.Location = new System.Drawing.Point(16, 72);
			this.datePicker1.Name = "datePicker1";
			this.datePicker1.TabIndex = 1;
			this.datePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// timePicker1
			// 
			this.timePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timePicker1.Location = new System.Drawing.Point(16, 112);
			this.timePicker1.Name = "timePicker1";
			this.timePicker1.ShowUpDown = true;
			this.timePicker1.TabIndex = 2;
			this.timePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(144, 144);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 16);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Is in  DST";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.statusBox1);
			this.groupBox1.Controls.Add(this.zonePicker1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.datePicker1);
			this.groupBox1.Controls.Add(this.timePicker1);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(32, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 208);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Local Time";
			// 
			// statusBox1
			// 
			this.statusBox1.Location = new System.Drawing.Point(16, 168);
			this.statusBox1.Name = "statusBox1";
			this.statusBox1.ReadOnly = true;
			this.statusBox1.Size = new System.Drawing.Size(200, 20);
			this.statusBox1.TabIndex = 1;
			this.statusBox1.Text = "";
			// 
			// zonePicker1
			// 
			this.zonePicker1.BackColor = System.Drawing.Color.Silver;
			this.zonePicker1.Location = new System.Drawing.Point(16, 32);
			this.zonePicker1.Name = "zonePicker1";
			this.zonePicker1.Size = new System.Drawing.Size(200, 21);
			this.zonePicker1.TabIndex = 0;
			this.zonePicker1.ZoneDir = "zoneinfo";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "Time Check Result:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.zonePicker2);
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.statusBox2);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.datePicker2);
			this.groupBox2.Controls.Add(this.timePicker2);
			this.groupBox2.Location = new System.Drawing.Point(280, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 208);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Destintation Time";
			// 
			// zonePicker2
			// 
			this.zonePicker2.BackColor = System.Drawing.Color.Silver;
			this.zonePicker2.Location = new System.Drawing.Point(16, 32);
			this.zonePicker2.Name = "zonePicker2";
			this.zonePicker2.Size = new System.Drawing.Size(200, 21);
			this.zonePicker2.TabIndex = 10;
			this.zonePicker2.ZoneDir = "zoneinfo";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(144, 144);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 16);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Is in  DST";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// statusBox2
			// 
			this.statusBox2.Location = new System.Drawing.Point(16, 168);
			this.statusBox2.Name = "statusBox2";
			this.statusBox2.ReadOnly = true;
			this.statusBox2.Size = new System.Drawing.Size(200, 20);
			this.statusBox2.TabIndex = 12;
			this.statusBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Time Check Result:";
			// 
			// datePicker2
			// 
			this.datePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.datePicker2.Location = new System.Drawing.Point(16, 72);
			this.datePicker2.Name = "datePicker2";
			this.datePicker2.TabIndex = 9;
			this.datePicker2.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// timePicker2
			// 
			this.timePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.timePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timePicker2.Location = new System.Drawing.Point(16, 112);
			this.timePicker2.Name = "timePicker2";
			this.timePicker2.ShowUpDown = true;
			this.timePicker2.TabIndex = 10;
			this.timePicker2.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Location = new System.Drawing.Point(32, 32);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(480, 56);
			this.groupBox3.TabIndex = 11;
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
			this.textBox1.Size = new System.Drawing.Size(424, 32);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "You could compare the conversion results with the zoneinfo based service availabl" +
				"e at http://www.timezoneconverter.com/cgi-bin/tzc.tzc";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(112, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Now";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(360, 344);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "Now";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ConverterForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 405);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ConverterForm";
			this.ShowInTaskbar = false;
			this.Text = "ConverterForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void OnValueChanged(object sender, EventArgs e) 
		{
			if (!inUpdate) 
			{
				inUpdate = true;
			} 
			else 
			{
				return;
			}

			try 
			{
				GroupBox	   fromGroup      = null;
				TimeZonePicker fromZonePicker = null;
				DateTimePicker fromDatePicker = null;
				DateTimePicker fromTimePicker = null;
				CheckBox       fromInDSTBox   = null;
				TextBox		   fromStatusBox  = null;

				GroupBox	   toGroup      = null;
				TimeZonePicker toZonePicker = null;
				DateTimePicker toDatePicker = null;
				DateTimePicker toTimePicker = null;
				CheckBox       toInDSTBox = null;
				TextBox		   toStatusBox  = null;

				if (sender == this.groupBox1) 
				{
					fromGroup = this.groupBox1;
					fromZonePicker = this.zonePicker1;
					fromDatePicker = this.datePicker1;
					fromTimePicker = this.timePicker1;
					fromInDSTBox = this.checkBox1;
					fromStatusBox = this.statusBox1;

					toGroup = this.groupBox2;
					toZonePicker = this.zonePicker2;
					toDatePicker = this.datePicker2;
					toTimePicker = this.timePicker2;
					toInDSTBox = this.checkBox2;
					toStatusBox = this.statusBox2;

				}
				else if(sender == this.groupBox2)
				{
					fromGroup = this.groupBox2;
					fromZonePicker = this.zonePicker2;
					fromDatePicker = this.datePicker2;
					fromTimePicker = this.timePicker2;
					fromInDSTBox = this.checkBox2;
					fromStatusBox = this.statusBox2;

					toGroup = this.groupBox1;
					toZonePicker = this.zonePicker1;
					toDatePicker = this.datePicker1;
					toTimePicker = this.timePicker1;
					toInDSTBox = this.checkBox1;
					toStatusBox = this.statusBox1;
				} 
				else 
				{
					Trace.Assert(false);
				}
				Trace.Assert(fromGroup != null);
				Trace.Assert(fromZonePicker != null);
				Trace.Assert(fromDatePicker != null);
				Trace.Assert(fromTimePicker != null);
				Trace.Assert(fromInDSTBox != null);
				Trace.Assert(fromStatusBox != null);

				Trace.Assert(toGroup != null);
				Trace.Assert(toZonePicker != null);
				Trace.Assert(toDatePicker != null);
				Trace.Assert(toTimePicker != null);
				Trace.Assert(toInDSTBox != null);
				Trace.Assert(toStatusBox != null);

				Trace.Assert(fromGroup != toGroup);
				Trace.Assert(fromZonePicker != toZonePicker);
				Trace.Assert(fromDatePicker != toDatePicker);
				Trace.Assert(fromTimePicker != toTimePicker);
				Trace.Assert(fromInDSTBox != toInDSTBox);
				Trace.Assert(fromStatusBox != toStatusBox);

				OlsonTimeZone fromZone = OlsonTimeZone.GetInstanceFromOlsonName(fromZonePicker.ZoneName);
				OlsonTimeZone toZone = OlsonTimeZone.GetInstanceFromOlsonName(toZonePicker.ZoneName);
				Text = string.Format("'{0}' to '{1}' time conversion", fromZone.Name, toZone.Name);
				DateTime fromDate = fromDatePicker.Value;
				DateTime fromTime = fromTimePicker.Value;
				DateTime fromDateTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
				TimeCheckResult fromCheckRes = fromZone.CheckLocalTime(fromDateTime);
				fromStatusBox.Text = fromCheckRes.ToString();
				switch (fromCheckRes) 
				{
					case TimeCheckResult.Valid : 
					{
						fromInDSTBox.Visible = true;
						fromInDSTBox.Checked = fromZone.IsDaylightSavingTime(fromDateTime);
						DateTime fromUtcDateTime = fromZone.ToUniversalTime(fromDateTime);
						DateTime toDateTime = toZone.ToLocalTime(fromUtcDateTime);
						toDatePicker.Value = toDateTime;
						toTimePicker.Value = toDateTime;
						TimeCheckResult toCheckRes = toZone.CheckLocalTime(toDateTime);
						toStatusBox.Text = toCheckRes.ToString();
						if (toCheckRes == TimeCheckResult.Valid) 
						{
							toInDSTBox.Checked = toZone.IsDaylightSavingTime(toDateTime);
							toGroup.Enabled = true;
						} 
						else 
						{
							toInDSTBox.Checked = false;
							toGroup.Enabled = false;
						}
						break;
					}
					case TimeCheckResult.LessThanUnixMin : 
					case TimeCheckResult.GreaterThanUnixMax : 
					case TimeCheckResult.InSpringForwardGap : 
					case TimeCheckResult.InFallBackRange : 
					{
						fromInDSTBox.Visible = false;
						toGroup.Enabled = false;
						break;
					}
				}
			}
			catch (ArgumentException) 
			{
				Trace.Assert(false, "Unexpected argument error.", "Local time is validated before using so this error should never happen.");
				throw;
			}
			finally 
			{
				inUpdate = false;
			}
		}

		private void OnValue1Changed(object sender, EventArgs e) 
		{
			OnValueChanged(this.groupBox1, e);
		}

		private void OnValue2Changed(object sender, EventArgs e) 
		{
			OnValueChanged(this.groupBox2, e);
		}

		private void zonePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValue1Changed(sender, e);
		}

		private void datePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValue1Changed(sender, e);
		}

		private void timePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValue1Changed(sender, e);
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			OnValue1Changed(sender, e);
		}

		private void zonePicker2_ValueChanged(object sender, EventArgs e)
		{
			OnValue2Changed(sender, e);
		}

		private void datePicker2_ValueChanged(object sender, EventArgs e)
		{
			OnValue2Changed(sender, e);
		}

		private void timePicker2_ValueChanged(object sender, EventArgs e)
		{
			OnValue2Changed(sender, e);
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			OnValue2Changed(sender, e);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			datePicker1.Value = DateTime.Now;
			timePicker1.Value = datePicker1.Value;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			datePicker2.Value = DateTime.Now;
			timePicker2.Value = datePicker2.Value;
		}
	}
}
