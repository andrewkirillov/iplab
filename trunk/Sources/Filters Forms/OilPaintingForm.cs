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
    /// Summary description for OilPaintingForm.
    /// </summary>
    public class OilPaintingForm : System.Windows.Forms.Form
    {
        private OilPainting filter = new OilPainting( 7 );
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.Label label1;
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
        public OilPaintingForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            trackBar.Value = ( filter.BrushSize - 3 ) / 2;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.trackBar = new System.Windows.Forms.TrackBar( );
            this.sizeBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.trackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 120, 160 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 35, 160 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 12;
            this.okButton.Text = "Ok";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 150 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 210, 2 );
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 230, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point( 10, 45 );
            this.trackBar.Maximum = 9;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size( 200, 45 );
            this.trackBar.TabIndex = 9;
            this.trackBar.ValueChanged += new System.EventHandler( this.trackBar_ValueChanged );
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point( 70, 15 );
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.ReadOnly = true;
            this.sizeBox.TabIndex = 8;
            this.sizeBox.TabStop = false;
            this.sizeBox.Text = "";
            this.sizeBox.TextChanged += new System.EventHandler( this.sizeBox_TextChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 60, 14 );
            this.label1.TabIndex = 7;
            this.label1.Text = "Brush size:";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 14;
            this.filterPreview.TabStop = false;
            // 
            // OilPaintingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 409, 193 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.trackBar );
            this.Controls.Add( this.sizeBox );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OilPaintingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oil Painting";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.trackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }
        #endregion

        // Size track bar changed
        private void trackBar_ValueChanged( object sender, System.EventArgs e )
        {
            int v = trackBar.Value * 2 + 3;
            sizeBox.Text = v.ToString( );
        }

        // Brush size changed
        private void sizeBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.BrushSize = int.Parse( sizeBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
