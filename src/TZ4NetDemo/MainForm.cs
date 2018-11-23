using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.ToolBarButton toolBarButton10;
		private System.Windows.Forms.ToolBarButton toolBarButton12;
		private System.Windows.Forms.ToolBarButton toolBarButton13;
		private System.Windows.Forms.ToolBarButton toolBarButton14;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.ToolBarButton toolBarButton11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.ToolBarButton toolBarButton15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.ToolBarButton toolBarButton16;
		private System.ComponentModel.IContainer components;

		public MainForm()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		internal Form OpenForm(Type formType) 
		{
			return OpenForm(formType, new object[]{});
		}

		internal Form OpenForm(Type formType, object[] args) 
		{
			Form child = null;
			Cursor oldCursor = Cursor;
			try 
			{
				Cursor = Cursors.WaitCursor;
				child = (Form)Activator.CreateInstance(formType, args);
				child.MdiParent = this;
				child.Show();
			} 
			finally 
			{
				Cursor = oldCursor;
			}
			return child;
		}

		internal Form OpenDialog(Type formType, object[] args) 
		{
			Form dialog = null;
			Cursor oldCursor = Cursor;
			try 
			{
				Cursor = Cursors.WaitCursor;
				dialog = (Form)Activator.CreateInstance(formType, args);
				dialog.StartPosition = FormStartPosition.CenterParent;
				dialog.ShowDialog(this);
			} 
			finally 
			{
				Cursor = oldCursor;
			}
			return dialog;
		}

		internal Form OpenDialog(Type formType) 
		{
			return OpenDialog(formType, new object[]{});
		}

		internal void CloseAll()
		{
			System.Windows.Forms.Form[] children = MdiChildren;
			for (int i = 0; i < children.GetLength(0); i++) 
			{
				children[i].Close();
			}	
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton15 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton12 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton11 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton14 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton13 = new System.Windows.Forms.ToolBarButton();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.toolBarButton16 = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem8,
																					  this.menuItem12});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem16,
																					  this.menuItem17,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "New &Converter";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "New &Generator";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "New &Explorer";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "New Current &Time";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 4;
			this.menuItem16.Text = "New &Abbreviations";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 6;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 7;
			this.menuItem5.Text = "E&xit";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem15,
																					  this.menuItem13});
			this.menuItem8.Text = "&Window";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "&Cascade";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Text = "Tile &Horizontal";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Text = "Tile &Vertical";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 3;
			this.menuItem15.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 4;
			this.menuItem13.Text = "Close &All";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem14});
			this.menuItem12.Text = "&Help";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 0;
			this.menuItem14.Text = "&About TZ4Net Demo...";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton5,
																						this.toolBarButton6,
																						this.toolBarButton7,
																						this.toolBarButton15,
																						this.toolBarButton16,
																						this.toolBarButton12,
																						this.toolBarButton4,
																						this.toolBarButton3,
																						this.toolBarButton8,
																						this.toolBarButton9,
																						this.toolBarButton10,
																						this.toolBarButton11,
																						this.toolBarButton14,
																						this.toolBarButton13});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 1;
			this.toolBarButton1.Tag = "ConverterForm";
			this.toolBarButton1.ToolTipText = "Add New Converter";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 2;
			this.toolBarButton2.Tag = "GeneratorForm";
			this.toolBarButton2.ToolTipText = "Add New Generator";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.ImageIndex = 3;
			this.toolBarButton5.Tag = "ExplorerForm";
			this.toolBarButton5.ToolTipText = "Add New Explorer";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.ImageIndex = 11;
			this.toolBarButton6.Tag = "Win32MapForm";
			this.toolBarButton6.ToolTipText = "Add New Win32 Map";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.ImageIndex = 10;
			this.toolBarButton7.Tag = "AliasMapForm";
			this.toolBarButton7.ToolTipText = "Add New Alias Map";
			// 
			// toolBarButton15
			// 
			this.toolBarButton15.ImageIndex = 21;
			this.toolBarButton15.Tag = "AbbreviationsForm";
			this.toolBarButton15.ToolTipText = "Add New Abbreviation Form";
			// 
			// toolBarButton12
			// 
			this.toolBarButton12.ImageIndex = 13;
			this.toolBarButton12.Tag = "WorldTimeForm";
			this.toolBarButton12.ToolTipText = "Add New World Time";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 19;
			this.toolBarButton4.Tag = "Exit";
			this.toolBarButton4.ToolTipText = "Exit";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton8
			// 
			this.toolBarButton8.ImageIndex = 15;
			this.toolBarButton8.Tag = "Cascade";
			this.toolBarButton8.ToolTipText = "Cascade";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.ImageIndex = 16;
			this.toolBarButton9.Tag = "TileHorizontal";
			this.toolBarButton9.ToolTipText = "Tile Horizontal";
			// 
			// toolBarButton10
			// 
			this.toolBarButton10.ImageIndex = 17;
			this.toolBarButton10.Tag = "TileVertical";
			this.toolBarButton10.ToolTipText = "Tile Vertical";
			// 
			// toolBarButton11
			// 
			this.toolBarButton11.ImageIndex = 20;
			this.toolBarButton11.Tag = "CloseAll";
			this.toolBarButton11.ToolTipText = "Close All";
			// 
			// toolBarButton14
			// 
			this.toolBarButton14.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton13
			// 
			this.toolBarButton13.ImageIndex = 18;
			this.toolBarButton13.Tag = "About";
			this.toolBarButton13.ToolTipText = "About TZ4Net Demo";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 5;
			this.menuItem17.Text = "New Miliary Form";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// toolBarButton16
			// 
			this.toolBarButton16.ImageIndex = 25;
			this.toolBarButton16.Tag = "MilitaryForm";
			this.toolBarButton16.ToolTipText = "Add New Military Form";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 603);
			this.Controls.Add(this.toolBar1);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "TZ4Net Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}


		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string tag = e.Button.Tag as string;
			if (tag == "ConverterForm") 
			{
				OpenForm(typeof(ConverterForm));
			} 
			else if (tag == "GeneratorForm") 
			{
				OpenForm(typeof(GeneratorForm));
			} 
			else if (tag == "ExplorerForm") 
			{
				OpenForm(typeof(ExplorerForm));
			}
			else if (tag == "Win32MapForm") 
			{
				OpenForm(typeof(Win32MapForm));
			}
			else if (tag == "AliasMapForm") 
			{
				OpenForm(typeof(AliasMapForm));
			}
			else if (tag == "WorldTimeForm") 
			{
				OpenForm(typeof(WorldTimeForm));
			}
			else if (tag == "AbbreviationsForm") 
			{
				OpenForm(typeof(AbbreviationsForm));
			}
			else if (tag == "MilitaryForm") 
			{
				OpenForm(typeof(MilitaryForm));
			} 
			else if (tag == "Exit") 
			{
				this.Close();
			} 
			else if (tag == "Cascade") 
			{
				this.LayoutMdi(MdiLayout.Cascade);
			}
			else if (tag == "TileHorizontal") 
			{
				this.LayoutMdi(MdiLayout.TileHorizontal);
			} 
			else if (tag == "TileVertical") 
			{
				this.LayoutMdi(MdiLayout.TileVertical);
			} 
			else if (tag == "About") 
			{
				OpenDialog(typeof(AboutForm));
			}
			else if (tag == "CloseAll") 
			{
				CloseAll();
			}	
			else 
			{
				System.Diagnostics.Trace.Assert(false, string.Format("Unknown tag ({0}).", tag));
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(ConverterForm));
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(GeneratorForm));
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(ExplorerForm));
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(WorldTimeForm));
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			OpenDialog(typeof(AboutForm));
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			CloseAll();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(AbbreviationsForm));
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(MilitaryForm));
		}
	}
}
