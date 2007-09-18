namespace IPLab
{
    partial class SaltNoiseForm
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
            this.filterPreview = new IPLab.FilterPreview( );
            this.okButton = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.noiseAmountBox = new System.Windows.Forms.TextBox( );
            this.noiseAmountTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.noiseAmountTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 145, 143 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 140, 140 );
            this.filterPreview.TabIndex = 12;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 55, 143 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 280, 5 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 160, 165 );
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 75, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Noise amount:";
            // 
            // noiseAmountBox
            // 
            this.noiseAmountBox.Location = new System.Drawing.Point( 90, 10 );
            this.noiseAmountBox.Name = "noiseAmountBox";
            this.noiseAmountBox.Size = new System.Drawing.Size( 70, 20 );
            this.noiseAmountBox.TabIndex = 1;
            this.noiseAmountBox.TextChanged += new System.EventHandler( this.noiseAmountBox_TextChanged );
            // 
            // noiseAmountTrackBar
            // 
            this.noiseAmountTrackBar.Location = new System.Drawing.Point( 10, 40 );
            this.noiseAmountTrackBar.Maximum = 100;
            this.noiseAmountTrackBar.Minimum = 1;
            this.noiseAmountTrackBar.Name = "noiseAmountTrackBar";
            this.noiseAmountTrackBar.Size = new System.Drawing.Size( 260, 45 );
            this.noiseAmountTrackBar.TabIndex = 2;
            this.noiseAmountTrackBar.TickFrequency = 5;
            this.noiseAmountTrackBar.Value = 1;
            this.noiseAmountTrackBar.ValueChanged += new System.EventHandler( this.noiseAmountTrackBar_ValueChanged );
            // 
            // SaltNoiseForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 449, 178 );
            this.Controls.Add( this.noiseAmountTrackBar );
            this.Controls.Add( this.noiseAmountBox );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaltNoiseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salt and Pepper Noise";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.noiseAmountTrackBar ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private FilterPreview filterPreview;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noiseAmountBox;
        private System.Windows.Forms.TrackBar noiseAmountTrackBar;
    }
}