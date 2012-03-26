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
    public partial class MoveTowardsFilterForm : Form
    {
        private MoveTowards filter;

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
        public MoveTowardsFilterForm( Bitmap overlay )
        {
            InitializeComponent( );

            // create filter
            filter = new MoveTowards( overlay );
            // set percent value on track bar
            stepSizeBar.Value = (int) ( filter.StepSize );
            // set filter for preview window
            filterPreview.Filter = filter;
        }

        private void stepSizeBar_Scroll( object sender, EventArgs e )
        {
            filter.StepSize = (int) stepSizeBar.Value;
            filterPreview.RefreshFilter( );
        }
    }
}
