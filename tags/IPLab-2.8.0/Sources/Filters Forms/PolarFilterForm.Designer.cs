namespace IPLab
{
    partial class PolarFilterForm
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
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.newHeightUpDown = new System.Windows.Forms.NumericUpDown( );
            this.newWidthUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label3 = new System.Windows.Forms.Label( );
            this.circleDepthUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label2 = new System.Windows.Forms.Label( );
            this.offsetAngleUpDown = new System.Windows.Forms.NumericUpDown( );
            this.label1 = new System.Windows.Forms.Label( );
            this.mapBackwardsCheck = new System.Windows.Forms.CheckBox( );
            this.mapFromTopCheck = new System.Windows.Forms.CheckBox( );
            this.fillColorLabel = new System.Windows.Forms.Label( );
            this.colorButton = new System.Windows.Forms.Button( );
            this.colorDialog = new System.Windows.Forms.ColorDialog( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.newHeightUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.newWidthUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.circleDepthUpDown ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.offsetAngleUpDown ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 109, 265 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 24, 265 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.colorButton );
            this.groupBox1.Controls.Add( this.fillColorLabel );
            this.groupBox1.Controls.Add( this.mapFromTopCheck );
            this.groupBox1.Controls.Add( this.mapBackwardsCheck );
            this.groupBox1.Controls.Add( this.label4 );
            this.groupBox1.Controls.Add( this.newHeightUpDown );
            this.groupBox1.Controls.Add( this.newWidthUpDown );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.circleDepthUpDown );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.offsetAngleUpDown );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 185, 240 );
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 10, 118 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 64, 13 );
            this.label4.TabIndex = 7;
            this.label4.Text = "New height:";
            // 
            // newHeightUpDown
            // 
            this.newHeightUpDown.Location = new System.Drawing.Point( 90, 115 );
            this.newHeightUpDown.Maximum = new decimal( new int[] {
            4000,
            0,
            0,
            0} );
            this.newHeightUpDown.Minimum = new decimal( new int[] {
            20,
            0,
            0,
            0} );
            this.newHeightUpDown.Name = "newHeightUpDown";
            this.newHeightUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.newHeightUpDown.TabIndex = 6;
            this.newHeightUpDown.Value = new decimal( new int[] {
            20,
            0,
            0,
            0} );
            this.newHeightUpDown.ValueChanged += new System.EventHandler( this.newSizeUpDown_ValueChanged );
            // 
            // newWidthUpDown
            // 
            this.newWidthUpDown.Location = new System.Drawing.Point( 90, 85 );
            this.newWidthUpDown.Maximum = new decimal( new int[] {
            4000,
            0,
            0,
            0} );
            this.newWidthUpDown.Minimum = new decimal( new int[] {
            20,
            0,
            0,
            0} );
            this.newWidthUpDown.Name = "newWidthUpDown";
            this.newWidthUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.newWidthUpDown.TabIndex = 5;
            this.newWidthUpDown.Value = new decimal( new int[] {
            20,
            0,
            0,
            0} );
            this.newWidthUpDown.ValueChanged += new System.EventHandler( this.newSizeUpDown_ValueChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 10, 88 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 60, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "New width:";
            // 
            // circleDepthUpDown
            // 
            this.circleDepthUpDown.DecimalPlaces = 2;
            this.circleDepthUpDown.Increment = new decimal( new int[] {
            1,
            0,
            0,
            65536} );
            this.circleDepthUpDown.Location = new System.Drawing.Point( 90, 55 );
            this.circleDepthUpDown.Maximum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.circleDepthUpDown.Name = "circleDepthUpDown";
            this.circleDepthUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.circleDepthUpDown.TabIndex = 3;
            this.circleDepthUpDown.ValueChanged += new System.EventHandler( this.circleDepthUpDown_ValueChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 58 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 66, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Circle depth:";
            // 
            // offsetAngleUpDown
            // 
            this.offsetAngleUpDown.DecimalPlaces = 1;
            this.offsetAngleUpDown.Location = new System.Drawing.Point( 90, 25 );
            this.offsetAngleUpDown.Maximum = new decimal( new int[] {
            359,
            0,
            0,
            0} );
            this.offsetAngleUpDown.Name = "offsetAngleUpDown";
            this.offsetAngleUpDown.Size = new System.Drawing.Size( 80, 20 );
            this.offsetAngleUpDown.TabIndex = 1;
            this.offsetAngleUpDown.ValueChanged += new System.EventHandler( this.offsetAngleUpDown_ValueChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Offset angle:";
            // 
            // mapBackwardsCheck
            // 
            this.mapBackwardsCheck.AutoSize = true;
            this.mapBackwardsCheck.Location = new System.Drawing.Point( 10, 150 );
            this.mapBackwardsCheck.Name = "mapBackwardsCheck";
            this.mapBackwardsCheck.Size = new System.Drawing.Size( 102, 17 );
            this.mapBackwardsCheck.TabIndex = 8;
            this.mapBackwardsCheck.Text = "Map backwards";
            this.mapBackwardsCheck.UseVisualStyleBackColor = true;
            this.mapBackwardsCheck.CheckedChanged += new System.EventHandler( this.mapBackwardsCheck_CheckedChanged );
            // 
            // mapFromTopCheck
            // 
            this.mapFromTopCheck.AutoSize = true;
            this.mapFromTopCheck.Location = new System.Drawing.Point( 10, 180 );
            this.mapFromTopCheck.Name = "mapFromTopCheck";
            this.mapFromTopCheck.Size = new System.Drawing.Size( 88, 17 );
            this.mapFromTopCheck.TabIndex = 9;
            this.mapFromTopCheck.Text = "Map from top";
            this.mapFromTopCheck.UseVisualStyleBackColor = true;
            this.mapFromTopCheck.CheckedChanged += new System.EventHandler( this.mapFromTopCheck_CheckedChanged );
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.AutoSize = true;
            this.fillColorLabel.Location = new System.Drawing.Point( 10, 210 );
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size( 48, 13 );
            this.fillColorLabel.TabIndex = 10;
            this.fillColorLabel.Text = "Fill color:";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point( 90, 205 );
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size( 80, 23 );
            this.colorButton.TabIndex = 11;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler( this.colorButton_Click );
            // 
            // PolarFilterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 208, 298 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PolarFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transform To Polar";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.newHeightUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.newWidthUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.circleDepthUpDown ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.offsetAngleUpDown ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown newHeightUpDown;
        private System.Windows.Forms.NumericUpDown newWidthUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown circleDepthUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown offsetAngleUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox mapFromTopCheck;
        private System.Windows.Forms.CheckBox mapBackwardsCheck;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label fillColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}