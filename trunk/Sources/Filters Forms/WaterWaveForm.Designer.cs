namespace IPLab
{
    partial class WaterWaveForm
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
            this.horAmplitudeTrackBar = new System.Windows.Forms.TrackBar( );
            this.horAmplitudeBox = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.horCountTrackBar = new System.Windows.Forms.TrackBar( );
            this.horCountBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.groupBox3 = new System.Windows.Forms.GroupBox( );
            this.vertAmplitudeTrackBar = new System.Windows.Forms.TrackBar( );
            this.vertAmplitudeBox = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.vertCountTrackBar = new System.Windows.Forms.TrackBar( );
            this.vertCountBox = new System.Windows.Forms.TextBox( );
            this.label4 = new System.Windows.Forms.Label( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.horAmplitudeTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.horCountTrackBar ) ).BeginInit( );
            this.groupBox3.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.vertAmplitudeTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.vertCountTrackBar ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 455, 210 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 360, 210 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 360, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 2;
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
            this.groupBox2.Controls.Add( this.horAmplitudeTrackBar );
            this.groupBox2.Controls.Add( this.horAmplitudeBox );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.horCountTrackBar );
            this.groupBox2.Controls.Add( this.horCountBox );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 340, 110 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horizontal Wave";
            // 
            // horAmplitudeTrackBar
            // 
            this.horAmplitudeTrackBar.Location = new System.Drawing.Point( 135, 60 );
            this.horAmplitudeTrackBar.Maximum = 50;
            this.horAmplitudeTrackBar.Minimum = 2;
            this.horAmplitudeTrackBar.Name = "horAmplitudeTrackBar";
            this.horAmplitudeTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.horAmplitudeTrackBar.TabIndex = 6;
            this.horAmplitudeTrackBar.TickFrequency = 5;
            this.horAmplitudeTrackBar.Value = 2;
            this.horAmplitudeTrackBar.ValueChanged += new System.EventHandler( this.horAmplitudeTrackBar_ValueChanged );
            // 
            // horAmplitudeBox
            // 
            this.horAmplitudeBox.Location = new System.Drawing.Point( 70, 65 );
            this.horAmplitudeBox.Name = "horAmplitudeBox";
            this.horAmplitudeBox.ReadOnly = true;
            this.horAmplitudeBox.Size = new System.Drawing.Size( 60, 20 );
            this.horAmplitudeBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 68 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 56, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Amplitude:";
            // 
            // horCountTrackBar
            // 
            this.horCountTrackBar.Location = new System.Drawing.Point( 135, 20 );
            this.horCountTrackBar.Maximum = 50;
            this.horCountTrackBar.Minimum = 3;
            this.horCountTrackBar.Name = "horCountTrackBar";
            this.horCountTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.horCountTrackBar.TabIndex = 3;
            this.horCountTrackBar.TickFrequency = 5;
            this.horCountTrackBar.Value = 3;
            this.horCountTrackBar.ValueChanged += new System.EventHandler( this.horCountTrackBar_ValueChanged );
            // 
            // horCountBox
            // 
            this.horCountBox.Location = new System.Drawing.Point( 70, 25 );
            this.horCountBox.Name = "horCountBox";
            this.horCountBox.ReadOnly = true;
            this.horCountBox.Size = new System.Drawing.Size( 60, 20 );
            this.horCountBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 38, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.vertAmplitudeTrackBar );
            this.groupBox3.Controls.Add( this.vertAmplitudeBox );
            this.groupBox3.Controls.Add( this.label3 );
            this.groupBox3.Controls.Add( this.vertCountTrackBar );
            this.groupBox3.Controls.Add( this.vertCountBox );
            this.groupBox3.Controls.Add( this.label4 );
            this.groupBox3.Location = new System.Drawing.Point( 10, 125 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 340, 110 );
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vertical Wave";
            // 
            // vertAmplitudeTrackBar
            // 
            this.vertAmplitudeTrackBar.Location = new System.Drawing.Point( 135, 60 );
            this.vertAmplitudeTrackBar.Maximum = 50;
            this.vertAmplitudeTrackBar.Minimum = 2;
            this.vertAmplitudeTrackBar.Name = "vertAmplitudeTrackBar";
            this.vertAmplitudeTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.vertAmplitudeTrackBar.TabIndex = 6;
            this.vertAmplitudeTrackBar.TickFrequency = 5;
            this.vertAmplitudeTrackBar.Value = 2;
            this.vertAmplitudeTrackBar.ValueChanged += new System.EventHandler( this.vertAmplitudeTrackBar_ValueChanged );
            // 
            // vertAmplitudeBox
            // 
            this.vertAmplitudeBox.Location = new System.Drawing.Point( 70, 65 );
            this.vertAmplitudeBox.Name = "vertAmplitudeBox";
            this.vertAmplitudeBox.ReadOnly = true;
            this.vertAmplitudeBox.Size = new System.Drawing.Size( 60, 20 );
            this.vertAmplitudeBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 10, 68 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 56, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Amplitude:";
            // 
            // vertCountTrackBar
            // 
            this.vertCountTrackBar.Location = new System.Drawing.Point( 135, 20 );
            this.vertCountTrackBar.Maximum = 50;
            this.vertCountTrackBar.Minimum = 3;
            this.vertCountTrackBar.Name = "vertCountTrackBar";
            this.vertCountTrackBar.Size = new System.Drawing.Size( 200, 45 );
            this.vertCountTrackBar.TabIndex = 3;
            this.vertCountTrackBar.TickFrequency = 5;
            this.vertCountTrackBar.Value = 3;
            this.vertCountTrackBar.ValueChanged += new System.EventHandler( this.vertCountTrackBar_ValueChanged );
            // 
            // vertCountBox
            // 
            this.vertCountBox.Location = new System.Drawing.Point( 70, 25 );
            this.vertCountBox.Name = "vertCountBox";
            this.vertCountBox.ReadOnly = true;
            this.vertCountBox.Size = new System.Drawing.Size( 60, 20 );
            this.vertCountBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 10, 28 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 38, 13 );
            this.label4.TabIndex = 0;
            this.label4.Text = "Count:";
            // 
            // WaterWaveForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 544, 246 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaterWaveForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Water Wave";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.horAmplitudeTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.horCountTrackBar ) ).EndInit( );
            this.groupBox3.ResumeLayout( false );
            this.groupBox3.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.vertAmplitudeTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.vertCountTrackBar ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox horCountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar horAmplitudeTrackBar;
        private System.Windows.Forms.TextBox horAmplitudeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar horCountTrackBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar vertAmplitudeTrackBar;
        private System.Windows.Forms.TextBox vertAmplitudeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar vertCountTrackBar;
        private System.Windows.Forms.TextBox vertCountBox;
        private System.Windows.Forms.Label label4;
    }
}