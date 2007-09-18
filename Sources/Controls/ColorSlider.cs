// Image Processing Lab
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace IPLab
{
    // ColorSliderType enumeration
    public enum ColorSliderType
    {
        Gradient,
        InnerGradient,
        OuterGradient,
        Threshold
    }

    /// <summary>
    /// ColorSlider control
    /// </summary>
    public class ColorSlider : System.Windows.Forms.Control
    {
        private Pen blackPen = new Pen( Color.Black, 1 );
        private Color color1 = Color.Black;
        private Color color2 = Color.White;
        private Color color3 = Color.Black;
        private ColorSliderType type = ColorSliderType.Gradient;
        private bool doubleArrow = true;
        private Bitmap arrow;
        private int min = 0, max = 255;
        private int width = 256, height = 10;
        private int trackMode = 0;
        private int dx;

        // values changed event
        public event EventHandler ValuesChanged;

        // Color1 property
        [DefaultValue( typeof( Color ), "Black" )]
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Invalidate( );
            }
        }
        // Color2 property
        [DefaultValue( typeof( Color ), "White" )]
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Invalidate( );
            }
        }
        // Color3 property
        [DefaultValue( typeof( Color ), "Black" )]
        public Color Color3
        {
            get { return color3; }
            set
            {
                color3 = value;
                Invalidate( );
            }
        }
        // Type property
        [DefaultValue( ColorSliderType.Gradient )]
        public ColorSliderType Type
        {
            get { return type; }
            set
            {
                type = value;
                if ( ( type != ColorSliderType.Gradient ) && ( type != ColorSliderType.Threshold ) )
                    DoubleArrow = true;
                Invalidate( );
            }
        }
        // Min property
        [DefaultValue( 0 )]
        public int Min
        {
            get { return min; }
            set
            {
                min = value;
                Invalidate( );
            }
        }
        // Max property
        [DefaultValue( 255 )]
        public int Max
        {
            get { return max; }
            set
            {
                max = value;
                Invalidate( );
            }
        }
        // DoubleArrow property
        [DefaultValue( true )]
        public bool DoubleArrow
        {
            get { return doubleArrow; }
            set
            {
                doubleArrow = value;
                if ( ( !doubleArrow ) && ( type != ColorSliderType.Threshold ) )
                {
                    Type = ColorSliderType.Gradient;
                }
                Invalidate( );
            }
        }


        // Constructor
        public ColorSlider( )
        {
            InitializeComponent( );

            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true );

            // load arrow bitmap
            Assembly assembly = this.GetType( ).Assembly;
            arrow = new Bitmap( assembly.GetManifestResourceStream( "IPLab.Resources.arrow.bmp" ) );
            arrow.MakeTransparent( Color.FromArgb( 255, 255, 255 ) );
        }

        // Dispose
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                blackPen.Dispose( );
                arrow.Dispose( );
            }
            base.Dispose( disposing );
        }

        // Init component
        private void InitializeComponent( )
        {
            // 
            // ColorSlider
            // 
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseUp );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseMove );
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ColorSlider_MouseDown );

        }

        // Paint control
        protected override void OnPaint( PaintEventArgs pe )
        {
            Graphics g = pe.Graphics;
            Rectangle rc = this.ClientRectangle;
            Brush brush;
            int x = ( rc.Right - width ) / 2;
            int y = 2;

            // draw rectangle around the control
            g.DrawRectangle( blackPen, x - 1, y - 1, width + 1, height + 1 );

            switch ( type )
            {
                case ColorSliderType.Gradient:
                case ColorSliderType.InnerGradient:
                case ColorSliderType.OuterGradient:

                    // create gradient brush
                    brush = new LinearGradientBrush( new Point( x, 0 ), new Point( x + width, 0 ), color1, color2 );
                    g.FillRectangle( brush, x, y, width, height );
                    brush.Dispose( );

                    // check type
                    if ( type == ColorSliderType.InnerGradient )
                    {
                        // inner gradient
                        brush = new SolidBrush( color3 );

                        if ( min != 0 )
                        {
                            g.FillRectangle( brush, x, y, min, height );
                        }
                        if ( max != 255 )
                        {
                            g.FillRectangle( brush, x + max + 1, y, 255 - max, height );
                        }
                        brush.Dispose( );
                    }
                    else if ( type == ColorSliderType.OuterGradient )
                    {
                        // outer gradient
                        brush = new SolidBrush( color3 );
                        // fill space between min & max with color 3
                        g.FillRectangle( brush, x + min, y, max - min + 1, height );
                        brush.Dispose( );
                    }
                    break;
                case ColorSliderType.Threshold:
                    // 1 - fill with color 1
                    brush = new SolidBrush( color1 );
                    g.FillRectangle( brush, x, y, width, height );
                    brush.Dispose( );
                    // 2 - fill space between min & max with color 2
                    brush = new SolidBrush( color2 );
                    g.FillRectangle( brush, x + min, y, max - min + 1, height );
                    brush.Dispose( );
                    break;
            }


            // draw arrows
            x -= 4;
            y += 1 + height;

            g.DrawImage( arrow, x + min, y, 9, 6 );
            if ( doubleArrow )
                g.DrawImage( arrow, x + max, y, 9, 6 );

            // Calling the base class OnPaint
            base.OnPaint( pe );
        }

        // On mouse down
        private void ColorSlider_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            int x = ( ClientRectangle.Right - width ) / 2 - 4;
            int y = 3 + height;

            // check Y coordinate
            if ( ( e.Y >= y ) && ( e.Y < y + 6 ) )
            {
                // check X coordinate
                if ( ( e.X >= x + min ) && ( e.X < x + min + 9 ) )
                {
                    // left arrow
                    trackMode = 1;
                    dx = e.X - min;
                }
                if ( ( doubleArrow ) && ( e.X >= x + max ) && ( e.X < x + max + 9 ) )
                {
                    // right arrow
                    trackMode = 2;
                    dx = e.X - max;
                }

                if ( trackMode != 0 )
                    this.Capture = true;
            }
        }

        // On mouse up
        private void ColorSlider_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( trackMode != 0 )
            {
                // release capture
                this.Capture = false;
                trackMode = 0;

                // notify client
                if ( ValuesChanged != null )
                    ValuesChanged( this, new EventArgs( ) );
            }
        }

        // On mouse move
        private void ColorSlider_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( trackMode != 0 )
            {
                if ( trackMode == 1 )
                {
                    // left arrow tracking
                    min = e.X - dx;
                    min = Math.Max( min, 0 );
                    min = Math.Min( min, max );
                }
                if ( trackMode == 2 )
                {
                    // right arrow tracking
                    max = e.X - dx;
                    max = Math.Max( max, min );
                    max = Math.Min( max, 255 );
                }

                // repaint control
                Invalidate( );
            }
        }
    }
}
