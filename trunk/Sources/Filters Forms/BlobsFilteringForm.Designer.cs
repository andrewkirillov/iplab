namespace IPLab
{
    partial class BlobsFilteringForm
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
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.minHeightTrackBar = new System.Windows.Forms.TrackBar( );
            this.minHeightBox = new System.Windows.Forms.TextBox( );
            this.minWidthTrackBar = new System.Windows.Forms.TrackBar( );
            this.label2 = new System.Windows.Forms.Label( );
            this.modeCombo = new System.Windows.Forms.ComboBox( );
            this.minWidthBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.minHeightTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.minWidthTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.minHeightTrackBar );
            this.groupBox2.Controls.Add( this.minHeightBox );
            this.groupBox2.Controls.Add( this.minWidthTrackBar );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.modeCombo );
            this.groupBox2.Controls.Add( this.minWidthBox );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 270, 215 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove blobs, which ...";
            // 
            // minHeightTrackBar
            // 
            this.minHeightTrackBar.Location = new System.Drawing.Point( 10, 160 );
            this.minHeightTrackBar.Minimum = 1;
            this.minHeightTrackBar.Name = "minHeightTrackBar";
            this.minHeightTrackBar.Size = new System.Drawing.Size( 250, 45 );
            this.minHeightTrackBar.TabIndex = 6;
            this.minHeightTrackBar.Value = 1;
            this.minHeightTrackBar.ValueChanged += new System.EventHandler( this.minHeightTrackBar_ValueChanged );
            // 
            // minHeightBox
            // 
            this.minHeightBox.Location = new System.Drawing.Point( 130, 140 );
            this.minHeightBox.Name = "minHeightBox";
            this.minHeightBox.Size = new System.Drawing.Size( 50, 20 );
            this.minHeightBox.TabIndex = 5;
            this.minHeightBox.TextChanged += new System.EventHandler( this.minHeightBox_TextChanged );
            // 
            // minWidthTrackBar
            // 
            this.minWidthTrackBar.Location = new System.Drawing.Point( 10, 45 );
            this.minWidthTrackBar.Minimum = 1;
            this.minWidthTrackBar.Name = "minWidthTrackBar";
            this.minWidthTrackBar.Size = new System.Drawing.Size( 250, 45 );
            this.minWidthTrackBar.TabIndex = 2;
            this.minWidthTrackBar.Value = 1;
            this.minWidthTrackBar.ValueChanged += new System.EventHandler( this.minWidthTrackBar_ValueChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 143 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 110, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Height is smaller than:";
            // 
            // modeCombo
            // 
            this.modeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeCombo.FormattingEnabled = true;
            this.modeCombo.Items.AddRange( new object[] {
            "Or",
            "And"} );
            this.modeCombo.Location = new System.Drawing.Point( 30, 95 );
            this.modeCombo.Name = "modeCombo";
            this.modeCombo.Size = new System.Drawing.Size( 70, 21 );
            this.modeCombo.TabIndex = 3;
            this.modeCombo.SelectedIndexChanged += new System.EventHandler( this.modeCombo_SelectedIndexChanged );
            // 
            // minWidthBox
            // 
            this.minWidthBox.Location = new System.Drawing.Point( 130, 25 );
            this.minWidthBox.Name = "minWidthBox";
            this.minWidthBox.Size = new System.Drawing.Size( 50, 20 );
            this.minWidthBox.TabIndex = 1;
            this.minWidthBox.TextChanged += new System.EventHandler( this.minWidthBox_TextChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 107, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Width is smaller than:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 385, 202 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 300, 202 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 14;
            this.okButton.Text = "Ok";
            // 
            // BlobsFilteringForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 474, 238 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlobsFilteringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Blobs\' Filtering";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.minHeightTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.minWidthTrackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modeCombo;
        private System.Windows.Forms.TextBox minWidthBox;
        private System.Windows.Forms.TrackBar minWidthTrackBar;
        private System.Windows.Forms.TrackBar minHeightTrackBar;
        private System.Windows.Forms.TextBox minHeightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}