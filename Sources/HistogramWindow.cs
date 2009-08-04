// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge.Math;
using AForge.Imaging;

namespace IPLab
{
    /// <summary>
    /// Summary description for HistogramWindow.
    /// </summary>
    public class HistogramWindow : Content
    {
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),
		};

        private int currentImageHash = 0;

        private ImageStatistics stat;
        private AForge.Controls.Histogram histogram;
        private AForge.Math.Histogram activeHistogram = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox channelCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label meanLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label stdDevLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label medianLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label percentileLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.CheckBox logCheck;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public HistogramWindow( )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HistogramWindow ) );
            this.label1 = new System.Windows.Forms.Label( );
            this.channelCombo = new System.Windows.Forms.ComboBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.meanLabel = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.stdDevLabel = new System.Windows.Forms.Label( );
            this.label4 = new System.Windows.Forms.Label( );
            this.medianLabel = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.label7 = new System.Windows.Forms.Label( );
            this.levelLabel = new System.Windows.Forms.Label( );
            this.countLabel = new System.Windows.Forms.Label( );
            this.percentileLabel = new System.Windows.Forms.Label( );
            this.label8 = new System.Windows.Forms.Label( );
            this.label9 = new System.Windows.Forms.Label( );
            this.minLabel = new System.Windows.Forms.Label( );
            this.maxLabel = new System.Windows.Forms.Label( );
            this.logCheck = new System.Windows.Forms.CheckBox( );
            this.histogram = new AForge.Controls.Histogram( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 5, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 51, 16 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel:";
            // 
            // channelCombo
            // 
            this.channelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelCombo.Location = new System.Drawing.Point( 60, 5 );
            this.channelCombo.Name = "channelCombo";
            this.channelCombo.Size = new System.Drawing.Size( 130, 21 );
            this.channelCombo.TabIndex = 3;
            this.channelCombo.SelectedIndexChanged += new System.EventHandler( this.channelCombo_SelectedIndexChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 5, 195 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 37, 15 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Mean:";
            // 
            // meanLabel
            // 
            this.meanLabel.Location = new System.Drawing.Point( 50, 195 );
            this.meanLabel.Name = "meanLabel";
            this.meanLabel.Size = new System.Drawing.Size( 40, 14 );
            this.meanLabel.TabIndex = 5;
            this.meanLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 5, 215 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 50, 15 );
            this.label3.TabIndex = 6;
            this.label3.Text = "Std Dev:";
            // 
            // stdDevLabel
            // 
            this.stdDevLabel.Location = new System.Drawing.Point( 50, 215 );
            this.stdDevLabel.Name = "stdDevLabel";
            this.stdDevLabel.Size = new System.Drawing.Size( 40, 14 );
            this.stdDevLabel.TabIndex = 7;
            this.stdDevLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 5, 235 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 47, 15 );
            this.label4.TabIndex = 8;
            this.label4.Text = "Median:";
            // 
            // medianLabel
            // 
            this.medianLabel.Location = new System.Drawing.Point( 50, 235 );
            this.medianLabel.Name = "medianLabel";
            this.medianLabel.Size = new System.Drawing.Size( 40, 14 );
            this.medianLabel.TabIndex = 9;
            this.medianLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 125, 195 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 44, 15 );
            this.label5.TabIndex = 10;
            this.label5.Text = "Level:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point( 125, 215 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 53, 15 );
            this.label6.TabIndex = 11;
            this.label6.Text = "Count:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point( 125, 235 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 59, 16 );
            this.label7.TabIndex = 12;
            this.label7.Text = "Percentile:";
            // 
            // levelLabel
            // 
            this.levelLabel.Location = new System.Drawing.Point( 190, 195 );
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size( 60, 15 );
            this.levelLabel.TabIndex = 13;
            // 
            // countLabel
            // 
            this.countLabel.Location = new System.Drawing.Point( 190, 215 );
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size( 60, 15 );
            this.countLabel.TabIndex = 14;
            // 
            // percentileLabel
            // 
            this.percentileLabel.Location = new System.Drawing.Point( 190, 235 );
            this.percentileLabel.Name = "percentileLabel";
            this.percentileLabel.Size = new System.Drawing.Size( 60, 15 );
            this.percentileLabel.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point( 5, 255 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 30, 15 );
            this.label8.TabIndex = 16;
            this.label8.Text = "Min:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point( 5, 275 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 30, 15 );
            this.label9.TabIndex = 17;
            this.label9.Text = "Max:";
            // 
            // minLabel
            // 
            this.minLabel.Location = new System.Drawing.Point( 50, 255 );
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size( 40, 14 );
            this.minLabel.TabIndex = 18;
            this.minLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // maxLabel
            // 
            this.maxLabel.Location = new System.Drawing.Point( 50, 275 );
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size( 40, 14 );
            this.maxLabel.TabIndex = 19;
            this.maxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // logCheck
            // 
            this.logCheck.Location = new System.Drawing.Point( 210, 10 );
            this.logCheck.Name = "logCheck";
            this.logCheck.Size = new System.Drawing.Size( 50, 20 );
            this.logCheck.TabIndex = 20;
            this.logCheck.Text = "Log";
            this.logCheck.CheckedChanged += new System.EventHandler( this.logCheck_CheckedChanged );
            // 
            // histogram
            // 
            this.histogram.AllowSelection = true;
            this.histogram.Location = new System.Drawing.Point( 5, 30 );
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size( 258, 162 );
            this.histogram.TabIndex = 0;
            this.histogram.SelectionChanged += new AForge.Controls.HistogramEventHandler( this.histogram_SelectionChanged );
            this.histogram.PositionChanged += new AForge.Controls.HistogramEventHandler( this.histogram_PositionChanged );
            // 
            // HistogramWindow
            // 
            this.AllowedStates = ( (WeifenLuo.WinFormsUI.ContentStates) ( ( ( WeifenLuo.WinFormsUI.ContentStates.Float | WeifenLuo.WinFormsUI.ContentStates.DockLeft )
                        | WeifenLuo.WinFormsUI.ContentStates.DockRight ) ) );
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.ClientSize = new System.Drawing.Size( 270, 341 );
            this.Controls.Add( this.logCheck );
            this.Controls.Add( this.maxLabel );
            this.Controls.Add( this.minLabel );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.percentileLabel );
            this.Controls.Add( this.countLabel );
            this.Controls.Add( this.levelLabel );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.medianLabel );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.stdDevLabel );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.meanLabel );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.channelCombo );
            this.Controls.Add( this.histogram );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 276, 280 );
            this.Name = "HistogramWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.DockState.DockRight;
            this.ShowInTaskbar = false;
            this.Text = "Histogram";
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

            if ( image != null )
                System.Diagnostics.Debug.WriteLine( "=== Gathering histogram" );

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            stat = ( image == null ) ? null : new ImageStatistics( image );

            // free
            Cursor = Cursors.Arrow;
            Capture = false;

            // clean combo
            channelCombo.Items.Clear( );
            channelCombo.Enabled = false;

            if ( stat != null )
            {
                if ( !stat.IsGrayscale )
                {
                    // RGB picture
                    channelCombo.Items.AddRange( new object[] { "Red", "Green", "Blue" } );
                    channelCombo.Enabled = true;
                }
                else
                {
                    // grayscale picture
                    channelCombo.Items.Add( "Gray" );
                }
                channelCombo.SelectedIndex = 0;
            }
            else
            {
                histogram.Values = null;
                meanLabel.Text = String.Empty;
                stdDevLabel.Text = String.Empty;
                medianLabel.Text = String.Empty;
                minLabel.Text = String.Empty;
                maxLabel.Text = String.Empty;
                levelLabel.Text = String.Empty;
                countLabel.Text = String.Empty;
                percentileLabel.Text = String.Empty;
            }
        }

        // selection changed in channels combo
        private void channelCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( stat != null )
            {
                SwitchChannel( ( stat.IsGrayscale ) ? 3 : channelCombo.SelectedIndex );
            }
        }

        // Switch channel
        public void SwitchChannel( int channel )
        {
            if ( ( channel >= 0 ) && ( channel <= 2 ) )
            {
                if ( !stat.IsGrayscale )
                {
                    histogram.Color = colors[channel];
                    activeHistogram = ( channel == 0 ) ? stat.Red : ( channel == 1 ) ? stat.Green : stat.Blue;
                }
            }
            else if ( channel == 3 )
            {
                if ( stat.IsGrayscale )
                {
                    histogram.Color = colors[3];
                    activeHistogram = stat.Gray;
                }
            }

            if ( activeHistogram != null )
            {
                histogram.Values = activeHistogram.Values;

                meanLabel.Text = activeHistogram.Mean.ToString( "F2" );
                stdDevLabel.Text = activeHistogram.StdDev.ToString( "F2" );
                medianLabel.Text = activeHistogram.Median.ToString( );
                minLabel.Text = activeHistogram.Min.ToString( );
                maxLabel.Text = activeHistogram.Max.ToString( );
            }
        }

        // Cursor position changed over the hostogram
        private void histogram_PositionChanged( object sender, AForge.Controls.HistogramEventArgs e )
        {
            int pos = e.Position;

            if ( pos != -1 )
            {
                levelLabel.Text = pos.ToString( );
                countLabel.Text = activeHistogram.Values[pos].ToString( );
                percentileLabel.Text = ( (float) activeHistogram.Values[pos] * 100 / stat.PixelsCount ).ToString( "F2" );
            }
            else
            {
                levelLabel.Text = "";
                countLabel.Text = "";
                percentileLabel.Text = "";
            }
        }

        // Selection changed in the hostogram
        private void histogram_SelectionChanged( object sender, AForge.Controls.HistogramEventArgs e )
        {
            int min = e.Min;
            int max = e.Max;
            int count = 0;

            levelLabel.Text = min.ToString( ) + "..." + max.ToString( );

            // count pixels
            for ( int i = min; i <= max; i++ )
            {
                count += activeHistogram.Values[i];
            }
            countLabel.Text = count.ToString( );
            percentileLabel.Text = ( (float) count * 100 / stat.PixelsCount ).ToString( "F2" );
        }

        // On "Log" check - switch mode
        private void logCheck_CheckedChanged( object sender, System.EventArgs e )
        {
            histogram.IsLogarithmicView = logCheck.Checked;
        }
    }
}
