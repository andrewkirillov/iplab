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
    /// Summary description for GammaForm.
    /// </summary>
    public class GammaForm : System.Windows.Forms.Form
    {
        private GammaCorrection filter = new GammaCorrection( );

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gammaBox;
        private System.Windows.Forms.TrackBar gammaTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
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
        public GammaForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            gammaBox.Text = filter.Gamma.ToString( );
            gammaTrackBar.Value = (int) ( filter.Gamma * 1000 );

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
            this.gammaBox = new System.Windows.Forms.TextBox( );
            this.gammaTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.filterPreview = new IPLab.FilterPreview( );
            ( (System.ComponentModel.ISupportInitialize) ( this.gammaTrackBar ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 80, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Gamma value:";
            // 
            // gammaBox
            // 
            this.gammaBox.Location = new System.Drawing.Point( 90, 10 );
            this.gammaBox.Name = "gammaBox";
            this.gammaBox.Size = new System.Drawing.Size( 70, 20 );
            this.gammaBox.TabIndex = 1;
            this.gammaBox.TextChanged += new System.EventHandler( this.gammaBox_TextChanged );
            // 
            // gammaTrackBar
            // 
            this.gammaTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.gammaTrackBar.Maximum = 5000;
            this.gammaTrackBar.Minimum = 100;
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Size = new System.Drawing.Size( 260, 45 );
            this.gammaTrackBar.TabIndex = 2;
            this.gammaTrackBar.TickFrequency = 100;
            this.gammaTrackBar.Value = 1000;
            this.gammaTrackBar.ValueChanged += new System.EventHandler( this.gammaTrackBar_ValueChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 280, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 145, 143 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 55, 143 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 15;
            this.okButton.Text = "&Ok";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 140, 140 );
            this.filterPreview.TabIndex = 12;
            // 
            // GammaForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 449, 178 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.gammaTrackBar );
            this.Controls.Add( this.gammaBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GammaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gamma Correction";
            ( (System.ComponentModel.ISupportInitialize) ( this.gammaTrackBar ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }
        #endregion

        // value of gamma track bar changed
        private void gammaTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            gammaBox.Text = ( (double) gammaTrackBar.Value / 1000 ).ToString( );
        }

        // value of gamma text box changed
        private void gammaBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.Gamma = double.Parse( gammaBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
