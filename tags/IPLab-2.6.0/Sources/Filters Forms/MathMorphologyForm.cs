// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    /// <summary>
    /// Summary description for MathMorphologyForm.
    /// </summary>
    public class MathMorphologyForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox sizeCombo;
        private System.Windows.Forms.Label label1;
        private IPLab.GridArrayInt grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox operatorCombo;

        private static int[] sizes = new int[] { 3, 5, 7, 9, 11, 13, 15 };
        private short[,] se;
        private AForge.Imaging.Filters.IFilter filter;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.GroupBox groupBox2;
        private IPLab.FilterPreview filterPreview;
        private FilterTypes filterType = FilterTypes.Simple;
        private System.Windows.Forms.Label legendLabel;

        // Type enumeration
        public enum FilterTypes
        {
            Simple = 0,
            HitAndMiss = 1
        }

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
        public MathMorphologyForm( FilterTypes filterType )
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent( );

            // filter type
            this.filterType = filterType;

            if ( filterType == FilterTypes.Simple )
            {
                legendLabel.Text = "1 - foreground, -1 - don't care";

                this.operatorCombo.Items.AddRange( new object[] {
                    "Errosion", "Dilatation", "Opening", "Closing", "Top-Hat", "Bottom-Hat" } );
            }
            else
            {
                legendLabel.Text = "1 - foreground, 0 - background, -1 - don't care";

                this.operatorCombo.Items.AddRange( new object[] {
																   "Hit And Miss",
																   "Thickening",
																   "Thinning"} );
            }

            // default kernel
            se = new short[3, 3] {
											 {1, 1, 1},
											 {1, 1, 1},
											 {1, 1, 1}};
            grid.LoadData( se );

            // add kernel sizes
            foreach ( int size in sizes )
            {
                string item = size.ToString( ) + " x " + size.ToString( );
                this.sizeCombo.Items.Add( (object) item );
            }

            // default size
            this.sizeCombo.SelectedIndex = 0;

            // default kernel
            this.operatorCombo.SelectedIndex = 0;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.legendLabel = new System.Windows.Forms.Label( );
            this.loadButton = new System.Windows.Forms.Button( );
            this.saveButton = new System.Windows.Forms.Button( );
            this.grid = new IPLab.GridArrayInt( );
            this.sizeCombo = new System.Windows.Forms.ComboBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.operatorCombo = new System.Windows.Forms.ComboBox( );
            this.OkButton = new System.Windows.Forms.Button( );
            this.cancelButton = new System.Windows.Forms.Button( );
            this.ofd = new System.Windows.Forms.OpenFileDialog( );
            this.sfd = new System.Windows.Forms.SaveFileDialog( );
            this.groupBox2 = new System.Windows.Forms.GroupBox( );
            this.filterPreview = new IPLab.FilterPreview( );
            this.groupBox1.SuspendLayout( );
            this.groupBox2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                | System.Windows.Forms.AnchorStyles.Left )
                | System.Windows.Forms.AnchorStyles.Right );
            this.groupBox1.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.legendLabel,
																					this.loadButton,
																					this.saveButton,
																					this.grid} );
            this.groupBox1.Location = new System.Drawing.Point( 10, 10 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 425, 375 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Structuring Element";
            // 
            // legendLabel
            // 
            this.legendLabel.Anchor = ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left );
            this.legendLabel.BackColor = System.Drawing.Color.White;
            this.legendLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.legendLabel.Location = new System.Drawing.Point( 10, 345 );
            this.legendLabel.Name = "legendLabel";
            this.legendLabel.Size = new System.Drawing.Size( 240, 18 );
            this.legendLabel.TabIndex = 4;
            this.legendLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right );
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point( 340, 345 );
            this.loadButton.Name = "loadButton";
            this.loadButton.TabIndex = 2;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "&Load";
            this.loadButton.Click += new System.EventHandler( this.loadButton_Click );
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right );
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point( 255, 345 );
            this.saveButton.Name = "saveButton";
            this.saveButton.TabIndex = 3;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "&Save";
            this.saveButton.Click += new System.EventHandler( this.saveButton_Click );
            // 
            // grid
            // 
            this.grid.Anchor = ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                | System.Windows.Forms.AnchorStyles.Left )
                | System.Windows.Forms.AnchorStyles.Right );
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
            this.grid.SpecialKeys = SourceGrid2.GridSpecialKeys.Default;
            this.grid.TabIndex = 0;
            this.grid.ValueChanged += new IPLab.GridArrayInt.GridEventHandler( this.grid_ValueChanged );
            // 
            // sizeCombo
            // 
            this.sizeCombo.Anchor = ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right );
            this.sizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombo.Location = new System.Drawing.Point( 450, 30 );
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size( 170, 21 );
            this.sizeCombo.TabIndex = 1;
            this.sizeCombo.SelectedIndexChanged += new System.EventHandler( this.sizeCombo_SelectedIndexChanged );
            // 
            // label1
            // 
            this.label1.Anchor = ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right );
            this.label1.Location = new System.Drawing.Point( 450, 15 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 132, 15 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Structuring element size:";
            // 
            // label2
            // 
            this.label2.Anchor = ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right );
            this.label2.Location = new System.Drawing.Point( 450, 60 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 120, 15 );
            this.label2.TabIndex = 2;
            this.label2.Text = "Morpology operator:";
            // 
            // operatorCombo
            // 
            this.operatorCombo.Anchor = ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right );
            this.operatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorCombo.Location = new System.Drawing.Point( 450, 75 );
            this.operatorCombo.Name = "operatorCombo";
            this.operatorCombo.Size = new System.Drawing.Size( 170, 21 );
            this.operatorCombo.TabIndex = 3;
            this.operatorCombo.SelectedIndexChanged += new System.EventHandler( this.operatorCombo_SelectedIndexChanged );
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right );
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point( 460, 355 );
            this.OkButton.Name = "OkButton";
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ok";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right );
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point( 545, 355 );
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "txt";
            this.ofd.Filter = "Text files (*.txt)|*.txt";
            this.ofd.Title = "Load structuring element from file";
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.FileName = "se.txt";
            this.sfd.Filter = "Text files (*.txt)|*.txt";
            this.sfd.Title = "Save structuring element to file";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right );
            this.groupBox2.Controls.AddRange( new System.Windows.Forms.Control[] {
																					this.filterPreview} );
            this.groupBox2.Location = new System.Drawing.Point( 450, 105 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 170, 175 );
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point( 10, 15 );
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size( 150, 150 );
            this.filterPreview.TabIndex = 8;
            // 
            // MathMorphologyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size( 627, 396 );
            this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.cancelButton,
																		  this.OkButton,
																		  this.operatorCombo,
																		  this.label2,
																		  this.label1,
																		  this.sizeCombo,
																		  this.groupBox1} );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MathMorphologyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mathematical Morphology";
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        // Selection changed in size combo
        private void sizeCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( se != null )
            {
                int size = sizes[this.sizeCombo.SelectedIndex];
                int oldSize = se.GetLength( 0 );
                int d = ( size - oldSize ) >> 1;
                short[,] array = new short[size, size];

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
                        array[i + d, j + d] = se[i, j];
                    }
                }

                se = array;
                grid.LoadData( se );
                UpdateFilter( );
            }
        }

        // Operator changed
        private void operatorCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            UpdateFilter( );
        }

        // Value changed in grid
        private void grid_ValueChanged( object sender, IPLab.GridEventArgs e )
        {
            UpdateFilter( );
        }

        // Update filter
        private void UpdateFilter( )
        {
            if ( se != null )
            {
                if ( filterType == FilterTypes.Simple )
                {
                    switch ( this.operatorCombo.SelectedIndex )
                    {
                        case 0:
                            filter = new Erosion( se );
                            break;
                        case 1:
                            filter = new Dilatation( se );
                            break;
                        case 2:
                            filter = new Opening( se );
                            break;
                        case 3:
                            filter = new Closing( se );
                            break;
                        case 4:
                            filter = new TopHat( se );
                            break;
                        case 5:
                            filter = new BottomHat( se );
                            break;
                    }
                }
                else
                {
                    switch ( this.operatorCombo.SelectedIndex )
                    {
                        case 0:
                            filter = new HitAndMiss( se, HitAndMiss.Modes.HitAndMiss );
                            break;
                        case 1:
                            filter = new HitAndMiss( se, HitAndMiss.Modes.Thickening );
                            break;
                        case 2:
                            filter = new HitAndMiss( se, HitAndMiss.Modes.Thinning );
                            break;
                    }
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
                    Serialize2DimArray.Save( sfd.FileName, se );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed saving structuring elemnt to specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
                    short[,] array = (short[,]) Serialize2DimArray.Load( ofd.FileName, typeof( short ) );
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

                    se = array;
                    grid.LoadData( se );
                    UpdateFilter( );
                }
                catch ( ApplicationException )
                {
                    MessageBox.Show( this, "Failed loading structuring element from specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }
    }
}
