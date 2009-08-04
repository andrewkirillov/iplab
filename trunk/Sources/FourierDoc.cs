// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.ComplexFilters;

namespace IPLab
{
    /// <summary>
    /// Summary description for FourierDoc.
    /// </summary>
    public class FourierDoc : Content
    {
        private ComplexImage image = null;
        private ComplexImage backup = null;
        private System.Drawing.Bitmap bitmap = null;
        private int width;
        private int height;
        private IDocumentsHost host = null;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem fourierItem;
        private System.Windows.Forms.MenuItem backwardFourierItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem frequencyFilterFourierItem;
        private System.Windows.Forms.MenuItem undoFourierItem;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Image property
        public Bitmap Image
        {
            get { return bitmap; }
        }
        // Width property
        public int ImageWidth
        {
            get { return width; }
        }
        // Height property
        public int ImageHeight
        {
            get { return height; }
        }

        // Constructors
        public FourierDoc( ComplexImage image, IDocumentsHost host )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            this.host = host;
            this.image = image;

            width = image.Width;
            height = image.Height;

            UpdateNewImage( );

            // form style
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );

            // init scroll bars
            this.AutoScroll = true;
            // scroll bar size
            this.AutoScrollMinSize = new Size( width, height );
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
                if ( bitmap != null )
                {
                    bitmap.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.mainMenu = new System.Windows.Forms.MainMenu( );
            this.fourierItem = new System.Windows.Forms.MenuItem( );
            this.backwardFourierItem = new System.Windows.Forms.MenuItem( );
            this.menuItem1 = new System.Windows.Forms.MenuItem( );
            this.frequencyFilterFourierItem = new System.Windows.Forms.MenuItem( );
            this.undoFourierItem = new System.Windows.Forms.MenuItem( );
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
																					 this.fourierItem} );
            // 
            // fourierItem
            // 
            this.fourierItem.Index = 0;
            this.fourierItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
																						this.backwardFourierItem,
																						this.menuItem1,
																						this.frequencyFilterFourierItem,
																						this.undoFourierItem} );
            this.fourierItem.MergeOrder = 1;
            this.fourierItem.Text = "Fourier";
            this.fourierItem.Popup += new System.EventHandler( this.fourierItem_Popup );
            // 
            // backwardFourierItem
            // 
            this.backwardFourierItem.Index = 0;
            this.backwardFourierItem.Text = "&Backward Transformation";
            this.backwardFourierItem.Click += new System.EventHandler( this.backwardFourierItem_Click );
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // frequencyFilterFourierItem
            // 
            this.frequencyFilterFourierItem.Index = 2;
            this.frequencyFilterFourierItem.Text = "Frequency Filter";
            this.frequencyFilterFourierItem.Click += new System.EventHandler( this.frequencyFilterFourierItem_Click );
            // 
            // undoFourierItem
            // 
            this.undoFourierItem.Index = 3;
            this.undoFourierItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.undoFourierItem.Text = "&Undo";
            this.undoFourierItem.Click += new System.EventHandler( this.undoFourierItem_Click );
            // 
            // FourierDoc
            // 
            this.AllowedStates = WeifenLuo.WinFormsUI.ContentStates.Document;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.ClientSize = new System.Drawing.Size( 576, 453 );
            this.Menu = this.mainMenu;
            this.Name = "FourierDoc";
            this.Text = "Fourier";

        }
        #endregion

        // Update document
        private void UpdateNewImage( )
        {
            if ( bitmap != null )
            {
                bitmap.Dispose( );
                bitmap = null;
            }

            bitmap = image.ToBitmap( );
            Invalidate( );
        }

        // Paint image
        protected override void OnPaint( PaintEventArgs e )
        {
            if ( bitmap != null )
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen( Color.FromArgb( 0, 0, 0 ) );

                int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                // draw rectangle around the image
                g.DrawRectangle( pen, x - 1, y - 1, width + 1, height + 1 );

                // draw image
                g.DrawImage( bitmap, x, y, width, height );

                pen.Dispose( );
            }
        }

        // Backward Fourier transformation
        private void backwardFourierItem_Click( object sender, System.EventArgs e )
        {
            ComplexImage cimg = (ComplexImage) image.Clone( );

            cimg.BackwardFourierTransform( );
            host.NewDocument( cimg.ToBitmap( ) );
        }

        // Frequency filter
        private void frequencyFilterFourierItem_Click( object sender, System.EventArgs e )
        {
            FrequencyFilterForm form = new FrequencyFilterForm( );

            form.InputRange = new IntRange( 0, width >> 1 );
            form.OutputRange = new IntRange( 0, width >> 1 );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                backup = (ComplexImage) image.Clone( );

                // create and apply filter
                FrequencyFilter filter = new FrequencyFilter( form.OutputRange );
                filter.Apply( image );

                UpdateNewImage( );
            }
        }

        // Undo filter
        private void undoFourierItem_Click( object sender, System.EventArgs e )
        {
            if ( backup != null )
            {
                image = backup;
                backup = null;
                UpdateNewImage( );
            }
        }

        // On "Fourier" menu popup
        private void fourierItem_Popup( object sender, System.EventArgs e )
        {
            undoFourierItem.Enabled = backup != null;
        }
    }
}
