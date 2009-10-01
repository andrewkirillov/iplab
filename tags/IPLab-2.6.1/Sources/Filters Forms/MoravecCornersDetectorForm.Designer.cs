namespace IPLab
{
    partial class MoravecCornersDetectorForm
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
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar( );
            this.thresholdBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.windowSizeCombo = new System.Windows.Forms.ComboBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.thresholdTrackBar ) ).BeginInit( );
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
            this.label1.Size = new System.Drawing.Size( 57, 13 );
            this.label1.TabIndex = 10;
            this.label1.Text = "Threshold:";
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point( 10, 45 );
            this.thresholdTrackBar.Maximum = 2500;
            this.thresholdTrackBar.Minimum = 50;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size( 275, 45 );
            this.thresholdTrackBar.TabIndex = 12;
            this.thresholdTrackBar.TickFrequency = 50;
            this.thresholdTrackBar.Value = 50;
            this.thresholdTrackBar.ValueChanged += new System.EventHandler( this.thresholdTrackBar_ValueChanged );
            // 
            // thresholdBox
            // 
            this.thresholdBox.Location = new System.Drawing.Point( 90, 25 );
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.ReadOnly = true;
            this.thresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.thresholdBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 93 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 70, 13 );
            this.label2.TabIndex = 13;
            this.label2.Text = "Window size:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 150, 162 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 65, 162 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 16;
            this.okButton.Text = "Ok";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 150 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 275, 2 );
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // windowSizeCombo
            // 
            this.windowSizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowSizeCombo.FormattingEnabled = true;
            this.windowSizeCombo.Items.AddRange( new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15"} );
            this.windowSizeCombo.Location = new System.Drawing.Point( 89, 90 );
            this.windowSizeCombo.Name = "windowSizeCombo";
            this.windowSizeCombo.Size = new System.Drawing.Size( 51, 21 );
            this.windowSizeCombo.TabIndex = 19;
            this.windowSizeCombo.SelectedIndexChanged += new System.EventHandler( this.windowSizeCombo_SelectedIndexChanged );
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
            // MoravecCornersDetectorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 469, 195 );
            this.Controls.Add( this.windowSizeCombo );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.thresholdTrackBar );
            this.Controls.Add( this.thresholdBox );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoravecCornersDetectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Moravec Corners Detector";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.thresholdTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.TextBox thresholdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox windowSizeCombo;
    }
}