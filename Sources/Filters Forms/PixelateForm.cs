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
    /// Summary description for PixelateForm.
    /// </summary>
    public class PixelateForm : System.Windows.Forms.Form
    {
        private Pixellate filter = new Pixellate( 8 );

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TrackBar widthTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TrackBar heightTrackBar;
        private System.Windows.Forms.CheckBox syncCheck;
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
        public PixelateForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            widthBox.Text = filter.PixelWidth.ToString( );
            heightBox.Text = filter.PixelHeight.ToString( );

            widthTrackBar.Value = filter.PixelWidth;
            heightTrackBar.Value = filter.PixelHeight;

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
            this.widthBox = new System.Windows.Forms.TextBox( );
            this.widthTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.label2 = new System.Windows.Forms.Label( );
            this.heightBox = new System.Windows.Forms.TextBox( );
            this.heightTrackBar = new System.Windows.Forms.TrackBar( );
            this.syncCheck = new System.Windows.Forms.CheckBox( );
            ( (System.ComponentModel.ISupportInitialize) ( this.widthTrackBar ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.heightTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 65, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Pixel Width:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point( 80, 15 );
            this.widthBox.Name = "widthBox";
            this.widthBox.ReadOnly = true;
            this.widthBox.Size = new System.Drawing.Size( 50, 20 );
            this.widthBox.TabIndex = 1;
            this.widthBox.TabStop = false;
            this.widthBox.Text = "";
            this.widthBox.TextChanged += new System.EventHandler( this.sizeBox_TextChanged );
            // 
            // widthTrackBar
            // 
            this.widthTrackBar.Location = new System.Drawing.Point( 10, 42 );
            this.widthTrackBar.Maximum = 32;
            this.widthTrackBar.Minimum = 2;
            this.widthTrackBar.Name = "widthTrackBar";
            this.widthTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.widthTrackBar.TabIndex = 2;
            this.widthTrackBar.Value = 2;
            this.widthTrackBar.Scroll += new System.EventHandler( this.widthTrackBar_Scroll );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 230, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 3;
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
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 182 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 210, 2 );
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 124, 195 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 209, 195 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 10, 98 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 70, 16 );
            this.label2.TabIndex = 7;
            this.label2.Text = "Pixel Height:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point( 80, 95 );
            this.heightBox.Name = "heightBox";
            this.heightBox.ReadOnly = true;
            this.heightBox.Size = new System.Drawing.Size( 50, 20 );
            this.heightBox.TabIndex = 8;
            this.heightBox.TabStop = false;
            this.heightBox.Text = "";
            this.heightBox.TextChanged += new System.EventHandler( this.heightBox_TextChanged );
            // 
            // heightTrackBar
            // 
            this.heightTrackBar.Location = new System.Drawing.Point( 10, 122 );
            this.heightTrackBar.Maximum = 32;
            this.heightTrackBar.Minimum = 2;
            this.heightTrackBar.Name = "heightTrackBar";
            this.heightTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.heightTrackBar.TabIndex = 9;
            this.heightTrackBar.Value = 2;
            this.heightTrackBar.Scroll += new System.EventHandler( this.heightTrackBar_Scroll );
            // 
            // syncCheck
            // 
            this.syncCheck.Checked = true;
            this.syncCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syncCheck.Location = new System.Drawing.Point( 160, 15 );
            this.syncCheck.Name = "syncCheck";
            this.syncCheck.Size = new System.Drawing.Size( 55, 24 );
            this.syncCheck.TabIndex = 10;
            this.syncCheck.Text = "Sync";
            // 
            // PixelateForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 409, 226 );
            this.Controls.Add( this.syncCheck );
            this.Controls.Add( this.heightTrackBar );
            this.Controls.Add( this.heightBox );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.widthTrackBar );
            this.Controls.Add( this.widthBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PixelateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixelate";
            ( (System.ComponentModel.ISupportInitialize) ( this.widthTrackBar ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.heightTrackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // Pixel width changed
        private void sizeBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.PixelWidth = int.Parse( widthBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Width trackbar scrolled
        private void widthTrackBar_Scroll( object sender, System.EventArgs e )
        {
            widthBox.Text = widthTrackBar.Value.ToString( );
            if ( syncCheck.Checked )
            {
                heightTrackBar.Value = widthTrackBar.Value;
                heightBox.Text = widthBox.Text;
            }
        }

        // Pixel height changed
        private void heightBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.PixelHeight = int.Parse( heightBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Height trackbar scrolled
        private void heightTrackBar_Scroll( object sender, System.EventArgs e )
        {
            heightBox.Text = heightTrackBar.Value.ToString( );
            if ( syncCheck.Checked )
            {
                widthTrackBar.Value = heightTrackBar.Value;
                widthBox.Text = heightBox.Text;
            }
        }
    }
}
