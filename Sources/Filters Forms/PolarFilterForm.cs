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
    public partial class PolarFilterForm : Form
    {
        private IFilter filter = null;
        private bool toPolar;

        // Filter property
        public IFilter Filter
        {
            get { return filter; }
        }

        // Constructor
        public PolarFilterForm( bool toPolar, Size originalSize )
        {
            InitializeComponent( );
            this.toPolar = toPolar;

            if ( toPolar )
            {
                Text = "Transform To Polar";
                filter = new TransformToPolar( );
                ( (TransformToPolar) filter ).UseOriginalImageSize = false;

                colorButton.BackColor = ( (TransformToPolar) filter ).FillColor;
            }
            else
            {
                Text = "Transform From Polar";
                filter = new TransformFromPolar( );
                ( (TransformFromPolar) filter ).UseOriginalImageSize = false;

                fillColorLabel.Visible = false;
                colorButton.Visible = false;
            }

            offsetAngleUpDown.Value = 0;
            circleDepthUpDown.Value = 1;

            newWidthUpDown.Value = originalSize.Width;
            newHeightUpDown.Value = originalSize.Height;

            mapBackwardsCheck.Checked = false;
            mapFromTopCheck.Checked = true;
        }

        private void offsetAngleUpDown_ValueChanged( object sender, EventArgs e )
        {
            double value = (double) offsetAngleUpDown.Value;

            if ( toPolar )
            {
                ( (TransformToPolar) filter ).OffsetAngle = value;
            }
            else
            {
                ( (TransformFromPolar) filter ).OffsetAngle = value;
            }
        }

        private void circleDepthUpDown_ValueChanged( object sender, EventArgs e )
        {
            double value = (double) circleDepthUpDown.Value;

            if ( toPolar )
            {
                ( (TransformToPolar) filter ).CirlceDepth = value;
            }
            else
            {
                ( (TransformFromPolar) filter ).CirlceDepth = value;
            }
        }

        private void newSizeUpDown_ValueChanged( object sender, EventArgs e )
        {
            Size newSize = new Size( (int) newWidthUpDown.Value, (int) newHeightUpDown.Value );

            if ( toPolar )
            {
                ( (TransformToPolar) filter ).NewSize = newSize;
            }
            else
            {
                ( (TransformFromPolar) filter ).NewSize = newSize;
            }
        }

        private void mapBackwardsCheck_CheckedChanged( object sender, EventArgs e )
        {
            bool value = mapBackwardsCheck.Checked;

            if ( toPolar )
            {
                ( (TransformToPolar) filter ).MapBackwards = value;
            }
            else
            {
                ( (TransformFromPolar) filter ).MapBackwards = value;
            }
        }

        private void mapFromTopCheck_CheckedChanged( object sender, EventArgs e )
        {
            bool value = mapFromTopCheck.Checked;

            if ( toPolar )
            {
                ( (TransformToPolar) filter ).MapFromTop = value;
            }
            else
            {
                ( (TransformFromPolar) filter ).MapFromTop = value;
            }
        }

        private void colorButton_Click( object sender, EventArgs e )
        {
            if ( colorDialog.ShowDialog( ) == DialogResult.OK )
            {
                colorButton.BackColor = colorDialog.Color;
                ( (TransformToPolar) filter ).FillColor = colorDialog.Color;
            }
        }
    }
}
