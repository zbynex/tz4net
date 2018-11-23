using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AnalogClock;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for CurrentTimeForm.
	/// </summary>
	public class WorldTimeForm : System.Windows.Forms.Form
	{
		private AnalogClock.AnalogClockGrid analogClockGrid1;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.ComponentModel.IContainer components;

		public WorldTimeForm()
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
			this.components = new System.ComponentModel.Container();
			this.analogClockGrid1 = new AnalogClock.AnalogClockGrid();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// analogClockGrid1
			// 
			this.analogClockGrid1.Dimension = 3;
			this.analogClockGrid1.Location = new System.Drawing.Point(40, 0);
			this.analogClockGrid1.Name = "analogClockGrid1";
			this.analogClockGrid1.Size = new System.Drawing.Size(576, 528);
			this.analogClockGrid1.TabIndex = 0;
			this.analogClockGrid1.ConvertFrom += new System.EventHandler(this.analogClockGrid1_ConvertFrom);
			this.analogClockGrid1.ExploreClock += new System.EventHandler(this.analogClockGrid1_ExploreClock);
			this.analogClockGrid1.EditClock += new System.EventHandler(this.analogClockGrid1_EditClock);
			this.analogClockGrid1.ConvertTo += new System.EventHandler(this.analogClockGrid1_ConvertTo);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(8, 8);
			this.trackBar1.Maximum = 6;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(42, 176);
			this.trackBar1.TabIndex = 1;
			this.trackBar1.Value = 3;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// WorldTimeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 541);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.analogClockGrid1);
			this.Name = "WorldTimeForm";
			this.Text = "World Time";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void timer_Tick(object sender, System.EventArgs e)
		{
			this.analogClockGrid1.Refresh();
		}

		protected override void OnResize(EventArgs e)
		{
			this.analogClockGrid1.Width = this.ClientSize.Width - this.trackBar1.Width;
			this.analogClockGrid1.Height = this.ClientSize.Height;
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			this.analogClockGrid1.Dimension = this.trackBar1.Value;
		}

		private void analogClockGrid1_EditClock(object sender, System.EventArgs e)
		{
			AnalogClock.AnalogClock clock = (AnalogClock.AnalogClock)sender;
			MainForm parent = (MainForm)this.MdiParent;
			parent.OpenDialog(typeof(AnalogClockEditor), new object[]{clock});
		}

		private void analogClockGrid1_ExploreClock(object sender, System.EventArgs e)
		{
			AnalogClock.AnalogClock clock = (AnalogClock.AnalogClock)sender;
			MainForm parent = (MainForm)this.MdiParent;
			parent.OpenForm(typeof(ExplorerForm), new object[]{null, clock.Timezone});
		}

		private void analogClockGrid1_ConvertFrom(object sender, System.EventArgs e)
		{
			AnalogClock.AnalogClock clock = (AnalogClock.AnalogClock)sender;
			MainForm parent = (MainForm)this.MdiParent;
			parent.OpenForm(typeof(ConverterForm), new object[]{clock.Timezone, null});
		}

		private void analogClockGrid1_ConvertTo(object sender, System.EventArgs e)
		{
			AnalogClock.AnalogClock clock = (AnalogClock.AnalogClock)sender;
			MainForm parent = (MainForm)this.MdiParent;
			parent.OpenForm(typeof(ConverterForm), new object[]{null, clock.Timezone});
		}
	}
}
