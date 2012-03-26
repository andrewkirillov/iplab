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
    public partial class BilateralForm : Form
    {
        private BilateralSmoothing filter = new BilateralSmoothing( );

        // Image property
        public Bitmap Image
        {
            set
            {
                filterPreview.Image = value;
            }
        }

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public BilateralForm( )
        {
            InitializeComponent( );

            kernelSizeUpDown.Value = filter.KernelSize;
            spatialFactorUpDown.Value = new decimal( filter.SpatialFactor );
            spatialPowerUpDown.Value = new decimal( filter.SpatialPower );
            colorFactorUpDown.Value = new decimal( filter.ColorFactor );
            colorPowerUpDown.Value = new decimal( filter.ColorPower );

            filter.EnableParallelProcessing = true;
            filterPreview.Filter = filter;
        }

        // Kernel size has changed
        private void kernelSizeUpDown_ValueChanged( object sender, EventArgs e )
        {
            int correctValue = (int) kernelSizeUpDown.Value | 1;

            if ( kernelSizeUpDown.Value != correctValue )
            {
                kernelSizeUpDown.Value = correctValue;
            }
            else
            {
                filter.KernelSize = correctValue;
                filterPreview.RefreshFilter( );
            }
        }

        // Spatial factor has changed
        private void spatialFactorUpDown_ValueChanged( object sender, EventArgs e )
        {
            filter.SpatialFactor = (double) spatialFactorUpDown.Value;
            filterPreview.RefreshFilter( );
        }

        // Spatial power has changed
        private void spatialPowerUpDown_ValueChanged( object sender, EventArgs e )
        {
            filter.SpatialPower = (double) spatialPowerUpDown.Value;
            filterPreview.RefreshFilter( );
        }

        // Color factor has changed
        private void colorFactorUpDown_ValueChanged( object sender, EventArgs e )
        {
            filter.ColorFactor = (double) colorFactorUpDown.Value;
            filterPreview.RefreshFilter( );
        }

        // Color power has changed
        private void colorPowerUpDown_ValueChanged( object sender, EventArgs e )
        {
            filter.ColorPower = (double) colorPowerUpDown.Value;
            filterPreview.RefreshFilter( );
        }
    }
}
