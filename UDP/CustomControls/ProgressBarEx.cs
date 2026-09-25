using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    [ToolboxBitmap("PBEX.bmp")]
    public class ProgressBarEx : UserControl
    {
        private Blend bBlend = new Blend();
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Value = 0;
        private bool _Border = true;
        private Pen _BorderPen;
        private Color _BorderColor = Color.Black;
        private GradientArea _GradientPosition;
        private Color _GradientColor = Color.White;
        private Color _BackColor = Color.DarkGray;
        private Color _ProgressColor = Color.Lime;
        private SolidBrush _ForeColorBrush;
        private bool _ShowPercentage = false;
        private bool _ShowText = false;
        private ImageLayoutType _ImageLayout = ImageLayoutType.None;
        private Bitmap _Image = null;
        private bool _RoundedCorners = true;
        private ProgressDir _ProgressDirection = ProgressDir.Horizontal;
        private bool _Countdown = false;

        /// <summary>Enum of positions used for the ProgressBar`s GradientPosition property.</summary>
        public enum GradientArea : int
        {
            None = 0,
            Top = 1,
            Center = 2,
            Bottom = 3
        }

        /// <summary>Enum of ImageLayout types used for the ProgressBar`s ImageLayout property.</summary>
        public enum ImageLayoutType : int
        {
            None = 0,
            Center = 1,
            Stretch = 2
        }

        /// <summary>Enum of Progress Direction types used for the ProgressDirection property.</summary>
        public enum ProgressDir : int
        {
            Horizontal = 0,
            Vertical = 1
        }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            base.TabStop = false;
            this.Size = new Size(200, 23);
            bBlend.Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
            this.GradientPosition = GradientArea.Top;
            base.BackColor = Color.Transparent;
            _ForeColorBrush = new SolidBrush(base.ForeColor);
            _BorderPen = new Pen(Color.Black);
        }

        [Category("Appearance"), Description("The foreground color of the ProgressBars text.")]
        [Browsable(true)]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ForeColorBrush.Color;
                }

                base.ForeColor = value;
                _ForeColorBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("The background color of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color BackgroundColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BackColor;
                }

                _BackColor = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The progress color of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Lime")]
        public Color ProgressColor
        {
            get
            {
                return _ProgressColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ProgressColor;
                }

                _ProgressColor = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The gradient highlight color of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "White")]
        public Color GradientColor
        {
            get
            {
                return _GradientColor;
            }
            set
            {
                _GradientColor = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The minimum value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum - 1;
                }

                _Minimum = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The maximum value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(100)]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value <= _Minimum)
                {
                    value = _Minimum + 1;
                }

                _Maximum = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("Controls count direction of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool Countdown
        {
            get
            {
                return _Countdown;
            }
            set
            {
                _Countdown = value;
                this.Refresh();
            }
        }

        [Category("Behavior"), Description("The current value of the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value < _Minimum)
                {
                    value = _Minimum;
                }

                if (value > _Maximum)
                {
                    value = _Maximum;
                }

                _Value = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Draw a border around the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Border
        {
            get
            {
                return _Border;
            }
            set
            {
                _Border = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the border around the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BorderColor;
                }

                _BorderColor = value;
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Shows the progress percentage as text in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowPercentage
        {
            get
            {
                return _ShowPercentage;
            }
            set
            {
                _ShowPercentage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Shows the text of the Text property in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowText
        {
            get
            {
                return _ShowText;
            }
            set
            {
                _ShowText = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Determines the position of the gradient shine in the ProgressBar.")]
        [Browsable(true)]
        [DefaultValue(typeof(GradientArea), "Top")]
        public GradientArea GradientPosition
        {
            get
            {
                return _GradientPosition;
            }
            set
            {
                _GradientPosition = value;
                if (value == GradientArea.None)
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0f, 0f, 0f, 0f }; //Shine None
                }
                else if (value == GradientArea.Top)
                {
                    bBlend.Factors = new float[] { 0.8f, 0.7f, 0.6f, 0.4f, 0f, 0f }; //Shine Top
                }
                else if (value == GradientArea.Center)
                {
                    bBlend.Factors = new float[] { 0f, 0.4f, 0.6f, 0.6f, 0.4f, 0f }; //Shine Center
                }
                else
                {
                    bBlend.Factors = new float[] { 0f, 0f, 0.4f, 0.6f, 0.7f, 0.8f }; //Shine Bottom
                }

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("An image to display on the ProgressBarEx.")]
        [Browsable(true)]
        public Bitmap Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Determines how the image is displayed in the ProgressBarEx.")]
        [Browsable(true)]
        [DefaultValue(typeof(ImageLayoutType), "None")]
        public ImageLayoutType ImageLayout
        {
            get
            {
                return _ImageLayout;
            }
            set
            {
                _ImageLayout = value;
                if (_Image != null)
                {
                    this.Refresh();
                }
            }
        }

        [Category("Appearance"), Description("True to draw corners rounded. False to draw square corners.")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool RoundedCorners
        {
            get
            {
                return _RoundedCorners;
            }
            set
            {
                _RoundedCorners = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Determines the direction of progress displayed in the ProgressBarEx.")]
        [Browsable(true)]
        [DefaultValue(typeof(ProgressDir), "Horizontal")]
        public ProgressDir ProgressDirection
        {
            get
            {
                return _ProgressDirection;
            }
            set
            {
                _ProgressDirection = value;
                this.Refresh();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point StartPoint = new Point(0, 0);
            Point EndPoint = new Point(0, this.Height);
            int PaintValue = _Value;

            if (_Countdown)
            {
                PaintValue = _Maximum - _Value;
            }

            if (_ProgressDirection == ProgressDir.Vertical)
            {
                EndPoint = new Point(this.Width, 0);
            }

            using (GraphicsPath Path1 = new GraphicsPath())
            {
                Rectangle DrawingRectangle = new Rectangle(0, 0, this.Width, this.Height);
                int rad = Convert.ToInt32(DrawingRectangle.Height / 2.5);

                if (DrawingRectangle.Width < DrawingRectangle.Height)
                {
                    rad = Convert.ToInt32(DrawingRectangle.Width / 2.5);
                }

                using (LinearGradientBrush _BackColorBrush = new LinearGradientBrush(StartPoint, EndPoint, _BackColor, _GradientColor))
                {
                    _BackColorBrush.Blend = bBlend;
                    if (_RoundedCorners)
                    {
                        Path1.AddArc(DrawingRectangle.X, DrawingRectangle.Y, rad, rad, 180, 90);
                        Path1.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Y, rad, rad, 270, 90);
                        Path1.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Bottom - rad, rad, rad, 0, 90);
                        Path1.AddArc(DrawingRectangle.X, DrawingRectangle.Bottom - rad, rad, rad, 90, 90);
                        Path1.CloseFigure();
                        e.Graphics.FillPath(_BackColorBrush, Path1);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(_BackColorBrush, DrawingRectangle);
                    }
                }

                if (PaintValue > _Minimum)
                {
                    int lngth = Convert.ToInt32((double)(this.Width / (double)(_Maximum - _Minimum)) * PaintValue);
                    if (_ProgressDirection == ProgressDir.Vertical)
                    {
                        lngth = Convert.ToInt32((double)(this.Height / (double)(_Maximum - _Minimum)) * PaintValue);
                        DrawingRectangle.Y = DrawingRectangle.Height - lngth;
                        DrawingRectangle.Height = lngth;
                    }
                    else
                    {
                        DrawingRectangle.Width = lngth;
                    }

                    using (LinearGradientBrush _ProgressBrush = new LinearGradientBrush(StartPoint, EndPoint, _ProgressColor, _GradientColor))
                    {
                        _ProgressBrush.Blend = bBlend;
                        if (_RoundedCorners)
                        {
                            if (_ProgressDirection == ProgressDir.Horizontal)
                            {
                                DrawingRectangle.Height -= 1;
                            }
                            else
                            {
                                DrawingRectangle.Width -= 1;
                            }

                            using (GraphicsPath Path2 = new GraphicsPath())
                            {
                                Path2.AddArc(DrawingRectangle.X, DrawingRectangle.Y, rad, rad, 180, 90);
                                Path2.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Y, rad, rad, 270, 90);
                                Path2.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Bottom - rad, rad, rad, 0, 90);
                                Path2.AddArc(DrawingRectangle.X, DrawingRectangle.Bottom - rad, rad, rad, 90, 90);
                                Path2.CloseFigure();
                                using (GraphicsPath Path3 = new GraphicsPath())
                                {
                                    using (Region rgn = new Region(Path1))
                                    {
                                        rgn.Intersect(Path2);
                                        Path3.AddRectangles(rgn.GetRegionScans(new Matrix()));
                                    }

                                    e.Graphics.FillPath(_ProgressBrush, Path3);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.FillRectangle(_ProgressBrush, DrawingRectangle);
                        }
                    }
                }

                if (_Image != null)
                {
                    if (_ImageLayout == ImageLayoutType.Stretch)
                    {
                        e.Graphics.DrawImage(_Image, 0, 0, this.Width, this.Height);
                    }
                    else if (_ImageLayout == ImageLayoutType.None)
                    {
                        e.Graphics.DrawImage(_Image, 0, 0);
                    }
                    else
                    {
                        int xx = Convert.ToInt32((this.Width / 2) - (_Image.Width / 2));
                        int yy = Convert.ToInt32((this.Height / 2) - (_Image.Height / 2));
                        e.Graphics.DrawImage(_Image, xx, yy);
                    }
                }

                if (_ShowPercentage | _ShowText)
                {
                    string PercentageText = "";
                    if (_ShowText)
                    {
                        PercentageText = this.Text;
                    }

                    if (_ShowPercentage)
                    {
                        PercentageText += Convert.ToString(Convert.ToInt32(100 / (double)(_Maximum - _Minimum) * PaintValue)) + "%";
                    }

                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(PercentageText, this.Font, _ForeColorBrush, new Rectangle(0, 0, this.Width, this.Height), sf);
                    }
                }

                if (_Border)
                {
                    DrawingRectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                    if (_RoundedCorners)
                    {
                        Path1.Reset();
                        Path1.AddArc(DrawingRectangle.X, DrawingRectangle.Y, rad, rad, 180, 90);
                        Path1.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Y, rad, rad, 270, 90);
                        Path1.AddArc(DrawingRectangle.Right - rad, DrawingRectangle.Bottom - rad, rad, rad, 0, 90);
                        Path1.AddArc(DrawingRectangle.X, DrawingRectangle.Bottom - rad, rad, rad, 90, 90);
                        Path1.CloseFigure();
                        e.Graphics.DrawPath(_BorderPen, Path1);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(_BorderPen, DrawingRectangle);
                    }
                }
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            this.Refresh();
            base.OnTextChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            _ForeColorBrush.Dispose();
            _BorderPen.Dispose();
            base.Dispose(disposing);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("BackgroundImageLayout is not implemented.", true)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                throw new NotImplementedException("BackgroundImageLayout is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("BackgroundImage is not implemented.", true)]
        public new Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException("BackgroundImage is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("TabStop is not implemented.", true)]
        public new bool TabStop
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException("TabStop is not implemented.");
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.Obsolete("TabIndex is not implemented.", true)]
        public new int TabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                throw new NotImplementedException("TabIndex is not implemented.");
            }
        }
    }
}
