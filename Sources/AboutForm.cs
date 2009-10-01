using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IPLab
{
    /// <summary>
    /// Summary description for AboutForm.
    /// </summary>
    public class AboutForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel mailLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Label label3;
        private LinkLabel aforgeLabel;
        private LinkLabel iplabLabel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public AboutForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            mailLabel.Links.Add( 0, mailLabel.Text.Length, "mailto:andrew.kirillov@aforgenet.com" );
            aforgeLabel.Links.Add( 0, aforgeLabel.Text.Length, "http://www.aforgenet.com/framework/" );
            iplabLabel.Links.Add( 0, iplabLabel.Text.Length, "http://www.aforgenet.com/projects/iplab/" );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutForm ) );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.mailLabel = new System.Windows.Forms.LinkLabel( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.aforgeLabel = new System.Windows.Forms.LinkLabel( );
            this.iplabLabel = new System.Windows.Forms.LinkLabel( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 15, 210 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 344, 2 );
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 150, 220 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Ok";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 103, 60 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 168, 24 );
            this.label1.TabIndex = 12;
            this.label1.Text = "Image Processing Lab v.2.6.1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 81, 115 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 212, 16 );
            this.label2.TabIndex = 13;
            this.label2.Text = "Copyright © 2005-2009, Andrew Kirillov";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mailLabel
            // 
            this.mailLabel.ActiveLinkColor = System.Drawing.Color.MediumBlue;
            this.mailLabel.LinkColor = System.Drawing.Color.MediumBlue;
            this.mailLabel.Location = new System.Drawing.Point( 102, 130 );
            this.mailLabel.Name = "mailLabel";
            this.mailLabel.Size = new System.Drawing.Size( 171, 23 );
            this.mailLabel.TabIndex = 14;
            this.mailLabel.TabStop = true;
            this.mailLabel.Text = "andrew.kirillov@aforgenet.com";
            this.mailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mailLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.label_LinkClicked );
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ( (System.Drawing.Image) ( resources.GetObject( "pictureBox2.Image" ) ) );
            this.pictureBox2.Location = new System.Drawing.Point( 0, -1 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 376, 56 );
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 104, 165 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 166, 13 );
            this.label3.TabIndex = 16;
            this.label3.Text = "Based on AForge.NET framework";
            // 
            // aforgeLabel
            // 
            this.aforgeLabel.AutoSize = true;
            this.aforgeLabel.Location = new System.Drawing.Point( 91, 180 );
            this.aforgeLabel.Name = "aforgeLabel";
            this.aforgeLabel.Size = new System.Drawing.Size( 192, 13 );
            this.aforgeLabel.TabIndex = 17;
            this.aforgeLabel.TabStop = true;
            this.aforgeLabel.Text = "http://www.aforgenet.com/framework/";
            this.aforgeLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.label_LinkClicked );
            // 
            // iplabLabel
            // 
            this.iplabLabel.AutoSize = true;
            this.iplabLabel.Location = new System.Drawing.Point( 84, 75 );
            this.iplabLabel.Name = "iplabLabel";
            this.iplabLabel.Size = new System.Drawing.Size( 207, 13 );
            this.iplabLabel.TabIndex = 18;
            this.iplabLabel.TabStop = true;
            this.iplabLabel.Text = "http://www.aforgenet.com/projects/iplab/";
            this.iplabLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.label_LinkClicked );
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size( 374, 253 );
            this.Controls.Add( this.iplabLabel );
            this.Controls.Add( this.aforgeLabel );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.pictureBox2 );
            this.Controls.Add( this.mailLabel );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }
        #endregion

        // On URL label click
        private void label_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            System.Diagnostics.Process.Start( e.Link.LinkData.ToString( ) );
        }
    }
}
