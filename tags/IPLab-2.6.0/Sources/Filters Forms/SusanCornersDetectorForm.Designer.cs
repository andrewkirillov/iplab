namespace IPLab
{
    partial class SusanCornersDetectorForm
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
            this.diffThresholdBox = new System.Windows.Forms.TextBox( );
            this.diffThresholdTrackBar = new System.Windows.Forms.TrackBar( );
            this.geometricalThresholdTrackBar = new System.Windows.Forms.TrackBar( );
            this.label2 = new System.Windows.Forms.Label( );
            this.geometricalThresholdBox = new System.Windows.Forms.TextBox( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.diffThresholdTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.geometricalThresholdTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 105, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Difference threshold:";
            // 
            // diffThresholdBox
            // 
            this.diffThresholdBox.Location = new System.Drawing.Point( 125, 20 );
            this.diffThresholdBox.Name = "diffThresholdBox";
            this.diffThresholdBox.ReadOnly = true;
            this.diffThresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.diffThresholdBox.TabIndex = 1;
            // 
            // diffThresholdTrackBar
            // 
            this.diffThresholdTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.diffThresholdTrackBar.Maximum = 200;
            this.diffThresholdTrackBar.Minimum = 5;
            this.diffThresholdTrackBar.Name = "diffThresholdTrackBar";
            this.diffThresholdTrackBar.Size = new System.Drawing.Size( 275, 45 );
            this.diffThresholdTrackBar.TabIndex = 2;
            this.diffThresholdTrackBar.TickFrequency = 5;
            this.diffThresholdTrackBar.Value = 5;
            this.diffThresholdTrackBar.ValueChanged += new System.EventHandler( this.diffThresholdTrackBar_ValueChanged );
            // 
            // geometricalThresholdTrackBar
            // 
            this.geometricalThresholdTrackBar.Location = new System.Drawing.Point( 10, 110 );
            this.geometricalThresholdTrackBar.Maximum = 37;
            this.geometricalThresholdTrackBar.Minimum = 5;
            this.geometricalThresholdTrackBar.Name = "geometricalThresholdTrackBar";
            this.geometricalThresholdTrackBar.Size = new System.Drawing.Size( 275, 45 );
            this.geometricalThresholdTrackBar.TabIndex = 5;
            this.geometricalThresholdTrackBar.Value = 5;
            this.geometricalThresholdTrackBar.ValueChanged += new System.EventHandler( this.geometricalThresholdTrackBar_ValueChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 88 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 112, 13 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Geometrical threshold:";
            // 
            // geometricalThresholdBox
            // 
            this.geometricalThresholdBox.Location = new System.Drawing.Point( 125, 85 );
            this.geometricalThresholdBox.Name = "geometricalThresholdBox";
            this.geometricalThresholdBox.ReadOnly = true;
            this.geometricalThresholdBox.Size = new System.Drawing.Size( 50, 20 );
            this.geometricalThresholdBox.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 150, 170 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 65, 170 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 155 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 275, 2 );
            this.pictureBox1.TabIndex = 14;
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
            // SusanCornersDetectorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 469, 206 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.geometricalThresholdBox );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.geometricalThresholdTrackBar );
            this.Controls.Add( this.diffThresholdTrackBar );
            this.Controls.Add( this.diffThresholdBox );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SusanCornersDetectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SUSAN Corners Detector";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.diffThresholdTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.geometricalThresholdTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox diffThresholdBox;
        private System.Windows.Forms.TrackBar diffThresholdTrackBar;
        private System.Windows.Forms.TrackBar geometricalThresholdTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox geometricalThresholdBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}