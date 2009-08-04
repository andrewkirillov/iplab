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
    /// Summary description for MorphPhorm.
    /// </summary>
    public class MorphForm : System.Windows.Forms.Form
    {
        private Morph filter;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.TrackBar percentageBar;
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
        public MorphForm( Bitmap overlay )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // create filter
            filter = new Morph( overlay );
            // set percent value on track bar
            percentageBar.Value = (int) ( filter.SourcePercent * 100 );
            // set filter for preview window
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
            this.percentageBar = new System.Windows.Forms.TrackBar( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            ( (System.ComponentModel.ISupportInitialize) ( this.percentageBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 10 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 110, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Source percentage:";
            // 
            // percentageBar
            // 
            this.percentageBar.Location = new System.Drawing.Point( 8, 35 );
            this.percentageBar.Maximum = 100;
            this.percentageBar.Minimum = 1;
            this.percentageBar.Name = "percentageBar";
            this.percentageBar.Size = new System.Drawing.Size( 220, 45 );
            this.percentageBar.TabIndex = 1;
            this.percentageBar.TickFrequency = 3;
            this.percentageBar.Value = 1;
            this.percentageBar.ValueChanged += new System.EventHandler( this.percentageBar_ValueChanged );
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 182 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 210, 2 );
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 209, 195 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 124, 195 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 12;
            this.okButton.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 230, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // MorphForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.ClientSize = new System.Drawing.Size( 409, 226 );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.percentageBar );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MorphForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morphing";
            ( (System.ComponentModel.ISupportInitialize) ( this.percentageBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // Value changed of percentage scroll bar
        private void percentageBar_ValueChanged( object sender, System.EventArgs e )
        {
            filter.SourcePercent = (double) percentageBar.Value / 100.0;
            filterPreview.RefreshFilter( );
        }
    }
}
