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
    /// Summary description for HueModifierForm.
    /// </summary>
    public class HueModifierForm : System.Windows.Forms.Form
    {
        private HueModifier filter = new HueModifier( );

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.TextBox hueBox;
        private IPLab.HuePicker huePicker;
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
        public HueModifierForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            hueBox.Text = filter.Hue.ToString( );
            huePicker.Min = filter.Hue;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.huePicker = new IPLab.HuePicker( );
            this.hueBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.huePicker,
																					this.hueBox,
																					this.label1} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 195, 225 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Hue Value";
            // 
            // huePicker
            // 
            this.huePicker.Location = new System.Drawing.Point( 10, 45 );
            this.huePicker.Name = "huePicker";
            this.huePicker.Size = new System.Drawing.Size( 170, 170 );
            this.huePicker.TabIndex = 2;
            this.huePicker.TabStop = false;
            this.huePicker.ValuesChanged += new System.EventHandler( this.huePicker_ValuesChanged );
            // 
            // hueBox
            // 
            this.hueBox.Location = new System.Drawing.Point( 45, 20 );
            this.hueBox.Name = "hueBox";
            this.hueBox.TabIndex = 1;
            this.hueBox.Text = "";
            this.hueBox.TextChanged += new System.EventHandler( this.hueBox_TextChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 30, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "&Hue:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox2.Location = new System.Drawing.Point( 215, 5 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 140, 140 );
            this.filterPreview.TabIndex = 12;
            this.filterPreview.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 300, 205 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 215, 205 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&Ok";
            // 
            // HueModifierForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 384, 238 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox2,
																		  this.groupBox1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HueModifierForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hue Modifier";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // hue picker's value changed
        private void huePicker_ValuesChanged( object sender, System.EventArgs e )
        {
            hueBox.Text = huePicker.Min.ToString( );
        }

        // Hue changed
        private void hueBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                huePicker.Min = filter.Hue = int.Parse( hueBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}
