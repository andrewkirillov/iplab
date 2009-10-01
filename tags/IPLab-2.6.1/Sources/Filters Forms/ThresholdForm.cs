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
    /// Summary description for ThresholdForm.
    /// </summary>
    public class ThresholdForm : System.Windows.Forms.Form
    {
        private Threshold filter = new Threshold( );
        private byte threshold = 128;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox thresholdBox;
        private AForge.Controls.ColorSlider slider;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox1;
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
        public ThresholdForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            thresholdBox.Text = threshold.ToString( );
            slider.Min = threshold;

            // initial filter values
            filter.ThresholdValue = threshold;

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
            this.thresholdBox = new System.Windows.Forms.TextBox( );
            this.slider = new AForge.Controls.ColorSlider( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 90, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "&Threshold value:";
            // 
            // thresholdBox
            // 
            this.thresholdBox.Location = new System.Drawing.Point( 100, 10 );
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.thresholdBox.TabIndex = 1;
            this.thresholdBox.TextChanged += new System.EventHandler( this.minBox_TextChanged );
            // 
            // slider
            // 
            this.slider.DoubleArrow = false;
            this.slider.Location = new System.Drawing.Point( 8, 40 );
            this.slider.Min = 127;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size( 262, 23 );
            this.slider.TabIndex = 4;
            this.slider.Type = AForge.Controls.ColorSlider.ColorSliderType.Threshold;
            this.slider.ValuesChanged += new System.EventHandler( this.slider_ValuesChanged );
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point( 10, 120 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 57, 140 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 147, 140 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 140, 140 );
            this.filterPreview.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 290, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // ThresholdForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 459, 178 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox2 );
            this.Controls.Add( this.slider );
            this.Controls.Add( this.thresholdBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThresholdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Threshold";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }
        #endregion

        // Min edit box changed
        private void minBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                slider.Min = threshold = byte.Parse( thresholdBox.Text );

                // refresh filter
                filter.ThresholdValue = threshold;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Slider position changed
        private void slider_ValuesChanged( object sender, System.EventArgs e )
        {
            threshold = (byte) slider.Min;
            thresholdBox.Text = threshold.ToString( );
        }
    }
}
