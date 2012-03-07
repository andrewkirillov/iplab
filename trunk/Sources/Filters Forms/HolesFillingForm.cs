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
    public partial class HolesFillingForm : Form
    {
        private FillHoles filter = new FillHoles( );
        private bool updating = false;

        // Image property
        public Bitmap Image
        {
            set
            {
                filterPreview.Image = value;

                maxWidthTrackBar.Maximum = filterPreview.Image.Width;
                maxHeightTrackBar.Maximum = filterPreview.Image.Height;

                maxWidthTrackBar.TickFrequency = maxWidthTrackBar.Maximum / 50;
                maxHeightTrackBar.TickFrequency = maxHeightTrackBar.Maximum / 50;
            }
        }

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public HolesFillingForm( )
        {
            InitializeComponent( );

            filter.MaxHoleWidth  = 100;
            filter.MaxHoleHeight = 100;
            filterPreview.Filter = filter;

            // default filtering settings
            maxWidthBox.Text = filter.MaxHoleWidth.ToString( );
            maxHeightBox.Text = filter.MaxHoleHeight.ToString( );

            // uncoupled filtering mode
            modeCombo.SelectedIndex = ( filter.CoupledSizeFiltering ) ? 1 : 0;
        }

        // Maximum hole width was changed
        private void maxWidthBox_TextChanged( object sender, EventArgs e )
        {
            updating = true;

            try
            {
                filter.MaxHoleWidth = Math.Min( int.Parse( maxWidthBox.Text ), maxWidthTrackBar.Maximum );
            }
            catch
            {
                maxWidthBox.Text = filter.MaxHoleWidth.ToString( );
            }

            maxWidthTrackBar.Value = filter.MaxHoleWidth;
            filterPreview.RefreshFilter( );

            updating = false;
        }

        // Maximum hole height was changed
        private void maxHeightBox_TextChanged( object sender, EventArgs e )
        {
            updating = true;

            try
            {
                filter.MaxHoleHeight = Math.Min( int.Parse( maxHeightBox.Text ), maxHeightTrackBar.Maximum );
            }
            catch
            {
                maxHeightBox.Text = filter.MaxHoleHeight.ToString( );
            }

            maxHeightTrackBar.Value = filter.MaxHoleHeight;
            filterPreview.RefreshFilter( );

            updating = false;
        }

        // Maximum hole width was changed
        private void maxWidthTrackBar_ValueChanged( object sender, EventArgs e )
        {
            if ( !updating )
            {
                maxWidthBox.Text = maxWidthTrackBar.Value.ToString( );
            }
        }

        // Maximum hole height was changed
        private void maxHeightTrackBar_ValueChanged( object sender, EventArgs e )
        {
            if ( !updating )
            {
                maxHeightBox.Text = maxHeightTrackBar.Value.ToString( );
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
