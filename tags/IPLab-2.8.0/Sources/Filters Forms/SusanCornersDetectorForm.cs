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
    public partial class SusanCornersDetectorForm : Form
    {
        SusanCornersDetector detector = new SusanCornersDetector( );
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
        public SusanCornersDetectorForm( )
        {
            InitializeComponent( );

            filter = new CornersMarker( detector );
            filterPreview.Filter = filter;

            // default filtering settings
            diffThresholdTrackBar.Value = detector.DifferenceThreshold;
            geometricalThresholdTrackBar.Value = detector.GeometricalThreshold;
        }

        // Dfference threshold was changed
        private void diffThresholdTrackBar_ValueChanged( object sender, EventArgs e )
        {
            detector.DifferenceThreshold = diffThresholdTrackBar.Value;
            diffThresholdBox.Text = diffThresholdTrackBar.Value.ToString( );
            filterPreview.RefreshFilter( );
        }

        // Geometrical threshold was changed
        private void geometricalThresholdTrackBar_ValueChanged( object sender, EventArgs e )
        {
            detector.GeometricalThreshold = geometricalThresholdTrackBar.Value;
            geometricalThresholdBox.Text = geometricalThresholdTrackBar.Value.ToString( );
            filterPreview.RefreshFilter( );
        }
    }
}
