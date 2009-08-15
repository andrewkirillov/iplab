namespace IPLab
{
    partial class SimplePosterizationForm
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
            this.label1 = new System.Windows.Forms.Label( );
            this.posterizationIntervalBox = new System.Windows.Forms.TextBox( );
            this.posterizationIntervalTrackBar = new System.Windows.Forms.TrackBar( );
            this.fillTypeCombo = new System.Windows.Forms.ComboBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.posterizationIntervalTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 108, 13 );
            this.label1.TabIndex = 10;
            this.label1.Text = "Posterization Interval:";
            // 
            // posterizationIntervalBox
            // 
            this.posterizationIntervalBox.Location = new System.Drawing.Point( 125, 25 );
            this.posterizationIntervalBox.Name = "posterizationIntervalBox";
            this.posterizationIntervalBox.Size = new System.Drawing.Size( 50, 20 );
            this.posterizationIntervalBox.TabIndex = 11;
            this.posterizationIntervalBox.TextChanged += new System.EventHandler( this.posterizationIntervalBox_TextChanged );
            // 
            // posterizationIntervalTrackBar
            // 
            this.posterizationIntervalTrackBar.Location = new System.Drawing.Point( 10, 45 );
            this.posterizationIntervalTrackBar.Maximum = 128;
            this.posterizationIntervalTrackBar.Minimum = 2;
            this.posterizationIntervalTrackBar.Name = "posterizationIntervalTrackBar";
            this.posterizationIntervalTrackBar.Size = new System.Drawing.Size( 275, 45 );
            this.posterizationIntervalTrackBar.TabIndex = 12;
            this.posterizationIntervalTrackBar.TickFrequency = 5;
            this.posterizationIntervalTrackBar.Value = 2;
            this.posterizationIntervalTrackBar.ValueChanged += new System.EventHandler( this.posterizationIntervalTrackBar_ValueChanged );
            // 
            // fillTypeCombo
            // 
            this.fillTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeCombo.FormattingEnabled = true;
            this.fillTypeCombo.Items.AddRange( new object[] {
            "Min",
            "Max",
            "Average"} );
            this.fillTypeCombo.Location = new System.Drawing.Point( 75, 85 );
            this.fillTypeCombo.Name = "fillTypeCombo";
            this.fillTypeCombo.Size = new System.Drawing.Size( 100, 21 );
            this.fillTypeCombo.TabIndex = 13;
            this.fillTypeCombo.SelectedIndexChanged += new System.EventHandler( this.fillTypeCombo_SelectedIndexChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 88 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 63, 13 );
            this.label2.TabIndex = 14;
            this.label2.Text = "Filling Type:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 150, 162 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 65, 162 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 19;
            this.okButton.Text = "Ok";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 150 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 275, 2 );
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
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
            // SimplePosterizationForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 469, 195 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.fillTypeCombo );
            this.Controls.Add( this.posterizationIntervalTrackBar );
            this.Controls.Add( this.posterizationIntervalBox );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimplePosterizationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Simple Posterization";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.posterizationIntervalTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox posterizationIntervalBox;
        private System.Windows.Forms.TrackBar posterizationIntervalTrackBar;
        private System.Windows.Forms.ComboBox fillTypeCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}