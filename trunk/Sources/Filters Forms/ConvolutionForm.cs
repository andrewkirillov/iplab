// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for ConvolutionForm.
    /// </summary>
    public class ConvolutionForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox sizeCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private IPLab.GridArrayInt grid;
        private System.Windows.Forms.Label label1;

        private static int[] sizes = new int[] { 3, 5, 7, 9, 11, 13, 15 };
        private int[,] kernel;
        private AForge.Imaging.Filters.Convolution filter;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private IPLab.FilterPreview filterPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private Label label2;
        private TextBox thresholdBox;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }
        // Image property
        public Bitmap Image
        {
            set { filterPreview.Image = value; }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        // Constructor
        public ConvolutionForm( )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // default kernel
            kernel = new int[3, 3] {
											 {1, 1, 1},
											 {1, 1, 1},
											 {1, 1, 1}};
            grid.LoadData( kernel );

            // add kernel sizes
            foreach ( int size in sizes )
            {
                string item = size.ToString( ) + " x " + size.ToString( );
                this.sizeCombo.Items.Add( (object) item );
            }

            // default size
            this.sizeCombo.SelectedIndex = 0;
            // default threshold
            thresholdBox.Text = filter.Threshold.ToString( );
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
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
            this.sizeCombo = new System.Windows.Forms.ComboBox( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.loadButton = new System.Windows.Forms.Button( );
            this.saveButton = new System.Windows.Forms.Button( );
            this.grid = new IPLab.GridArrayInt( );
            this.label1 = new System.Windows.Forms.Label( );
            this.sfd = new System.Windows.Forms.SaveFileDialog( );
            this.ofd = new System.Windows.Forms.OpenFileDialog( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.thresholdBox = new System.Windows.Forms.TextBox( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 545, 355 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point( 460, 355 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 75, 23 );
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            // 
            // sizeCombo
            // 
            this.sizeCombo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.sizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombo.Location = new System.Drawing.Point( 450, 30 );
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size( 170, 21 );
            this.sizeCombo.TabIndex = 1;
            this.sizeCombo.SelectedIndexChanged += new System.EventHandler( this.sizeCombo_SelectedIndexChanged );
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.groupBox1.Controls.Add( this.loadButton );
            this.groupBox1.Controls.Add( this.saveButton );
            this.groupBox1.Controls.Add( this.grid );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 425, 375 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kernel";
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point( 340, 344 );
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size( 75, 23 );
            this.loadButton.TabIndex = 0;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "&Load";
            this.loadButton.Click += new System.EventHandler( this.loadButton_Click );
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point( 260, 344 );
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size( 75, 23 );
            this.saveButton.TabIndex = 1;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler( this.saveButton_Click );
            // 
            // grid
            // 
            this.grid.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.CustomSort = false;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point( 10, 20 );
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size( 405, 315 );
            this.grid.SpecialKeys = ( (SourceGrid2.GridSpecialKeys) ( ( ( ( ( ( ( ( ( ( ( SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V )
                        | SourceGrid2.GridSpecialKeys.Ctrl_X )
                        | SourceGrid2.GridSpecialKeys.Delete )
                        | SourceGrid2.GridSpecialKeys.Arrows )
                        | SourceGrid2.GridSpecialKeys.Tab )
                        | SourceGrid2.GridSpecialKeys.PageDownUp )
                        | SourceGrid2.GridSpecialKeys.Enter )
                        | SourceGrid2.GridSpecialKeys.Escape )
                        | SourceGrid2.GridSpecialKeys.Control )
                        | SourceGrid2.GridSpecialKeys.Shift ) ) );
            this.grid.TabIndex = 2;
            this.grid.TabStop = true;
            this.grid.ValueChanged += new IPLab.GridArrayInt.GridEventHandler( this.grid_ValueChanged );
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.Location = new System.Drawing.Point( 450, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 66, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Kernel size:";
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.FileName = "kernel.txt";
            this.sfd.Filter = "Text files (*.txt)|*.txt";
            this.sfd.Title = "Save kernel to file";
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "txt";
            this.ofd.Filter = "Text files (*.txt)|*.txt";
            this.ofd.Title = "Load kernel from file";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.groupBox2.Controls.Add( this.filterPreview );
            this.groupBox2.Location = new System.Drawing.Point( 450, 105 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 450, 68 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 57, 13 );
            this.label2.TabIndex = 10;
            this.label2.Text = "Threshold:";
            // 
            // thresholdBox
            // 
            this.thresholdBox.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.thresholdBox.Location = new System.Drawing.Point( 510, 65 );
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.Size = new System.Drawing.Size( 105, 20 );
            this.thresholdBox.TabIndex = 11;
            this.thresholdBox.TextChanged += new System.EventHandler( this.thresholdBox_TextChanged );
            // 
            // ConvolutionForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 627, 396 );
            this.Controls.Add( this.thresholdBox );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.cancelButton );
            this.Controls.Add( this.okButton );
            this.Controls.Add( this.sizeCombo );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ConvolutionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convolution & Correlation";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }
        #endregion

        // Selection changed in size combo
        private void sizeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( kernel != null )
            {
                int size = sizes[this.sizeCombo.SelectedIndex];
                int oldSize = kernel.GetLength( 0 );
                int d = ( size - oldSize ) >> 1;
                int[,] array = new int[size, size];

                // copy old kernel into new
                for ( int i = 0; i < oldSize; i++ )
                {
                    if ( i + d < 0 )
                        continue;
                    if ( i + d >= size )
                        break;

                    for ( int j = 0; j < oldSize; j++ )
                    {
                        if ( j + d < 0 )
                            continue;
                        if ( j + d >= size )
                            break;
                        array[i + d, j + d] = kernel[i, j];
                    }
                }

                kernel = array;
                grid.LoadData( kernel );

                UpdateFilter( );
            }
        }

        // Value changed in grid
        private void grid_ValueChanged( object sender, IPLab.GridEventArgs e )
        {
            UpdateFilter( );
        }

        // Update filter
        private void UpdateFilter( )
        {
            if ( kernel != null )
            {
                try
                {
                    filter = new Convolution( kernel );
                    filter.Threshold = int.Parse( thresholdBox.Text );
                }
                catch
                {

                }
            }
            filterPreview.Filter = filter;
        }

        // On "Save" button - save kernel
        private void saveButton_Click( object sender, System.EventArgs e )
        {
            if ( sfd.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    Serialize2DimArray.Save( sfd.FileName, kernel );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed saving kernel to specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        // On "Load" button - load kernel
        private void loadButton_Click( object sender, System.EventArgs e )
        {
            if ( ofd.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    int[,] array = (int[,]) Serialize2DimArray.Load( ofd.FileName, typeof( int ) );
                    int size = array.GetLength( 0 );
                    int i;

                    // check size
                    if ( size != array.GetLength( 1 ) )
                        throw new ApplicationException( );

                    for ( i = 0; i < sizes.Length; i++ )
                    {
                        if ( size == sizes[i] )
                        {
                            this.sizeCombo.SelectedIndex = i;
                            break;
                        }
                    }
                    if ( i == sizes.Length )
                        throw new ApplicationException( );

                    kernel = array;
                    grid.LoadData( kernel );

                    UpdateFilter( );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed loading kernel from specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        // Threshold value is chenged
        private void thresholdBox_TextChanged( object sender, EventArgs e )
        {
            UpdateFilter( );
        }
    }
}
