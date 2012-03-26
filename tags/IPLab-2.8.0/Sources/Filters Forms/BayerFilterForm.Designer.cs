namespace IPLab
{
    partial class BayerFilterForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.mosaicTypeCombo = new System.Windows.Forms.ComboBox( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 101, 70 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 16, 70 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.mosaicTypeCombo );
            this.groupBox2.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 170, 50 );
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mosaic type";
            // 
            // mosaicTypeCombo
            // 
            this.mosaicTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mosaicTypeCombo.FormattingEnabled = true;
            this.mosaicTypeCombo.Items.AddRange( new object[] {
            "GRBG",
            "BGGR"} );
            this.mosaicTypeCombo.Location = new System.Drawing.Point( 10, 19 );
            this.mosaicTypeCombo.Name = "mosaicTypeCombo";
            this.mosaicTypeCombo.Size = new System.Drawing.Size( 150, 21 );
            this.mosaicTypeCombo.TabIndex = 0;
            this.mosaicTypeCombo.SelectedIndexChanged += new System.EventHandler( this.mosaicTypeCombo_SelectedIndexChanged );
            // 
            // BayerFilterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 193, 106 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BayerFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bayer filter";
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox mosaicTypeCombo;
    }
}