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
    /// Summary description for ThresholdForm.
    /// </summary>
    public class BradleyLocalThresholdForm : System.Windows.Forms.Form
    {
        private BradleyLocalThresholding filter = new BradleyLocalThresholding();
        private int windowSize = 41;
        private float pixelDifferenceLimit = 0.15f;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWindowSize;
        private AForge.Controls.ColorSlider sliderWindowSize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private AForge.Controls.ColorSlider sliderPixelDifferenceLimit;
        private TextBox txtPixelDifferenceLimit;
        private Label label2;

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
        public BradleyLocalThresholdForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            txtWindowSize.Text = windowSize.ToString();
            txtPixelDifferenceLimit.Text = pixelDifferenceLimit.ToString();
            sliderWindowSize.Min = windowSize;
            sliderPixelDifferenceLimit.Min = (int)(pixelDifferenceLimit * 255f);

            // initial filter values
            filter.WindowSize = windowSize;
            filter.PixelBrightnessDifferenceLimit = pixelDifferenceLimit;
            filterPreview.Filter = filter;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtWindowSize = new System.Windows.Forms.TextBox();
            this.sliderWindowSize = new AForge.Controls.ColorSlider();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sliderPixelDifferenceLimit = new AForge.Controls.ColorSlider();
            this.txtPixelDifferenceLimit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filterPreview = new IPLab.FilterPreview();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Window size:";
            // 
            // txtWindowSize
            // 
            this.txtWindowSize.Location = new System.Drawing.Point(82, 8);
            this.txtWindowSize.Name = "txtWindowSize";
            this.txtWindowSize.Size = new System.Drawing.Size(50, 20);
            this.txtWindowSize.TabIndex = 1;
            this.txtWindowSize.TextChanged += new System.EventHandler(this.minBox_TextChanged);
            // 
            // sliderWindowSize
            // 
            this.sliderWindowSize.DoubleArrow = false;
            this.sliderWindowSize.Location = new System.Drawing.Point(8, 40);
            this.sliderWindowSize.Min = 127;
            this.sliderWindowSize.Name = "sliderWindowSize";
            this.sliderWindowSize.Size = new System.Drawing.Size(262, 23);
            this.sliderWindowSize.TabIndex = 4;
            this.sliderWindowSize.Type = AForge.Controls.ColorSlider.ColorSliderType.Threshold;
            this.sliderWindowSize.ValuesChanged += new System.EventHandler(this.slider_ValuesChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(6, 142);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 2);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(53, 162);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(143, 162);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterPreview);
            this.groupBox1.Location = new System.Drawing.Point(287, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 165);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // sliderPixelDifferenceLimit
            // 
            this.sliderPixelDifferenceLimit.DoubleArrow = false;
            this.sliderPixelDifferenceLimit.Location = new System.Drawing.Point(8, 113);
            this.sliderPixelDifferenceLimit.Min = 127;
            this.sliderPixelDifferenceLimit.Name = "sliderPixelDifferenceLimit";
            this.sliderPixelDifferenceLimit.Size = new System.Drawing.Size(262, 23);
            this.sliderPixelDifferenceLimit.TabIndex = 16;
            this.sliderPixelDifferenceLimit.Type = AForge.Controls.ColorSlider.ColorSliderType.Threshold;
            this.sliderPixelDifferenceLimit.ValuesChanged += new System.EventHandler(this.diffSlider_ValuesChanged);
            // 
            // txtPixelDifferenceLimit
            // 
            this.txtPixelDifferenceLimit.Location = new System.Drawing.Point(124, 81);
            this.txtPixelDifferenceLimit.Name = "txtPixelDifferenceLimit";
            this.txtPixelDifferenceLimit.Size = new System.Drawing.Size(50, 20);
            this.txtPixelDifferenceLimit.TabIndex = 15;
            this.txtPixelDifferenceLimit.TextChanged += new System.EventHandler(this.diffBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "&Pixel difference limit:";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(10, 12);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(140, 140);
            this.filterPreview.TabIndex = 13;
            // 
            // BradleyLocalThresholdForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(459, 202);
            this.Controls.Add(this.sliderPixelDifferenceLimit);
            this.Controls.Add(this.txtPixelDifferenceLimit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.sliderWindowSize);
            this.Controls.Add(this.txtWindowSize);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BradleyLocalThresholdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bradley Local Thresholding";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // Min edit box changed
        private void minBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                var value = int.Parse(txtWindowSize.Text);
                value = Math.Min(255, value);
                value = Math.Max(3, value);
                value = value | 1;
                sliderWindowSize.Min = windowSize = value;

                // refresh filter
                filter.WindowSize = windowSize;
                filterPreview.RefreshFilter();
            }
            catch (Exception)
            {
            }
        }

        // Slider position changed
        private void slider_ValuesChanged(object sender, System.EventArgs e)
        {
            windowSize = (byte)sliderWindowSize.Min;
            txtWindowSize.Text = windowSize.ToString();
        }

        private void diffBox_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                var value = float.Parse(txtPixelDifferenceLimit.Text);
                value = Math.Max(0f, value);
                value = Math.Min(1f, value);

                pixelDifferenceLimit = value;
                sliderPixelDifferenceLimit.Min = (int)(255 * pixelDifferenceLimit);

                // refresh filter
                filter.PixelBrightnessDifferenceLimit = pixelDifferenceLimit;
                filterPreview.RefreshFilter();
            }
            catch (Exception)
            {
            }
        }

        // Slider position changed
        private void diffSlider_ValuesChanged(object sender, System.EventArgs e)
        {
            pixelDifferenceLimit = sliderPixelDifferenceLimit.Min / 255f;
            txtPixelDifferenceLimit.Text = pixelDifferenceLimit.ToString();
        }
    }
}
