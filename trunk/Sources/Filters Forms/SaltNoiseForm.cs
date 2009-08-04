// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge;
using AForge.Math.Random;
using AForge.Imaging.Filters;

namespace IPLab
{
    public partial class SaltNoiseForm : Form
    {
        private SaltAndPepperNoise filter = new SaltAndPepperNoise( );

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
        public SaltNoiseForm( )
        {
            InitializeComponent( );

            //
            noiseAmountBox.Text = filter.NoiseAmount.ToString( );
            noiseAmountTrackBar.Value = (int) filter.NoiseAmount;

            filterPreview.Filter = filter;
        }

        // Value of noise amount track bar changed
        private void noiseAmountTrackBar_ValueChanged( object sender, EventArgs e )
        {
            noiseAmountBox.Text = noiseAmountTrackBar.Value.ToString( );
        }

        // Value of noise amount box changed
        private void noiseAmountBox_TextChanged( object sender, EventArgs e )
        {
            try
            {
                filter.NoiseAmount = double.Parse( noiseAmountBox.Text );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}