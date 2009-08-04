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

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for YCbCrLinearForm.
    /// </summary>
    public class YCbCrLinearForm : System.Windows.Forms.Form
    {
        private YCbCrLinear filter = new YCbCrLinear( );
        private DoubleRange inY = new DoubleRange( 0, 1 );
        private DoubleRange inCb = new DoubleRange( -0.5, 0.5 );
        private DoubleRange inCr = new DoubleRange( -0.5, 0.5 );
        private DoubleRange outY = new DoubleRange( 0, 1 );
        private DoubleRange outCb = new DoubleRange( -0.5, 0.5 );
        private DoubleRange outCr = new DoubleRange( -0.5, 0.5 );
        private AForge.Imaging.ImageStatisticsYCbCr imgStat;

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private IPLab.FilterPreview filterPreview;
        private AForge.Controls.ColorSlider outSlider;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox outMaxBox;
        private System.Windows.Forms.TextBox outMinBox;
        private System.Windows.Forms.Label label3;
        private AForge.Controls.ColorSlider inSlider;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AForge.Controls.Histogram histogram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inMinBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inMaxBox;
        private System.Windows.Forms.ComboBox componentCombo;
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
        public YCbCrLinearForm( AForge.Imaging.ImageStatisticsYCbCr imgStat )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            this.imgStat = imgStat;

            componentCombo.SelectedIndex = 0;

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
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.outSlider = new AForge.Controls.ColorSlider( );
            this.pictureBox3 = new System.Windows.Forms.PictureBox( );
            this.outMaxBox = new System.Windows.Forms.TextBox( );
            this.outMinBox = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.inSlider = new AForge.Controls.ColorSlider( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.histogram = new AForge.Controls.Histogram( );
            this.label2 = new System.Windows.Forms.Label( );
            this.inMinBox = new System.Windows.Forms.TextBox( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.inMaxBox = new System.Windows.Forms.TextBox( );
            this.componentCombo = new System.Windows.Forms.ComboBox( );
            this.groupBox4.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 385, 300 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 42;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 295, 300 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 41;
            this.okButton.Text = "Ok";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox4.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Preview";
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
            // outSlider
            // 
            this.outSlider.Location = new System.Drawing.Point( 8, 295 );
            this.outSlider.Name = "outSlider";
            this.outSlider.Size = new System.Drawing.Size( 262, 20 );
            this.outSlider.TabIndex = 39;
            this.outSlider.TabStop = false;
            this.outSlider.ValuesChanged += new System.EventHandler( this.outSlider_ValuesChanged );
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point( 10, 323 );
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // outMaxBox
            // 
            this.outMaxBox.Location = new System.Drawing.Point( 140, 270 );
            this.outMaxBox.Name = "outMaxBox";
            this.outMaxBox.Size = new System.Drawing.Size( 50, 20 );
            this.outMaxBox.TabIndex = 37;
            this.outMaxBox.Text = "";
            this.outMaxBox.TextChanged += new System.EventHandler( this.outMaxBox_TextChanged );
            // 
            // outMinBox
            // 
            this.outMinBox.Location = new System.Drawing.Point( 80, 270 );
            this.outMinBox.Name = "outMinBox";
            this.outMinBox.Size = new System.Drawing.Size( 50, 20 );
            this.outMinBox.TabIndex = 36;
            this.outMinBox.Text = "";
            this.outMinBox.TextChanged += new System.EventHandler( this.outMinBox_TextChanged );
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 10, 273 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 73, 17 );
            this.label3.TabIndex = 35;
            this.label3.Text = "&Output levels:";
            // 
            // inSlider
            // 
            this.inSlider.Location = new System.Drawing.Point( 8, 232 );
            this.inSlider.Max = 253;
            this.inSlider.Min = 2;
            this.inSlider.Name = "inSlider";
            this.inSlider.Size = new System.Drawing.Size( 262, 20 );
            this.inSlider.TabIndex = 34;
            this.inSlider.TabStop = false;
            this.inSlider.ValuesChanged += new System.EventHandler( this.inSlider_ValuesChanged );
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point( 10, 260 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point( 10, 75 );
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size( 258, 162 );
            this.histogram.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 10, 53 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 65, 17 );
            this.label2.TabIndex = 29;
            this.label2.Text = "&Input levels:";
            // 
            // inMinBox
            // 
            this.inMinBox.Location = new System.Drawing.Point( 80, 50 );
            this.inMinBox.Name = "inMinBox";
            this.inMinBox.Size = new System.Drawing.Size( 50, 20 );
            this.inMinBox.TabIndex = 30;
            this.inMinBox.Text = "";
            this.inMinBox.TextChanged += new System.EventHandler( this.inMinBox_TextChanged );
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 40 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 70, 15 );
            this.label1.TabIndex = 26;
            this.label1.Text = "Component:";
            // 
            // inMaxBox
            // 
            this.inMaxBox.Location = new System.Drawing.Point( 140, 50 );
            this.inMaxBox.Name = "inMaxBox";
            this.inMaxBox.Size = new System.Drawing.Size( 50, 20 );
            this.inMaxBox.TabIndex = 31;
            this.inMaxBox.Text = "";
            this.inMaxBox.TextChanged += new System.EventHandler( this.inMaxBox_TextChanged );
            // 
            // componentCombo
            // 
            this.componentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.componentCombo.Items.AddRange( new object[] {
																"Y Channel",
																"Cb Channel",
																"Cr Channel"} );
            this.componentCombo.Location = new System.Drawing.Point( 80, 10 );
            this.componentCombo.Name = "componentCombo";
            this.componentCombo.Size = new System.Drawing.Size( 90, 21 );
            this.componentCombo.TabIndex = 27;
            this.componentCombo.SelectedIndexChanged += new System.EventHandler( this.componentCombo_SelectedIndexChanged );
            // 
            // YCbCrLinearForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 469, 333 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox4,
																		  this.outSlider,
																		  this.pictureBox3,
																		  this.outMaxBox,
																		  this.outMinBox,
																		  this.label3,
																		  this.inSlider,
																		  this.pictureBox2,
																		  this.histogram,
																		  this.label2,
																		  this.inMinBox,
																		  this.pictureBox1,
																		  this.label1,
																		  this.inMaxBox,
																		  this.componentCombo} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YCbCrLinearForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YCbCr Linear Correction";
            this.groupBox4.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Selection changed in component combo
        private void componentCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            AForge.Math.ContinuousHistogram h = null;
            DoubleRange input = new DoubleRange( 0, 1 );
            DoubleRange output = new DoubleRange( 0, 1 );
            double start = 0;

            switch ( componentCombo.SelectedIndex )
            {
                case 0:
                    // Y
                    h = imgStat.Y;
                    input = inY;
                    output = outY;
                    break;

                case 1:
                    // Cb
                    h = imgStat.Cb;
                    input = inCb;
                    output = outCb;
                    start = -0.5;
                    break;

                case 2:
                    // Cr
                    h = imgStat.Cr;
                    input = inCr;
                    output = outCr;
                    start = -0.5;
                    break;
            }

            histogram.Values = h.Values;

            inMinBox.Text = input.Min.ToString( "F3" );
            inMaxBox.Text = input.Max.ToString( "F3" );
            outMinBox.Text = output.Min.ToString( "F3" );
            outMaxBox.Text = output.Max.ToString( "F3" );

            // input slider
            inSlider.Min = (int) ( ( input.Min - start ) * 255 );
            inSlider.Max = (int) ( ( input.Max - start ) * 255 );
            // output slider
            outSlider.Min = (int) ( ( output.Min - start ) * 255 );
            outSlider.Max = (int) ( ( output.Max - start ) * 255 );
        }

        // inMin changed
        private void inMinBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( inMinBox.Text );
                double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

                switch ( componentCombo.SelectedIndex )
                {
                    case 0:	// Y
                        inY.Min = Math.Max( 0.0, Math.Min( 1.0, v ) );
                        break;
                    case 1:	// Cb
                        inCb.Min = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                    case 2:	// Cr
                        inCr.Min = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                }
                inSlider.Min = (int) ( ( v - start ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // inMax changed
        private void inMaxBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( inMaxBox.Text );
                double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

                switch ( componentCombo.SelectedIndex )
                {
                    case 0:	// Y
                        inY.Max = Math.Max( 0.0, Math.Min( 1.0, v ) );
                        break;
                    case 1:	// Cb
                        inCb.Max = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                    case 2:	// Cr
                        inCr.Max = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                }
                inSlider.Max = (int) ( ( v - start ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // outMin changed
        private void outMinBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( outMinBox.Text );
                double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

                switch ( componentCombo.SelectedIndex )
                {
                    case 0:	// Y
                        outY.Min = Math.Max( 0.0, Math.Min( 1.0, v ) );
                        break;
                    case 1:	// Cb
                        outCb.Min = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                    case 2:	// Cr
                        outCr.Min = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                }
                outSlider.Min = (int) ( ( v - start ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // outMax changed
        private void outMaxBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                double v = double.Parse( outMaxBox.Text );
                double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

                switch ( componentCombo.SelectedIndex )
                {
                    case 0:	// Y
                        outY.Max = Math.Max( 0.0, Math.Min( 1.0, v ) );
                        break;
                    case 1:	// Cb
                        outCb.Max = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                    case 2:	// Cr
                        outCr.Max = Math.Max( -0.5, Math.Min( 0.5, v ) );
                        break;
                }
                outSlider.Max = (int) ( ( v - start ) * 255 );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Input slider`s values changed
        private void inSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

            inMinBox.Text = ( (double) inSlider.Min / 255 + start ).ToString( "F3" );
            inMaxBox.Text = ( (double) inSlider.Max / 255 + start ).ToString( "F3" );
        }

        // Output slider`s values changed
        private void outSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            double start = ( componentCombo.SelectedIndex == 0 ) ? 0.0 : -0.5;

            outMinBox.Text = ( (double) outSlider.Min / 255 + start ).ToString( "F3" );
            outMaxBox.Text = ( (double) outSlider.Max / 255 + start ).ToString( "F3" );
        }

        // Update filert
        private void UpdateFilter( )
        {
            // input values
            filter.InY = inY;
            filter.InCb = inCb;
            filter.InCr = inCr;
            // output values
            filter.OutY = outY;
            filter.OutCb = outCb;
            filter.OutCr = outCr;

            filterPreview.RefreshFilter( );
        }
    }
}
