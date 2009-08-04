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
    /// Summary description for RotateForm.
    /// </summary>
    public class RotateForm : System.Windows.Forms.Form
    {
        private BaseRotateFilter filter = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox angleBox;
        private System.Windows.Forms.ComboBox methodCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox keepSizeCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox redBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox blueBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public RotateForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            angleBox.Text = "45";
            redBox.Text = "0";
            greenBox.Text = "0";
            blueBox.Text = "0";

            methodCombo.SelectedIndex = 1;
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
            this.angleBox = new System.Windows.Forms.TextBox( );
            this.methodCombo = new System.Windows.Forms.ComboBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.keepSizeCheck = new System.Windows.Forms.CheckBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.redBox = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.greenBox = new System.Windows.Forms.TextBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.blueBox = new System.Windows.Forms.TextBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 42, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "&Angle:";
            // 
            // angleBox
            // 
            this.angleBox.Location = new System.Drawing.Point( 100, 10 );
            this.angleBox.Name = "angleBox";
            this.angleBox.TabIndex = 1;
            this.angleBox.Text = "";
            // 
            // methodCombo
            // 
            this.methodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodCombo.Items.AddRange( new object[] {
															 "Nearest neighbour",
															 "Bilinear",
															 "Bicubic"} );
            this.methodCombo.Location = new System.Drawing.Point( 100, 40 );
            this.methodCombo.Name = "methodCombo";
            this.methodCombo.Size = new System.Drawing.Size( 100, 21 );
            this.methodCombo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 10, 43 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 85, 14 );
            this.label3.TabIndex = 2;
            this.label3.Text = "&Interpolation:";
            // 
            // keepSizeCheck
            // 
            this.keepSizeCheck.Location = new System.Drawing.Point( 100, 70 );
            this.keepSizeCheck.Name = "keepSizeCheck";
            this.keepSizeCheck.Size = new System.Drawing.Size( 93, 24 );
            this.keepSizeCheck.TabIndex = 4;
            this.keepSizeCheck.Text = "&Keep size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.greenBox,
																					this.label4,
																					this.redBox,
																					this.label2,
																					this.label5,
																					this.blueBox} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 100 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 190, 50 );
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Fill color";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 5, 23 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 20, 14 );
            this.label2.TabIndex = 0;
            this.label2.Text = "R:";
            // 
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point( 25, 20 );
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size( 35, 20 );
            this.redBox.TabIndex = 1;
            this.redBox.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 68, 23 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 20, 14 );
            this.label4.TabIndex = 2;
            this.label4.Text = "G:";
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point( 87, 20 );
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size( 35, 20 );
            this.greenBox.TabIndex = 3;
            this.greenBox.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 125, 23 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 20, 14 );
            this.label5.TabIndex = 6;
            this.label5.Text = "B:";
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point( 145, 20 );
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size( 35, 20 );
            this.blueBox.TabIndex = 6;
            this.blueBox.Text = "";
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 27, 170 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler( this.okButton_Click );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 112, 170 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            // 
            // RotateForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 214, 205 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox1,
																		  this.keepSizeCheck,
																		  this.methodCombo,
																		  this.label3,
																		  this.angleBox,
																		  this.label1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotate image";
            this.groupBox1.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // On "Ok" button
        private void okButton_Click( object sender, System.EventArgs e )
        {
            try
            {
                // get rotation angle
                double angle = double.Parse( angleBox.Text );

                // create appropriate rotation filter
                switch ( methodCombo.SelectedIndex )
                {
                    case 0:
                        filter = new RotateNearestNeighbor( angle );
                        break;
                    case 1:
                        filter = new RotateBilinear( angle );
                        break;
                    case 2:
                        filter = new RotateBicubic( angle );
                        break;
                }

                // fill color
                filter.FillColor = Color.FromArgb(
                    byte.Parse( redBox.Text ),
                    byte.Parse( greenBox.Text ),
                    byte.Parse( blueBox.Text ) );

                // keep size
                filter.KeepSize = keepSizeCheck.Checked;

                // close dialog
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
