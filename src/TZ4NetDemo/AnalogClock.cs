using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using TZ4Net;

namespace AnalogClock
{
    //[ToolboxBitmap(typeof(Timer))]
    public class AnalogClock : UserControl
    {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2,
																						 this.menuItem3,
																						 this.menuItem4,
																						 this.menuItem5,
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "Properties...";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Explore";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Convert From";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Convert To";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// AnalogClock
			// 
			this.ContextMenu = this.contextMenu1;
			this.Name = "AnalogClock";
			this.Size = new System.Drawing.Size(150, 93);
			this.Resize += new System.EventHandler(this.AnalogClock_Resize);
			this.DoubleClick += new System.EventHandler(this.AnalogClock_DoubleClick);

		}

		#endregion

		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Timer timer;
		private DateTime currentTime = DateTime.Now;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private bool paused;

		#region Public interface

		public event System.EventHandler Explore;
		public event System.EventHandler ConvertFrom;
		public event System.EventHandler ConvertTo;
		public event System.EventHandler Edit;

		#endregion

        public AnalogClock()
        {
            InitializeComponent();
            _radius = (this.Width * .9f) / 2;
            _center = new PointF(this.Width / 2, this.Height / 2);
        }

        #region Fields and Enums
        public enum ClockStyles
        {
            Standard,
            Classic
        }
        public enum HandStyles
        {
            Uniform,
            Sharp
        }
        public enum TickStyles
        {
            All,
            Twelve,
            Quadric,
            None
        }
        public enum DateStyles
        {
            Full,
            DayOfMonth,
            None
        }
        public enum NumberStyles
        {
            All,
            Quadric,
            None
        }
        public enum CalendarTypes
        {
            Gregorian,
            Persian   
        }
        private float _radius;
        private PointF _center;

        #endregion Fields and Enums

        #region Clock Methods
        public void Start()
        {
            timer.Enabled = true;
        }
        public void Stop()
        {
            timer.Enabled = false;
        }

		public bool Paused 
		{
			get 
			{
				return paused;
			}
			set 
			{
				paused = value;
			}
		}

        #endregion Clock Methods

        #region Properties
        private ClockStyles _clockstyle = ClockStyles.Standard;
        public ClockStyles ClockStyle
        {
            get { return _clockstyle; }
            set { _clockstyle = value; }
        }

        private HandStyles _handstyle = HandStyles.Uniform;
        public HandStyles HandStyle
        {
            get { return _handstyle; }
            set { _handstyle = value; }
        }

        private TickStyles _tickstyle = TickStyles.All;
        public TickStyles TickStyle
        {
            get { return _tickstyle; }
            set { _tickstyle = value; }
        }

        private DateStyles _datestyle = DateStyles.Full;
        public DateStyles DateStyle
        {
            get { return _datestyle; }
            set { _datestyle = value; }
        }

        private NumberStyles _numberstyle = NumberStyles.All;
        public NumberStyles NumberStyle
        {
            get { return _numberstyle; }
            set { _numberstyle = value; }
        }
	
        private Color _innercolor = Color.SkyBlue;
        public Color InnerColor
        {
            get { return _innercolor; }
            set { _innercolor = value; }
        }

        private Color _outercolor = Color.SteelBlue;
        public Color OuterColor
        {
            get { return _outercolor; }
            set { _outercolor = value; }
        }

        private Color _handcolor = Color.Black;
        public Color HandColor
        {
            get { return _handcolor; }
            set { _handcolor = value; }
        }

        private Color _secondhandcolor = Color.Red;
        public Color SecondHandColor
        {
            get { return _secondhandcolor; }
            set { _secondhandcolor = value; }
        }

        private Color _tickcolor = Color.Black;
        public Color TickColor
        {
            get { return _tickcolor; }
            set { _tickcolor = value; }
        }

		private Color _circumferencecolor = Color.Black;
		public Color CircumferenceColor
		{
			get { return _circumferencecolor; }
			set { _circumferencecolor = value; }
		}

        private Color _textcolor = Color.Black;
        public Color TextColor
        {
            get { return _textcolor; }
            set { _textcolor = value; }
        }

        private string _caption = "C# CLOCK";
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public new bool Enabled
        {
            get { return timer.Enabled; }
            set { timer.Enabled = value; }
        }

		public static string GetCaptionFromTimezone(string timezone) 
		{
			string city = timezone.Substring(timezone.LastIndexOf("/") + 1);
			return city.Replace("_", " ");
		}

		private OlsonTimeZone machineTimeZone = OlsonTimeZone.CurrentTimeZone;
		private OlsonTimeZone _timezone = OlsonTimeZone.DefaultUtcTimeZone;
		public string Timezone
		{
			get { return _timezone.Name; }
			set 
			{
				if (OlsonTimeZone.LookupName(value) != null) 
				{
					_timezone = OlsonTimeZone.GetInstance(value);
				}
			}
		}

        #endregion Properties

        #region Draw Methods

        private void DrawBackground(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(_center.X - _radius, _center.Y - _radius, _radius * 2, _radius * 2);
            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = _innercolor;
            pgb.SurroundColors = new Color[] { _outercolor };
            g.FillEllipse(pgb, _center.X - _radius, _center.Y - _radius, _radius * 2, _radius * 2);
            g.DrawEllipse(new Pen( _circumferencecolor, _radius * .01f), _center.X - _radius, _center.Y - _radius, _radius * 2, _radius * 2);
        }

        private void DrawCaption(Graphics g)
        {
            if (_caption.Trim() == string.Empty)
                return;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(_caption, new Font("Tahoma", _radius * .09f, FontStyle.Bold), new SolidBrush(_textcolor), _center.X, _center.Y - _radius * .4f, sf);
			if (currentTime.Hour >= 12) 
			{
				g.DrawString("PM", new Font("Tahoma", _radius * .09f, FontStyle.Bold), new SolidBrush(_textcolor), _center.X, _center.Y + _radius * .4f, sf);
			}
        }

        private void DrawTicks(Graphics g)
        {
            if (_tickstyle == TickStyles.None)
                return;

            for (int i = 0; i < 4; i++)
                g.DrawLine(new Pen(_tickcolor, _radius * .05f),
                    (float)Math.Cos(i * 90 * Math.PI / 180) * _radius * .9f + _center.X,
                    (float)Math.Sin(i * 90 * Math.PI / 180) * _radius * .9f + _center.Y,
                    (float)Math.Cos(i * 90 * Math.PI / 180) * _radius + _center.X,
                    (float)Math.Sin(i * 90 * Math.PI / 180) * _radius + _center.Y);

            if (_tickstyle == TickStyles.All || _tickstyle == TickStyles.Twelve)
                for (int i = 0; i < 12; i++)
                    if (i % 3 != 0)
                        g.DrawLine(new Pen(_tickcolor, _radius * .03f),
                            (float)Math.Cos(i * 30 * Math.PI / 180) * _radius * .9f + _center.X,
                            (float)Math.Sin(i * 30 * Math.PI / 180) * _radius * .9f + _center.Y,
                            (float)Math.Cos(i * 30 * Math.PI / 180) * _radius + _center.X,
                            (float)Math.Sin(i * 30 * Math.PI / 180) * _radius + _center.Y);

            if (_tickstyle == TickStyles.All)
                for (int i = 0; i < 60; i++)
                    if (i % 5 != 0)
                        g.DrawLine(new Pen(_tickcolor, _radius * .01f),
                            (float)Math.Cos(i * 6 * Math.PI / 180) * _radius * .95f + _center.X,
                            (float)Math.Sin(i * 6 * Math.PI / 180) * _radius * .95f + _center.Y,
                            (float)Math.Cos(i * 6 * Math.PI / 180) * _radius + _center.X,
                            (float)Math.Sin(i * 6 * Math.PI / 180) * _radius + _center.Y);
        }

        private void DrawNumbers(Graphics g)
        {
            if (_numberstyle == NumberStyles.None)
                return;
            
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 1; i <= 12; i++)
                switch (i)
                {
                    case 10:
                        if (_numberstyle == NumberStyles.All)
                            g.DrawString(i.ToString(), new Font("Tahoma", _radius * .15f, FontStyle.Bold), new SolidBrush(_textcolor),
                                (float)Math.Sin(i * 30 * Math.PI / 180) * _radius * .72f + _center.X,
                                (float)-Math.Cos(i * 30 * Math.PI / 180) * _radius * .8f + _center.Y, sf);
                        break;
                    case 11:
                        if (_numberstyle == NumberStyles.All)
                            g.DrawString(i.ToString(), new Font("Tahoma", _radius * .15f, FontStyle.Bold), new SolidBrush(_textcolor),
                                (float)Math.Sin(i * 30 * Math.PI / 180) * _radius * .64f + _center.X,
                                (float)-Math.Cos(i * 30 * Math.PI / 180) * _radius * .8f + _center.Y, sf);
                        break;
                    default:
                        if (_numberstyle == NumberStyles.Quadric && i % 3 != 0)
                            break;
                        if (i == 3 && _datestyle != DateStyles.None)
                            break;
                        if (i == 6 && _clockstyle == ClockStyles.Classic)
                            break;
                        g.DrawString(i.ToString(), new Font("Tahoma", _radius * .15f, FontStyle.Bold), new SolidBrush(_textcolor),
                            (float)Math.Sin(i * 30 * Math.PI / 180) * _radius * .8f + _center.X,
                            (float)-Math.Cos(i * 30 * Math.PI / 180) * _radius * .8f + _center.Y, sf);
                        break;
                }
        }

        private void DrawDate(Graphics g)
        {       
            if (_datestyle == DateStyles.None)
                return;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            g.FillRectangle(Brushes.White, _center.X + _radius * .7f, _center.Y - _radius * .06f, _radius * .16f, _radius * .12f);
            g.DrawRectangle(new Pen(Color.Black, _radius * .01f), _center.X + _radius * .7f, _center.Y - _radius * .06f, _radius * .16f, _radius * .12f);
            g.DrawString(currentTime.Day.ToString() , new Font("Lucida Console", _radius * .08f, FontStyle.Bold), Brushes.Black,
                _center.X + _radius * .785f, _center.Y - _radius * .04f, sf);

            if (_datestyle == DateStyles.Full)
            {
                g.FillRectangle(Brushes.White, _center.X + _radius * .46f, _center.Y - _radius * .06f, _radius * .24f, _radius * .12f);
                g.DrawRectangle(new Pen(Color.Black, _radius * .01f), _center.X + _radius * .46f, _center.Y - _radius * .06f, _radius * .24f, _radius * .12f);
                g.DrawString(currentTime.DayOfWeek.ToString().Substring(0, 3).ToUpper(), new Font("Lucida Console", _radius * .09f, FontStyle.Bold), Brushes.Black,
                    _center.X + _radius * .585f, _center.Y - _radius * .05f, sf);
            }
        }

        private void DrawHands(Graphics g)
        {
            int hour = currentTime.Hour % 12;
            int minute = currentTime.Minute;
            int second = currentTime.Second;
            if (_clockstyle == ClockStyles.Classic)
            {
                Color c = Color.FromArgb((_innercolor.R + _outercolor.R) / 2, (_innercolor.G + _outercolor.G) / 2, (_innercolor.B + _outercolor.B) / 2);
                g.FillEllipse(new SolidBrush(c), _center.X - _radius * .25f, _center.Y + _radius * .25f, _radius * .5f, _radius * .5f);
                Pen p = new Pen(_tickcolor);
                p.DashStyle = DashStyle.Custom;
                p.DashPattern = new float[] { 1f, 3f };
                g.DrawEllipse(p, _center.X - _radius * .25f, _center.Y + _radius * .25f, _radius * .5f, _radius * .5f);
                g.DrawLine(new Pen(_secondhandcolor, _radius * .01f),
                    _center.X - (float)(Math.Sin(second * 6 * Math.PI / 180)) * _radius * .05f,
                    _center.Y + _radius * .5f - (float)(-Math.Cos(second * 6 * Math.PI / 180)) * _radius * .05f,
                    (float)(Math.Sin(second * 6 * Math.PI / 180)) * _radius * .25f + _center.X,
                    (float)(-Math.Cos(second * 6 * Math.PI / 180)) * _radius * .25f + _center.Y + _radius * .5f);
                g.FillEllipse(new SolidBrush(_secondhandcolor), _center.X - _radius * .02f, _center.Y + _radius * .48f, _radius * .04f, _radius * .04f);
            }

            if (_handstyle == HandStyles.Uniform)
            {
                g.DrawLine(new Pen(_handcolor, _radius * .05f),
                    _center.X - (float)(Math.Sin((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .1f,
                    _center.Y - (float)(-Math.Cos((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .1f,
                    (float)(Math.Sin((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .5f + _center.X,
                    (float)(-Math.Cos((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .5f + _center.Y);
                g.DrawLine(new Pen(_handcolor, _radius * .03f),
                    _center.X - (float)(Math.Sin(minute * 6 * Math.PI / 180)) * _radius * .1f,
                    _center.Y - (float)(-Math.Cos(minute * 6 * Math.PI / 180)) * _radius * .1f,
                    (float)(Math.Sin(minute * 6 * Math.PI / 180)) * _radius * .7f + _center.X,
                    (float)(-Math.Cos(minute * 6 * Math.PI / 180)) * _radius * .7f + _center.Y);
                g.FillEllipse(new SolidBrush(_handcolor), _center.X - _radius * .05f, _center.Y - _radius * .05f, _radius * .1f, _radius * .1f);
            }
            else
            {
                g.FillPolygon(new SolidBrush(_handcolor),
                    new PointF[]{
                        new PointF(
                            _center.X - (float)(Math.Sin((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .1f,
                            _center.Y - (float)(-Math.Cos((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .1f),
                        new PointF(
                            _center.X - (float)(Math.Sin((hour * 30 + minute / 12 * 6 + 90) * Math.PI / 180)) * _radius * .05f,
                            _center.Y - (float)(-Math.Cos((hour * 30 + minute / 12 * 6 + 90) * Math.PI / 180)) * _radius * .05f),
                        new PointF(
                            (float)(Math.Sin((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .5f + _center.X,
                            (float)(-Math.Cos((hour * 30 + minute / 12 * 6) * Math.PI / 180)) * _radius * .5f + _center.Y),
                        new PointF(
                            _center.X - (float)(Math.Sin((hour * 30 + minute / 12 * 6 - 90) * Math.PI / 180)) * _radius * .05f,
                            _center.Y - (float)(-Math.Cos((hour * 30 + minute / 12 * 6 - 90) * Math.PI / 180)) * _radius * .05f)
                    });
                g.FillPolygon(new SolidBrush(_handcolor),
                    new PointF[] {
                        new PointF(
                            _center.X - (float)(Math.Sin(minute * 6 * Math.PI / 180)) * _radius * .1f, 
                            _center.Y - (float)(-Math.Cos(minute * 6 * Math.PI / 180)) * _radius * .1f),
                        new PointF( 
                            _center.X - (float)(Math.Sin((minute * 6 + 90) * Math.PI / 180)) * _radius * .05f,
                            _center.Y - (float)(-Math.Cos((minute * 6 + 90) * Math.PI / 180)) * _radius * .05f),
                        new PointF(
                            (float)(Math.Sin(minute * 6 * Math.PI / 180)) * _radius * .7f + _center.X,
                            (float)(-Math.Cos(minute * 6 * Math.PI / 180)) * _radius * .7f + _center.Y),
                        new PointF( 
                            _center.X - (float)(Math.Sin((minute * 6 - 90) * Math.PI / 180)) * _radius * .05f,
                            _center.Y - (float)(-Math.Cos((minute * 6 - 90) * Math.PI / 180)) * _radius * .05f)
                    });
            }

            if (_clockstyle == ClockStyles.Standard)
            {
                g.DrawLine(new Pen(_secondhandcolor, _radius * .01f),
                    _center.X - (float)(Math.Sin(second * 6 * Math.PI / 180)) * _radius * .2f,
                    _center.Y - (float)(-Math.Cos(second * 6 * Math.PI / 180)) * _radius * .2f,
                    (float)(Math.Sin(second * 6 * Math.PI / 180)) * _radius * .9f + _center.X,
                    (float)(-Math.Cos(second * 6 * Math.PI / 180)) * _radius * .9f + _center.Y);
                g.FillEllipse(new SolidBrush(_secondhandcolor), _center.X - _radius * .03f, _center.Y - _radius * .03f, _radius * .06f, _radius * .06f);
            }
        }
        #endregion Draw Methods

		private void UpdateCurrentTime()
		{
			if (!paused) 
			{
				currentTime = OlsonTimeZone.Convert(machineTimeZone.Name, DateTime.Now, this.Timezone);
			}
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (e.ClipRectangle.Width > 0 && e.ClipRectangle.Height > 0) 
			{
				UpdateCurrentTime();
				Bitmap buffer = new Bitmap(e.ClipRectangle.Width,e.ClipRectangle.Height);
				Graphics gfx = Graphics.FromImage(buffer); 
				DrawClock(gfx);
				e.Graphics.DrawImageUnscaled(buffer, 0, 0);
			}
		}

		private void DrawClock(Graphics g) 
		{
			g.Clear(this.BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;			
			this.DrawBackground(g);
			this.DrawCaption(g);
			this.DrawTicks(g);
			this.DrawNumbers(g);
			this.DrawDate(g);
			this.DrawHands(g); 
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}
        
        private void AnalogClock_Resize(object sender, EventArgs e)
        {
            if (this.Width < this.Height)
                _radius = (this.Width * .9f) / 2;
            else
                _radius = (this.Height * .9f) / 2;
            _center = new PointF((float)this.Width / 2, (float)this.Height / 2);
            this.Invalidate();
        }

		private void AnalogClock_DoubleClick(object sender, System.EventArgs e)
		{
			OnEdit();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			OnEdit();
		}

		private void OnEdit() 
		{
			if (Edit != null) 
			{
				Edit(this, new System.EventArgs());
			}
		}

		private void OnExplore() 
		{
			if (Explore != null) 
			{
				Explore(this, new System.EventArgs());
			}
		}

		private void OnConvertFrom() 
		{
			if (ConvertFrom != null) 
			{
				ConvertFrom(this, new System.EventArgs());
			}
		}

		private void OnConvertTo() 
		{
			if (ConvertTo!= null) 
			{
				ConvertTo(this, new System.EventArgs());
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			OnExplore();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			OnConvertFrom();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			OnConvertTo(); 
		}
    }
}