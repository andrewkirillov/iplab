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
    /// Summary description for AdaptiveSmoothForm.
    /// </summary>
    public class AdaptiveSmoothForm : System.Windows.Forms.Form
    {
        private AdaptiveSmoothing filter = new AdaptiveSmoothing( 1.0 );
        private double factor = 1.0;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox factorBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private IPLab.FilterPreview filterPreview;
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
        public AdaptiveSmoothForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            factorBox.Text = factor.ToString( );
            trackBar.Value = (int) factor * 10;

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
            this.label1 = new System.Windows.Forms.Label( );
            this.factorBox = new System.Windows.Forms.TextBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.trackBar = new System.Windows.Forms.TrackBar( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.trackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 50, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Factor:";
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point( 60, 15 );
            this.factorBox.Name = "factorBox";
            this.factorBox.Size = new System.Drawing.Size( 50, 20 );
            this.factorBox.TabIndex = 1;
            this.factorBox.Text = "";
            this.factorBox.TextChanged += new System.EventHandler( this.factorBox_TextChanged );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 120, 160 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 35, 160 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 230, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point( 10, 45 );
            this.trackBar.Maximum = 100;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size( 200, 45 );
            this.trackBar.TabIndex = 7;
            this.trackBar.TickFrequency = 5;
            this.trackBar.Value = 2;
            this.trackBar.ValueChanged += new System.EventHandler( this.trackBar_ValueChanged );
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 150 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 210, 2 );
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 13;
            // 
            // AdaptiveSmoothForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 409, 193 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.trackBar );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.factorBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdaptiveSmoothForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptive Smooth";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.trackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // Factor changed
        private void factorBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                factor = Math.Max( 0.1f, Math.Min( 10.0f, double.Parse( factorBox.Text ) ) );

                filter.Factor = factor;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Trackbar scrolled
        private void trackBar_ValueChanged( object sender, System.EventArgs e )
        {
            factorBox.Text = ( (double) trackBar.Value / 10 ).ToString( );
        }
    }
}
