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
    /// Summary description for LevelsLinearForm.
    /// </summary>
    public class LevelsLinearForm : System.Windows.Forms.Form
    {
        private static Color[] colors = new Color[] {
														Color.FromArgb(192, 0, 0),
														Color.FromArgb(0, 192, 0),
														Color.FromArgb(0, 0, 192),
														Color.FromArgb(128, 128, 128),
		};
        private LevelsLinear filter = new LevelsLinear( );

        private IntRange inRed      = new IntRange( 0, 255 );
        private IntRange inGreen    = new IntRange( 0, 255 );
        private IntRange inBlue     = new IntRange( 0, 255 );
        private IntRange outRed     = new IntRange( 0, 255 );
        private IntRange outGreen   = new IntRange( 0, 255 );
        private IntRange outBlue    = new IntRange( 0, 255 );

        private AForge.Imaging.ImageStatistics imgStat;
        private AForge.Controls.Histogram histogram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox channelCombo;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox inMinBox;
        private System.Windows.Forms.TextBox inMaxBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox allCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outMinBox;
        private System.Windows.Forms.TextBox outMaxBox;
        private AForge.Controls.ColorSlider inSlider;
        private AForge.Controls.ColorSlider outSlider;
        private System.Windows.Forms.GroupBox groupBox4;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.PictureBox pictureBox3;
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
        public LevelsLinearForm( AForge.Imaging.ImageStatistics imgStat )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.imgStat = imgStat;

            if ( !imgStat.IsGrayscale )
            {
                // RGB picture
                channelCombo.Items.AddRange( new object[] { "Red", "Green", "Blue" } );
                channelCombo.Enabled = true;
            }
            else
            {
                // grayscale picture
                channelCombo.Items.Add( "Gray" );
                channelCombo.Enabled = false;
                allCheckBox.Enabled = false;
            }
            channelCombo.SelectedIndex = 0;

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
            this.histogram = new AForge.Controls.Histogram( );
            this.label1 = new System.Windows.Forms.Label( );
            this.channelCombo = new System.Windows.Forms.ComboBox( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.inMinBox = new System.Windows.Forms.TextBox( );
            this.inMaxBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.allCheckBox = new System.Windows.Forms.CheckBox( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.outMinBox = new System.Windows.Forms.TextBox( );
            this.outMaxBox = new System.Windows.Forms.TextBox( );
            this.inSlider = new AForge.Controls.ColorSlider( );
            this.outSlider = new AForge.Controls.ColorSlider( );
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.pictureBox3 = new System.Windows.Forms.PictureBox( );
            this.groupBox4.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point( 10, 75 );
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size( 258, 162 );
            this.histogram.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 51, 16 );
            this.label1.TabIndex = 1;
            this.label1.Text = "&Channel:";
            // 
            // channelCombo
            // 
            this.channelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelCombo.Location = new System.Drawing.Point( 60, 10 );
            this.channelCombo.Name = "channelCombo";
            this.channelCombo.Size = new System.Drawing.Size( 90, 21 );
            this.channelCombo.TabIndex = 2;
            this.channelCombo.SelectedIndexChanged += new System.EventHandler( this.channelCombo_SelectedIndexChanged );
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 295, 300 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 385, 300 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // inMinBox
            // 
            this.inMinBox.Location = new System.Drawing.Point( 80, 50 );
            this.inMinBox.Name = "inMinBox";
            this.inMinBox.Size = new System.Drawing.Size( 50, 20 );
            this.inMinBox.TabIndex = 5;
            this.inMinBox.Text = "";
            this.inMinBox.TextChanged += new System.EventHandler( this.inMinBox_TextChanged );
            // 
            // inMaxBox
            // 
            this.inMaxBox.Location = new System.Drawing.Point( 140, 50 );
            this.inMaxBox.Name = "inMaxBox";
            this.inMaxBox.Size = new System.Drawing.Size( 50, 20 );
            this.inMaxBox.TabIndex = 6;
            this.inMaxBox.Text = "";
            this.inMaxBox.TextChanged += new System.EventHandler( this.inMaxBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 10, 53 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 65, 17 );
            this.label2.TabIndex = 4;
            this.label2.Text = "&Input levels:";
            // 
            // allCheckBox
            // 
            this.allCheckBox.Location = new System.Drawing.Point( 165, 10 );
            this.allCheckBox.Name = "allCheckBox";
            this.allCheckBox.TabIndex = 3;
            this.allCheckBox.Text = "&Sync channels";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 40 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point( 10, 260 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 10, 273 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 73, 17 );
            this.label3.TabIndex = 7;
            this.label3.Text = "&Output levels:";
            // 
            // outMinBox
            // 
            this.outMinBox.Location = new System.Drawing.Point( 80, 270 );
            this.outMinBox.Name = "outMinBox";
            this.outMinBox.Size = new System.Drawing.Size( 50, 20 );
            this.outMinBox.TabIndex = 8;
            this.outMinBox.Text = "";
            this.outMinBox.TextChanged += new System.EventHandler( this.outMinBox_TextChanged );
            // 
            // outMaxBox
            // 
            this.outMaxBox.Location = new System.Drawing.Point( 140, 270 );
            this.outMaxBox.Name = "outMaxBox";
            this.outMaxBox.Size = new System.Drawing.Size( 50, 20 );
            this.outMaxBox.TabIndex = 9;
            this.outMaxBox.Text = "";
            this.outMaxBox.TextChanged += new System.EventHandler( this.outMaxBox_TextChanged );
            // 
            // inSlider
            // 
            this.inSlider.Location = new System.Drawing.Point( 8, 232 );
            this.inSlider.Max = 253;
            this.inSlider.Min = 2;
            this.inSlider.Name = "inSlider";
            this.inSlider.Size = new System.Drawing.Size( 262, 20 );
            this.inSlider.TabIndex = 15;
            this.inSlider.TabStop = false;
            this.inSlider.ValuesChanged += new System.EventHandler( this.inSlider_ValuesChanged );
            // 
            // outSlider
            // 
            this.outSlider.Location = new System.Drawing.Point( 8, 295 );
            this.outSlider.Name = "outSlider";
            this.outSlider.Size = new System.Drawing.Size( 262, 20 );
            this.outSlider.TabIndex = 16;
            this.outSlider.TabStop = false;
            this.outSlider.ValuesChanged += new System.EventHandler( this.outSlider_ValuesChanged );
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox4.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox4.TabIndex = 17;
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
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point( 10, 323 );
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size( 258, 2 );
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // LevelsLinearForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 469, 333 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.groupBox4,
																		  this.outSlider,
																		  this.inSlider,
																		  this.pictureBox3,
																		  this.outMaxBox,
																		  this.outMinBox,
																		  this.label3,
																		  this.pictureBox2,
																		  this.pictureBox1,
																		  this.allCheckBox,
																		  this.label2,
																		  this.inMaxBox,
																		  this.inMinBox,
																		  this.cancelButton,
																		  this.okButton,
																		  this.channelCombo,
																		  this.histogram,
																		  this.label1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LevelsLinearForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Levels";
            this.groupBox4.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Selection changed in channels combo
        private void channelCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            AForge.Math.Histogram h = null;
            Color color = Color.White;
            IntRange input = new IntRange( 0, 255 );
            IntRange output = new IntRange( 0, 255 );
            int index = channelCombo.SelectedIndex;

            if ( !imgStat.IsGrayscale )
            {
                // RGB image
                histogram.Color = colors[index];

                switch ( index )
                {
                    case 0:	// red
                        h = imgStat.Red;
                        input = inRed;
                        output = outRed;
                        color = Color.FromArgb( 255, 0, 0 );
                        break;
                    case 1:	// green
                        h = imgStat.Green;
                        input = inGreen;
                        output = outGreen;
                        color = Color.FromArgb( 0, 255, 0 );
                        break;
                    case 2:	// blue
                        h = imgStat.Blue;
                        input = inBlue;
                        output = outBlue;
                        color = Color.FromArgb( 0, 0, 255 );
                        break;
                }
            }
            else
            {
                // grayscale image
                histogram.Color = colors[3];
                h = imgStat.Gray;

                input = inGreen;
                output = outGreen;
            }
            histogram.Values = h.Values;

            inMinBox.Text = input.Min.ToString( );
            inMaxBox.Text = input.Max.ToString( );
            outMinBox.Text = output.Min.ToString( );
            outMaxBox.Text = output.Max.ToString( );

            // input slider
            inSlider.EndColor = color;
            inSlider.Min = input.Min;
            inSlider.Max = input.Max;
            // output slider
            outSlider.EndColor = color;
            outSlider.Min = output.Min;
            outSlider.Max = output.Max;
        }

        // inMin changed
        private void inMinBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                byte v = byte.Parse( inMinBox.Text );

                inSlider.Min = v;

                if ( !imgStat.IsGrayscale )
                {
                    // RGB
                    if ( allCheckBox.Checked )
                    {
                        // sync channels
                        inRed.Min = inGreen.Min = inBlue.Min = v;
                    }
                    else
                    {
                        switch ( channelCombo.SelectedIndex )
                        {
                            case 0:
                                inRed.Min = v;
                                break;
                            case 1:
                                inGreen.Min = v;
                                break;
                            case 2:
                                inBlue.Min = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    inGreen.Min = v;
                }

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
                byte v = byte.Parse( inMaxBox.Text );

                inSlider.Max = v;

                if ( !imgStat.IsGrayscale )
                {
                    // RGB
                    if ( allCheckBox.Checked )
                    {
                        // sync channels
                        inRed.Max = inGreen.Max = inBlue.Max = v;
                    }
                    else
                    {
                        switch ( channelCombo.SelectedIndex )
                        {
                            case 0:
                                inRed.Max = v;
                                break;
                            case 1:
                                inGreen.Max = v;
                                break;
                            case 2:
                                inBlue.Max = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    inGreen.Max = v;
                }

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
                byte v = byte.Parse( outMinBox.Text );

                outSlider.Min = v;

                if ( !imgStat.IsGrayscale )
                {
                    // RGB
                    if ( allCheckBox.Checked )
                    {
                        // sync channels
                        outRed.Min = outGreen.Min = outBlue.Min = v;
                    }
                    else
                    {
                        switch ( channelCombo.SelectedIndex )
                        {
                            case 0:
                                outRed.Min = v;
                                break;
                            case 1:
                                outGreen.Min = v;
                                break;
                            case 2:
                                outBlue.Min = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    outGreen.Min = v;
                }

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
                byte v = byte.Parse( outMaxBox.Text );

                outSlider.Max = v;

                if ( !imgStat.IsGrayscale )
                {
                    // RGB
                    if ( allCheckBox.Checked )
                    {
                        // sync channels
                        outRed.Max = outGreen.Max = outBlue.Max = v;
                    }
                    else
                    {
                        switch ( channelCombo.SelectedIndex )
                        {
                            case 0:
                                outRed.Max = v;
                                break;
                            case 1:
                                outGreen.Max = v;
                                break;
                            case 2:
                                outBlue.Max = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    outGreen.Max = v;
                }

                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Input slider`s values changed
        private void inSlider_ValuesChanged( object sender, EventArgs e )
        {
            inMinBox.Text = inSlider.Min.ToString( );
            inMaxBox.Text = inSlider.Max.ToString( );
        }

        // Output slider`s values changed
        private void outSlider_ValuesChanged( object sender, EventArgs e )
        {
            outMinBox.Text = outSlider.Min.ToString( );
            outMaxBox.Text = outSlider.Max.ToString( );
        }

        // Update filert
        private void UpdateFilter( )
        {
            // input values
            filter.InRed = inRed;
            filter.InGreen = inGreen;
            filter.InBlue = inBlue;
            // output values
            filter.OutRed = outRed;
            filter.OutGreen = outGreen;
            filter.OutBlue = outBlue;

            filterPreview.RefreshFilter( );
        }
    }
}
