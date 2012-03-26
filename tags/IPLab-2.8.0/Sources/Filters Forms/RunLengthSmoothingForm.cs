// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2012
// andrew.kirillov@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    public partial class RunLengthSmoothingForm : Form
    {
        private IFilter filter = null;

        // Image property
        public Bitmap Image
        {
            set { filterPreview.Image = value; }
        }

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public RunLengthSmoothingForm( )
        {
            InitializeComponent( );

            typeCombo.SelectedIndex = 0;
            maxGapUpDown.Value = 10;
        }

        private void typeCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            int maxGapSize = (int) maxGapUpDown.Value;

            if ( typeCombo.SelectedIndex == 0 )
            {
                filter = new HorizontalRunLengthSmoothing( maxGapSize );
            }
            else
            {
                filter = new VerticalRunLengthSmoothing( maxGapSize );
            }

            filterPreview.Filter = filter;
            filterPreview.RefreshFilter( );
        }

        private void maxGapUpDown_ValueChanged( object sender, EventArgs e )
        {
            int maxGapSize = (int) maxGapUpDown.Value;

            if ( typeCombo.SelectedIndex == 0 )
            {
                ( (HorizontalRunLengthSmoothing) filter ).MaxGapSize = maxGapSize;
            }
            else
            {
                ( (VerticalRunLengthSmoothing) filter ).MaxGapSize = maxGapSize;
            }

            filterPreview.RefreshFilter( );
        }

        private void processBordersCheck_CheckedChanged( object sender, EventArgs e )
        {
            bool processBorders = processBordersCheck.Checked;

            if ( typeCombo.SelectedIndex == 0 )
            {
                ( (HorizontalRunLengthSmoothing) filter ).ProcessGapsWithImageBorders = processBorders;
            }
            else
            {
                ( (VerticalRunLengthSmoothing) filter ).ProcessGapsWithImageBorders = processBorders;
            }

            filterPreview.RefreshFilter( );
        }
    }
}
