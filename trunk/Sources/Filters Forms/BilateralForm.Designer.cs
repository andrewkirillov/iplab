namespace IPLab
{
    partial class BilateralForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
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
            this.kernelSizeUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.label2 = new System.Windows.Forms.Label( );
            this.spatialFactorUpDown = new System.Windows.Forms.NumericUpDown( );
            this.spatialPowerUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label3 = new System.Windows.Forms.Label( );
            this.colorFactorUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label4 = new System.Windows.Forms.Label( );
            this.colorPowerUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label5 = new System.Windows.Forms.Label( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.kernelSizeUpDown ) ).BeginInit( );
            this.groupBox2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.spatialFactorUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.spatialPowerUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.colorFactorUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.colorPowerUpDown ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.colorPowerUpDown );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.colorFactorUpDown );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.spatialPowerUpDown );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.spatialFactorUpDown );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.kernelSizeUpDown );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 200, 175 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter settings";
            // 
            // kernelSizeUpDown
            // 
            this.kernelSizeUpDown.Increment = new decimal( new int[] {
            2,
            0,
            0,
            0} );
            this.kernelSizeUpDown.Location = new System.Drawing.Point( 90, 25 );
            this.kernelSizeUpDown.Maximum = new decimal( new int[] {
            25,
            0,
            0,
            0} );
            this.kernelSizeUpDown.Minimum = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.kernelSizeUpDown.Name = "kernelSizeUpDown";
            this.kernelSizeUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.kernelSizeUpDown.TabIndex = 1;
            this.kernelSizeUpDown.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.kernelSizeUpDown.ValueChanged += new System.EventHandler( this.kernelSizeUpDown_ValueChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 61, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Kernel size:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.filterPreview );
            this.groupBox2.Location = new System.Drawing.Point( 220, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 315, 200 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 230, 200 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 58 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 72, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Spatial factor:";
            // 
            // spatialFactorUpDown
            // 
            this.spatialFactorUpDown.DecimalPlaces = 2;
            this.spatialFactorUpDown.Location = new System.Drawing.Point( 90, 55 );
            this.spatialFactorUpDown.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.spatialFactorUpDown.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.spatialFactorUpDown.Name = "spatialFactorUpDown";
            this.spatialFactorUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.spatialFactorUpDown.TabIndex = 3;
            this.spatialFactorUpDown.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.spatialFactorUpDown.ValueChanged += new System.EventHandler( this.spatialFactorUpDown_ValueChanged );
            // 
            // spatialPowerUpDown
            // 
            this.spatialPowerUpDown.DecimalPlaces = 2;
            this.spatialPowerUpDown.Location = new System.Drawing.Point( 90, 85 );
            this.spatialPowerUpDown.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.spatialPowerUpDown.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.spatialPowerUpDown.Name = "spatialPowerUpDown";
            this.spatialPowerUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.spatialPowerUpDown.TabIndex = 5;
            this.spatialPowerUpDown.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.spatialPowerUpDown.ValueChanged += new System.EventHandler( this.spatialPowerUpDown_ValueChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 10, 88 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 74, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Spatial power:";
            // 
            // colorFactorUpDown
            // 
            this.colorFactorUpDown.DecimalPlaces = 2;
            this.colorFactorUpDown.Location = new System.Drawing.Point( 90, 115 );
            this.colorFactorUpDown.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.colorFactorUpDown.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.colorFactorUpDown.Name = "colorFactorUpDown";
            this.colorFactorUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.colorFactorUpDown.TabIndex = 7;
            this.colorFactorUpDown.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.colorFactorUpDown.ValueChanged += new System.EventHandler( this.colorFactorUpDown_ValueChanged );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 10, 118 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 64, 13 );
            this.label4.TabIndex = 6;
            this.label4.Text = "Color factor:";
            // 
            // colorPowerUpDown
            // 
            this.colorPowerUpDown.DecimalPlaces = 2;
            this.colorPowerUpDown.Location = new System.Drawing.Point( 90, 145 );
            this.colorPowerUpDown.Maximum = new decimal( new int[] {
            255,
            0,
            0,
            0} );
            this.colorPowerUpDown.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.colorPowerUpDown.Name = "colorPowerUpDown";
            this.colorPowerUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.colorPowerUpDown.TabIndex = 9;
            this.colorPowerUpDown.Value = new decimal( new int[] {
            3,
            0,
            0,
            0} );
            this.colorPowerUpDown.ValueChanged += new System.EventHandler( this.colorPowerUpDown_ValueChanged );
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 10, 148 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 66, 13 );
            this.label5.TabIndex = 8;
            this.label5.Text = "Color power:";
            // 
            // BilateralForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 399, 235 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BilateralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilateral smoothing";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.kernelSizeUpDown ) ).EndInit( );
            this.groupBox2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.spatialFactorUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.spatialPowerUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.colorFactorUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.colorPowerUpDown ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FilterPreview filterPreview;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown kernelSizeUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown colorPowerUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown colorFactorUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spatialPowerUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown spatialFactorUpDown;
        private System.Windows.Forms.Label label2;
    }
}