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

using AForge.Math;
using AForge.Imaging;

namespace IPLab
{
    /// <summary>
    /// Summary description for ImageStatisticsWindow.
    /// </summary>
    public class ImageStatisticsWindow : Content
    {
        private System.Windows.Forms.PropertyGrid propertyGrid;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private int currentImageHash = 0;

        // Constructor
        public ImageStatisticsWindow( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( ImageStatisticsWindow ) );
            this.propertyGrid = new System.Windows.Forms.PropertyGrid( );
            this.SuspendLayout( );
            // 
            // propertyGrid
            // 
            this.propertyGrid.CommandsVisibleIfAvailable = true;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.LargeButtons = false;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size( 270, 255 );
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.Text = "PropertyGrid";
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
            this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
            // 
            // ImageStatisticsWindow
            // 
            this.AllowedStates = ( ( WeifenLuo.WinFormsUI.ContentStates.Float | WeifenLuo.WinFormsUI.ContentStates.DockLeft )
                | WeifenLuo.WinFormsUI.ContentStates.DockRight );
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.ClientSize = new System.Drawing.Size( 270, 255 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.propertyGrid} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 276, 280 );
            this.Name = "ImageStatisticsWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.DockState.DockRight;
            this.ShowInTaskbar = false;
            this.Text = "Image Statistics";
            this.ResumeLayout( false );

        }
        #endregion

        // Gather image statistics
        public void GatherStatistics( Bitmap image )
        {
            // avoid calculation in the case of the same image
            if ( image != null )
            {
                if ( currentImageHash == image.GetHashCode( ) )
                    return;
                currentImageHash = image.GetHashCode( );
            }
            else
            {
                propertyGrid.SelectedObject = null;
                return;
            }

            System.Diagnostics.Debug.WriteLine( "--- Gathering stastics" );

            // check pixel format
            if ( image.PixelFormat == PixelFormat.Format24bppRgb )
            {
                // busy
                Capture = true;
                Cursor = Cursors.WaitCursor;

                ColorImageStatisticsDescription statDesc = new ColorImageStatisticsDescription( image );
                // show statistics
                propertyGrid.SelectedObject = statDesc;
                propertyGrid.ExpandAllGridItems( );

                // free
                Cursor = Cursors.Arrow;
                Capture = false;
            }
            else
            {
                propertyGrid.SelectedObject = null;
            }
        }
    }

    // Helper class to display image statistics
    internal class ColorImageStatisticsDescription
    {
        private ImageStatistics statRGB;
        private ImageStatisticsHSL statHSL;
        private ImageStatisticsYCbCr statYCbCr;

        // General with black ------------------------------------
        // Total pixels count
        [Category( "0: General" )]
        public int PixelsCount
        {
            get { return statRGB.PixelsCount; }
        }
        // Pixels without black
        [Category( "0: General" )]
        public int PixelsWithoutBlack
        {
            get { return statRGB.PixelsCountWithoutBlack; }
        }

        // Red with black ------------------------------------
        // RedMin		
        [Category( "1: Red with black" )]
        public int RedMin
        {
            get { return statRGB.Red.Min; }
        }
        // RedMax
        [Category( "1: Red with black" )]
        public int RedMax
        {
            get { return statRGB.Red.Max; }
        }
        // RedMean
        [Category( "1: Red with black" )]
        public double RedMean
        {
            get { return statRGB.Red.Mean; }
        }
        // RedStdDev
        [Category( "1: Red with black" )]
        public double RedStdDev
        {
            get { return statRGB.Red.StdDev; }
        }
        // RedMean
        [Category( "1: Red with black" )]
        public int RedMedian
        {
            get { return statRGB.Red.Median; }
        }

        // Green with black ------------------------------------
        // GreenMin		
        [Category( "2: Green with black" )]
        public int GreenMin
        {
            get { return statRGB.Green.Min; }
        }
        // GreenMax
        [Category( "2: Green with black" )]
        public int GreenMax
        {
            get { return statRGB.Green.Max; }
        }
        // GreenMean
        [Category( "2: Green with black" )]
        public double GreenMean
        {
            get { return statRGB.Green.Mean; }
        }
        // GreenStdDev
        [Category( "2: Green with black" )]
        public double GreenStdDev
        {
            get { return statRGB.Green.StdDev; }
        }
        // GreenMean
        [Category( "2: Green with black" )]
        public int GreenMedian
        {
            get { return statRGB.Green.Median; }
        }

        // Blue with black ------------------------------------
        // BlueMin		
        [Category( "3: Blue with black" )]
        public int BlueMin
        {
            get { return statRGB.Blue.Min; }
        }
        // BlueMax
        [Category( "3: Blue with black" )]
        public int BlueMax
        {
            get { return statRGB.Blue.Max; }
        }
        // BlueMean
        [Category( "3: Blue with black" )]
        public double BlueMean
        {
            get { return statRGB.Blue.Mean; }
        }
        // BlueStdDev
        [Category( "3: Blue with black" )]
        public double BlueStdDev
        {
            get { return statRGB.Blue.StdDev; }
        }
        // BlueMean
        [Category( "3: Blue with black" )]
        public int BlueMedian
        {
            get { return statRGB.Blue.Median; }
        }


        // Red without black ------------------------------------
        // RedMinWB		
        [Category( "4: Red without black" )]
        public int RedMinWB
        {
            get { return statRGB.RedWithoutBlack.Min; }
        }
        // RedMaxWB
        [Category( "4: Red without black" )]
        public int RedMaxWB
        {
            get { return statRGB.RedWithoutBlack.Max; }
        }
        // RedMeanWB
        [Category( "4: Red without black" )]
        public double RedMeanWB
        {
            get { return statRGB.RedWithoutBlack.Mean; }
        }
        // RedStdDevWB
        [Category( "4: Red without black" )]
        public double RedStdDevWB
        {
            get { return statRGB.RedWithoutBlack.StdDev; }
        }
        // RedMeanWB
        [Category( "4: Red without black" )]
        public int RedMedianWB
        {
            get { return statRGB.RedWithoutBlack.Median; }
        }

        // Green without black ------------------------------------
        // GreenMinWB	
        [Category( "5: Green without black" )]
        public int GreenMinWB
        {
            get { return statRGB.GreenWithoutBlack.Min; }
        }
        // GreenMaxWB
        [Category( "5: Green without black" )]
        public int GreenMaxWB
        {
            get { return statRGB.GreenWithoutBlack.Max; }
        }
        // GreenMeanWB
        [Category( "5: Green without black" )]
        public double GreenMeanWB
        {
            get { return statRGB.GreenWithoutBlack.Mean; }
        }
        // GreenStdDevWB
        [Category( "5: Green without black" )]
        public double GreenStdDevWB
        {
            get { return statRGB.GreenWithoutBlack.StdDev; }
        }
        // GreenMeanWB
        [Category( "5: Green without black" )]
        public int GreenMedianWB
        {
            get { return statRGB.GreenWithoutBlack.Median; }
        }

        // Blue without black ------------------------------------
        // BlueMinWB	
        [Category( "6: Blue without black" )]
        public int BlueMinWB
        {
            get { return statRGB.BlueWithoutBlack.Min; }
        }
        // BlueMaxWB
        [Category( "6: Blue without black" )]
        public int BlueMaxWB
        {
            get { return statRGB.BlueWithoutBlack.Max; }
        }
        // BlueMeanWB
        [Category( "6: Blue without black" )]
        public double BlueMeanWB
        {
            get { return statRGB.BlueWithoutBlack.Mean; }
        }
        // BlueStdDevWB
        [Category( "6: Blue without black" )]
        public double BlueStdDevWB
        {
            get { return statRGB.BlueWithoutBlack.StdDev; }
        }
        // BlueMeanWB
        [Category( "6: Blue without black" )]
        public int BlueMedianWB
        {
            get { return statRGB.BlueWithoutBlack.Median; }
        }

        // Saturation with black ------------------------------------
        // SaturationMin		
        [Category( "7: Saturation with black" )]
        public double SaturationMin
        {
            get { return statHSL.Saturation.Min; }
        }
        // SaturationMax
        [Category( "7: Saturation with black" )]
        public double SaturationMax
        {
            get { return statHSL.Saturation.Max; }
        }
        // SaturationMean
        [Category( "7: Saturation with black" )]
        public double SaturationMean
        {
            get { return statHSL.Saturation.Mean; }
        }
        // SaturationStdDev
        [Category( "7: Saturation with black" )]
        public double SaturationStdDev
        {
            get { return statHSL.Saturation.StdDev; }
        }
        // SaturationMean
        [Category( "7: Saturation with black" )]
        public double SaturationMedian
        {
            get { return statHSL.Saturation.Median; }
        }

        // Luminance with black ------------------------------------
        // LuminanceMin		
        [Category( "8: Luminance with black" )]
        public double LuminanceMin
        {
            get { return statHSL.Luminance.Min; }
        }
        // LuminanceMax
        [Category( "8: Luminance with black" )]
        public double LuminanceMax
        {
            get { return statHSL.Luminance.Max; }
        }
        // LuminanceMean
        [Category( "8: Luminance with black" )]
        public double LuminanceMean
        {
            get { return statHSL.Luminance.Mean; }
        }
        // LuminanceStdDev
        [Category( "8: Luminance with black" )]
        public double LuminanceStdDev
        {
            get { return statHSL.Luminance.StdDev; }
        }
        // LuminanceMean
        [Category( "8: Luminance with black" )]
        public double LuminanceMedian
        {
            get { return statHSL.Luminance.Median; }
        }


        // Saturation without black ------------------------------------
        // SaturationMinWB
        [Category( "9: Saturation without black" )]
        public double SaturationMinWB
        {
            get { return statHSL.SaturationWithoutBlack.Min; }
        }
        // SaturationMaxWB
        [Category( "9: Saturation without black" )]
        public double SaturationMaxWB
        {
            get { return statHSL.SaturationWithoutBlack.Max; }
        }
        // SaturationMeanWB
        [Category( "9: Saturation without black" )]
        public double SaturationMeanWB
        {
            get { return statHSL.SaturationWithoutBlack.Mean; }
        }
        // SaturationStdDevWB
        [Category( "9: Saturation without black" )]
        public double SaturationStdDevWB
        {
            get { return statHSL.SaturationWithoutBlack.StdDev; }
        }
        // SaturationMeanWB
        [Category( "9: Saturation without black" )]
        public double SaturationMedianWB
        {
            get { return statHSL.SaturationWithoutBlack.Median; }
        }

        // Luminance without black ------------------------------------
        // LuminanceMinWB
        [Category( "A: Luminance without black" )]
        public double LuminanceMinWB
        {
            get { return statHSL.LuminanceWithoutBlack.Min; }
        }
        // LuminanceMaxWB
        [Category( "A: Luminance without black" )]
        public double LuminanceMaxWB
        {
            get { return statHSL.LuminanceWithoutBlack.Max; }
        }
        // LuminanceMeanWB
        [Category( "A: Luminance without black" )]
        public double LuminanceMeanWB
        {
            get { return statHSL.LuminanceWithoutBlack.Mean; }
        }
        // LuminanceStdDevWB
        [Category( "A: Luminance without black" )]
        public double LuminanceStdDevWB
        {
            get { return statHSL.LuminanceWithoutBlack.StdDev; }
        }
        // LuminanceMeanWB
        [Category( "A: Luminance without black" )]
        public double LuminanceMedianWB
        {
            get { return statHSL.LuminanceWithoutBlack.Median; }
        }

        // Y with black ------------------------------------
        // YMin		
        [Category( "B: Y with black" )]
        public double YMin
        {
            get { return statYCbCr.Y.Min; }
        }
        // YMax
        [Category( "B: Y with black" )]
        public double YMax
        {
            get { return statYCbCr.Y.Max; }
        }
        // YMean
        [Category( "B: Y with black" )]
        public double YMean
        {
            get { return statYCbCr.Y.Mean; }
        }
        // YStdDev
        [Category( "B: Y with black" )]
        public double YStdDev
        {
            get { return statYCbCr.Y.StdDev; }
        }
        // YMean
        [Category( "B: Y with black" )]
        public double YMedian
        {
            get { return statYCbCr.Y.Median; }
        }

        // Cb with black ------------------------------------
        // CbMin		
        [Category( "C: Cb with black" )]
        public double CbMin
        {
            get { return statYCbCr.Cb.Min; }
        }
        // CbMax
        [Category( "C: Cb with black" )]
        public double CbMax
        {
            get { return statYCbCr.Cb.Max; }
        }
        // CbMean
        [Category( "C: Cb with black" )]
        public double CbMean
        {
            get { return statYCbCr.Cb.Mean; }
        }
        // CbStdDev
        [Category( "C: Cb with black" )]
        public double CbStdDev
        {
            get { return statYCbCr.Cb.StdDev; }
        }
        // CbMean
        [Category( "C: Cb with black" )]
        public double CbMedian
        {
            get { return statYCbCr.Cb.Median; }
        }

        // Cr with black ------------------------------------
        // CrMin		
        [Category( "D: Cr with black" )]
        public double CrMin
        {
            get { return statYCbCr.Cr.Min; }
        }
        // CrMax
        [Category( "D: Cr with black" )]
        public double CrMax
        {
            get { return statYCbCr.Cr.Max; }
        }
        // CrMean
        [Category( "D: Cr with black" )]
        public double CrMean
        {
            get { return statYCbCr.Cr.Mean; }
        }
        // CrStdDev
        [Category( "D: Cr with black" )]
        public double CrStdDev
        {
            get { return statYCbCr.Cr.StdDev; }
        }
        // CrMean
        [Category( "D: Cr with black" )]
        public double CrMedian
        {
            get { return statYCbCr.Cr.Median; }
        }

        // Y without black ------------------------------------
        // YMinWB
        [Category( "E: Y without black" )]
        public double YMinWB
        {
            get { return statYCbCr.YWithoutBlack.Min; }
        }
        // YMaxWB
        [Category( "E: Y without black" )]
        public double YMaxWB
        {
            get { return statYCbCr.YWithoutBlack.Max; }
        }
        // YMeanWB
        [Category( "E: Y without black" )]
        public double YMeanWB
        {
            get { return statYCbCr.YWithoutBlack.Mean; }
        }
        // YStdDevWB
        [Category( "E: Y without black" )]
        public double YStdDevWB
        {
            get { return statYCbCr.YWithoutBlack.StdDev; }
        }
        // YMeanWB
        [Category( "E: Y without black" )]
        public double YMedianWB
        {
            get { return statYCbCr.YWithoutBlack.Median; }
        }

        // Cb without black ------------------------------------
        // CbMinWB
        [Category( "F: Cb without black" )]
        public double CbMinWB
        {
            get { return statYCbCr.CbWithoutBlack.Min; }
        }
        // CbMaxWB
        [Category( "F: Cb without black" )]
        public double CbMaxWB
        {
            get { return statYCbCr.CbWithoutBlack.Max; }
        }
        // CbMeanWB
        [Category( "F: Cb without black" )]
        public double CbMeanWB
        {
            get { return statYCbCr.CbWithoutBlack.Mean; }
        }
        // CbStdDevWB
        [Category( "F: Cb without black" )]
        public double CbStdDevWB
        {
            get { return statYCbCr.CbWithoutBlack.StdDev; }
        }
        // CbMeanWB
        [Category( "F: Cb without black" )]
        public double CbMedianWB
        {
            get { return statYCbCr.CbWithoutBlack.Median; }
        }

        // Cr without black ------------------------------------
        // CrMinWB
        [Category( "G: Cr without black" )]
        public double CrMinWB
        {
            get { return statYCbCr.CrWithoutBlack.Min; }
        }
        // CrMaxWB
        [Category( "G: Cr without black" )]
        public double CrMaxWB
        {
            get { return statYCbCr.CrWithoutBlack.Max; }
        }
        // CrMeanWB
        [Category( "G: Cr without black" )]
        public double CrMeanWB
        {
            get { return statYCbCr.CrWithoutBlack.Mean; }
        }
        // CrStdDevWB
        [Category( "G: Cr without black" )]
        public double CrStdDevWB
        {
            get { return statYCbCr.CrWithoutBlack.StdDev; }
        }
        // CrMeanWB
        [Category( "G: Cr without black" )]
        public double CrMedianWB
        {
            get { return statYCbCr.CrWithoutBlack.Median; }
        }

        // Constructor
        public ColorImageStatisticsDescription( Bitmap image )
        {
            // get image dimension
            int width = image.Width;
            int height = image.Height;

            // lock it
            BitmapData imgData = image.LockBits( new Rectangle( 0, 0, width, height ), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb );

            // gather statistics
            statRGB = new ImageStatistics( imgData );
            statHSL = new ImageStatisticsHSL( imgData );
            statYCbCr = new ImageStatisticsYCbCr( imgData );

            // unlock image
            image.UnlockBits( imgData );
        }
    }
}
