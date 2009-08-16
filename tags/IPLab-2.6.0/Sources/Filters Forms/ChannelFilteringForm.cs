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
    /// Summary description for ChannelFilteringForm.
    /// </summary>
    public class ChannelFilteringForm : System.Windows.Forms.Form
    {
        private ChannelFiltering filter = new ChannelFiltering( );
        private IntRange red = new IntRange( 0, 255 );
        private IntRange green = new IntRange( 0, 255 );
        private IntRange blue = new IntRange( 0, 255 );
        private byte fillR = 0, fillG = 0, fillB = 0;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minRBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxRBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fillRBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox fillGBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxGBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minGBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox fillBBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox maxBBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox minBBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private AForge.Controls.ColorSlider redSlider;
        private AForge.Controls.ColorSlider greenSlider;
        private AForge.Controls.ColorSlider blueSlider;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox redFillTypeCombo;
        private System.Windows.Forms.ComboBox greenFillTypeCombo;
        private System.Windows.Forms.ComboBox blueFillTypeCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        public ChannelFilteringForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            minRBox.Text = red.Min.ToString( );
            maxRBox.Text = red.Max.ToString( );
            fillRBox.Text = fillR.ToString( );
            //
            minGBox.Text = green.Min.ToString( );
            maxGBox.Text = green.Max.ToString( );
            fillGBox.Text = fillG.ToString( );
            //
            minBBox.Text = blue.Min.ToString( );
            maxBBox.Text = blue.Max.ToString( );
            fillBBox.Text = fillB.ToString( );

            redFillTypeCombo.SelectedIndex = 0;
            greenFillTypeCombo.SelectedIndex = 0;
            blueFillTypeCombo.SelectedIndex = 0;

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
            this.redSlider = new AForge.Controls.ColorSlider( );
            this.fillRBox = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.maxRBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.minRBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.greenSlider = new AForge.Controls.ColorSlider( );
            this.fillGBox = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.maxGBox = new System.Windows.Forms.TextBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.minGBox = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.blueSlider = new AForge.Controls.ColorSlider( );
            this.fillBBox = new System.Windows.Forms.TextBox( );
            this.label7 = new System.Windows.Forms.Label( );
            this.maxBBox = new System.Windows.Forms.TextBox( );
            this.label8 = new System.Windows.Forms.Label( );
            this.minBBox = new System.Windows.Forms.TextBox( );
            this.label9 = new System.Windows.Forms.Label( );
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.okButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.label10 = new System.Windows.Forms.Label( );
            this.redFillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.greenFillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.blueFillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.label11 = new System.Windows.Forms.Label( );
            this.label12 = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.groupBox3.SuspendLayout( );
            this.groupBox4.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.redSlider,
																					this.fillRBox,
																					this.label3,
																					this.maxRBox,
																					this.label2,
																					this.minRBox,
																					this.label1} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 280, 75 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Red";
            // 
            // redSlider
            // 
            this.redSlider.EndColor = System.Drawing.Color.Red;
            this.redSlider.Location = new System.Drawing.Point( 8, 45 );
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size( 262, 23 );
            this.redSlider.TabIndex = 6;
            this.redSlider.TabStop = false;
            this.redSlider.Type = AForge.Controls.ColorSlider.ColorSliderType.InnerGradient;
            this.redSlider.ValuesChanged += new System.EventHandler( this.redSlider_ValuesChanged );
            // 
            // fillRBox
            // 
            this.fillRBox.Location = new System.Drawing.Point( 218, 20 );
            this.fillRBox.Name = "fillRBox";
            this.fillRBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillRBox.TabIndex = 5;
            this.fillRBox.Text = "";
            this.fillRBox.TextChanged += new System.EventHandler( this.fillRBox_TextChanged );
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 190, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 30, 14 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Fill:";
            // 
            // maxRBox
            // 
            this.maxRBox.Location = new System.Drawing.Point( 130, 20 );
            this.maxRBox.Name = "maxRBox";
            this.maxRBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxRBox.TabIndex = 3;
            this.maxRBox.Text = "";
            this.maxRBox.TextChanged += new System.EventHandler( this.maxRBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 100, 23 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 30, 14 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Max:";
            // 
            // minRBox
            // 
            this.minRBox.Location = new System.Drawing.Point( 40, 20 );
            this.minRBox.Name = "minRBox";
            this.minRBox.Size = new System.Drawing.Size( 50, 20 );
            this.minRBox.TabIndex = 1;
            this.minRBox.Text = "";
            this.minRBox.TextChanged += new System.EventHandler( this.minRBox_TextChanged );
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 10, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 30, 14 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Min:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.greenSlider,
																					this.fillGBox,
																					this.label4,
																					this.maxGBox,
																					this.label5,
																					this.minGBox,
																					this.label6} );
            this.groupBox2.Location = new System.Drawing.Point( 10, 100 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 280, 75 );
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Green";
            // 
            // greenSlider
            // 
            this.greenSlider.EndColor = System.Drawing.Color.Lime;
            this.greenSlider.Location = new System.Drawing.Point( 8, 45 );
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size( 262, 23 );
            this.greenSlider.TabIndex = 6;
            this.greenSlider.TabStop = false;
            this.greenSlider.Type = AForge.Controls.ColorSlider.ColorSliderType.InnerGradient;
            this.greenSlider.ValuesChanged += new System.EventHandler( this.greenSlider_ValuesChanged );
            // 
            // fillGBox
            // 
            this.fillGBox.Location = new System.Drawing.Point( 218, 20 );
            this.fillGBox.Name = "fillGBox";
            this.fillGBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillGBox.TabIndex = 5;
            this.fillGBox.Text = "";
            this.fillGBox.TextChanged += new System.EventHandler( this.fillGBox_TextChanged );
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 190, 23 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 30, 14 );
            this.label4.TabIndex = 4;
            this.label4.Text = "Fill:";
            // 
            // maxGBox
            // 
            this.maxGBox.Location = new System.Drawing.Point( 130, 20 );
            this.maxGBox.Name = "maxGBox";
            this.maxGBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxGBox.TabIndex = 3;
            this.maxGBox.Text = "";
            this.maxGBox.TextChanged += new System.EventHandler( this.maxGBox_TextChanged );
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 100, 23 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 30, 14 );
            this.label5.TabIndex = 2;
            this.label5.Text = "Max:";
            // 
            // minGBox
            // 
            this.minGBox.Location = new System.Drawing.Point( 40, 20 );
            this.minGBox.Name = "minGBox";
            this.minGBox.Size = new System.Drawing.Size( 50, 20 );
            this.minGBox.TabIndex = 1;
            this.minGBox.Text = "";
            this.minGBox.TextChanged += new System.EventHandler( this.minGBox_TextChanged );
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point( 10, 23 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 30, 14 );
            this.label6.TabIndex = 0;
            this.label6.Text = "Min:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.blueSlider,
																					this.fillBBox,
																					this.label7,
																					this.maxBBox,
																					this.label8,
																					this.minBBox,
																					this.label9} );
            this.groupBox3.Location = new System.Drawing.Point( 10, 190 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 280, 75 );
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blue";
            // 
            // blueSlider
            // 
            this.blueSlider.EndColor = System.Drawing.Color.Blue;
            this.blueSlider.Location = new System.Drawing.Point( 8, 45 );
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size( 262, 23 );
            this.blueSlider.TabIndex = 6;
            this.blueSlider.TabStop = false;
            this.blueSlider.Type = AForge.Controls.ColorSlider.ColorSliderType.InnerGradient;
            this.blueSlider.ValuesChanged += new System.EventHandler( this.blueSlider_ValuesChanged );
            // 
            // fillBBox
            // 
            this.fillBBox.Location = new System.Drawing.Point( 218, 20 );
            this.fillBBox.Name = "fillBBox";
            this.fillBBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillBBox.TabIndex = 5;
            this.fillBBox.Text = "";
            this.fillBBox.TextChanged += new System.EventHandler( this.fillBBox_TextChanged );
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point( 190, 23 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 30, 14 );
            this.label7.TabIndex = 4;
            this.label7.Text = "Fill:";
            // 
            // maxBBox
            // 
            this.maxBBox.Location = new System.Drawing.Point( 130, 20 );
            this.maxBBox.Name = "maxBBox";
            this.maxBBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxBBox.TabIndex = 3;
            this.maxBBox.Text = "";
            this.maxBBox.TextChanged += new System.EventHandler( this.maxBBox_TextChanged );
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point( 100, 23 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 30, 14 );
            this.label8.TabIndex = 2;
            this.label8.Text = "Max:";
            // 
            // minBBox
            // 
            this.minBBox.Location = new System.Drawing.Point( 40, 20 );
            this.minBBox.Name = "minBBox";
            this.minBBox.Size = new System.Drawing.Size( 50, 20 );
            this.minBBox.TabIndex = 1;
            this.minBBox.Text = "";
            this.minBBox.TextChanged += new System.EventHandler( this.minBBox_TextChanged );
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point( 10, 23 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 30, 14 );
            this.label9.TabIndex = 0;
            this.label9.Text = "Min:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox4.Location = new System.Drawing.Point( 300, 10 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox4.TabIndex = 3;
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
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 152, 295 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 252, 295 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point( 300, 198 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 67, 14 );
            this.label10.TabIndex = 4;
            this.label10.Text = "Red fill type:";
            // 
            // redFillTypeCombo
            // 
            this.redFillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.redFillTypeCombo.Items.AddRange( new object[] {
																  "Outside",
																  "Inside"} );
            this.redFillTypeCombo.Location = new System.Drawing.Point( 380, 195 );
            this.redFillTypeCombo.Name = "redFillTypeCombo";
            this.redFillTypeCombo.Size = new System.Drawing.Size( 90, 21 );
            this.redFillTypeCombo.TabIndex = 5;
            this.redFillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.redFillTypeCombo_SelectedIndexChanged );
            // 
            // greenFillTypeCombo
            // 
            this.greenFillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.greenFillTypeCombo.Items.AddRange( new object[] {
																	"Outside",
																	"Inside"} );
            this.greenFillTypeCombo.Location = new System.Drawing.Point( 380, 220 );
            this.greenFillTypeCombo.Name = "greenFillTypeCombo";
            this.greenFillTypeCombo.Size = new System.Drawing.Size( 90, 21 );
            this.greenFillTypeCombo.TabIndex = 7;
            this.greenFillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.greenFillTypeCombo_SelectedIndexChanged );
            // 
            // blueFillTypeCombo
            // 
            this.blueFillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blueFillTypeCombo.Items.AddRange( new object[] {
																   "Outside",
																   "Inside"} );
            this.blueFillTypeCombo.Location = new System.Drawing.Point( 380, 245 );
            this.blueFillTypeCombo.Name = "blueFillTypeCombo";
            this.blueFillTypeCombo.Size = new System.Drawing.Size( 90, 21 );
            this.blueFillTypeCombo.TabIndex = 9;
            this.blueFillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.blueFillTypeCombo_SelectedIndexChanged );
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point( 300, 223 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 77, 14 );
            this.label11.TabIndex = 6;
            this.label11.Text = "Green fill type:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point( 300, 248 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 67, 14 );
            this.label12.TabIndex = 8;
            this.label12.Text = "Blue fill type:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 275 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 460, 2 );
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ChannelFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 479, 328 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.label12,
																		  this.label11,
																		  this.blueFillTypeCombo,
																		  this.greenFillTypeCombo,
																		  this.redFillTypeCombo,
																		  this.label10,
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox4,
																		  this.groupBox3,
																		  this.groupBox2,
																		  this.groupBox1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Channel Filtering";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.groupBox4.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Update filter
        private void UpdateFilter( )
        {
            filter.Red = red;
            filter.Green = green;
            filter.Blue = blue;
            filterPreview.RefreshFilter( );
        }

        // Min red changed
        private void minRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                redSlider.Min = red.Min = Math.Min( red.Max, byte.Parse( minRBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max red changed
        private void maxRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                redSlider.Max = red.Max = Math.Max( red.Min, byte.Parse( maxRBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill red changed
        private void fillRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillR = byte.Parse( fillRBox.Text );
                filter.FillRed = fillR;
                redSlider.FillColor = Color.FromArgb( fillR, 0, 0 );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min green changed
        private void minGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                greenSlider.Min = green.Min = (byte) Math.Min( green.Max, byte.Parse( minGBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max green changed
        private void maxGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                greenSlider.Max = green.Max = Math.Max( green.Min, byte.Parse( maxGBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill green changed
        private void fillGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillG = byte.Parse( fillGBox.Text );
                filter.FillGreen = fillG;
                greenSlider.FillColor = Color.FromArgb( 0, fillG, 0 );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Min blue changed
        private void minBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blueSlider.Min = blue.Min = Math.Min( blue.Max, byte.Parse( minBBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Max blue changed
        private void maxBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blueSlider.Max = blue.Max = Math.Max( blue.Min, byte.Parse( maxBBox.Text ) );
                UpdateFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill blue changed
        private void fillBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillB = byte.Parse( fillBBox.Text );
                filter.FillBlue = fillB;
                blueSlider.FillColor = Color.FromArgb( 0, 0, fillB );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Red slider changed
        private void redSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minRBox.Text = redSlider.Min.ToString( );
            maxRBox.Text = redSlider.Max.ToString( );
        }

        // Green slider changed
        private void greenSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minGBox.Text = greenSlider.Min.ToString( );
            maxGBox.Text = greenSlider.Max.ToString( );
        }

        // Blue slider changed
        private void blueSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            minBBox.Text = blueSlider.Min.ToString( );
            maxBBox.Text = blueSlider.Max.ToString( );
        }

        // Red fill type changed
        private void redFillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            redSlider.Type = ( redFillTypeCombo.SelectedIndex == 0 ) ?
                AForge.Controls.ColorSlider.ColorSliderType.InnerGradient :
                AForge.Controls.ColorSlider.ColorSliderType.OuterGradient;
            filter.RedFillOutsideRange = ( redFillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }

        // Green fill type changed
        private void greenFillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            greenSlider.Type = ( greenFillTypeCombo.SelectedIndex == 0 ) ?
                AForge.Controls.ColorSlider.ColorSliderType.InnerGradient :
                AForge.Controls.ColorSlider.ColorSliderType.OuterGradient;
            filter.GreenFillOutsideRange = ( greenFillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }

        // Blue fill type changed
        private void blueFillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            blueSlider.Type = ( blueFillTypeCombo.SelectedIndex == 0 ) ?
                AForge.Controls.ColorSlider.ColorSliderType.InnerGradient :
                AForge.Controls.ColorSlider.ColorSliderType.OuterGradient;
            filter.BlueFillOutsideRange = blueFillTypeCombo.SelectedIndex == 0;
            filterPreview.RefreshFilter( );
        }
    }
}
