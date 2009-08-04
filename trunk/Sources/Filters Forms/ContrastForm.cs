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
    /// Summary description for ContrastForm.
    /// </summary>
    public class ContrastForm : System.Windows.Forms.Form
    {
        private ContrastCorrection filter = new ContrastCorrection( );
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox contrastBox;
        private System.Windows.Forms.TrackBar contrastTrackBar;
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
        public ContrastForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            contrastBox.Text = filter.Factor.ToString( );
            contrastTrackBar.Value = (int) ( filter.Factor * 1000 );

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
            this.contrastBox = new System.Windows.Forms.TextBox( );
            this.contrastTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            ( (System.ComponentModel.ISupportInitialize) ( this.contrastTrackBar ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 100, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Contrast factor:";
            // 
            // contrastBox
            // 
            this.contrastBox.Location = new System.Drawing.Point( 110, 10 );
            this.contrastBox.Name = "contrastBox";
            this.contrastBox.Size = new System.Drawing.Size( 50, 20 );
            this.contrastBox.TabIndex = 1;
            this.contrastBox.Text = "";
            this.contrastBox.TextChanged += new System.EventHandler( this.contrastBox_TextChanged );
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.contrastTrackBar.Maximum = 5000;
            this.contrastTrackBar.Minimum = 1;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size( 250, 42 );
            this.contrastTrackBar.TabIndex = 17;
            this.contrastTrackBar.TickFrequency = 200;
            this.contrastTrackBar.Value = 1;
            this.contrastTrackBar.ValueChanged += new System.EventHandler( this.contrastTrackBar_ValueChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox1.Location = new System.Drawing.Point( 270, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox1.TabIndex = 18;
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
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 150, 143 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 60, 143 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 19;
            this.okButton.Text = "&Ok";
            // 
            // ContrastForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 439, 178 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox1,
																		  this.contrastTrackBar,
																		  this.contrastBox,
																		  this.label1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContrastForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contrast";
            ( (System.ComponentModel.ISupportInitialize) ( this.contrastTrackBar ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // value of contrast track bar changed
        private void contrastTrackBar_ValueChanged( object sender, System.EventArgs e )
        {
            contrastBox.Text = ( (double) contrastTrackBar.Value / 1000 ).ToString( );
        }

        // value of contrast text box changed
        private void contrastBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                filter.Factor = double.Parse( contrastBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
