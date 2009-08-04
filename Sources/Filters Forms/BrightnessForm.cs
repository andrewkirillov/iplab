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
    /// Summary description for BrightnessForm.
    /// </summary>
    public class BrightnessForm : System.Windows.Forms.Form
    {
        private BrightnessCorrection filter = new BrightnessCorrection( );
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox brightnessBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
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
        public BrightnessForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            brightnessBox.Text = filter.AdjustValue.ToString( );
            brightnessTrackBar.Value = (int) ( filter.AdjustValue * 1000 );

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
            this.brightnessBox = new System.Windows.Forms.TextBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.brightnessTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 110, 16 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Adjust brightness by:";
            // 
            // brightnessBox
            // 
            this.brightnessBox.Location = new System.Drawing.Point( 115, 10 );
            this.brightnessBox.Name = "brightnessBox";
            this.brightnessBox.Size = new System.Drawing.Size( 50, 20 );
            this.brightnessBox.TabIndex = 1;
            this.brightnessBox.Text = "";
            this.brightnessBox.TextChanged += new System.EventHandler( this.brightnessBox_TextChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 270, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 140, 140 );
            this.filterPreview.TabIndex = 12;
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.brightnessTrackBar.Maximum = 1000;
            this.brightnessTrackBar.Minimum = -1000;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size( 250, 42 );
            this.brightnessTrackBar.TabIndex = 16;
            this.brightnessTrackBar.TickFrequency = 50;
            this.brightnessTrackBar.ValueChanged += new System.EventHandler( this.brightnessTrackBar_ValueChanged );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 150, 143 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 60, 143 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 17;
            this.okButton.Text = "&Ok";
            // 
            // BrightnessForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 439, 178 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.brightnessTrackBar );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.brightnessBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrightnessForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brightness";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.brightnessTrackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // value of brightness track bar changed
        private void brightnessTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            brightnessBox.Text = ( (double) brightnessTrackBar.Value / 1000 ).ToString( );
        }

        // value of brightness text box changed
        private void brightnessBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.AdjustValue = double.Parse( brightnessBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
