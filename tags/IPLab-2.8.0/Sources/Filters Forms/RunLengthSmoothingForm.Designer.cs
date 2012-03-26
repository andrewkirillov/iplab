namespace IPLab
{
    partial class RunLengthSmoothingForm
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
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.typeCombo = new System.Windows.Forms.ComboBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.maxGapUpDown = new System.Windows.Forms.NumericUpDown( );
            this.processBordersCheck = new System.Windows.Forms.CheckBox( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxGapUpDown ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 113, 335 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 28, 335 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 10, 125 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 195, 200 );
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 175, 175 );
            this.filterPreview.TabIndex = 0;
            this.filterPreview.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.processBordersCheck );
            this.groupBox2.Controls.Add( this.maxGapUpDown );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.typeCombo );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 195, 110 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 34, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // typeCombo
            // 
            this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombo.FormattingEnabled = true;
            this.typeCombo.Items.AddRange( new object[] {
            "Horizontal",
            "Vertical"} );
            this.typeCombo.Location = new System.Drawing.Point( 50, 25 );
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size( 110, 21 );
            this.typeCombo.TabIndex = 1;
            this.typeCombo.SelectedIndexChanged += new System.EventHandler( this.typeCombo_SelectedIndexChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 58 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 75, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum gap:";
            // 
            // maxGapUpDown
            // 
            this.maxGapUpDown.Location = new System.Drawing.Point( 90, 55 );
            this.maxGapUpDown.Maximum = new decimal( new int[] {
            200,
            0,
            0,
            0} );
            this.maxGapUpDown.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.maxGapUpDown.Name = "maxGapUpDown";
            this.maxGapUpDown.Size = new System.Drawing.Size( 70, 20 );
            this.maxGapUpDown.TabIndex = 3;
            this.maxGapUpDown.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.maxGapUpDown.ValueChanged += new System.EventHandler( this.maxGapUpDown_ValueChanged );
            // 
            // processBordersCheck
            // 
            this.processBordersCheck.AutoSize = true;
            this.processBordersCheck.Location = new System.Drawing.Point( 10, 85 );
            this.processBordersCheck.Name = "processBordersCheck";
            this.processBordersCheck.Size = new System.Drawing.Size( 181, 17 );
            this.processBordersCheck.TabIndex = 4;
            this.processBordersCheck.Text = "Process gaps with image borders";
            this.processBordersCheck.UseVisualStyleBackColor = true;
            this.processBordersCheck.CheckedChanged += new System.EventHandler( this.processBordersCheck_CheckedChanged );
            // 
            // RunLengthSmoothingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 216, 366 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RunLengthSmoothingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Length Smoothing";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxGapUpDown ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown maxGapUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox processBordersCheck;
    }
}