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
    /// Summary description for EuclideanColorFilteringForm.
    /// </summary>
    public class EuclideanColorFilteringForm : System.Windows.Forms.Form
    {
        private EuclideanColorFiltering filter = new EuclideanColorFiltering( );
        private byte red = 255, green = 255, blue = 255;
        private byte fillR = 0, fillG = 0, fillB = 0;
        private short radius = 100;

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox redBox;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.TextBox blueBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private IPLab.FilterPreview filterPreview;
        private AForge.Controls.ColorSlider redSlider;
        private AForge.Controls.ColorSlider greenSlider;
        private AForge.Controls.ColorSlider blueSlider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fillRBox;
        private System.Windows.Forms.TextBox fillGBox;
        private System.Windows.Forms.TextBox fillBBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TrackBar radiusTrackBar;
        private System.Windows.Forms.ComboBox fillTypeCombo;
        private System.Windows.Forms.Label label7;
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
        public EuclideanColorFilteringForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            //
            redBox.Text = red.ToString( );
            greenBox.Text = green.ToString( );
            blueBox.Text = blue.ToString( );

            radiusBox.Text = radius.ToString( );

            fillRBox.Text = fillR.ToString( );
            fillGBox.Text = fillG.ToString( );
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
            this.groupBox4 = new System.Windows.Forms.GroupBox( );
            this.blueSlider = new AForge.Controls.ColorSlider( );
            this.greenSlider = new AForge.Controls.ColorSlider( );
            this.redSlider = new AForge.Controls.ColorSlider( );
            this.label4 = new System.Windows.Forms.Label( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label10 = new System.Windows.Forms.Label( );
            this.redBox = new System.Windows.Forms.TextBox( );
            this.greenBox = new System.Windows.Forms.TextBox( );
            this.blueBox = new System.Windows.Forms.TextBox( );
            this.groupBox5 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.radiusTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.radiusBox = new System.Windows.Forms.TextBox( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.fillRBox = new System.Windows.Forms.TextBox( );
            this.fillGBox = new System.Windows.Forms.TextBox( );
            this.fillBBox = new System.Windows.Forms.TextBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.fillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.label7 = new System.Windows.Forms.Label( );
            this.groupBox4.SuspendLayout( );
            this.groupBox5.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.radiusTrackBar ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.blueSlider,
																					this.greenSlider,
																					this.redSlider,
																					this.label4,
																					this.label3,
																					this.label10,
																					this.redBox,
																					this.greenBox,
																					this.blueBox} );
            this.groupBox4.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 280, 120 );
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Center color";
            // 
            // blueSlider
            // 
            this.blueSlider.EndColor = System.Drawing.Color.Blue;
            this.blueSlider.DoubleArrow = false;
            this.blueSlider.Location = new System.Drawing.Point( 8, 90 );
            this.blueSlider.Name = "blueSlider";
            this.blueSlider.Size = new System.Drawing.Size( 262, 20 );
            this.blueSlider.TabIndex = 8;
            this.blueSlider.TabStop = false;
            this.blueSlider.ValuesChanged += new System.EventHandler( this.blueSlider_ValuesChanged );
            // 
            // greenSlider
            // 
            this.greenSlider.EndColor = System.Drawing.Color.Lime;
            this.greenSlider.DoubleArrow = false;
            this.greenSlider.Location = new System.Drawing.Point( 8, 70 );
            this.greenSlider.Name = "greenSlider";
            this.greenSlider.Size = new System.Drawing.Size( 262, 20 );
            this.greenSlider.TabIndex = 7;
            this.greenSlider.TabStop = false;
            this.greenSlider.ValuesChanged += new System.EventHandler( this.greenSlider_ValuesChanged );
            // 
            // redSlider
            // 
            this.redSlider.EndColor = System.Drawing.Color.Red;
            this.redSlider.DoubleArrow = false;
            this.redSlider.Location = new System.Drawing.Point( 8, 50 );
            this.redSlider.Name = "redSlider";
            this.redSlider.Size = new System.Drawing.Size( 262, 20 );
            this.redSlider.TabIndex = 6;
            this.redSlider.TabStop = false;
            this.redSlider.ValuesChanged += new System.EventHandler( this.redSlider_ValuesChanged );
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point( 197, 23 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 17, 14 );
            this.label4.TabIndex = 4;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 100, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 17, 14 );
            this.label3.TabIndex = 2;
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
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point( 30, 20 );
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size( 50, 20 );
            this.redBox.TabIndex = 1;
            this.redBox.Text = "";
            this.redBox.TextChanged += new System.EventHandler( this.redBox_TextChanged );
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point( 120, 20 );
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size( 50, 20 );
            this.greenBox.TabIndex = 3;
            this.greenBox.Text = "";
            this.greenBox.TextChanged += new System.EventHandler( this.greenBox_TextChanged );
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point( 218, 20 );
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size( 50, 20 );
            this.blueBox.TabIndex = 5;
            this.blueBox.Text = "";
            this.blueBox.TextChanged += new System.EventHandler( this.blueBox_TextChanged );
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox5.Location = new System.Drawing.Point( 300, 10 );
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox5.TabIndex = 4;
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
            // radiusTrackBar
            // 
            this.radiusTrackBar.Location = new System.Drawing.Point( 5, 45 );
            this.radiusTrackBar.Maximum = 450;
            this.radiusTrackBar.Minimum = 1;
            this.radiusTrackBar.Name = "radiusTrackBar";
            this.radiusTrackBar.Size = new System.Drawing.Size( 268, 42 );
            this.radiusTrackBar.TabIndex = 1;
            this.radiusTrackBar.TickFrequency = 10;
            this.radiusTrackBar.Value = 100;
            this.radiusTrackBar.Scroll += new System.EventHandler( this.radiusTrackBar_Scroll );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.radiusBox,
																					this.radiusTrackBar} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 135 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 280, 90 );
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Radius";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point( 13, 20 );
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size( 50, 20 );
            this.radiusBox.TabIndex = 0;
            this.radiusBox.Text = "";
            this.radiusBox.TextChanged += new System.EventHandler( this.radiusBox_TextChanged );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.label1,
																					this.label2,
																					this.label5,
																					this.fillRBox,
																					this.fillGBox,
																					this.fillBBox} );
            this.groupBox2.Location = new System.Drawing.Point( 10, 230 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 280, 50 );
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fill color";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 197, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 17, 14 );
            this.label1.TabIndex = 7;
            this.label1.Text = "B:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 100, 23 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 17, 14 );
            this.label2.TabIndex = 6;
            this.label2.Text = "G:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point( 10, 23 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 15, 14 );
            this.label5.TabIndex = 0;
            this.label5.Text = "R:";
            // 
            // fillRBox
            // 
            this.fillRBox.Location = new System.Drawing.Point( 30, 20 );
            this.fillRBox.Name = "fillRBox";
            this.fillRBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillRBox.TabIndex = 0;
            this.fillRBox.Text = "";
            this.fillRBox.TextChanged += new System.EventHandler( this.fillBox_TextChanged );
            // 
            // fillGBox
            // 
            this.fillGBox.Location = new System.Drawing.Point( 120, 20 );
            this.fillGBox.Name = "fillGBox";
            this.fillGBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillGBox.TabIndex = 1;
            this.fillGBox.Text = "";
            this.fillGBox.TextChanged += new System.EventHandler( this.fillBox_TextChanged );
            // 
            // fillBBox
            // 
            this.fillBBox.Location = new System.Drawing.Point( 218, 20 );
            this.fillBBox.Name = "fillBBox";
            this.fillBBox.Size = new System.Drawing.Size( 50, 20 );
            this.fillBBox.TabIndex = 2;
            this.fillBBox.Text = "";
            this.fillBBox.TextChanged += new System.EventHandler( this.fillBox_TextChanged );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 395, 255 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 310, 255 );
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
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
            this.fillTypeCombo.TabIndex = 9;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.fillTypeCombo_SelectedIndexChanged );
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point( 300, 198 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 50, 14 );
            this.label7.TabIndex = 12;
            this.label7.Text = "Fill type:";
            // 
            // EuclideanColorFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 479, 288 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.fillTypeCombo,
																		  this.label7,
																		  this.cancelButton,
																		  this.okButton,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.groupBox5,
																		  this.groupBox4} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EuclideanColorFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Euclidean Color Filtering";
            this.groupBox4.ResumeLayout( false );
            this.groupBox5.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.radiusTrackBar ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Red changed
        private void redBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                red = byte.Parse( redBox.Text );
                redSlider.Min = red;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Green changed
        private void greenBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                green = byte.Parse( greenBox.Text );
                greenSlider.Min = green;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Blue changed
        private void blueBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                blue = byte.Parse( blueBox.Text );
                blueSlider.Min = blue;
                UpdateCenterColor( );
            }
            catch ( Exception )
            {
            }
        }

        // Red slider changed
        private void redSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            redBox.Text = redSlider.Min.ToString( );
        }

        // Green slider changed
        private void greenSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            greenBox.Text = greenSlider.Min.ToString( );
        }

        // Blue slider changed
        private void blueSlider_ValuesChanged( object sender, System.EventArgs e )
        {
            blueBox.Text = blueSlider.Min.ToString( );
        }

        // Update center color
        private void UpdateCenterColor( )
        {
            // update slider colors
            redSlider.StartColor   = Color.FromArgb( 0, green, blue );
            redSlider.EndColor     = Color.FromArgb( 255, green, blue );
            greenSlider.StartColor = Color.FromArgb( red, 0, blue );
            greenSlider.EndColor   = Color.FromArgb( red, 255, blue );
            blueSlider.StartColor  = Color.FromArgb( red, green, 0 );
            blueSlider.EndColor    = Color.FromArgb( red, green, 255 );

            // update filter
            filter.CenterColor = Color.FromArgb( red, green, blue );
            filterPreview.RefreshFilter( );
        }

        // Radius changed
        private void radiusBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                radius = Math.Max( (short) 1, Math.Min( (short) 450, short.Parse( radiusBox.Text ) ) );

                radiusTrackBar.Value = filter.Radius = radius;
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Radius trackbar scrolled
        private void radiusTrackBar_Scroll( object sender, System.EventArgs e )
        {
            radiusBox.Text = radiusTrackBar.Value.ToString( );
        }

        // Fill color changed
        private void fillBox_TextChanged( object sender, System.EventArgs e )
        {
            try
            {
                fillR = byte.Parse( fillRBox.Text );
                fillG = byte.Parse( fillGBox.Text );
                fillB = byte.Parse( fillBBox.Text );

                filter.FillColor = Color.FromArgb( fillR, fillG, fillB );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }

        // Fill type changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            filter.FillOutside = ( fillTypeCombo.SelectedIndex == 0 );
            filterPreview.RefreshFilter( );
        }
    }
}
