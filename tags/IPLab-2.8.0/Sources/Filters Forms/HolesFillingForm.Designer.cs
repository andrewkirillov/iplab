namespace IPLab
{
    partial class HolesFillingForm
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
            this.maxHeightBox = new System.Windows.Forms.TextBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.maxHeightTrackBar = new System.Windows.Forms.TrackBar( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.maxWidthTrackBar = new System.Windows.Forms.TrackBar( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.modeCombo = new System.Windows.Forms.ComboBox( );
            this.maxWidthBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.okButton = new System.Windows.Forms.Button( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxHeightTrackBar ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxWidthTrackBar ) ).BeginInit( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // maxHeightBox
            // 
            this.maxHeightBox.Location = new System.Drawing.Point( 160, 140 );
            this.maxHeightBox.Name = "maxHeightBox";
            this.maxHeightBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxHeightBox.TabIndex = 5;
            this.maxHeightBox.TextChanged += new System.EventHandler( this.maxHeightBox_TextChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.filterPreview );
            this.groupBox1.Location = new System.Drawing.Point( 290, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // maxHeightTrackBar
            // 
            this.maxHeightTrackBar.Location = new System.Drawing.Point( 10, 160 );
            this.maxHeightTrackBar.Maximum = 10000;
            this.maxHeightTrackBar.Minimum = 1;
            this.maxHeightTrackBar.Name = "maxHeightTrackBar";
            this.maxHeightTrackBar.Size = new System.Drawing.Size( 250, 45 );
            this.maxHeightTrackBar.TabIndex = 6;
            this.maxHeightTrackBar.Value = 1;
            this.maxHeightTrackBar.ValueChanged += new System.EventHandler( this.maxHeightTrackBar_ValueChanged );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 387, 204 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            // 
            // maxWidthTrackBar
            // 
            this.maxWidthTrackBar.Location = new System.Drawing.Point( 10, 45 );
            this.maxWidthTrackBar.Maximum = 10000;
            this.maxWidthTrackBar.Minimum = 1;
            this.maxWidthTrackBar.Name = "maxWidthTrackBar";
            this.maxWidthTrackBar.Size = new System.Drawing.Size( 250, 45 );
            this.maxWidthTrackBar.TabIndex = 2;
            this.maxWidthTrackBar.Value = 1;
            this.maxWidthTrackBar.ValueChanged += new System.EventHandler( this.maxWidthTrackBar_ValueChanged );
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.maxHeightTrackBar );
            this.groupBox2.Controls.Add( this.maxHeightBox );
            this.groupBox2.Controls.Add( this.maxWidthTrackBar );
            this.groupBox2.Controls.Add( this.label2 );
            this.groupBox2.Controls.Add( this.modeCombo );
            this.groupBox2.Controls.Add( this.maxWidthBox );
            this.groupBox2.Controls.Add( this.label1 );
            this.groupBox2.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 270, 215 );
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fill holes, which ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 10, 143 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 151, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Height is smaller than or equal:";
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
            // maxWidthBox
            // 
            this.maxWidthBox.Location = new System.Drawing.Point( 160, 25 );
            this.maxWidthBox.Name = "maxWidthBox";
            this.maxWidthBox.Size = new System.Drawing.Size( 50, 20 );
            this.maxWidthBox.TabIndex = 1;
            this.maxWidthBox.TextChanged += new System.EventHandler( this.maxWidthBox_TextChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 10, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 148, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Width is smaller than or equal:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 302, 204 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 18;
            this.okButton.Text = "Ok";
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
            // HolesFillingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 474, 238 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.okButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HolesFillingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Holes Filling";
            this.groupBox1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxHeightTrackBar ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.maxWidthTrackBar ) ).EndInit( );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TextBox maxHeightBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private FilterPreview filterPreview;
        private System.Windows.Forms.TrackBar maxHeightTrackBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TrackBar maxWidthTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modeCombo;
        private System.Windows.Forms.TextBox maxWidthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
    }
}