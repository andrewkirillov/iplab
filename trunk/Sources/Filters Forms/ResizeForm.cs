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

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for ResizeForm.
    /// </summary>
    public class ResizeForm : System.Windows.Forms.Form
    {
        private Size originalSize;
        private BaseResizeFilter filter = null;
        private bool updating = false;

        private System.Windows.Forms.RadioButton factorButton;
        private System.Windows.Forms.TextBox factorBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton sizeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox methodCombo;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox ratioCheck;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // OriginalSize property
        public Size OriginalSize
        {
            get { return originalSize; }
            set { originalSize = value; }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public ResizeForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );
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
            this.factorButton = new System.Windows.Forms.RadioButton( );
            this.factorBox = new System.Windows.Forms.TextBox( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.sizeButton = new System.Windows.Forms.RadioButton( );
            this.label1 = new System.Windows.Forms.Label( );
            this.widthBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.heightBox = new System.Windows.Forms.TextBox( );
            this.ratioCheck = new System.Windows.Forms.CheckBox( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.methodCombo = new System.Windows.Forms.ComboBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.SuspendLayout( );
            // 
            // factorButton
            // 
            this.factorButton.Checked = true;
            this.factorButton.Location = new System.Drawing.Point( 10, 10 );
            this.factorButton.Name = "factorButton";
            this.factorButton.Size = new System.Drawing.Size( 100, 20 );
            this.factorButton.TabIndex = 0;
            this.factorButton.TabStop = true;
            this.factorButton.Text = "Resize &factor:";
            this.factorButton.CheckedChanged += new System.EventHandler( this.factorButton_CheckedChanged );
            // 
            // factorBox
            // 
            this.factorBox.Location = new System.Drawing.Point( 100, 10 );
            this.factorBox.Name = "factorBox";
            this.factorBox.TabIndex = 1;
            this.factorBox.Text = "";
            this.factorBox.TextChanged += new System.EventHandler( this.factorBox_TextChanged );
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 40 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 190, 2 );
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // sizeButton
            // 
            this.sizeButton.Location = new System.Drawing.Point( 10, 50 );
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size( 100, 20 );
            this.sizeButton.TabIndex = 2;
            this.sizeButton.Text = "Resize to &size";
            this.sizeButton.CheckedChanged += new System.EventHandler( this.sizeButton_CheckedChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 30, 78 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 44, 14 );
            this.label1.TabIndex = 3;
            this.label1.Text = "&Width:";
            // 
            // widthBox
            // 
            this.widthBox.Enabled = false;
            this.widthBox.Location = new System.Drawing.Point( 100, 75 );
            this.widthBox.Name = "widthBox";
            this.widthBox.TabIndex = 4;
            this.widthBox.Text = "";
            this.widthBox.TextChanged += new System.EventHandler( this.widthBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 30, 103 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 60, 14 );
            this.label2.TabIndex = 5;
            this.label2.Text = "&Height:";
            // 
            // heightBox
            // 
            this.heightBox.Enabled = false;
            this.heightBox.Location = new System.Drawing.Point( 100, 100 );
            this.heightBox.Name = "heightBox";
            this.heightBox.TabIndex = 6;
            this.heightBox.Text = "";
            this.heightBox.TextChanged += new System.EventHandler( this.heightBox_TextChanged );
            // 
            // ratioCheck
            // 
            this.ratioCheck.Checked = true;
            this.ratioCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ratioCheck.Enabled = false;
            this.ratioCheck.Location = new System.Drawing.Point( 30, 130 );
            this.ratioCheck.Name = "ratioCheck";
            this.ratioCheck.Size = new System.Drawing.Size( 150, 20 );
            this.ratioCheck.TabIndex = 7;
            this.ratioCheck.Text = "&Keep aspect ratio";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point( 10, 155 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 190, 2 );
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 10, 168 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 85, 14 );
            this.label3.TabIndex = 8;
            this.label3.Text = "&Interpolation:";
            // 
            // methodCombo
            // 
            this.methodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodCombo.Items.AddRange( new object[] {
															 "Nearest neighbour",
															 "Bilinear",
															 "Bicubic"} );
            this.methodCombo.Location = new System.Drawing.Point( 100, 165 );
            this.methodCombo.Name = "methodCombo";
            this.methodCombo.Size = new System.Drawing.Size( 100, 21 );
            this.methodCombo.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 25, 205 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler( this.okButton_Click );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 115, 205 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // ResizeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 214, 238 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.methodCombo,
																		  this.label3,
																		  this.pictureBox2,
																		  this.ratioCheck,
																		  this.heightBox,
																		  this.label2,
																		  this.widthBox,
																		  this.label1,
																		  this.sizeButton,
																		  this.pictureBox1,
																		  this.factorBox,
																		  this.factorButton} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resize image";
            this.Load += new System.EventHandler( this.ResizeForm_Load );
            this.ResumeLayout( false );

        }
        #endregion

        // On form load
        private void ResizeForm_Load( object sender, System.EventArgs e )
        {
            // default resize factor
            factorBox.Text = "2";

            // width & height
            widthBox.Text = ( originalSize.Width * 2 ).ToString( );
            heightBox.Text = ( originalSize.Height * 2 ).ToString( );

            methodCombo.SelectedIndex = 1;
        }

        // On size radio button checked state changed
        private void sizeButton_CheckedChanged( object sender, System.EventArgs e )
        {
            bool enable = sizeButton.Checked;

            widthBox.Enabled = enable;
            heightBox.Enabled = enable;
            ratioCheck.Enabled = enable;
        }

        // On factor radio button checked state changed
        private void factorButton_CheckedChanged( object sender, System.EventArgs e )
        {
            factorBox.Enabled = factorButton.Checked;
        }

        // On factor changed
        private void factorBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                float factor = float.Parse( factorBox.Text );

                updating = true;
                widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * originalSize.Width ) ) ).ToString( );
                heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( factor * originalSize.Height ) ) ).ToString( );
                updating = false;
            }
            catch ( Exception )
            {
            }
        }

        // On width changed
        private void widthBox_TextChanged( object sender, System.EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int width = int.Parse( widthBox.Text );

                    updating = true;
                    heightBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( width * originalSize.Height / originalSize.Width ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On height changed
        private void heightBox_TextChanged( object sender, System.EventArgs e )
        {
            if ( ( !updating ) && ( ratioCheck.Checked ) )
            {
                try
                {
                    int height = int.Parse( heightBox.Text );

                    updating = true;
                    widthBox.Text = Math.Max( 1, Math.Min( 5000, (int) ( height * originalSize.Width / originalSize.Height ) ) ).ToString( );
                    updating = false;
                }
                catch ( Exception )
                {
                }
            }
        }

        // On "Ok" button
        private void okButton_Click( object sender, System.EventArgs e )
        {
            try
            {
                // get new image size
                int width = Math.Max( 1, Math.Min( 5000, int.Parse( widthBox.Text ) ) );
                int height = Math.Max( 1, Math.Min( 5000, int.Parse( heightBox.Text ) ) );

                // create appropriate filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new ResizeNearestNeighbor( width, height );
                        break;
                    case 1:
                        filter = new ResizeBilinear( width, height );
                        break;
                    case 2:
                        filter = new ResizeBicubic( width, height );
                        break;
                }

                // close the dialog
                this.DialogResult = DialogResult.OK;
                this.Close( );
            }
            catch ( Exception )
            {
                MessageBox.Show( this, "Incorrect values are entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
