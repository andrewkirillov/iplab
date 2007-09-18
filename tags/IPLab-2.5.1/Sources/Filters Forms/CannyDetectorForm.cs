using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for CannyDetectorForm.
    /// </summary>
    public class CannyDetectorForm : System.Windows.Forms.Form
    {
        private CannyEdgeDetector filter = new CannyEdgeDetector( );
        private System.Windows.Forms.TextBox sigmaBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar sigmaTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private IPLab.ColorSlider thresholdSlider;
        private System.Windows.Forms.GroupBox groupBox3;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox highThresholdBox;
        private System.Windows.Forms.TextBox lowThresholdBox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Image property
        public Bitmap Image
        {
            set { filterPreview.Image = value; }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public CannyDetectorForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // set edit boxes
            sigmaBox.Text = filter.GaussianSigma.ToString( );
            lowThresholdBox.Text = filter.LowThreshold.ToString( );
            highThresholdBox.Text = filter.HighThreshold.ToString( );

            // set sliders
            sigmaTrackBar.Value = (int) ( ( filter.GaussianSigma - 1.0 ) * 20 );
            thresholdSlider.Min = filter.LowThreshold;
            thresholdSlider.Max = filter.HighThreshold;

            filterPreview.Filter = filter;
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
            this.sigmaBox = new System.Windows.Forms.TextBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.sigmaTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.thresholdSlider = new IPLab.ColorSlider( );
            this.highThresholdBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.lowThresholdBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.sigmaTrackBar ) ).BeginInit( );
            this.groupBox2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // sigmaBox
            // 
            this.sigmaBox.Location = new System.Drawing.Point( 10, 20 );
            this.sigmaBox.Name = "sigmaBox";
            this.sigmaBox.Size = new System.Drawing.Size( 60, 20 );
            this.sigmaBox.TabIndex = 1;
            this.sigmaBox.Text = "";
            this.sigmaBox.TextChanged += new System.EventHandler( this.sigmaBox_TextChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.sigmaTrackBar );
            this.groupBox1.Controls.Add( this.sigmaBox );
            this.groupBox1.Location = new System.Drawing.Point( 10, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 280, 95 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gaussian Sigma";
            // 
            // sigmaTrackBar
            // 
            this.sigmaTrackBar.Location = new System.Drawing.Point( 10, 45 );
            this.sigmaTrackBar.Maximum = 40;
            this.sigmaTrackBar.Name = "sigmaTrackBar";
            this.sigmaTrackBar.Size = new System.Drawing.Size( 260, 45 );
            this.sigmaTrackBar.TabIndex = 2;
            this.sigmaTrackBar.TickFrequency = 2;
            this.sigmaTrackBar.ValueChanged += new System.EventHandler( this.sigmaTrackBar_ValueChanged );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.thresholdSlider );
            this.groupBox2.Controls.Add( this.highThresholdBox );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.lowThresholdBox );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 110 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 280, 80 );
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Threshold Values";
            // 
            // thresholdSlider
            // 
            this.thresholdSlider.Location = new System.Drawing.Point( 8, 50 );
            this.thresholdSlider.Name = "thresholdSlider";
            this.thresholdSlider.Size = new System.Drawing.Size( 262, 23 );
            this.thresholdSlider.TabIndex = 4;
            this.thresholdSlider.Text = "colorSlider1";
            this.thresholdSlider.ValuesChanged += new System.EventHandler( this.thresholdSlider_ValuesChanged );
            // 
            // highThresholdBox
            // 
            this.highThresholdBox.Location = new System.Drawing.Point( 155, 20 );
            this.highThresholdBox.Name = "highThresholdBox";
            this.highThresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.highThresholdBox.TabIndex = 3;
            this.highThresholdBox.Text = "";
            this.highThresholdBox.TextChanged += new System.EventHandler( this.highThresholdBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 120, 23 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 35, 14 );
            this.label2.TabIndex = 2;
            this.label2.Text = "High:";
            // 
            // lowThresholdBox
            // 
            this.lowThresholdBox.Location = new System.Drawing.Point( 45, 20 );
            this.lowThresholdBox.Name = "lowThresholdBox";
            this.lowThresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.lowThresholdBox.TabIndex = 1;
            this.lowThresholdBox.Text = "";
            this.lowThresholdBox.TextChanged += new System.EventHandler( this.lowThresholdBox_TextChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 35, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Low:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.filterPreview );
            this.groupBox3.Location = new System.Drawing.Point( 300, 5 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 170, 185 );
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 13;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 244, 205 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 159, 205 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 12;
            this.okButton.Text = "Ok";
            // 
            // CannyDetectorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 479, 236 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CannyDetectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canny Edge Detector";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.sigmaTrackBar ) ).EndInit( );
            this.groupBox2.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Changed value of sigma track bar
        private void sigmaTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            double v = (double) sigmaTrackBar.Value / 20 + 1.0;

            sigmaBox.Text = v.ToString( );
        }

        // Treshold values changed using slider
        private void thresholdSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            lowThresholdBox.Text = thresholdSlider.Min.ToString( );
            highThresholdBox.Text = thresholdSlider.Max.ToString( );
        }

        // Sigma changed
        private void sigmaBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.GaussianSigma = double.Parse( sigmaBox.Text );

                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Low threshold value changed
        private void lowThresholdBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.LowThreshold = byte.Parse( lowThresholdBox.Text );

                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Hight threshold value changed
        private void highThresholdBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.HighThreshold = byte.Parse( highThresholdBox.Text );

                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
