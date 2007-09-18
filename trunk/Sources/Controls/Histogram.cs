// Image Processing Lab
//
// Copyright © Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IPLab
{
    // Events arguments
    public class HistogramEventArgs : EventArgs
    {
        private int min, max;

        // Constructor
        public HistogramEventArgs( int pos )
        {
            this.min = pos;
        }
        public HistogramEventArgs( int min, int max )
        {
            this.min = min;
            this.max = max;
        }

        // Min property
        public int Min
        {
            get { return min; }
        }
        // Max property
        public int Max
        {
            get { return max; }
        }
        // Position property
        public int Position
        {
            get { return min; }
        }
    }


    /// <summary>
    /// Summary description for ColorHistogram.
    /// </summary>
    public class Histogram : System.Windows.Forms.Control
    {
        private Color color = Color.Black;
        private int width = 256;
        private int height = 150;
        private bool log = false;

        private int[] values;
        private int max;
        private double maxLog;
        private bool allowSelection = false;

        private Pen blackPen = new Pen( Color.Black, 1 );
        private Pen whitePen = new Pen( Color.White, 1 );
        private Pen drawPen = new Pen( Color.Black );
        private bool tracking = false;
        private bool over = false;
        private int start, stop;

        // Color property
        [DefaultValue( typeof( Color ), "Black" )]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;

                drawPen.Dispose( );
                drawPen = new Pen( color );
                Invalidate( );
            }
        }
        // Width property
        [DefaultValue( 256 )]
        public int HistogramWidth
        {
            get { return width; }
            set
            {
                width = value;
                Invalidate( );
            }
        }
        // Height property
        [DefaultValue( 150 )]
        public int HistogramHeight
        {
            get { return height; }
            set
            {
                height = value;
                Invalidate( );
            }
        }
        // Allow selection property
        [DefaultValue( false )]
        public bool AllowSelection
        {
            get { return allowSelection; }
            set { allowSelection = value; }
        }
        // LogView property
        [DefaultValue( false )]
        public bool LogView
        {
            get { return log; }
            set
            {
                log = value;
                Invalidate( );
            }
        }


        // Values property
        [Browsable( false )]
        public int[] Values
        {
            set
            {
                values = value;

                if ( values != null )
                {
                    // get the max
                    max = 0;
                    foreach ( int v in values )
                    {
                        if ( v > max )
                        {
                            max = v;
                            maxLog = Math.Log10( max );
                        }
                    }
                }
                Invalidate( );
            }
        }

        // events
        public delegate void HistogramEventHandler( object sender, HistogramEventArgs e );
        public event HistogramEventHandler PositionChanged;
        public event HistogramEventHandler SelectionChanged;

        // Constructor
        public Histogram( )
        {
            InitializeComponent( );
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true );
        }

        // Dispose
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                blackPen.Dispose( );
                whitePen.Dispose( );
                drawPen.Dispose( );
            }
            base.Dispose( disposing );
        }

        // Init component
        private void InitializeComponent( )
        {
            // 
            // Histogram
            // 
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.Histogram_MouseUp );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.Histogram_MouseMove );
            this.MouseLeave += new System.EventHandler( this.Histogram_MouseLeave );
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.Histogram_MouseDown );

        }

        // Paint control
        protected override void OnPaint( PaintEventArgs pe )
        {
            Graphics g = pe.Graphics;
            int x = ( ClientRectangle.Right - width ) / 2;
            int y = 5;
            int l;

            // draw rectangle around the image
            g.DrawRectangle( blackPen, x - 1, y - 1, width + 1, height + 1 );

            if ( values != null )
            {
                int count = Math.Min( values.Length, width );
                int start = Math.Min( this.start, this.stop );
                int stop = Math.Max( this.start, this.stop );

                if ( tracking )
                {
                    // fill region of selection
                    Brush brush = new SolidBrush( Color.FromArgb( 92, 92, 92 ) );
                    g.FillRectangle( brush, x + start, y, Math.Abs( start - stop ), height );
                    brush.Dispose( );
                }

                // draw histogram
                for ( int i = 0; i < count; i++ )
                {
                    if ( log )
                    {
                        l = ( values[i] == 0 ) ? 0 : (int) ( Math.Log10( values[i] ) * height / maxLog );
                    }
                    else
                    {
                        l = (int) ( values[i] * height / max );
                    }

                    if ( l != 0 )
                    {
                        g.DrawLine( ( ( tracking ) && ( i >= start ) && ( i <= stop ) ) ? whitePen : drawPen,
                            new Point( x + i, y + height - 1 ),
                            new Point( x + i, y + height - l )
                            );
                    }
                }
            }

            // Calling the base class OnPaint
            base.OnPaint( pe );
        }

        // On mouse down
        private void Histogram_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( ( allowSelection ) && ( values != null ) )
            {
                int x = ( ClientRectangle.Right - width ) / 2;
                int y = 5;

                if ( ( e.X >= x ) && ( e.Y >= y ) && ( e.X < x + width ) && ( e.Y < y + height ) )
                {
                    // start selection
                    tracking = true;
                    start = e.X - x;
                    this.Capture = true;
                }
            }
        }

        // On mouse up
        private void Histogram_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( tracking )
            {
                // stop selection
                tracking = false;
                this.Capture = false;
                Invalidate( );
            }
        }

        // On mouse move
        private void Histogram_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( ( allowSelection ) && ( values != null ) )
            {
                int x = ( ClientRectangle.Right - width ) / 2;
                int y = 5;

                if ( !tracking )
                {
                    if ( ( e.X >= x ) && ( e.Y >= y ) && ( e.X < x + width ) && ( e.Y < y + height ) )
                    {
                        over = true;

                        // moving over
                        this.Cursor = Cursors.Cross;

                        // notify parent
                        if ( PositionChanged != null )
                            PositionChanged( this, new HistogramEventArgs( e.X - x ) );
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;

                        if ( over )
                        {
                            over = false;

                            // notify parent
                            if ( PositionChanged != null )
                                PositionChanged( this, new HistogramEventArgs( -1 ) );
                        }
                    }
                }
                else
                {
                    // selecting region
                    stop = e.X - x;

                    stop = Math.Min( stop, 255 );
                    stop = Math.Max( stop, 0 );

                    Invalidate( );

                    // notify parent
                    if ( SelectionChanged != null )
                        SelectionChanged( this, new HistogramEventArgs( Math.Min( start, stop ), Math.Max( start, stop ) ) );
                }
            }
        }

        // On mouse leave
        private void Histogram_MouseLeave( object sender, System.EventArgs e )
        {
            if ( ( allowSelection ) && ( values != null ) && ( !tracking ) )
            {
                // notify parent
                if ( PositionChanged != null )
                    PositionChanged( this, new HistogramEventArgs( -1 ) );
            }
        }
    }
}
