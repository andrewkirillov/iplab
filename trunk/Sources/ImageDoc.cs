// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2010
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace IPLab
{
    /// <summary>
    /// Summary description for ImageDoc.
    /// </summary>
    public partial class ImageDoc : Content
    {
        private System.Drawing.Bitmap backup = null;
        private System.Drawing.Bitmap image = null;
        private string fileName = null;
        private int width;
        private int height;
        private float zoom = 1;
        private IDocumentsHost host = null;

        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;

        // Image property
        public Bitmap Image
        {
            get { return image; }
        }
        // Width property
        public int ImageWidth
        {
            get { return width; }
        }
        // Height property
        public int ImageHeight
        {
            get { return height; }
        }
        // Zoom property
        public float Zoom
        {
            get { return zoom; }
        }
        // FileName property
        // return file name if the document was created from file or null
        public string FileName
        {
            get { return fileName; }
        }


        // Events
        public delegate void SelectionEventHandler( object sender, SelectionEventArgs e );

        public event EventHandler DocumentChanged;
        public event EventHandler ZoomChanged;
        public event SelectionEventHandler MouseImagePosition;
        public event SelectionEventHandler SelectionChanged;


        // Constructors
        private ImageDoc( IDocumentsHost host )
        {
            this.host = host;
        }

        // Construct from file
        public ImageDoc( string fileName, IDocumentsHost host ) : this( host )
        {
            try
            {
                image = LoadImageFromFile( fileName );

                // format image
                if ( !AForge.Imaging.Image.IsGrayscale( image ) && ( image.PixelFormat != PixelFormat.Format24bppRgb ) )
                {
                    Bitmap temp = AForge.Imaging.Image.Clone( image, PixelFormat.Format24bppRgb );
                    image.Dispose( );
                    image = temp;
                }

                this.fileName = fileName;
            }
            catch ( Exception )
            {
                throw new ApplicationException( "Failed loading image" );
            }

            Init( );
        }

        // Construct from image
        public ImageDoc( Bitmap image, IDocumentsHost host ) : this( host )
        {
            this.image = image;

            if ( !AForge.Imaging.Image.IsGrayscale( image ) && ( image.PixelFormat != PixelFormat.Format24bppRgb ) )
            {
                this.image = AForge.Imaging.Image.Clone( image, PixelFormat.Format24bppRgb );
            }

            Init( );
        }

        // Init the document
        private void Init( )
        {
            // init components
            InitializeComponent( );

            // form style
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );

            // init scroll bars
            this.AutoScroll = true;

            UpdateSize( );
        }

        // Load image from file
        private Bitmap LoadImageFromFile( string fileName )
        {
            Bitmap loadedImage = null;
            FileStream stream = null;

            try
            {
                // read image to temporary memory stream
                // (.NET locks any stream until bitmap is disposed,
                // so that is why this work around is required to prevent file locking)
                stream = File.OpenRead( fileName );
                MemoryStream memoryStream = new MemoryStream( );

                byte[] buffer = new byte[10000];
                while ( true )
                {
                    int read = stream.Read( buffer, 0, 10000 );

                    if ( read == 0 )
                        break;

                    memoryStream.Write( buffer, 0, read );
                }

                loadedImage = (Bitmap) Bitmap.FromStream( memoryStream );
            }
            finally
            {
                if ( stream != null )
                {
                    stream.Close( );
                    stream.Dispose( );
                }
            }

            return loadedImage;
        }

        // Execute command
        public void ExecuteCommand( ImageDocCommands cmd )
        {
            switch ( cmd )
            {
                case ImageDocCommands.Clone:		// clone the image
                    Clone( );
                    break;
                case ImageDocCommands.Crop:			// crop the image
                    Crop( );
                    break;
                case ImageDocCommands.ZoomIn:		// zoom in
                    ZoomIn( );
                    break;
                case ImageDocCommands.ZoomOut:		// zoom out
                    ZoomOut( );
                    break;
                case ImageDocCommands.ZoomOriginal:	// original size
                    zoom = 1;
                    UpdateZoom( );
                    break;
                case ImageDocCommands.FitToSize:	// fit to screen
                    FitToScreen( );
                    break;
                case ImageDocCommands.Levels:		// levels
                    Levels( );
                    break;
                case ImageDocCommands.Grayscale:	// grayscale
                    Grayscale( );
                    break;
                case ImageDocCommands.Threshold:	// threshold
                    Threshold( );
                    break;
                case ImageDocCommands.Morphology:	// morphology
                    Morphology( );
                    break;
                case ImageDocCommands.Convolution:	// convolution
                    Convolution( );
                    break;
                case ImageDocCommands.Resize:		// resize the image
                    ResizeImage( );
                    break;
                case ImageDocCommands.Rotate:		// rotate the image
                    RotateImage( );
                    break;
                case ImageDocCommands.Brightness:	// adjust brightness
                    Brightness( );
                    break;
                case ImageDocCommands.Contrast:		// modify contrast
                    Contrast( );
                    break;
                case ImageDocCommands.Saturation:	// adjust saturation
                    Saturation( );
                    break;
                case ImageDocCommands.Fourier:		// fourier transformation
                    ForwardFourierTransformation( );
                    break;
            }
        }

        // Update document and notify client about changes
        private void UpdateNewImage( )
        {
            // update size
            UpdateSize( );
            // repaint
            Invalidate( );

            // notify host
            if ( DocumentChanged != null )
                DocumentChanged( this, null );
        }

        // Reload image from file
        public void Reload( )
        {
            if ( fileName != null )
            {
                try
                {
                    // load image
                    Bitmap newImage = LoadImageFromFile( fileName );

                    // release current image
                    image.Dispose( );
                    // set document image to just loaded
                    image = newImage;

                    // format image
                    if ( !AForge.Imaging.Image.IsGrayscale( image ) && ( image.PixelFormat != PixelFormat.Format24bppRgb ) )
                    {
                        Bitmap temp = AForge.Imaging.Image.Clone( image, PixelFormat.Format24bppRgb );
                        image.Dispose( );
                        image = temp;
                    }
                }
                catch ( Exception )
                {
                    throw new ApplicationException( "Failed reloading image" );
                }

                // update
                UpdateNewImage( );
            }
        }

        // Center image in the document
        public void Center( )
        {
            Rectangle rc = ClientRectangle;
            Point p = this.AutoScrollPosition;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );

            if ( rc.Width < width )
                p.X = ( width - rc.Width ) >> 1;
            if ( rc.Height < height )
                p.Y = ( height - rc.Height ) >> 1;

            this.AutoScrollPosition = p;
        }

        // Update document size 
        private void UpdateSize( )
        {
            // image dimension
            width = image.Width;
            height = image.Height;

            // scroll bar size
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
        }

        // Check if the image is color RGB image
        private bool CheckIfColor( string filterName )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( filterName + " can be applied to RGB images only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return false;
            }
            return true;
        }

        // Check if the image is grayscale image
        private bool CheckIfGrayscale( string filterName )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( filterName + " can be applied to grayscale images only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return false;
            }
            return true;
        }

        // Check if the image is binary image
        private bool CheckIfBinary( string filterName )
        {
            // check pixel format (binary images are represented as grayscale images to simplify image processing)
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( filterName + " can be applied to binary images only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return false;
            }
            return true;
        }

        // Paint image
        protected override void OnPaint( PaintEventArgs e )
        {
            if ( image != null )
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen( Color.FromArgb( 0, 0, 0 ) );

                int width = (int) ( this.width * zoom );
                int height = (int) ( this.height * zoom );
                int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                // draw rectangle around the image
                g.DrawRectangle( pen, x - 1, y - 1, width + 1, height + 1 );

                // set nearest neighbor interpolation to avoid image smoothing
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                // draw image
                g.DrawImage( image, x, y, width, height );

                pen.Dispose( );
            }
        }

        // Mouse click
        protected override void OnClick( EventArgs e )
        {
            Focus( );
        }

        // Apply filter on the image
        private void ApplyFilter( IFilter filter )
        {
            if ( filter is IFilterInformation )
            {
                IFilterInformation filterInfo = (IFilterInformation) filter;

                if ( !filterInfo.FormatTranslations.ContainsKey( image.PixelFormat ) )
                {
                    if ( filterInfo.FormatTranslations.ContainsKey( PixelFormat.Format24bppRgb ) )
                    {
                        MessageBox.Show( "The selected image processing routine can be applied to color image only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                    else
                    {
                        MessageBox.Show( "The selected image processing routine can be applied to grayscale or binary image only.\n\nUse grayscale (and threshold filter if required) before.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                    return;
                }
            }

            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply( image );

                if ( host.CreateNewDocumentOnChange )
                {
                    // open new image in new document
                    host.NewDocument( newImage );
                }
                else
                {
                    if ( host.RememberOnChange )
                    {
                        // backup current image
                        if ( backup != null )
                            backup.Dispose( );

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose( );
                    }

                    image = newImage;

                    // update
                    UpdateNewImage( );
                }
            }
            catch
            {
                MessageBox.Show( "Error occured applying selected filter to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        // on "Image" item popup
        private void imageItem_Popup( object sender, System.EventArgs e )
        {
            this.backImageItem.Enabled = ( backup != null );
            this.cropImageItem.Checked = cropping;
        }

        // Restore image to previous
        private void backImageItem_Click( object sender, System.EventArgs e )
        {
            if ( backup != null )
            {
                // release current image
                image.Dispose( );
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage( );
            }
        }

        // Clone the image
        private void Clone( )
        {
            if ( host != null )
            {
                Bitmap clone = AForge.Imaging.Image.Clone( image );

                if ( !host.NewDocument( clone ) )
                {
                    clone.Dispose( );
                }
            }
        }

        // On "Image->Clone" item click
        private void cloneImageItem_Click( object sender, System.EventArgs e )
        {
            Clone( );
        }

        // Update zoom factor
        private void UpdateZoom( )
        {
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
            this.Invalidate( );

            // notify host
            if ( ZoomChanged != null )
                ZoomChanged( this, null );
        }

        // Zoom image
        private void zoomItem_Click( object sender, System.EventArgs e )
        {
            // get menu item text
            String t = ( (MenuItem) sender ).Text;
            // parse it`s value
            int i = int.Parse( t.Remove( t.Length - 1, 1 ) );
            // calc zoom factor
            zoom = (float) i / 100;

            UpdateZoom( );
        }

        // Zoom In image
        private void ZoomIn( )
        {
            float z = zoom * 1.5f;

            if ( z <= 10 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom In" item click
        private void zoomInImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomIn( );
        }

        // Zoom Out image
        private void ZoomOut( )
        {
            float z = zoom / 1.5f;

            if ( z >= 0.05 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom out" item click
        private void zoomOutImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomOut( );
        }

        // Fit to size
        private void FitToScreen( )
        {
            Rectangle rc = ClientRectangle;

            zoom = Math.Min( (float) rc.Width / ( width + 2 ), (float) rc.Height / ( height + 2 ) );

            UpdateZoom( );
        }

        // On "Image->Zoom->Fit To Screen" item click
        private void zoomFitImageItem_Click( object sender, System.EventArgs e )
        {
            FitToScreen( );
        }

        // Flip image
        private void flipImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipY );

            Invalidate( );
        }

        // Mirror image
        private void mirrorItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipX );

            Invalidate( );
        }

        // Rotate image 90 degree
        private void rotateImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.Rotate90FlipNone );

            // update
            UpdateNewImage( );
        }

        // Invert image
        private void invertColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Invert( ) );
        }

        // Rotatet colors
        private void rotateColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new RotateChannels( ) );
        }

        // Sepia image
        private void sepiaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sepia( ) );
        }

        // Grayscale image
        private void Grayscale( )
        {
            ApplyFilter( AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709 );
        }

        // On "Filter->Color->Grayscale"
        private void grayscaleColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Grayscale( );
        }

        // Converts grayscale image to RGB
        private void toRgbColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new GrayscaleToRGB( ) );
        }

        // Remove green and blue channels
        private void redColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and blue channels
        private void greenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and green channels
        private void blueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void cyanColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void magentaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove blue channel
        private void yellowColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

        // Color filtering
        private void colorFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "Color filtering" ) )
            {
                ColorFilteringForm form = new ColorFilteringForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Euclidean color filtering
        private void euclideanFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "Euclidean color filtering" ) )
            {
                EuclideanColorFilteringForm form = new EuclideanColorFilteringForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Channels filtering
        private void channelsFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "Channels filtering" ) )
            {
                ChannelFilteringForm form = new ChannelFilteringForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Extract red channel of image
        private void extractRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.R ) );
        }

        // Extract green channel of image
        private void extractGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.G ) );
        }

        // Extract blue channel of image
        private void extractRedBlueFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.B ) );
        }

        // Replace red channel
        private void replaceRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the red channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.R, channelImage ) );
        }

        // Replace green channel
        private void replaceGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the green channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.G, channelImage ) );
        }

        // Replace blue channel
        private void replaceBlueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the blue channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.B, channelImage ) );
        }

        // Extract red channel of NRGB color space
        private void extractRedFromNrgbMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new ExtractNormalizedRGBChannel( RGB.R ) );
        }

        // Extract green channel of NRGB color space
        private void extractGreenFromNrgbMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new ExtractNormalizedRGBChannel( RGB.G ) );
        }

        // Extract blue channel of NRGB color space
        private void extractBlueFromNrgbMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new ExtractNormalizedRGBChannel( RGB.B ) );
        }

        // Adjust brighness using HSL
        private void Brightness( )
        {
            if ( CheckIfColor( "Brightness filter using HSL color space" ) )
            {
                BrightnessForm form = new BrightnessForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // On "Filters->HSL Color space->Brighness" menu item click
        private void brightnessHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Brightness( );
        }

        // Modify contrast
        private void Contrast( )
        {
            if ( CheckIfColor( "Contrast filter using HSL color space" ) )
            {
                ContrastForm form = new ContrastForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // On "Filters->HSL Color space->Contrast" menu item click
        private void contrastHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Contrast( );
        }

        // Adjust saturation using HSL
        private void Saturation( )
        {
            if ( CheckIfColor( "Saturation filter using HSL color space" ) )
            {
                SaturationForm form = new SaturationForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // On "Filters->HSL Color space->Saturation" menu item click
        private void saturationHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Saturation( );
        }

        // HSL linear correction
        private void linearHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "HSL linear correction" ) )
            {
                HSLLinearForm form = new HSLLinearForm( new ImageStatisticsHSL( image ) );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // HSL filtering
        private void filteringHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "HSL filtering" ) )
            {
                HSLFilteringForm form = new HSLFilteringForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Hue modifier
        private void hueHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "Hue modifier" ) )
            {
                HueModifierForm form = new HueModifierForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Linear correction of YCbCr channels
        private void linearYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "YCbCr linear correction" ) )
            {
                YCbCrLinearForm form = new YCbCrLinearForm( new ImageStatisticsYCbCr( image ) );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Filtering of YCbCr channels
        private void filteringYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfColor( "YCbCr filtering" ) )
            {
                YCbCrFilteringForm form = new YCbCrFilteringForm( );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Extract Y channel of YCbCr color space
        private void extracYFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.YIndex ) );
        }

        // Extract Cb channel of YCbCr color space
        private void extracCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CbIndex ) );
        }

        // Extract Cr channel of YCbCr color space
        private void extracCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CrIndex ) );
        }

        // Replace Y channel of YCbCr color space
        private void replaceYFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Y channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.YIndex, channelImage ) );
        }

        // Replace Cb channel of YCbCr color space
        private void replaceCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cb channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CbIndex, channelImage ) );
        }

        // Replace Cr channel of YCbCr color space
        private void replaceCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cr channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CrIndex, channelImage ) );
        }

        // Threshold binarization
        private void Threshold( )
        {
            if ( CheckIfGrayscale( "Threshold filter" ) )
            {
                ThresholdForm form = new ThresholdForm( );

                // set image to preview
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // On "Filters->Binarization->Threshold" menu item click
        private void thresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            Threshold( );
        }

        // Threshold binarization with carry
        private void thresholdCarryBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ThresholdWithCarry( ) );
        }

        // Ordered dithering
        private void orderedDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new OrderedDithering( ) );
        }

        // Bayer ordered dithering
        private void bayerDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BayerDithering( ) );
        }

        // Binarization using Floyd-Steinverg dithering algorithm
        private void floydBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new FloydSteinbergDithering( ) );
        }

        // Binarization using Burkes dithering algorithm
        private void burkesBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BurkesDithering( ) );
        }

        // Binarization using Stucki dithering algorithm
        private void stuckiBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new StuckiDithering( ) );
        }

        // Binarization using Jarvis, Judice and Ninke dithering algorithm
        private void jarvisBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new JarvisJudiceNinkeDithering( ) );
        }

        // Binarization using Sierra dithering algorithm
        private void sierraBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SierraDithering( ) );
        }

        // Threshold using Simple Image Statistics
        private void sisThresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SISThreshold( ) );
        }

        // Otsu threshold
        private void otsuThresholdMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new OtsuThreshold( ) );
        }

        // Errosion (Mathematical Morphology)
        private void erosionMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Erosion( ) );
        }

        // Dilatation (Mathematical Morphology)
        private void dilatationMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Dilatation( ) );
        }

        // Opening (Mathematical Morphology)
        private void openingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Opening( ) );
        }

        // Closing (Mathematical Morphology)
        private void closingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Closing( ) );
        }

        // Top-hat (Mathematical Morphology)
        private void tophatMorphologyFiltersItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new TopHat( ) );
        }

        // Bottom-hat (Mathematical Morphology)
        private void bottomMorphologyFiltersItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new BottomHat( ) );
        }

        // Custom morphology operator
        private void Morphology( )
        {
            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.Simple );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Morphology->Custom" menu item click
        private void customMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            Morphology( );
        }

        // Hit & Miss mathematical morphology operator
        private void hitAndMissFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( CheckIfBinary( "Hit & Miss morpholgy filters" ) )
            {
                MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.HitAndMiss );
                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Mean
        private void meanConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Mean( ) );
        }

        // Blur
        private void blurConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Blur( ) );
        }

        // Gaussian smoothing
        private void gaussianConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            GaussianForm form = new GaussianForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extended sharpening
        private void sharpenExConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            SharpenExForm form = new SharpenExForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Sharpen
        private void sharpenConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sharpen( ) );
        }

        // Edges
        private void edgesConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Edges( ) );
        }

        // Custom convolution filter
        private void Convolution( )
        {
            ConvolutionForm form = new ConvolutionForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Convolution & Correlation->Custom" menu item click
        private void customConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            Convolution( );
        }

        // Merge two images
        private void mergeTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to merge with the current image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Merge( overlayImage ) );
        }

        // Intersect
        private void intersectTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to intersect with the current image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Intersect( overlayImage ) );
        }

        // Add
        private void addTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to add to the current image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Add( overlayImage ) );
        }

        // Subtract
        private void subtractTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to subtract from the current image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Subtract( overlayImage ) );
        }

        // Difference
        private void differenceTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to get difference with the current image", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Difference( overlayImage ) );
        }

        // Move towards
        private void moveTowardsTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the current image will be moved", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new MoveTowards( overlayImage, 10 ) );
        }

        // Morph an image
        private void morphTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            // get overlay image
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the current image will be morphed", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
            {
                // show filter setting dialog
                MorphForm form = new MorphForm( overlayImage );

                form.Image = image;

                // get filter settings
                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Homogenity edge detector
        private void homogenityEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                ApplyFilter( new HomogenityEdgeDetector( ) );
            }
            else
            {
                ApplyFilter(
                    new FiltersSequence(
                        AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709,
                        new HomogenityEdgeDetector( )
                        ) );
            }
        }

        // Difference edge detector
        private void differenceEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                ApplyFilter( new DifferenceEdgeDetector( ) );
            }
            else
            {
                ApplyFilter(
                    new FiltersSequence(
                        AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709,
                        new DifferenceEdgeDetector( )
                        ) );
            }
        }

        // Sobel edge detector
        private void sobelEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                ApplyFilter( new SobelEdgeDetector( ) );
            }
            else
            {
                ApplyFilter(
                    new FiltersSequence(
                        AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709,
                        new SobelEdgeDetector( )
                        ) );
            }
        }

        // Canny edge detector
        private void cannyEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            CannyDetectorForm form = new CannyDetectorForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // SUSAN corners detector
        private void susanCornersDetectorMenuItem_Click( object sender, EventArgs e )
        {
            SusanCornersDetectorForm form = new SusanCornersDetectorForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Moravec corners detector
        private void moravecCornersDetectorMenuItem_Click( object sender, EventArgs e )
        {
            MoravecCornersDetectorForm form = new MoravecCornersDetectorForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Additive noise
        private void additiveNoiseFiltersItem_Click( object sender, EventArgs e )
        {
            AdditiveNoiseForm form = new AdditiveNoiseForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Salt and Pepper noise
        private void saltNoiseFiltersItem_Click( object sender, EventArgs e )
        {
            SaltNoiseForm form = new SaltNoiseForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Adaptive smoothing
        private void adaptiveSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            AdaptiveSmoothForm form = new AdaptiveSmoothForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conservative smoothing
        private void conservativeSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ConservativeSmoothing( ) );
        }

        // Perlin noise effects
        private void perlinNoiseFiltersItem_Click( object sender, System.EventArgs e )
        {
            PerlinNoiseForm form = new PerlinNoiseForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Oil painting filter
        private void oilPaintingFiltersItem_Click( object sender, System.EventArgs e )
        {
            OilPaintingForm form = new OilPaintingForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Random jitter filter
        private void jitterFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Jitter( 1 ) );
        }

        // Pixellate filter
        private void pixellateFiltersItem_Click( object sender, System.EventArgs e )
        {
            PixelateForm form = new PixelateForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Simple skeletonization
        private void simpleSkeletonizationFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SimpleSkeletonization( ) );
        }

        // Shrink the image, removing specified color from it`s borders
        private void shrinkFiltersItem_Click( object sender, System.EventArgs e )
        {
            ShrinkForm form = new ShrinkForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Simple posterization
        private void simplePosterizatonMenuItem_Click( object sender, EventArgs e )
        {
            SimplePosterizationForm form = new SimplePosterizationForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conected components labeling
        private void labelingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ConnectedComponentsLabeling( ) );
        }

        // Extract separate blobs
        private void blobExtractorFiltersItem_Click( object sender, System.EventArgs e )
        {
            BlobCounter blobCounter = new BlobCounter( image );
            Blob[] blobs = blobCounter.GetObjects( image, false );

            foreach ( Blob blob in blobs )
            {
                host.NewDocument( blob.Image );
            }
        }

        // Filter blobs by size
        private void filterBlobsMenuItem_Click( object sender, EventArgs e )
        {
            BlobsFilteringForm form = new BlobsFilteringForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extract biggest blob
        private void extractBiggestBlobMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new ExtractBiggestBlob( ) );
        }

        // Resize the image
        private void ResizeImage( )
        {
            ResizeForm form = new ResizeForm( );

            form.OriginalSize = new Size( width, height );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Resize" menu item click
        private void resizeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ResizeImage( );
        }

        // Rotate the image
        private void RotateImage( )
        {
            RotateForm form = new RotateForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Rotate" menu item click
        private void rotateFiltersItem_Click( object sender, System.EventArgs e )
        {
            RotateImage( );
        }

        // Levels
        private void Levels( )
        {
            LevelsLinearForm form = new LevelsLinearForm( new ImageStatistics( image ) );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filter->Levels" menu item click
        private void levelsFiltersItem_Click( object sender, System.EventArgs e )
        {
            Levels( );
        }

        // Contrast stretch filter
        private void contrastStretchMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new ContrastStretch( ) );
        }

        // Histogram equalization filter
        private void histogramEqualizationMenuItem_Click( object sender, EventArgs e )
        {
            ApplyFilter( new HistogramEqualization( ) );
        }

        // Median filter
        private void medianFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Median( ) );
        }

        // Gamma correction
        private void gammaFiltersItem_Click( object sender, System.EventArgs e )
        {
            GammaForm form = new GammaForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Create stereo anaglyph using current image as the "left" image
        private void CreateStereoAnaglyph( StereoAnaglyph.Algorithm algorithm )
        {
            // get overlay image
            Bitmap overlayImage = host.GetImage( this, "Select an image which should be used as the 'right' image for stereo anaglyph.",
                new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
            {
                StereoAnaglyph filter = new StereoAnaglyph( algorithm );
                filter.OverlayImage = overlayImage;

                ApplyFilter( filter );
            }
        }
       
        // True Stereo Anaglyph
        private void trueAnaglyphMenuItem_Click( object sender, EventArgs e )
        {
            CreateStereoAnaglyph( StereoAnaglyph.Algorithm.TrueAnaglyph );
        }

        // Gray Stereo Anaglyph
        private void grayAnaglyphMenuItem_Click( object sender, EventArgs e )
        {
            CreateStereoAnaglyph( StereoAnaglyph.Algorithm.GrayAnaglyph );
        }

        // Color Stereo Anaglyph
        private void colorAnaglyphMenuItem_Click( object sender, EventArgs e )
        {
            CreateStereoAnaglyph( StereoAnaglyph.Algorithm.ColorAnaglyph );
        }

        // Half color Stereo Anaglyph
        private void halfColorAnaglyphMenuItem_Click( object sender, EventArgs e )
        {
            CreateStereoAnaglyph( StereoAnaglyph.Algorithm.HalfColorAnaglyph );
        }

        // Optimized Stereo Anaglyph
        private void optimizedAnaglyphMenuItem_Click( object sender, EventArgs e )
        {
            CreateStereoAnaglyph( StereoAnaglyph.Algorithm.OptimizedAnaglyph );
        }

        // Fourier transformation
        private void ForwardFourierTransformation( )
        {
            // check image dimension
            if ( ( !Tools.IsPowerOf2( width ) ) || ( !Tools.IsPowerOf2( height ) ) )
            {
                MessageBox.Show( "Fourier trasformation can be applied to an image with width and height of power of 2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            // check pixel format
            if ( CheckIfGrayscale( "Fourier transformation" ) )
            {
                ComplexImage cImage = ComplexImage.FromBitmap( image );

                cImage.ForwardFourierTransform( );
                host.NewDocument( cImage );
            }
       }

        // On "Filters->Fourier Transformation" click
        private void fourierFiltersItem_Click( object sender, System.EventArgs e )
        {
            ForwardFourierTransformation( );
        }

        // Calculate image and screen coordinates of the point
        private void GetImageAndScreenPoints( Point point, out Point imgPoint, out Point screenPoint )
        {
            Rectangle rc = this.ClientRectangle;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );
            int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
            int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

            int ix = Math.Min( Math.Max( x, point.X ), x + width - 1 );
            int iy = Math.Min( Math.Max( y, point.Y ), y + height - 1 );

            ix = (int) ( ( ix - x ) / zoom );
            iy = (int) ( ( iy - y ) / zoom );

            // image point
            imgPoint = new Point( ix, iy );
            // screen point
            screenPoint = this.PointToScreen( new Point( (int) ( ix * zoom + x ), (int) ( iy * zoom + y ) ) );
        }

        // Normalize points so, that pt1 becomes top-left point of rectangle
        // and pt2 becomes right-bottom
        private void NormalizePoints( ref Point pt1, ref Point pt2 )
        {
            Point t1 = pt1;
            Point t2 = pt2;

            pt1.X = Math.Min( t1.X, t2.X );
            pt1.Y = Math.Min( t1.Y, t2.Y );
            pt2.X = Math.Max( t1.X, t2.X );
            pt2.Y = Math.Max( t1.Y, t2.Y );
        }

        // Draw selection rectangle
        private void DrawSelectionFrame( Graphics g )
        {
            Point sp = startW;
            Point ep = endW;

            // Normalize points
            NormalizePoints( ref sp, ref ep );
            // Draw reversible frame
            ControlPaint.DrawReversibleFrame( new Rectangle( sp.X, sp.Y, ep.X - sp.X + 1, ep.Y - sp.Y + 1 ), Color.White, FrameStyle.Dashed );
        }

        // Crop the image
        private void Crop( )
        {
            if ( !cropping )
            {
                // turn on
                cropping = true;
                this.Cursor = Cursors.Cross;

            }
            else
            {
                // turn off
                cropping = false;
                this.Cursor = Cursors.Default;
            }
        }

        // On "Image->Crop" - turn on/off cropping mode
        private void cropImageItem_Click( object sender, System.EventArgs e )
        {
            Crop( );
        }

        // On mouse down
        private void ImageDoc_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                // turn off cropping mode
                if ( !dragging )
                {
                    cropping = false;
                    this.Cursor = Cursors.Default;
                }
            }
            else if ( e.Button == MouseButtons.Left )
            {
                if ( cropping )
                {
                    // start dragging
                    dragging = true;
                    // set mouse capture
                    this.Capture = true;

                    // get selection start point
                    GetImageAndScreenPoints( new Point( e.X, e.Y ), out start, out startW );

                    // end point is the same as start
                    end = start;
                    endW = startW;

                    // draw frame
                    Graphics g = this.CreateGraphics( );
                    DrawSelectionFrame( g );
                    g.Dispose( );
                }
            }
        }

        // On mouse up
        private void ImageDoc_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {
                // stop dragging and cropping
                dragging = cropping = false;
                // release capture
                this.Capture = false;
                // set default mouse pointer
                this.Cursor = Cursors.Default;

                // erase frame
                Graphics g = this.CreateGraphics( );
                DrawSelectionFrame( g );
                g.Dispose( );

                // normalize start and end points
                NormalizePoints( ref start, ref end );

                // crop tge image
                ApplyFilter( new Crop( new Rectangle( start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1 ) ) );
            }
        }

        // On mouse move
        private void ImageDoc_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {

                Graphics g = this.CreateGraphics( );

                // erase frame
                DrawSelectionFrame( g );

                // get selection end point
                GetImageAndScreenPoints( new Point( e.X, e.Y ), out end, out endW );

                // draw frame
                DrawSelectionFrame( g );

                g.Dispose( );

                if ( SelectionChanged != null )
                {
                    Point sp = start;
                    Point ep = end;

                    // normalize start and end points
                    NormalizePoints( ref sp, ref ep );

                    SelectionChanged( this, new SelectionEventArgs(
                        sp, new Size( ep.X - sp.X + 1, ep.Y - sp.Y + 1 ) ) );
                }
            }
            else
            {
                if ( MouseImagePosition != null )
                {
                    Rectangle rc = this.ClientRectangle;
                    int width = (int) ( this.width * zoom );
                    int height = (int) ( this.height * zoom );
                    int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                    int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                    if ( ( e.X >= x ) && ( e.Y >= y ) &&
                        ( e.X < x + width ) && ( e.Y < y + height ) )
                    {
                        // mouse is over the image
                        MouseImagePosition( this, new SelectionEventArgs(
                            new Point( (int) ( ( e.X - x ) / zoom ), (int) ( ( e.Y - y ) / zoom ) ) ) );
                    }
                    else
                    {
                        // mouse is outside image region
                        MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
                    }
                }
            }
        }

        // On mouse leave
        private void ImageDoc_MouseLeave( object sender, System.EventArgs e )
        {
            if ( ( !dragging ) && ( MouseImagePosition != null ) )
            {
                MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
            }
        }
    }

    // Selection arguments
    public class SelectionEventArgs : EventArgs
    {
        private Point location;
        private Size size;

        // Constructors
        public SelectionEventArgs( Point location )
        {
            this.location = location;
        }
        public SelectionEventArgs( Point location, Size size )
        {
            this.location = location;
            this.size = size;
        }

        // Location property
        public Point Location
        {
            get { return location; }
        }
        // Size property
        public Size Size
        {
            get { return size; }
        }
    }

    // Commands
    public enum ImageDocCommands
    {
        Clone,
        Crop,
        ZoomIn,
        ZoomOut,
        ZoomOriginal,
        FitToSize,
        Levels,
        Grayscale,
        Threshold,
        Morphology,
        Convolution,
        Resize,
        Rotate,
        Brightness,
        Contrast,
        Saturation,
        Fourier
    }
}
