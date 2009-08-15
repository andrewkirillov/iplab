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

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace IPLab
{
    public partial class MoravecCornersDetectorForm : Form
    {
        MoravecCornersDetector detector = new MoravecCornersDetector( );
        CornersMarker filter = null;

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
        public MoravecCornersDetectorForm( )
        {
            InitializeComponent( );

            filter = new CornersMarker( detector );
            filterPreview.Filter = filter;

            // default filtering settings
            thresholdTrackBar.Value  = detector.Threshold;
            windowSizeCombo.SelectedIndex = 0;
        }

        // Threshold was changed
        private void thresholdTrackBar_ValueChanged( object sender, EventArgs e )
        {
            detector.Threshold = thresholdTrackBar.Value;
            thresholdBox.Text = thresholdTrackBar.Value.ToString( );
            filterPreview.RefreshFilter( );
        }

        // Window size was changed
        private void windowSizeCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            detector.WindowSize = 3 + windowSizeCombo.SelectedIndex * 2;
            filterPreview.RefreshFilter( );
        }
    }
}
