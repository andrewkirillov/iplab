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

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for SharpenExForm.
    /// </summary>
    public class SharpenExForm : System.Windows.Forms.Form
    {
        private GaussianSharpen filter = new GaussianSharpen( );

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.TrackBar sizeTrackBar;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.TextBox sigmaBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar sigmaTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        public SharpenExForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // set edit boxes
            sigmaBox.Text = filter.Sigma.ToString( );
            sizeBox.Text = filter.Size.ToString( );

            // set sliders
            sigmaTrackBar.Value = (int) ( ( filter.Sigma - 0.5 ) * 20 );
            sizeTrackBar.Value = ( filter.Size - 3 ) / 2;

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
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.sizeTrackBar = new System.Windows.Forms.TrackBar( );
            this.sizeBox = new System.Windows.Forms.TextBox( );
            this.sigmaBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.sigmaTrackBar = new System.Windows.Forms.TrackBar( );
            this.label1 = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.groupBox3.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.sizeTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.sigmaTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 237, 195 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 152, 195 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 23;
            this.okButton.Text = "Ok";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.filterPreview );
            this.groupBox3.Location = new System.Drawing.Point( 280, 5 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox3.TabIndex = 22;
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
            // sizeTrackBar
            // 
            this.sizeTrackBar.LargeChange = 1;
            this.sizeTrackBar.Location = new System.Drawing.Point( 10, 120 );
            this.sizeTrackBar.Maximum = 9;
            this.sizeTrackBar.Name = "sizeTrackBar";
            this.sizeTrackBar.Size = new System.Drawing.Size( 260, 45 );
            this.sizeTrackBar.TabIndex = 21;
            this.sizeTrackBar.Value = 1;
            this.sizeTrackBar.ValueChanged += new System.EventHandler( this.sizeTrackBar_ValueChanged );
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point( 60, 90 );
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size( 60, 20 );
            this.sizeBox.TabIndex = 20;
            this.sizeBox.Text = "";
            this.sizeBox.TextChanged += new System.EventHandler( this.sizeBox_TextChanged );
            // 
            // sigmaBox
            // 
            this.sigmaBox.Location = new System.Drawing.Point( 60, 10 );
            this.sigmaBox.Name = "sigmaBox";
            this.sigmaBox.Size = new System.Drawing.Size( 60, 20 );
            this.sigmaBox.TabIndex = 17;
            this.sigmaBox.Text = "";
            this.sigmaBox.TextChanged += new System.EventHandler( this.sigmaBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 10, 93 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 35, 15 );
            this.label2.TabIndex = 19;
            this.label2.Text = "Size:";
            // 
            // sigmaTrackBar
            // 
            this.sigmaTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.sigmaTrackBar.Maximum = 50;
            this.sigmaTrackBar.Name = "sigmaTrackBar";
            this.sigmaTrackBar.Size = new System.Drawing.Size( 260, 45 );
            this.sigmaTrackBar.TabIndex = 18;
            this.sigmaTrackBar.TickFrequency = 2;
            this.sigmaTrackBar.ValueChanged += new System.EventHandler( this.sigmaTrackBar_ValueChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 42, 19 );
            this.label1.TabIndex = 16;
            this.label1.Text = "Sigma:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 178 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 260, 2 );
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // SharpenExForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 464, 226 );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.sizeTrackBar );
            this.Controls.Add( this.sizeBox );
            this.Controls.Add( this.sigmaBox );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.sigmaTrackBar );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpenExForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharpen";
            this.groupBox3.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.sizeTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.sigmaTrackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // Changed value of sigma track bar
        private void sigmaTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            double v = (double) sigmaTrackBar.Value / 20 + 0.5;

            sigmaBox.Text = v.ToString( );
        }

        // Changed value of size track bar
        private void sizeTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            int v = sizeTrackBar.Value * 2 + 3;

            sizeBox.Text = v.ToString( );
        }

        // Sigma changed
        private void sigmaBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.Sigma = double.Parse( sigmaBox.Text );

                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Size changed
        private void sizeBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.Size = int.Parse( sizeBox.Text );

                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
