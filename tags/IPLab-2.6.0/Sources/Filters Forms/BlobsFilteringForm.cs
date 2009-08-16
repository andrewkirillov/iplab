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

using AForge.Imaging.Filters;

namespace IPLab
{
    public partial class BlobsFilteringForm : Form
    {
        private BlobsFiltering filter = new BlobsFiltering( );
        private bool updating = false;

        // Image property
        public Bitmap Image
        {
            set
            {
                filterPreview.Image = value;

                minWidthTrackBar.Maximum  = filterPreview.Image.Width;
                minHeightTrackBar.Maximum = filterPreview.Image.Height;

                minWidthTrackBar.TickFrequency  = minWidthTrackBar.Maximum / 50;
                minHeightTrackBar.TickFrequency = minHeightTrackBar.Maximum / 50;
            }
        }
        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public BlobsFilteringForm( )
        {
            InitializeComponent( );

            filterPreview.Filter = filter;

            // default filtering settings
            minWidthBox.Text  = filter.MinWidth.ToString( );
            minHeightBox.Text = filter.MinHeight.ToString( );

            // uncoupled filtering mode
            modeCombo.SelectedIndex = ( filter.CoupledSizeFiltering ) ? 1 : 0;
        }

        // Minimum width was changed
        private void minWidthBox_TextChanged( object sender, EventArgs e )
        {
            updating = true;

            try
            {
                filter.MinWidth = Math.Min( int.Parse( minWidthBox.Text ), minWidthTrackBar.Maximum );
            }
            catch
            {
                minWidthBox.Text = filter.MinWidth.ToString( );
            }

            minWidthTrackBar.Value = filter.MinWidth;
            filterPreview.RefreshFilter( );

            updating = false;
        }

        // Minimum height was changed
        private void minHeightBox_TextChanged( object sender, EventArgs e )
        {
            updating = true;

            try
            {
                filter.MinHeight = Math.Min( int.Parse( minHeightBox.Text ), minHeightTrackBar.Maximum );
            }
            catch
            {
                minHeightBox.Text = filter.MinHeight.ToString( );
            }

            minHeightTrackBar.Value = filter.MinHeight;
            filterPreview.RefreshFilter( );

            updating = false;
        }

        // Minimum width was changed
        private void minWidthTrackBar_ValueChanged( object sender, EventArgs e )
        {
            if ( !updating )
            {
                minWidthBox.Text = minWidthTrackBar.Value.ToString( );
            }
        }

        // Minimum height was changed
        private void minHeightTrackBar_ValueChanged( object sender, EventArgs e )
        {
            if ( !updating )
            {
                minHeightBox.Text = minHeightTrackBar.Value.ToString( );
            }
        }

        // Filtering mode was changed
        private void modeCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            filter.CoupledSizeFiltering = ( modeCombo.SelectedIndex == 1 );
            filterPreview.RefreshFilter( );
        }
    }
}
