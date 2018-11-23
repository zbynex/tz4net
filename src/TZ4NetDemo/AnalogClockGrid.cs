using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace AnalogClock
{
	/// <summary>
	/// Summary description for PanelGrid.
	/// </summary>
	public class AnalogClockGrid : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AnalogClockGrid()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

			this.SuspendLayout();
			// 
			// AnalogClockGrid
			// 
			this.Name = "AnalogClockGrid";
			this.Size = new System.Drawing.Size(352, 312);
			this.ResumeLayout(false);

		}

		private int dimension;
		public const int MaxDimension = 6;
		static readonly string[,] zones = new string[MaxDimension, MaxDimension]
		{
			{"UTC","Europe/Warsaw","Europe/London","Europe/Moscow","Europe/Malta","Europe/Sofia"},
			{"America/New_York","America/Los_Angeles","Asia/Tokyo","Africa/Lusaka","Africa/Nairobi","Africa/Lagos"},
			{"Australia/Sydney","America/Chicago","Africa/Cairo","Australia/Hobart","Australia/Darwin","Australia/Perth"},
			{"America/New_York","Atlantic/Bermuda","America/Los_Angeles","America/Phoenix","America/Indianapolis","America/Denver"},
			{"Asia/Singapore","Australia/Adelaide","Asia/Tokyo","Asia/Shanghai","Asia/Dubai","Asia/Baghdad"},
			{"Pacific/Honolulu","Pacific/Tahiti","Pacific/Fiji","Pacific/Auckland","Pacific/Galapagos","Pacific/Samoa"},
		};

		
		#region Public interface

		public event System.EventHandler EditClock;
		public event System.EventHandler ExploreClock;
		public event System.EventHandler ConvertFrom;
		public event System.EventHandler ConvertTo;

		public int Dimension 
		{
			get 
			{
				return dimension;
			}
			set 
			{
				if (value >= 0 && value <= MaxDimension) 
				{
					Reset(value);
				}
			}
		}

		public AnalogClock[] Clocks 
		{
			get 
			{
				ArrayList res = new ArrayList();
				foreach(Control control in this.Controls) 
				{
					AnalogClock clock = control as AnalogClock;
					if (clock != null) 
					{
						res.Add(clock);
					}
				}
				return (AnalogClock[])res.ToArray(typeof(AnalogClock));
			}
		}

		#endregion

		private void Reset(int dimension) 
		{
			foreach(Control control in new ArrayList(this.Controls)) 
			{
				AnalogClock clock = control as AnalogClock;
				if (clock != null) 
				{
					this.Controls.Remove(clock);
					clock.Edit -= new EventHandler(clock_Edit);
					clock.Explore -= new EventHandler(clock_Explore);
					clock.ConvertFrom -= new EventHandler(clock_ConvertFrom);
					clock.ConvertTo -= new EventHandler(clock_ConvertTo);
					clock.Dispose();
				}
			}
			this.dimension = dimension;
			for (int i = 0; i < dimension; i++)
			{
				for (int j = 0; j < dimension; j++)
				{
					AnalogClock clock = new AnalogClock();
					clock.InnerColor = Color.Transparent;
					clock.OuterColor = Color.Transparent;
					clock.CircumferenceColor = Color.Transparent;
					clock.Tag = new Point(i, j);
					clock.Timezone = zones[i,j];
					clock.Caption = AnalogClock.GetCaptionFromTimezone(clock.Timezone);
					clock.Edit += new EventHandler(clock_Edit);
					clock.Explore += new EventHandler(clock_Explore);
					clock.ConvertFrom += new EventHandler(clock_ConvertFrom);
					clock.ConvertTo += new EventHandler(clock_ConvertTo);
					this.Controls.Add(clock);
				}
			}
			ResizeClocks();
		}

		private void ResizeClocks() 
		{
			if (dimension > 0) 
			{
				int hFactor = this.Width / dimension;
				int vFactor = this.Height / dimension;

				foreach(Control control in this.Controls) 
				{
					AnalogClock clock = control as AnalogClock;
					if (clock != null) 
					{
						Point point = (Point)clock.Tag;
						clock.Location = new Point(point.X * hFactor, point.Y * vFactor);
						clock.Size = new Size(hFactor, vFactor);
					}
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			ResizeClocks();
		}

		private void clock_Edit(object sender, System.EventArgs e) 
		{
			if (EditClock != null) 
			{
				EditClock(sender, e);
			}
		}

		private void clock_Explore(object sender, System.EventArgs e) 
		{
			if (ExploreClock != null) 
			{
				ExploreClock(sender, e);
			}
		}

		#endregion

		private void clock_ConvertFrom(object sender, EventArgs e)
		{
			if (ConvertFrom != null) 
			{
				ConvertFrom(sender, e);
			}
		}

		private void clock_ConvertTo(object sender, EventArgs e)
		{
			if (ConvertTo!= null) 
			{
				ConvertTo(sender, e);
			}
		}
	}
}
