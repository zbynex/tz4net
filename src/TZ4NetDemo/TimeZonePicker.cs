using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for TimeZonePicker.
	/// </summary>
	public class TimeZonePicker : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string zoneDir;

		public event System.EventHandler ValueChanged;

		public TimeZonePicker()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ZoneDir = ZoneInfo.DefaultDir;
		}

		public string ZoneName
		{
			get 
			{
				return (string)comboBox1.SelectedValue;
			}
			set 
			{
				if (value != null && comboBox1.Items.IndexOf(value) >= 0) 
				{
					comboBox1.SelectedIndex = comboBox1.Items.IndexOf(value);
				}
			}
		}

		public string ZoneDir
		{
			get 
			{
				return zoneDir;
			}
			set 
			{
				Trace.Assert(value != null);
				zoneDir = value;
				System.Collections.ArrayList dataSource = new ArrayList(ZoneInfo.GetAllNames(zoneDir));
				dataSource.Sort();
				comboBox1.DataSource = dataSource;
				comboBox1.SelectedIndex = dataSource.IndexOf(ZoneInfo.DefaultName);
			}
		}

		public string[] AllNames 
		{
			get 
			{
				ArrayList res = new ArrayList();
				foreach(string name in comboBox1.Items) 
				{
					res.Add(name);
				}
				res.Sort();
				return (string[])res.ToArray(typeof(string));
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(0, 0);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// TimeZonePicker
			// 
			this.BackColor = System.Drawing.Color.Silver;
			this.Controls.Add(this.comboBox1);
			this.Name = "TimeZonePicker";
			this.Size = new System.Drawing.Size(200, 21);
			this.ResumeLayout(false);

		}
		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ValueChanged != null) 
			{
				ValueChanged(this, new System.EventArgs());
			}
		} 
	}
}
