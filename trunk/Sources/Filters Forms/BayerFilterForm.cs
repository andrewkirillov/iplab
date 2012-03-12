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
    public partial class BayerFilterForm : Form
    {
        private BayerFilterOptimized filter = new BayerFilterOptimized( );

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public BayerFilterForm( )
        {
            InitializeComponent( );

            mosaicTypeCombo.SelectedIndex = 0;
        }

        static BayerPattern[] patterns = new BayerPattern[] { BayerPattern.GRBG, BayerPattern.BGGR };

        // Bayer pattern has changed
        private void mosaicTypeCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            filter.Pattern = patterns[mosaicTypeCombo.SelectedIndex];
        }
    }
}
