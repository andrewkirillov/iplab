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
    public partial class SimplePosterizationForm : Form
    {
        private SimplePosterization filter = new SimplePosterization( );
        private bool updating = false;

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
        public SimplePosterizationForm( )
        {
            InitializeComponent( );

            filterPreview.Filter = filter;

            // default filtering settings
            posterizationIntervalTrackBar.Value = filter.PosterizationInterval;
            fillTypeCombo.SelectedIndex = (int) filter.FillingType;
        }


        // Posterization interval was changed
        private void posterizationIntervalBox_TextChanged( object sender, EventArgs e )
        {
            updating = true;

            try
            {
                filter.PosterizationInterval = (byte) Math.Max( 2, Math.Min( 128,
                    int.Parse( posterizationIntervalBox.Text ) ) );
            }
            catch
            {
                posterizationIntervalBox.Text = filter.PosterizationInterval.ToString( );
            }

            posterizationIntervalTrackBar.Value = filter.PosterizationInterval;
            filterPreview.RefreshFilter( );

            updating = false;
        }

        // Posterization interval was changed
        private void posterizationIntervalTrackBar_ValueChanged( object sender, EventArgs e )
        {
            if ( !updating )
            {
                posterizationIntervalBox.Text = posterizationIntervalTrackBar.Value.ToString( );
            }
        }

        // Fill type was changed
        private void fillTypeCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            filter.FillingType = (SimplePosterization.PosterizationFillingType) fillTypeCombo.SelectedIndex;
            filterPreview.RefreshFilter( );
        }
    }
}
