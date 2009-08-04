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
    /// Summary description for ShrinkForm.
    /// </summary>
    public class ShrinkForm : System.Windows.Forms.Form
    {
        private Shrink filter = new Shrink( );

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox redBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.Label label4;
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
        public ShrinkForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            redBox.Text = "0";
            greenBox.Text = "0";
            blueBox.Text = "0";
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
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.redBox = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.greenBox = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.blueBox = new System.Windows.Forms.TextBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point( 10, 50 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 230, 40 );
            this.label1.TabIndex = 0;
            this.label1.Text = "The image will be shrinked by removing pixels with specified color from it`s bord" +
                "ers.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.blueBox,
																					this.label4,
																					this.greenBox,
																					this.label3,
																					this.redBox,
																					this.label2,
																					this.label1} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 250, 100 );
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color to remove";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 10, 23 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 20, 14 );
            this.label2.TabIndex = 0;
            this.label2.Text = "R:";
            // 
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point( 30, 20 );
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size( 50, 20 );
            this.redBox.TabIndex = 1;
            this.redBox.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 90, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 20, 14 );
            this.label3.TabIndex = 2;
            this.label3.Text = "G:";
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point( 110, 20 );
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size( 50, 20 );
            this.greenBox.TabIndex = 3;
            this.greenBox.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 170, 23 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 20, 14 );
            this.label4.TabIndex = 4;
            this.label4.Text = "B:";
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point( 190, 20 );
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size( 50, 20 );
            this.blueBox.TabIndex = 5;
            this.blueBox.Text = "";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 53, 125 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler( this.okButton_Click );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 143, 125 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            // 
            // ShrinkForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 271, 158 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShrinkForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shrink image";
            this.groupBox1.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // On "Ok" button
        private void okButton_Click( object sender, System.EventArgs e )
        {
            try
            {
                filter.ColorToRemove = Color.FromArgb(
                    byte.Parse( redBox.Text ),
                    byte.Parse( greenBox.Text ),
                    byte.Parse( blueBox.Text ) );
            }
            catch ( Exception )
            {
            }
        }
    }
}
