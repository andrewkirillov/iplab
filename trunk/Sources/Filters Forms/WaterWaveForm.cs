// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2010
// andrew.kirillov@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using AForge.Imaging.Filters;

namespace IPLab
{
    public partial class WaterWaveForm : Form
    {
        private WaterWave filter = new WaterWave( );

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
        public WaterWaveForm( )
        {
            InitializeComponent( );

            filterPreview.Filter = filter;

            horCountTrackBar.Value = filter.HorizontalWavesCount;
            horAmplitudeTrackBar.Value = filter.HorizontalWavesAmplitude;

            vertCountTrackBar.Value = filter.VerticalWavesCount;
            vertAmplitudeTrackBar.Value = filter.VerticalWavesAmplitude;
        }

        private void horCountTrackBar_ValueChanged( object sender, EventArgs e )
        {
            horCountBox.Text = horCountTrackBar.Value.ToString( );
            filter.HorizontalWavesCount = horCountTrackBar.Value;
            filterPreview.RefreshFilter( );
        }

        private void horAmplitudeTrackBar_ValueChanged( object sender, EventArgs e )
        {
            horAmplitudeBox.Text = horAmplitudeTrackBar.Value.ToString( );
            filter.HorizontalWavesAmplitude = horAmplitudeTrackBar.Value;
            filterPreview.RefreshFilter( );
        }

        private void vertCountTrackBar_ValueChanged( object sender, EventArgs e )
        {
            vertCountBox.Text = vertCountTrackBar.Value.ToString( );
            filter.VerticalWavesCount = vertCountTrackBar.Value;
            filterPreview.RefreshFilter( );
        }

        private void vertAmplitudeTrackBar_ValueChanged( object sender, EventArgs e )
        {
            vertAmplitudeBox.Text = vertAmplitudeTrackBar.Value.ToString( );
            filter.VerticalWavesAmplitude = vertAmplitudeTrackBar.Value;
            filterPreview.RefreshFilter( );
        }
    }
}
