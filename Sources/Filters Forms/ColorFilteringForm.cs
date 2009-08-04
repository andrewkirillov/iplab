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
    /// Summary description for ColorFilteringForm.
    /// </summary>
    public class ColorFilteringForm : System.Windows.Forms.Form
    {
        private ColorFiltering filter = new ColorFiltering( );
        private IntRange red = new IntRange( 0, 255 );
        private IntRange green = new IntRange( 0, 255 );
        private IntRange blue = new IntRange( 0, 255 );
        private byte fillR = 0, fillG = 0, fillB = 0;

        private System.Windows.Forms.GroupBox groupBox3;
        private AForge.Controls.ColorSlider blueSlider;
        private System.Windows.Forms.TextBox fillBBox;
        private System.Windows.Forms.TextBox maxBBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox minBBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private AForge.Controls.ColorSlider greenSlider;
        private System.Windows.Forms.TextBox fillGBox;
        private System.Windows.Forms.TextBox maxGBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minGBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private AForge.Controls.ColorSlider redSlider;
        private System.Windows.Forms.TextBox fillRBox;
        private System.Windows.Forms.TextBox maxRBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minRBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox fillTypeCombo;
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
        public ColorFilteringForm( )
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

            fillTypeCombo.SelectedIndex = 0;

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
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.blueSlider = new AForge.Controls.ColorSlider( );
            this.maxBBox = new System.Windows.Forms.TextBox( );
            this.label8 = new System.Windows.Forms.Label( );
            this.minBBox = new System.Windows.Forms.TextBox( );
            this.label9 = new System.Windows.Forms.Label( );
            this.fillBBox = new System.Windows.Forms.TextBox( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.greenSlider = new AForge.Controls.ColorSlider( );
            this.maxGBox = new System.Windows.Forms.TextBox( );
            this.label5 = new System.Windows.Forms.Label( );
            this.minGBox = new System.Windows.Forms.TextBox( );
            this.label6 = new System.Windows.Forms.Label( );
            this.fillGBox = new System.Windows.Forms.TextBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.redSlider = new AForge.Controls.ColorSlider( );
            this.maxRBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.minRBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.fillRBox = new System.Windows.Forms.TextBox( );
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label10 = new System.Windows.Forms.Label( );
            this.groupBox5 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.label7 = new System.Windows.Forms.Label( );
            this.fillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.groupBox3.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.groupBox1.SuspendLayout( );
            this.groupBox4.SuspendLayout( );
            this.groupBox5.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.blueSlider,
																					this.maxBBox,
																					this.label8,
																					this.minBBox,
																					this.label9} );
            this.groupBox3.Location = new System.Drawing.Point( 10, 170 );
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
            // maxBBox
            // 
            this.maxBBox.Location = new System.Drawing.Point( 218, 20 );
            this.maxBBox.Name = "maxBBox";
            this.maxBBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxBBox.TabIndex = 3;
            this.maxBBox.Text = "";
            this.maxBBox.TextChanged += new System.EventHandler( this.maxBBox_TextChanged );
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point( 186, 23 );
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
            // fillBBox
            // 
            this.fillBBox.Location = new System.Drawing.Point( 218, 20 );
            this.fillBBox.Name = "fillBBox";
            this.fillBBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillBBox.TabIndex = 2;
            this.fillBBox.Text = "";
            this.fillBBox.TextChanged += new System.EventHandler( this.fillBBox_TextChanged );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.greenSlider,
																					this.maxGBox,
																					this.label5,
																					this.minGBox,
																					this.label6} );
            this.groupBox2.Location = new System.Drawing.Point( 10, 90 );
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
            // maxGBox
            // 
            this.maxGBox.Location = new System.Drawing.Point( 218, 20 );
            this.maxGBox.Name = "maxGBox";
            this.maxGBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxGBox.TabIndex = 3;
            this.maxGBox.Text = "";
            this.maxGBox.TextChanged += new System.EventHandler( this.maxGBox_TextChanged );
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 186, 23 );
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
            // fillGBox
            // 
            this.fillGBox.Location = new System.Drawing.Point( 120, 20 );
            this.fillGBox.Name = "fillGBox";
            this.fillGBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillGBox.TabIndex = 1;
            this.fillGBox.Text = "";
            this.fillGBox.TextChanged += new System.EventHandler( this.fillGBox_TextChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.redSlider,
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
            // maxRBox
            // 
            this.maxRBox.Location = new System.Drawing.Point( 218, 20 );
            this.maxRBox.Name = "maxRBox";
            this.maxRBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxRBox.TabIndex = 3;
            this.maxRBox.Text = "";
            this.maxRBox.TextChanged += new System.EventHandler( this.maxRBox_TextChanged );
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 186, 23 );
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
            // fillRBox
            // 
            this.fillRBox.Location = new System.Drawing.Point( 30, 20 );
            this.fillRBox.Name = "fillRBox";
            this.fillRBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillRBox.TabIndex = 0;
            this.fillRBox.Text = "";
            this.fillRBox.TextChanged += new System.EventHandler( this.fillRBox_TextChanged );
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.label4,
																					this.label3,
																					this.label10,
																					this.fillRBox,
																					this.fillGBox,
																					this.fillBBox} );
            this.groupBox4.Location = new System.Drawing.Point( 10, 250 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 280, 50 );
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fill color";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 197, 23 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 17, 14 );
            this.label4.TabIndex = 7;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 100, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 17, 14 );
            this.label3.TabIndex = 6;
            this.label3.Text = "G:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point( 10, 23 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 15, 14 );
            this.label10.TabIndex = 0;
            this.label10.Text = "R:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox5.Location = new System.Drawing.Point( 300, 10 );
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
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
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 395, 275 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 310, 275 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point( 300, 198 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 50, 14 );
            this.label7.TabIndex = 9;
            this.label7.Text = "Fill type:";
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeCombo.Items.AddRange( new object[] {
															   "Outside",
															   "Inside"} );
            this.fillTypeCombo.Location = new System.Drawing.Point( 350, 195 );
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size( 120, 21 );
            this.fillTypeCombo.TabIndex = 7;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.fillTypeCombo_SelectedIndexChanged );
            // 
            // ColorFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 479, 308 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.fillTypeCombo,
																		  this.label7,
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox4,
																		  this.groupBox3,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.groupBox5} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Filtering";
            this.groupBox3.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            this.groupBox4.ResumeLayout( false );
            this.groupBox5.ResumeLayout( false );
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

        // Min green changed
        private void minGBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                greenSlider.Min = green.Min = Math.Min( green.Max, byte.Parse( minGBox.Text ) );
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

        // Fill red changed
        private void fillRBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillR = byte.Parse( fillRBox.Text );
                UpdateFillColor( );
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
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Fil blue changed
        private void fillBBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillB = byte.Parse( fillBBox.Text );
                UpdateFillColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Update fil color
        private void UpdateFillColor( )
        {
            redSlider.FillColor = greenSlider.FillColor = blueSlider.FillColor = Color.FromArgb( fillR, fillG, fillB );
            filter.FillColor = new RGB( fillR, fillG, fillB );
            filterPreview.RefreshFilter( );
        }

        // Fill type changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            AForge.Controls.ColorSlider.ColorSliderType[] types =
                new AForge.Controls.ColorSlider.ColorSliderType[]
                {
                    AForge.Controls.ColorSlider.ColorSliderType.InnerGradient,
                    AForge.Controls.ColorSlider.ColorSliderType.OuterGradient
                };
            AForge.Controls.ColorSlider.ColorSliderType type = types[fillTypeCombo.SelectedIndex];

            redSlider.Type = type;
            greenSlider.Type = type;
            blueSlider.Type = type;

            filter.FillOutsideRange = ( fillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }
    }
}
