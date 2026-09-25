using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public class LabelEx : UserControl
    {
        #region Enums

        public enum AutosizeDrawMethod
        {
            /// <summary>
            /// Create the smallest bitmap needed to draw the text without word wrap
            /// </summary>
            Smallest,
            /// <summary>
            /// Draw text with the biggest font possible while not exceeding rectangle dimensions, without word wrap
            /// </summary>
            LargestNoWrap,
            /// <summary>
            /// Draw text in rectangle while performing word wrap. Font size is a constant input. Drawing may exceed bitmap rectangle.
            /// </summary>
            NoWrap,
            /// <summary>
            /// Draw text with the biggest font possible while not exceeding rectangle dimensions, with word wrap
            /// </summary>
            LargestWrap
        }

        /// <summary>Enum of BorderTypes used for the Labels BorderStyle.</summary> 
        public enum BorderType : int
        {
            None = 0,
            Squared = 1,
            Rounded = 2
        }

        /// <summary>Enum of layout styles used for the Labels TextPaternImage.</summary> 
        public enum PatternLayout : int
        {
            Normal = 0,
            Center = 1,
            Stretch = 2,
            Tile = 3
        }

        /// <summary>Enum of areas used for the Labels ShadowPosition.</summary> 
        public enum ShadowArea : int
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3
        }

        /// <summary>Enum of drawing types used for the Labels ShadowStyle.</summary> 
        public enum ShadowDrawingType : int
        {
            DrawShadow = 1,
            FillShadow = 2
        }

        #endregion

        #region Fields

        //Add all of the Property Backing Fields for the Properties added to the LabelEx class 
        private bool _Autosize = false;
        private AutosizeDrawMethod _AutosizeMethod = AutosizeDrawMethod.LargestNoWrap;
        private SolidBrush _BackgroundBrush = new SolidBrush(Color.Transparent);
        private Bitmap _BackgroundImage = null;
        private ContentAlignment _BackgroundImageAlign = ContentAlignment.MiddleCenter;
        private Pen _BorderPen = new Pen(Color.Black);
        private BorderType _BorderStyle = BorderType.None;
        private bool _DrawOutline = false;

        //private IContainer components;
        private bool _Flash = false;
        private SolidBrush _ForeColorBrush = new SolidBrush(Color.Black);
        private int _ForeColorTransparency = 255;
        private Bitmap _Image = null;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        private Pen _OutLinePen = new Pen(Color.Black);
        private int _OutlineThickness = 1;
        private SolidBrush _ShadowBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
        private Color _ShadowColor = Color.Black;
        private int _ShadowDepth = 2;
        private Pen _ShadowPen = new Pen(Color.FromArgb(128, Color.Black));
        private ShadowArea _ShadowPosition = ShadowArea.BottomRight;
        private ShadowDrawingType _ShadowStyle = ShadowDrawingType.FillShadow;
        private int _ShadowTransparency = 128;
        private bool _ShowTextShadow = false;
        private ContentAlignment _TextAlign = ContentAlignment.MiddleLeft;
        private Bitmap _TextPatternImage = null;
        private PatternLayout _TextPatternImageLayout = PatternLayout.Stretch;

        //private bool _TextVisible = true;
        private System.Threading.Timer _tmrFlash = null;

        #endregion

        #region Properties

        [Category("Appearance"), Description("Controls autosizing of the label")]
        [Browsable(true), DefaultValue(typeof(bool), "false")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get
            {
                return _Autosize;
            }
            set
            {
                _Autosize = value;
                this.Invalidate(true);
                //Refresh();
            }
        }

        //Create all of the properties we want the control to have and Override the ones it already has if they need to be used for special reasons.  

        [Category("Appearance"), Description("Controls the method used to draw text when AutoSize is used")]
        [Browsable(true), DefaultValue(typeof(AutosizeDrawMethod), "LargestNoWrap")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AutosizeDrawMethod AutosizeMethod
        {
            get
            {
                return _AutosizeMethod;
            }
            set
            {
                _AutosizeMethod = value;
                Refresh();
            }
        }

        [Category("Appearance"), Description("The background color of the Label")]
        [Browsable(true), DefaultValue(typeof(Color), "Transparent")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                _BackgroundBrush.Color = value;
            }
        }

        [Category("Appearance"), Description("The Background Image for the Label")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Bitmap BackgroundImage
        {
            get
            {
                return _BackgroundImage;
            }
            set
            {
                _BackgroundImage = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Aligns the Background Image to the left, right, top, or bottom")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment BackgroundImageAlign
        {
            get
            {
                return _BackgroundImageAlign;
            }
            set
            {
                _BackgroundImageAlign = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the border")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get
            {
                return _BorderPen.Color;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    _ = _BorderPen.Color;
                    //Set it back to the prior color 
                    //Alert the user that Color.Transparent is not supported for this property 
                    throw new Exception("The border color does not support the Transparent color");
                }

                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The style of the border.")]
        [Browsable(true), DefaultValue(typeof(BorderType), "None")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new BorderType BorderStyle
        {
            get
            {
                return _BorderStyle;
            }
            set
            {
                _BorderStyle = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Controls the drawing of the control's outline")]
        [Browsable(true), DefaultValue(typeof(bool), "false")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool DrawOutline
        {
            get
            {
                return _DrawOutline;
            }
            set
            {
                _DrawOutline = value;
                this.Invalidate(true);
                //Refresh();
            }
        }

        [Category("Appearance"), Description("The foreground color of the text")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;

                if (value == Color.Transparent)
                {
                    _ForeColorTransparency = 0;
                }

                try
                {
                    _ForeColorBrush.Color = Color.FromArgb(_ForeColorTransparency, value);
                }
                catch
                {
                }
            }
        }

        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the ForeColor")]
        [Browsable(true), DefaultValue(255)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ForeColorTransparency
        {
            get
            {
                return _ForeColorTransparency;
            }
            set
            {
                if (value > 255)
                {
                    value = 255;
                }

                if (value < 0 | this.ForeColor == Color.Transparent)
                {
                    value = 0;
                }

                _ForeColorTransparency = value;
                _ForeColorBrush.Color = Color.FromArgb(value, this.ForeColor);

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The Image for the Label")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [Category("Appearance"), Description("Aligns the Image to the left, right, top, or bottom")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return _ImageAlign;
            }
            set
            {
                _ImageAlign = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The outline color of the text")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OutlineColor
        {
            get
            {
                return _OutLinePen.Color;
            }
            set
            {
                _OutLinePen.Color = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The thickness of the text outline (1-10)")]
        [Browsable(true), DefaultValue(1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OutlineThickness
        {
            get
            {
                return _OutlineThickness;
            }
            set
            {
                //Dont let the user set lower than 1 
                if (value < 1)
                {
                    value = 1;
                }

                //Dont let the user set higher than 10 
                if (value > 10)
                {
                    value = 10;
                }

                _OutlineThickness = value;
                _OutLinePen.Width = value;
                _ShadowPen.Width = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The color of the shadow behind the text")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ShadowColor
        {
            get
            {
                return _ShadowColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    //Set it back to the prior color 
                    _ = _ShadowBrush.Color;

                    //Alert the user that Color.Transparent is not supported for this property 
                    throw new Exception("The Shadow color does not support using Color.Transparent");
                }

                _ShadowColor = value;
                _ShadowBrush.Color = Color.FromArgb(_ShadowTransparency, value);
                _ShadowPen.Color = Color.FromArgb(_ShadowTransparency, value);

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("A value that controls the depth of the shadow behind the text (1-10)")]
        [Browsable(true), DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowDepth
        {
            get
            {
                return _ShadowDepth;
            }
            set
            {
                //Dont let user set this property lower than 1 
                if (value < 1)
                {
                    value = 1;
                }

                //Dont let user set this property higher than 10 
                if (value > 10)
                {
                    value = 10;
                }

                _ShadowDepth = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The position of the shadow behind the text")]
        [Browsable(true), DefaultValue(typeof(ShadowArea), "BottomRight")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ShadowArea ShadowPosition
        {
            get
            {
                return _ShadowPosition;
            }
            set
            {
                _ShadowPosition = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The style used to draw the shadow")]
        [Browsable(true), DefaultValue(typeof(ShadowDrawingType), "FillShadow")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ShadowDrawingType ShadowStyle
        {
            get
            {
                return _ShadowStyle;
            }
            set
            {
                _ShadowStyle = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the shadow.")]
        [Browsable(true), DefaultValue(128)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowTransparency
        {
            get
            {
                return _ShadowTransparency;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                //Dont let user set this property lower than 0 
                if (value > 255)
                {
                    value = 255;
                }

                //Dont let user set this property higher than 255 
                _ShadowTransparency = value;
                _ShadowBrush.Color = Color.FromArgb(value, _ShadowColor);
                _ShadowPen.Color = Color.FromArgb(value, _ShadowColor);
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Show a shadow behind the text")]
        [Browsable(true), DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowTextShadow
        {
            get
            {
                return _ShowTextShadow;
            }
            set
            {
                _ShowTextShadow = value;

                this.Refresh();
            }
        }

        [Category("Appearance"), Description("Controls the visible content of the Label")]
        [Browsable(true), DefaultValue(typeof(string), "Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate(true);
                //Refresh();
            }
        }

        [Category("Appearance"), Description("Aligns the text to the left, right, top, or bottom of the Label")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("An image used as a fill pattern for the center of the text")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Bitmap TextPatternImage
        {
            get
            {
                return _TextPatternImage;
            }
            set
            {
                _TextPatternImage = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), Description("The layout of the pattern image inside the text")]
        [Browsable(true), DefaultValue(typeof(PatternLayout), "Stretch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PatternLayout TextPatternImageLayout
        {
            get
            {
                return _TextPatternImageLayout;
            }
            set
            {
                _TextPatternImageLayout = value;
                this.Refresh();
            }
        }

        #endregion

        #region Constructors

        //In the constructor we set all the styles we want the LabelEx control to have when it is created. 
        //We also set a few properties that we want the control to have set by default when a new instance is created. 
        public LabelEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Refresh();
        }

        #endregion

        #region Private Methods

        //A private function used for calculating the rectangle area of the Label to draw the Image in 
        private Rectangle AlignImage(Rectangle Rect)
        {
            //Use the value of the ContentAlignment assigned to the ImageAlign property to set the X and Y 
            //values of the returned rectangle for the image. 
            int XPosition = 0;
            int Alignment = Convert.ToInt32(_ImageAlign);

            int YPosition;
            if (Alignment < 8)
            {
                YPosition = 0 + this.Padding.Top;
            }
            else if (Alignment < 128)
            {
                YPosition = Convert.ToInt32(Rect.Height / 2) - Convert.ToInt32(_Image.Height / 2);
                Alignment /= 16;
            }
            else
            {
                YPosition = Rect.Height - _Image.Height - this.Padding.Bottom;
                Alignment /= 256;
            }

            if (Alignment == Convert.ToInt32(ContentAlignment.TopLeft))
            {
                XPosition = 0 + this.Padding.Left;
            }
            else if (Alignment == Convert.ToInt32(ContentAlignment.TopCenter))
            {
                XPosition = Convert.ToInt32(Rect.Width / 2) - Convert.ToInt32(_Image.Width / 2);
            }
            else if (Alignment == Convert.ToInt32(ContentAlignment.TopRight))
            {
                XPosition = Rect.Width - _Image.Width - this.Padding.Right;
            }

            return new Rectangle(XPosition, YPosition, _Image.Width, _Image.Height);
        }

        //Need to use the Dispose Overides sub to make sure all of the New brushes and pens created for the 
        //property backing fields are disposed. 
        protected override void Dispose(bool disposing)
        {
            this._BackgroundBrush.Dispose();
            this._BorderPen.Dispose();
            this._ForeColorBrush.Dispose();
            this._OutLinePen.Dispose();
            this._ShadowBrush.Dispose();
            this._ShadowPen.Dispose();
            base.Dispose(disposing);
        }

        //A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout 
        private void DrawBackgroundImage(Graphics g)
        {
            if (this.BackgroundImageLayout == ImageLayout.None)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Tile)
            {
                int Width = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Width / this.BackgroundImage.Width)));
                int Height = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Height / this.BackgroundImage.Height)));

                for (int y = 0; y <= Height; y++)
                {
                    for (int x = 0; x <= Width; x++)
                    {
                        g.DrawImage(this.BackgroundImage, x * this.BackgroundImage.Width, y * this.BackgroundImage.Height, this.BackgroundImage.Width, this.BackgroundImage.Height);
                    }
                }
            }
            else if (this.BackgroundImageLayout == ImageLayout.Center)
            {
                int xx = Convert.ToInt32((this.Width / 2) - (this.BackgroundImage.Width / 2));
                int yy = Convert.ToInt32((this.Height / 2) - (this.BackgroundImage.Height / 2));

                g.DrawImage(this.BackgroundImage, xx, yy, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Stretch)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Zoom)  // No distortion
            {
                int MaxWidth = this.Width;
                int MaxHeight = this.Height;
                int OriginalWidth = BackgroundImage.Width;
                int OriginalHeight = BackgroundImage.Height;

                float RatioX = MaxWidth / (float)OriginalWidth;
                float RatioY = MaxHeight / (float)OriginalHeight;
                float Ratio = Math.Min(RatioX, RatioY);

                int NewWidth = (int)(OriginalWidth * Ratio);
                int NewHeight = (int)(OriginalHeight * Ratio);

                // To position the image in the centre, use this...
                _ = (int)(Width - (float)NewWidth) / 2;
                _ = (int)(Height - (float)NewHeight) / 2;

                // For now, set the image origin at 0,0
                int NewX = 0;
                int NewY = 0;

                g.DrawImage(this.BackgroundImage, new Rectangle(NewX, NewY, NewWidth, NewHeight));
            }
        }

        //A private sub used for drawing the Border part of the control 
        private void DrawLabelBorder(Graphics g, Rectangle rec)
        {
            //If the ShowTextShadow property is true and the Text property is not an empty string then because of the 
            //prior calls to the Graphics.TranslateTransform used for the shadow effect the Graphics must be shifted 
            //back to its center position before drawing the border. 
            if (_ShowTextShadow & !string.IsNullOrEmpty(this.Text))
            {
                if (_ShadowPosition == ShadowArea.TopLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.TopRight)
                {
                    g.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.BottomLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                }
                else
                {
                    g.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                }
            }

            //If the BorderStyle property is set to Rounded then draw the border with rounded corners 
            //else just draw a Rectangle 
            if (_BorderStyle == BorderType.Rounded)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    int rad = Convert.ToInt32(rec.Height / 3);
                    if (rec.Width < rec.Height)
                    {
                        rad = Convert.ToInt32(rec.Width / 3);
                    }

                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                    gp.AddArc(rec.Right - rad, rec.Y, rad, rad, 270, 90);
                    gp.AddArc(rec.Right - rad, rec.Bottom - rad, rad, rad, 0, 90);
                    gp.AddArc(rec.X, rec.Bottom - rad, rad, rad, 90, 90);
                    gp.CloseFigure();
                    g.DrawPath(_BorderPen, gp);
                }
            }
            else
            {
                g.DrawRectangle(_BorderPen, rec.X, rec.Y, rec.Width, rec.Height);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LabelEx
            // 
            this.DoubleBuffered = true;
            this.Name = "LabelEx";
            this.ResumeLayout(false);
        }

        private int MaxFontSize(string Text, Font Font, RectangleF RectangleDimensions, bool AllowWrap, int MinimumFontSize = 5, int MaximumFontSize = 1000)
        {
            Font newFont;
            Rectangle rect = Rectangle.Ceiling(RectangleDimensions);

            for (int newFontSize = MinimumFontSize; ; newFontSize++)
            {
                newFont = new Font(Font.FontFamily, newFontSize, Font.Style);

                List<string> Strings = WrapText(Text, newFont, rect.Width);

                StringBuilder sb = new StringBuilder();

                if (AllowWrap)
                {
                    for (int i = 0; i < Strings.Count; ++i)
                    {
                        _ = sb.Append(Strings[i] + Environment.NewLine);
                    }
                }
                else
                {
                    _ = sb.Append(Text);
                }

                Size size = MeasureDrawnTextBitmapSize(sb.ToString(), newFont);
                if (size.Width > RectangleDimensions.Width || size.Height > RectangleDimensions.Height)
                {
                    return newFontSize - 1;
                }

                if (newFontSize >= MaximumFontSize)
                {
                    return newFontSize - 1;
                }
            }
        }

        private Size MeasureDrawnTextBitmapSize(string Text, Font Font)
        {
            Bitmap bmp = new Bitmap(1, 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                SizeF size = g.MeasureString(Text, Font);
                return new Size((int)Math.Ceiling(size.Width), (int)Math.Ceiling(size.Height));
            }
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
            this.Refresh();
        }

        //Use the OnPaint overrides sub to paint the control to match how all the properties settings have been set by the user 
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Fill the background with the BackColor color 
            g.FillRectangle(_BackgroundBrush, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            //If the BackgroundImage property has been set to an image then draw the BackgroundImage 
            if (this.BackgroundImage != null)
            {
                DrawBackgroundImage(g);
            }

            //If the Image property has been set to an image then draw the image on the control 
            if (_Image != null)
            {
                g.DrawImage(_Image, AlignImage(new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height)));
            }

            //If the Text property has been assigned then draw the text on the control 
            if (!string.IsNullOrEmpty(this.Text.Trim()))
            {
                SetGraphicsQuality(g, PixelOffsetMode.HighQuality);

                //The Drawing2D.GraphicsPath used for drawing and/or filling the text 
                using (GraphicsPath Path = new GraphicsPath())
                {
                    StringFormat DrawFormat = new StringFormat();

                    int Alignment = Convert.ToInt32(_TextAlign);

                    // Vertical alignment
                    if (Alignment < 8)
                    {
                        DrawFormat.LineAlignment = StringAlignment.Near;
                    }
                    else if (Alignment < 128)
                    {
                        DrawFormat.LineAlignment = StringAlignment.Center;
                        Alignment /= 16;
                    }
                    else
                    {
                        DrawFormat.LineAlignment = StringAlignment.Far;
                        Alignment /= 256;
                    }

                    // Horizontal Alignment
                    if (Alignment == Convert.ToInt32(ContentAlignment.TopLeft))
                    {
                        DrawFormat.Alignment = StringAlignment.Near;
                    }
                    else if (Alignment == Convert.ToInt32(ContentAlignment.TopCenter))
                    {
                        DrawFormat.Alignment = StringAlignment.Center;
                    }
                    else if (Alignment == Convert.ToInt32(ContentAlignment.TopRight))
                    {
                        DrawFormat.Alignment = StringAlignment.Far;
                    }

                    if (_Autosize)
                    {
                        switch (_AutosizeMethod)
                        {
                            case AutosizeDrawMethod.Smallest:
                                {
                                    Path.AddString(Text, Font.FontFamily, Convert.ToInt32(Font.Style), Convert.ToSingle(g.DpiY * Font.Size / 72), new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), DrawFormat);

                                    break;
                                }
                            case AutosizeDrawMethod.NoWrap:
                                {
                                    Path.AddString(Text, Font.FontFamily, Convert.ToInt32(Font.Style), Convert.ToSingle(g.DpiY * Font.Size / 72), new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), DrawFormat);

                                    break;
                                }
                            //case AutosizeDrawMethod.LargestNoWrap:
                            //    {
                            //        int fontSize = MaxFontSize(Text, Font, new RectangleF(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), false);

                            //        Path.AddString(Text, Font.FontFamily, Convert.ToInt32(Font.Style), Convert.ToSingle(g.DpiY * fontSize / 72), new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), DrawFormat);

                            //        break;
                            //    }
                            case AutosizeDrawMethod.LargestNoWrap:
                                {
                                    // 1) compute your max font size
                                    int fontSize = MaxFontSize(
                                        Text,
                                        Font,
                                        new RectangleF(0, 0, this.ClientSize.Width, this.ClientSize.Height),
                                        false
                                    );

                                    // 2) draw into the full client rectangle
                                    Rectangle layout = this.ClientRectangle;
                                    float emSize = (float)(g.DpiY * fontSize / 72.0);

                                    Path.AddString(
                                        Text,
                                        Font.FontFamily,
                                        (int)Font.Style,
                                        emSize,
                                        layout,
                                        DrawFormat
                                    );
                                    break;
                                }

                            case AutosizeDrawMethod.LargestWrap:
                                {
                                    int fontSize = MaxFontSize(Text, Font, new RectangleF(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), false);

                                    Path.AddString(Text, Font.FontFamily, Convert.ToInt32(Font.Style), Convert.ToSingle(g.DpiY * fontSize / 72), new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), DrawFormat);

                                    break;
                                }
                        }
                    }
                    else
                    {
                        //Add the text to the Drawing2D.GraphicsPath using the StringFormat 
                        Path.AddString(Text, Font.FontFamily, Convert.ToInt32(Font.Style), Convert.ToSingle(g.DpiY * Font.Size / 72), new Rectangle(this.Padding.Left, this.Padding.Top, this.ClientSize.Width - 1 - (this.Padding.Left + this.Padding.Right), this.ClientSize.Height - 1 - (this.Padding.Top + this.Padding.Bottom)), DrawFormat);
                    }

                    //If the ShowTextShadow property is set to true then draw the shadow 
                    if (_ShowTextShadow)
                    {
                        //Use the ShadowPosition property to set the Graphics.TranslateTransform to draw the 
                        //shadow at the correct offset position. 
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            g.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            g.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            g.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                        }
                        else
                        {
                            g.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                        }

                        if (_ShadowStyle == ShadowDrawingType.DrawShadow)
                        {
                            //Draw the Drawing2D.GraphicsPath with the _ShadowPen that is set to the ShadowColor having the ShadowTransparency 
                            g.DrawPath(_ShadowPen, Path);
                            //Draws the shadow 
                        }
                        else if (_ShadowStyle == ShadowDrawingType.FillShadow)
                        {
                            //Fill the Drawing2D.GraphicsPath with the _ShadowBrush that is set to the ShadowColor having the ShadowTransparency 
                            g.FillPath(_ShadowBrush, Path);
                            //Draws the shadow 
                        }
                        else
                        {
                            // None
                        }

                        //Now use the Graphics.TranslateTransform to shift the graphics back in the opposite 
                        //direction before Drawing and Filling the Drawing2D.GraphicsPath again with text colors 
                        //if (_ShadowStyle != ShadowDrawingType.NoShadow)
                        //{
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            g.TranslateTransform(+(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            g.TranslateTransform(-(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            g.TranslateTransform(+(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                        else
                        {
                            g.TranslateTransform(-(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                        //}
                    }

                    //If the TextPatternImage property has been set to an image then fill the center of the text with the image 
                    //else the center will be filled with a solid color of the ForeColor property. 
                    if (_TextPatternImage != null)
                    {
                        //Use the TextPatternImageLayout property to resize and/or position the TextPatternImage 
                        Rectangle Rect = new Rectangle();
                        RectangleF Bounds = Path.GetBounds();

                        if (_TextPatternImageLayout == PatternLayout.Normal | _TextPatternImageLayout == PatternLayout.Tile)
                        {
                            Rect = new Rectangle(Convert.ToInt32(Bounds.X) + 1, Convert.ToInt32(Bounds.Y + 1), _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Center)
                        {
                            int xx = Convert.ToInt32(Bounds.X + 1 + ((Bounds.Width / 2) - (_TextPatternImage.Width / 2)));
                            int yy = Convert.ToInt32(Bounds.Y + 1 + ((Bounds.Height / 2) - (_TextPatternImage.Height / 2)));

                            Rect = new Rectangle(xx, yy, _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Stretch)
                        {
                            Rect = new Rectangle(Convert.ToInt32(Bounds.X) + 1, Convert.ToInt32(Bounds.Y + 1), Convert.ToInt32(Bounds.Width) + 1, Convert.ToInt32(Bounds.Height) + 1);
                        }

                        using (Bitmap patBmp = new Bitmap(_TextPatternImage, Rect.Width, Rect.Height))
                        {
                            //Use a TextureBrush with the TextPatternImage assigned as the texture image 
                            using (TextureBrush Brush = new TextureBrush(patBmp))
                            {
                                //If the TextPatternImageLayout property is not set to Tile then set the 
                                //TextureBrush`s WrapMode to Clamp to stop it from tiling the image. 
                                if (!(_TextPatternImageLayout == PatternLayout.Tile))
                                {
                                    Brush.WrapMode = WrapMode.Clamp;
                                }

                                Brush.TranslateTransform(Rect.X, Rect.Y);
                                //Fill the GraphicsPath with the TextureBrush. 
                                g.FillPath(Brush, Path);
                            }
                        }
                    }
                    else
                    {
                        //Fill the GraphicsPath with a solid color of the ForeColor property. 
                        g.FillPath(_ForeColorBrush, Path);
                    }

                    if (_DrawOutline)
                    {
                        //Draw the GraphicsPath with the OutlineColor. 
                        g.DrawPath(_OutLinePen, Path);
                    }
                }
            }

            //If the BorderStyle property is other than None then call the DrawBorder sub to draw the border 
            if (_BorderStyle != BorderType.None)
            {
                DrawLabelBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        //Need to use the OnTextChanged overrides sub to make the Label repaint itself when the text is changed 
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        private void SetGraphicsQuality(Graphics g, PixelOffsetMode Quality)
        {
            // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing).
            // One exception is that path gradient brushes do not obey the smoothing mode.
            // Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // The interpolation mode determines how intermediate values between two endpoints are calculated.
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
            g.PixelOffsetMode = Quality;

            // This one is important
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }

        private List<string> WrapText(string Text, Font Font, int LineWidthPx)
        {
            string[] originalLines = Text.Split(new string[] { " " }, StringSplitOptions.None);

            List<string> wrappedLines = new List<string>();

            StringBuilder actualLine = new StringBuilder();
            double actualWidthInPixels = 0;

            foreach (string str in originalLines)
            {
                Size size = MeasureDrawnTextBitmapSize(str, Font);

                _ = actualLine.Append(str + " ");
                actualWidthInPixels += size.Width;

                if (actualWidthInPixels > LineWidthPx)
                {
                    actualLine = actualLine.Remove(actualLine.ToString().Length - str.Length - 1, str.Length);
                    wrappedLines.Add(actualLine.ToString());
                    _ = actualLine.Clear();
                    _ = actualLine.Append(str + " ");
                    actualWidthInPixels = size.Width;
                }
            }

            if (actualLine.Length > 0)
            {
                wrappedLines.Add(actualLine.ToString());
            }

            return wrappedLines;
        }

        #endregion
        // By convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace


    }
}
