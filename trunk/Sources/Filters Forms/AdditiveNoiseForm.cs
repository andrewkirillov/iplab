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
    public partial class AdditiveNoiseForm : Form
    {
        private AdditiveNoise filter = new AdditiveNoise( );

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
        public AdditiveNoiseForm( )
        {
            InitializeComponent( );

            //
            noiseAmplitudeBox.Text = "10";
            noiseAmplitudeTrackBar.Value = 10;

            filterPreview.Filter = filter;
        }

        // Value of noise amplitude track bar changed
        private void noiseAmplitudeTrackBar_ValueChanged( object sender, EventArgs e )
        {
            noiseAmplitudeBox.Text = noiseAmplitudeTrackBar.Value.ToString( );
        }

        // Value of noise amplitude box changed
        private void noiseAmplitudeBox_TextChanged( object sender, EventArgs e )
        {
            try
            {
                int amplitude = int.Parse( noiseAmplitudeBox.Text );
                filter.Generator = new UniformGenerator( new DoubleRange( -amplitude, amplitude ) );
                filterPreview.RefreshFilter( );
            }
            catch ( Exception )
            {
            }
        }
    }
}