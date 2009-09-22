// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
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
    public class ImageDoc : Content
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

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem imageItem;
        private System.Windows.Forms.MenuItem filtersItem;
        private System.Windows.Forms.MenuItem cloneImageItem;
        private System.Windows.Forms.MenuItem rotateColorFiltersItem;
        private System.Windows.Forms.MenuItem invertColorFiltersItem;
        private System.Windows.Forms.MenuItem sepiaColorFiltersItem;
        private System.Windows.Forms.MenuItem grayscaleColorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem backImageItem;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem z10ImageItem;
        private System.Windows.Forms.MenuItem z25ImageItem;
        private System.Windows.Forms.MenuItem z50ImageItem;
        private System.Windows.Forms.MenuItem z75ImageItem;
        private System.Windows.Forms.MenuItem z100ImageItem;
        private System.Windows.Forms.MenuItem z150ImageItem;
        private System.Windows.Forms.MenuItem z200ImageItem;
        private System.Windows.Forms.MenuItem z400ImageItem;
        private System.Windows.Forms.MenuItem z500ImageItem;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem zoomInImageItem;
        private System.Windows.Forms.MenuItem zoomOutImageItem;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem zoomFitImageItem;
        private System.Windows.Forms.MenuItem colorFiltersItem;
        private System.Windows.Forms.MenuItem binaryFiltersItem;
        private System.Windows.Forms.MenuItem thresholdBinaryFiltersItem;
        private System.Windows.Forms.MenuItem thresholdCarryBinaryFiltersItem;
        private System.Windows.Forms.MenuItem floydBinaryFiltersItem;
        private System.Windows.Forms.MenuItem morphologyFiltersItem;
        private System.Windows.Forms.MenuItem dilatationMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem convolutionFiltersItem;
        private System.Windows.Forms.MenuItem meanConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem blurConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem sharpenConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem edgesConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem levelsFiltersItem;
        private System.Windows.Forms.MenuItem flipImageItem;
        private System.Windows.Forms.MenuItem mirrorItem;
        private System.Windows.Forms.MenuItem rotateImageItem;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem cropImageItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem customMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem customConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem openingMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem medianFiltersItem;
        private System.Windows.Forms.MenuItem closingMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem erosionMorphologyFiltersItem;
        private System.Windows.Forms.MenuItem pixellateFiltersItem;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem redColorFiltersItem;
        private System.Windows.Forms.MenuItem greenColorFiltersItem;
        private System.Windows.Forms.MenuItem blueColorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem cyanColorFiltersItem;
        private System.Windows.Forms.MenuItem magentaColorFiltersItem;
        private System.Windows.Forms.MenuItem yellowColorFiltersItem;
        private System.Windows.Forms.MenuItem channelsFilteringColorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem colorFilteringColorFiltersItem;
        private System.Windows.Forms.MenuItem euclideanFilteringColorFiltersItem;
        private System.Windows.Forms.MenuItem extractRedColorFiltersItem;
        private System.Windows.Forms.MenuItem extractGreenColorFiltersItem;
        private System.Windows.Forms.MenuItem extractRedBlueFiltersItem;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem replaceRedColorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem replaceGreenColorFiltersItem;
        private System.Windows.Forms.MenuItem replaceBlueColorFiltersItem;
        private System.Windows.Forms.MenuItem twosrcFiltersItem;
        private System.Windows.Forms.MenuItem mergeTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem intersectTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem addTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem subtractTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem differenceTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem moveTowardsTwosrcFiltersItem;
        private System.Windows.Forms.MenuItem simpleSkeletonizationFiltersItem;
        private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.MenuItem orderedDitherBinaryFiltersItem;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem bayerDitherBinaryFiltersItem;
        private System.Windows.Forms.MenuItem burkesBinaryFiltersItem;
        private System.Windows.Forms.MenuItem stuckiBinaryFiltersItem;
        private System.Windows.Forms.MenuItem jarvisBinaryFiltersItem;
        private System.Windows.Forms.MenuItem sierraBinaryFiltersItem;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem resizeFiltersItem;
        private System.Windows.Forms.MenuItem menuItem26;
        private System.Windows.Forms.MenuItem shrinkFiltersItem;
        private System.Windows.Forms.MenuItem rotateFiltersItem;
        private System.Windows.Forms.MenuItem jitterFiltersItem;
        private System.Windows.Forms.MenuItem gammaFiltersItem;
        private System.Windows.Forms.MenuItem menuItem27;
        private System.Windows.Forms.MenuItem hitAndMissFiltersItem;
        private System.Windows.Forms.MenuItem hslFiltersItem;
        private System.Windows.Forms.MenuItem brightnessHslFiltersItem;
        private System.Windows.Forms.MenuItem contrastHslFiltersItem;
        private System.Windows.Forms.MenuItem saturationHslFiltersItem;
        private System.Windows.Forms.MenuItem menuItem28;
        private System.Windows.Forms.MenuItem filteringHslFiltersItem;
        private System.Windows.Forms.MenuItem hueHslFiltersItem;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.MenuItem linearHslFiltersItem;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem fourierFiltersItem;
        private System.Windows.Forms.MenuItem edgeFiltersItem;
        private System.Windows.Forms.MenuItem homogenityEdgeFiltersItem;
        private System.Windows.Forms.MenuItem differenceEdgeFiltersItem;
        private System.Windows.Forms.MenuItem labelingFiltersItem;
        private System.Windows.Forms.MenuItem sobelEdgeFiltersItem;
        private System.Windows.Forms.MenuItem gaussianConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem adaptiveSmoothingFiltersItem;
        private System.Windows.Forms.MenuItem blobExtractorFiltersItem;
        private System.Windows.Forms.MenuItem menuItem31;
        private System.Windows.Forms.MenuItem sisThresholdBinaryFiltersItem;
        private System.Windows.Forms.MenuItem conservativeSmoothingFiltersItem;
        private System.Windows.Forms.MenuItem menuItem34;
        private System.Windows.Forms.MenuItem cannyEdgeFiltersItem;
        private System.Windows.Forms.MenuItem menuItem33;
        private System.Windows.Forms.MenuItem sharpenExConvolutionFiltersItem;
        private System.Windows.Forms.MenuItem oilPaintingFiltersItem;
        private System.Windows.Forms.MenuItem ycbcrFiltersItem;
        private System.Windows.Forms.MenuItem extracYFiltersItem;
        private System.Windows.Forms.MenuItem extracCbFiltersItem;
        private System.Windows.Forms.MenuItem extracCrFiltersItem;
        private System.Windows.Forms.MenuItem menuItem37;
        private System.Windows.Forms.MenuItem menuItem38;
        private System.Windows.Forms.MenuItem replaceYFiltersItem;
        private System.Windows.Forms.MenuItem replaceCbFiltersItem;
        private System.Windows.Forms.MenuItem replaceCrFiltersItem;
        private System.Windows.Forms.MenuItem linearYCbCrFiltersItem;
        private System.Windows.Forms.MenuItem filteringYCbCrFiltersItem;
        private System.Windows.Forms.MenuItem toRgbColorFiltersItem;
        private System.Windows.Forms.MenuItem perlinNoiseFiltersItem;
        private System.Windows.Forms.MenuItem morphTwosrcFiltersItem;
        private MenuItem tophatMorphologyFiltersItem;
        private MenuItem bottomMorphologyFiltersItem;
        private MenuItem noiseFiltersItem;
        private MenuItem additiveNoiseFiltersItem;
        private MenuItem saltNoiseFiltersItem;
        private MenuItem menuItem13;
        private MenuItem extractBiggestBlobMenuItem;
        private MenuItem menuItem30;
        private MenuItem contrastStretchMenuItem;
        private MenuItem histogramEqualizationMenuItem;
        private MenuItem menuItem32;
        private MenuItem extractRedFromNrgbMenuItem;
        private MenuItem extractGreenFromNrgbMenuItem;
        private MenuItem extractBlueFromNrgbMenuItem;
        private MenuItem otsuThresholdMenuItem;
        private MenuItem filterBlobsMenuItem;
        private MenuItem menuItem35;
        private MenuItem susanCornersDetectorMenuItem;
        private MenuItem moravecCornersDetectorMenuItem;
        private MenuItem simplePosterizatonMenuItem;
        private System.ComponentModel.IContainer components;

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
            FileStream stream = null;
            try
            {
                // read image to temporary memory stream
                // (.NET locks any stream until bitmap is disposed,
                // so that is why this work around is required)
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

                image = (Bitmap) Bitmap.FromStream( memoryStream );

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
            finally
            {
                if ( stream != null )
                {
                    stream.Close( );
                    stream.Dispose( );
                }
            }

            Init( );
        }
        // Construct from image
        public ImageDoc( Bitmap image, IDocumentsHost host ) : this( host )
        {
            this.image = image;

            if ( !AForge.Imaging.Image.IsGrayscale( this.image ) )
            {
                this.image = AForge.Imaging.Image.Clone( image, PixelFormat.Format24bppRgb );
            }

            Init( );
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
                if ( image != null )
                {
                    image.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            this.mainMenu = new System.Windows.Forms.MainMenu( this.components );
            this.imageItem = new System.Windows.Forms.MenuItem( );
            this.backImageItem = new System.Windows.Forms.MenuItem( );
            this.cloneImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem4 = new System.Windows.Forms.MenuItem( );
            this.menuItem5 = new System.Windows.Forms.MenuItem( );
            this.z10ImageItem = new System.Windows.Forms.MenuItem( );
            this.z25ImageItem = new System.Windows.Forms.MenuItem( );
            this.z50ImageItem = new System.Windows.Forms.MenuItem( );
            this.z75ImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem7 = new System.Windows.Forms.MenuItem( );
            this.z100ImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem6 = new System.Windows.Forms.MenuItem( );
            this.z150ImageItem = new System.Windows.Forms.MenuItem( );
            this.z200ImageItem = new System.Windows.Forms.MenuItem( );
            this.z400ImageItem = new System.Windows.Forms.MenuItem( );
            this.z500ImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem8 = new System.Windows.Forms.MenuItem( );
            this.zoomInImageItem = new System.Windows.Forms.MenuItem( );
            this.zoomOutImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem11 = new System.Windows.Forms.MenuItem( );
            this.zoomFitImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem10 = new System.Windows.Forms.MenuItem( );
            this.flipImageItem = new System.Windows.Forms.MenuItem( );
            this.mirrorItem = new System.Windows.Forms.MenuItem( );
            this.rotateImageItem = new System.Windows.Forms.MenuItem( );
            this.menuItem3 = new System.Windows.Forms.MenuItem( );
            this.cropImageItem = new System.Windows.Forms.MenuItem( );
            this.filtersItem = new System.Windows.Forms.MenuItem( );
            this.colorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.grayscaleColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.toRgbColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.gammaFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem1 = new System.Windows.Forms.MenuItem( );
            this.sepiaColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem2 = new System.Windows.Forms.MenuItem( );
            this.invertColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.rotateColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem16 = new System.Windows.Forms.MenuItem( );
            this.colorFilteringColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.euclideanFilteringColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.channelsFilteringColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem19 = new System.Windows.Forms.MenuItem( );
            this.extractRedColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.extractGreenColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.extractRedBlueFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem20 = new System.Windows.Forms.MenuItem( );
            this.replaceRedColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.replaceGreenColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.replaceBlueColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem18 = new System.Windows.Forms.MenuItem( );
            this.redColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.greenColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.blueColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem17 = new System.Windows.Forms.MenuItem( );
            this.cyanColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.magentaColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.yellowColorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem32 = new System.Windows.Forms.MenuItem( );
            this.extractRedFromNrgbMenuItem = new System.Windows.Forms.MenuItem( );
            this.extractGreenFromNrgbMenuItem = new System.Windows.Forms.MenuItem( );
            this.extractBlueFromNrgbMenuItem = new System.Windows.Forms.MenuItem( );
            this.hslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.brightnessHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.contrastHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.saturationHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem29 = new System.Windows.Forms.MenuItem( );
            this.linearHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem28 = new System.Windows.Forms.MenuItem( );
            this.filteringHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.hueHslFiltersItem = new System.Windows.Forms.MenuItem( );
            this.ycbcrFiltersItem = new System.Windows.Forms.MenuItem( );
            this.linearYCbCrFiltersItem = new System.Windows.Forms.MenuItem( );
            this.filteringYCbCrFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem37 = new System.Windows.Forms.MenuItem( );
            this.extracYFiltersItem = new System.Windows.Forms.MenuItem( );
            this.extracCbFiltersItem = new System.Windows.Forms.MenuItem( );
            this.extracCrFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem38 = new System.Windows.Forms.MenuItem( );
            this.replaceYFiltersItem = new System.Windows.Forms.MenuItem( );
            this.replaceCbFiltersItem = new System.Windows.Forms.MenuItem( );
            this.replaceCrFiltersItem = new System.Windows.Forms.MenuItem( );
            this.binaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.thresholdBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem15 = new System.Windows.Forms.MenuItem( );
            this.thresholdCarryBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.orderedDitherBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.bayerDitherBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem14 = new System.Windows.Forms.MenuItem( );
            this.floydBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.burkesBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.stuckiBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.jarvisBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.sierraBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem31 = new System.Windows.Forms.MenuItem( );
            this.sisThresholdBinaryFiltersItem = new System.Windows.Forms.MenuItem( );
            this.otsuThresholdMenuItem = new System.Windows.Forms.MenuItem( );
            this.morphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.erosionMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.dilatationMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.openingMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.closingMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.tophatMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.bottomMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem9 = new System.Windows.Forms.MenuItem( );
            this.customMorphologyFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem27 = new System.Windows.Forms.MenuItem( );
            this.hitAndMissFiltersItem = new System.Windows.Forms.MenuItem( );
            this.convolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.meanConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.blurConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.sharpenConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.edgesConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem12 = new System.Windows.Forms.MenuItem( );
            this.customConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem33 = new System.Windows.Forms.MenuItem( );
            this.gaussianConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.sharpenExConvolutionFiltersItem = new System.Windows.Forms.MenuItem( );
            this.twosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.mergeTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.intersectTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem21 = new System.Windows.Forms.MenuItem( );
            this.addTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.subtractTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem22 = new System.Windows.Forms.MenuItem( );
            this.differenceTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.moveTowardsTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.morphTwosrcFiltersItem = new System.Windows.Forms.MenuItem( );
            this.edgeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.homogenityEdgeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.differenceEdgeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.sobelEdgeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.cannyEdgeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem35 = new System.Windows.Forms.MenuItem( );
            this.susanCornersDetectorMenuItem = new System.Windows.Forms.MenuItem( );
            this.moravecCornersDetectorMenuItem = new System.Windows.Forms.MenuItem( );
            this.menuItem13 = new System.Windows.Forms.MenuItem( );
            this.filterBlobsMenuItem = new System.Windows.Forms.MenuItem( );
            this.extractBiggestBlobMenuItem = new System.Windows.Forms.MenuItem( );
            this.blobExtractorFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem30 = new System.Windows.Forms.MenuItem( );
            this.labelingFiltersItem = new System.Windows.Forms.MenuItem( );
            this.noiseFiltersItem = new System.Windows.Forms.MenuItem( );
            this.additiveNoiseFiltersItem = new System.Windows.Forms.MenuItem( );
            this.saltNoiseFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem24 = new System.Windows.Forms.MenuItem( );
            this.adaptiveSmoothingFiltersItem = new System.Windows.Forms.MenuItem( );
            this.conservativeSmoothingFiltersItem = new System.Windows.Forms.MenuItem( );
            this.medianFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem34 = new System.Windows.Forms.MenuItem( );
            this.perlinNoiseFiltersItem = new System.Windows.Forms.MenuItem( );
            this.oilPaintingFiltersItem = new System.Windows.Forms.MenuItem( );
            this.jitterFiltersItem = new System.Windows.Forms.MenuItem( );
            this.pixellateFiltersItem = new System.Windows.Forms.MenuItem( );
            this.simpleSkeletonizationFiltersItem = new System.Windows.Forms.MenuItem( );
            this.shrinkFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem23 = new System.Windows.Forms.MenuItem( );
            this.resizeFiltersItem = new System.Windows.Forms.MenuItem( );
            this.rotateFiltersItem = new System.Windows.Forms.MenuItem( );
            this.menuItem26 = new System.Windows.Forms.MenuItem( );
            this.levelsFiltersItem = new System.Windows.Forms.MenuItem( );
            this.contrastStretchMenuItem = new System.Windows.Forms.MenuItem( );
            this.histogramEqualizationMenuItem = new System.Windows.Forms.MenuItem( );
            this.menuItem25 = new System.Windows.Forms.MenuItem( );
            this.fourierFiltersItem = new System.Windows.Forms.MenuItem( );
            this.simplePosterizatonMenuItem = new System.Windows.Forms.MenuItem( );
            this.SuspendLayout( );
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.imageItem,
            this.filtersItem} );
            // 
            // imageItem
            // 
            this.imageItem.Index = 0;
            this.imageItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.backImageItem,
            this.cloneImageItem,
            this.menuItem4,
            this.menuItem5,
            this.menuItem10,
            this.flipImageItem,
            this.mirrorItem,
            this.rotateImageItem,
            this.menuItem3,
            this.cropImageItem} );
            this.imageItem.MergeOrder = 1;
            this.imageItem.Text = "&Image";
            this.imageItem.Popup += new System.EventHandler( this.imageItem_Popup );
            // 
            // backImageItem
            // 
            this.backImageItem.Index = 0;
            this.backImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.backImageItem.Text = "&Back";
            this.backImageItem.Click += new System.EventHandler( this.backImageItem_Click );
            // 
            // cloneImageItem
            // 
            this.cloneImageItem.Index = 1;
            this.cloneImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.cloneImageItem.Text = "&Clone";
            this.cloneImageItem.Click += new System.EventHandler( this.cloneImageItem_Click );
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.z10ImageItem,
            this.z25ImageItem,
            this.z50ImageItem,
            this.z75ImageItem,
            this.menuItem7,
            this.z100ImageItem,
            this.menuItem6,
            this.z150ImageItem,
            this.z200ImageItem,
            this.z400ImageItem,
            this.z500ImageItem,
            this.menuItem8,
            this.zoomInImageItem,
            this.zoomOutImageItem,
            this.menuItem11,
            this.zoomFitImageItem} );
            this.menuItem5.Text = "&Zoom";
            // 
            // z10ImageItem
            // 
            this.z10ImageItem.Index = 0;
            this.z10ImageItem.Text = "10%";
            this.z10ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z25ImageItem
            // 
            this.z25ImageItem.Index = 1;
            this.z25ImageItem.Text = "25%";
            this.z25ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z50ImageItem
            // 
            this.z50ImageItem.Index = 2;
            this.z50ImageItem.Text = "50%";
            this.z50ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z75ImageItem
            // 
            this.z75ImageItem.Index = 3;
            this.z75ImageItem.Text = "75%";
            this.z75ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // z100ImageItem
            // 
            this.z100ImageItem.Index = 5;
            this.z100ImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
            this.z100ImageItem.Text = "100%";
            this.z100ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "-";
            // 
            // z150ImageItem
            // 
            this.z150ImageItem.Index = 7;
            this.z150ImageItem.Text = "150%";
            this.z150ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z200ImageItem
            // 
            this.z200ImageItem.Index = 8;
            this.z200ImageItem.Text = "200%";
            this.z200ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z400ImageItem
            // 
            this.z400ImageItem.Index = 9;
            this.z400ImageItem.Text = "400%";
            this.z400ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // z500ImageItem
            // 
            this.z500ImageItem.Index = 10;
            this.z500ImageItem.Text = "500%";
            this.z500ImageItem.Click += new System.EventHandler( this.zoomItem_Click );
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 11;
            this.menuItem8.Text = "-";
            // 
            // zoomInImageItem
            // 
            this.zoomInImageItem.Index = 12;
            this.zoomInImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl8;
            this.zoomInImageItem.Text = "Zoom &In";
            this.zoomInImageItem.Click += new System.EventHandler( this.zoomInImageItem_Click );
            // 
            // zoomOutImageItem
            // 
            this.zoomOutImageItem.Index = 13;
            this.zoomOutImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl7;
            this.zoomOutImageItem.Text = "Zoom &Out";
            this.zoomOutImageItem.Click += new System.EventHandler( this.zoomOutImageItem_Click );
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 14;
            this.menuItem11.Text = "-";
            // 
            // zoomFitImageItem
            // 
            this.zoomFitImageItem.Index = 15;
            this.zoomFitImageItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl9;
            this.zoomFitImageItem.Text = "Fit to screen";
            this.zoomFitImageItem.Click += new System.EventHandler( this.zoomFitImageItem_Click );
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.Text = "-";
            // 
            // flipImageItem
            // 
            this.flipImageItem.Index = 5;
            this.flipImageItem.Text = "&Flip";
            this.flipImageItem.Click += new System.EventHandler( this.flipImageItem_Click );
            // 
            // mirrorItem
            // 
            this.mirrorItem.Index = 6;
            this.mirrorItem.Text = "&Mirror";
            this.mirrorItem.Click += new System.EventHandler( this.mirrorItem_Click );
            // 
            // rotateImageItem
            // 
            this.rotateImageItem.Index = 7;
            this.rotateImageItem.Text = "&Rotate 90 degree";
            this.rotateImageItem.Click += new System.EventHandler( this.rotateImageItem_Click );
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "-";
            // 
            // cropImageItem
            // 
            this.cropImageItem.Index = 9;
            this.cropImageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.cropImageItem.Text = "Cro&p";
            this.cropImageItem.Click += new System.EventHandler( this.cropImageItem_Click );
            // 
            // filtersItem
            // 
            this.filtersItem.Index = 1;
            this.filtersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.colorFiltersItem,
            this.menuItem32,
            this.hslFiltersItem,
            this.ycbcrFiltersItem,
            this.binaryFiltersItem,
            this.morphologyFiltersItem,
            this.convolutionFiltersItem,
            this.twosrcFiltersItem,
            this.edgeFiltersItem,
            this.menuItem35,
            this.menuItem13,
            this.noiseFiltersItem,
            this.menuItem24,
            this.menuItem23,
            this.resizeFiltersItem,
            this.rotateFiltersItem,
            this.menuItem26,
            this.levelsFiltersItem,
            this.contrastStretchMenuItem,
            this.histogramEqualizationMenuItem,
            this.menuItem25,
            this.fourierFiltersItem} );
            this.filtersItem.MergeOrder = 1;
            this.filtersItem.Text = "Fi&lters";
            // 
            // colorFiltersItem
            // 
            this.colorFiltersItem.Index = 0;
            this.colorFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.grayscaleColorFiltersItem,
            this.toRgbColorFiltersItem,
            this.gammaFiltersItem,
            this.menuItem1,
            this.sepiaColorFiltersItem,
            this.menuItem2,
            this.invertColorFiltersItem,
            this.rotateColorFiltersItem,
            this.menuItem16,
            this.colorFilteringColorFiltersItem,
            this.euclideanFilteringColorFiltersItem,
            this.channelsFilteringColorFiltersItem,
            this.menuItem19,
            this.extractRedColorFiltersItem,
            this.extractGreenColorFiltersItem,
            this.extractRedBlueFiltersItem,
            this.menuItem20,
            this.replaceRedColorFiltersItem,
            this.replaceGreenColorFiltersItem,
            this.replaceBlueColorFiltersItem,
            this.menuItem18,
            this.redColorFiltersItem,
            this.greenColorFiltersItem,
            this.blueColorFiltersItem,
            this.menuItem17,
            this.cyanColorFiltersItem,
            this.magentaColorFiltersItem,
            this.yellowColorFiltersItem} );
            this.colorFiltersItem.Text = "&Color (RGB)";
            // 
            // grayscaleColorFiltersItem
            // 
            this.grayscaleColorFiltersItem.Index = 0;
            this.grayscaleColorFiltersItem.Text = "&Grayscale";
            this.grayscaleColorFiltersItem.Click += new System.EventHandler( this.grayscaleColorFiltersItem_Click );
            // 
            // toRgbColorFiltersItem
            // 
            this.toRgbColorFiltersItem.Index = 1;
            this.toRgbColorFiltersItem.Text = "Grayscale To RGB";
            this.toRgbColorFiltersItem.Click += new System.EventHandler( this.toRgbColorFiltersItem_Click );
            // 
            // gammaFiltersItem
            // 
            this.gammaFiltersItem.Index = 2;
            this.gammaFiltersItem.Text = "&Gamma Correction";
            this.gammaFiltersItem.Click += new System.EventHandler( this.gammaFiltersItem_Click );
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // sepiaColorFiltersItem
            // 
            this.sepiaColorFiltersItem.Index = 4;
            this.sepiaColorFiltersItem.Text = "&Sepia";
            this.sepiaColorFiltersItem.Click += new System.EventHandler( this.sepiaColorFiltersItem_Click );
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.Text = "-";
            // 
            // invertColorFiltersItem
            // 
            this.invertColorFiltersItem.Index = 6;
            this.invertColorFiltersItem.Text = "&Invert";
            this.invertColorFiltersItem.Click += new System.EventHandler( this.invertColorFiltersItem_Click );
            // 
            // rotateColorFiltersItem
            // 
            this.rotateColorFiltersItem.Index = 7;
            this.rotateColorFiltersItem.Text = "&Rotate";
            this.rotateColorFiltersItem.Click += new System.EventHandler( this.rotateColorFiltersItem_Click );
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 8;
            this.menuItem16.Text = "-";
            // 
            // colorFilteringColorFiltersItem
            // 
            this.colorFilteringColorFiltersItem.Index = 9;
            this.colorFilteringColorFiltersItem.Text = "Color Filtering";
            this.colorFilteringColorFiltersItem.Click += new System.EventHandler( this.colorFilteringColorFiltersItem_Click );
            // 
            // euclideanFilteringColorFiltersItem
            // 
            this.euclideanFilteringColorFiltersItem.Index = 10;
            this.euclideanFilteringColorFiltersItem.Text = "Euclidean Color Filtering";
            this.euclideanFilteringColorFiltersItem.Click += new System.EventHandler( this.euclideanFilteringColorFiltersItem_Click );
            // 
            // channelsFilteringColorFiltersItem
            // 
            this.channelsFilteringColorFiltersItem.Index = 11;
            this.channelsFilteringColorFiltersItem.Text = "Channels Filtering";
            this.channelsFilteringColorFiltersItem.Click += new System.EventHandler( this.channelsFilteringColorFiltersItem_Click );
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 12;
            this.menuItem19.Text = "-";
            // 
            // extractRedColorFiltersItem
            // 
            this.extractRedColorFiltersItem.Index = 13;
            this.extractRedColorFiltersItem.Text = "Extract Red Channel";
            this.extractRedColorFiltersItem.Click += new System.EventHandler( this.extractRedColorFiltersItem_Click );
            // 
            // extractGreenColorFiltersItem
            // 
            this.extractGreenColorFiltersItem.Index = 14;
            this.extractGreenColorFiltersItem.Text = "Extract Green Channel";
            this.extractGreenColorFiltersItem.Click += new System.EventHandler( this.extractGreenColorFiltersItem_Click );
            // 
            // extractRedBlueFiltersItem
            // 
            this.extractRedBlueFiltersItem.Index = 15;
            this.extractRedBlueFiltersItem.Text = "Extract Blue Channel";
            this.extractRedBlueFiltersItem.Click += new System.EventHandler( this.extractRedBlueFiltersItem_Click );
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 16;
            this.menuItem20.Text = "-";
            // 
            // replaceRedColorFiltersItem
            // 
            this.replaceRedColorFiltersItem.Index = 17;
            this.replaceRedColorFiltersItem.Text = "Replace Red Channel";
            this.replaceRedColorFiltersItem.Click += new System.EventHandler( this.replaceRedColorFiltersItem_Click );
            // 
            // replaceGreenColorFiltersItem
            // 
            this.replaceGreenColorFiltersItem.Index = 18;
            this.replaceGreenColorFiltersItem.Text = "Replace Green Channel";
            this.replaceGreenColorFiltersItem.Click += new System.EventHandler( this.replaceGreenColorFiltersItem_Click );
            // 
            // replaceBlueColorFiltersItem
            // 
            this.replaceBlueColorFiltersItem.Index = 19;
            this.replaceBlueColorFiltersItem.Text = "Replace Blue Channel";
            this.replaceBlueColorFiltersItem.Click += new System.EventHandler( this.replaceBlueColorFiltersItem_Click );
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 20;
            this.menuItem18.Text = "-";
            // 
            // redColorFiltersItem
            // 
            this.redColorFiltersItem.Index = 21;
            this.redColorFiltersItem.Text = "Red";
            this.redColorFiltersItem.Click += new System.EventHandler( this.redColorFiltersItem_Click );
            // 
            // greenColorFiltersItem
            // 
            this.greenColorFiltersItem.Index = 22;
            this.greenColorFiltersItem.Text = "Green";
            this.greenColorFiltersItem.Click += new System.EventHandler( this.greenColorFiltersItem_Click );
            // 
            // blueColorFiltersItem
            // 
            this.blueColorFiltersItem.Index = 23;
            this.blueColorFiltersItem.Text = "Blue";
            this.blueColorFiltersItem.Click += new System.EventHandler( this.blueColorFiltersItem_Click );
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 24;
            this.menuItem17.Text = "-";
            // 
            // cyanColorFiltersItem
            // 
            this.cyanColorFiltersItem.Index = 25;
            this.cyanColorFiltersItem.Text = "Cyan";
            this.cyanColorFiltersItem.Click += new System.EventHandler( this.cyanColorFiltersItem_Click );
            // 
            // magentaColorFiltersItem
            // 
            this.magentaColorFiltersItem.Index = 26;
            this.magentaColorFiltersItem.Text = "Magenta";
            this.magentaColorFiltersItem.Click += new System.EventHandler( this.magentaColorFiltersItem_Click );
            // 
            // yellowColorFiltersItem
            // 
            this.yellowColorFiltersItem.Index = 27;
            this.yellowColorFiltersItem.Text = "Yellow";
            this.yellowColorFiltersItem.Click += new System.EventHandler( this.yellowColorFiltersItem_Click );
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 1;
            this.menuItem32.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.extractRedFromNrgbMenuItem,
            this.extractGreenFromNrgbMenuItem,
            this.extractBlueFromNrgbMenuItem} );
            this.menuItem32.Text = "Normalized RGB";
            // 
            // extractRedFromNrgbMenuItem
            // 
            this.extractRedFromNrgbMenuItem.Index = 0;
            this.extractRedFromNrgbMenuItem.Text = "Extract Red Channel";
            this.extractRedFromNrgbMenuItem.Click += new System.EventHandler( this.extractRedFromNrgbMenuItem_Click );
            // 
            // extractGreenFromNrgbMenuItem
            // 
            this.extractGreenFromNrgbMenuItem.Index = 1;
            this.extractGreenFromNrgbMenuItem.Text = "Extract Green Channel";
            this.extractGreenFromNrgbMenuItem.Click += new System.EventHandler( this.extractGreenFromNrgbMenuItem_Click );
            // 
            // extractBlueFromNrgbMenuItem
            // 
            this.extractBlueFromNrgbMenuItem.Index = 2;
            this.extractBlueFromNrgbMenuItem.Text = "Extract Blue Channel";
            this.extractBlueFromNrgbMenuItem.Click += new System.EventHandler( this.extractBlueFromNrgbMenuItem_Click );
            // 
            // hslFiltersItem
            // 
            this.hslFiltersItem.Index = 2;
            this.hslFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.brightnessHslFiltersItem,
            this.contrastHslFiltersItem,
            this.saturationHslFiltersItem,
            this.menuItem29,
            this.linearHslFiltersItem,
            this.menuItem28,
            this.filteringHslFiltersItem,
            this.hueHslFiltersItem} );
            this.hslFiltersItem.Text = "&HSL Color space";
            // 
            // brightnessHslFiltersItem
            // 
            this.brightnessHslFiltersItem.Index = 0;
            this.brightnessHslFiltersItem.Text = "&Brightness";
            this.brightnessHslFiltersItem.Click += new System.EventHandler( this.brightnessHslFiltersItem_Click );
            // 
            // contrastHslFiltersItem
            // 
            this.contrastHslFiltersItem.Index = 1;
            this.contrastHslFiltersItem.Text = "&Contrast";
            this.contrastHslFiltersItem.Click += new System.EventHandler( this.contrastHslFiltersItem_Click );
            // 
            // saturationHslFiltersItem
            // 
            this.saturationHslFiltersItem.Index = 2;
            this.saturationHslFiltersItem.Text = "&Saturation";
            this.saturationHslFiltersItem.Click += new System.EventHandler( this.saturationHslFiltersItem_Click );
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 3;
            this.menuItem29.Text = "-";
            // 
            // linearHslFiltersItem
            // 
            this.linearHslFiltersItem.Index = 4;
            this.linearHslFiltersItem.Text = "HSL Linear";
            this.linearHslFiltersItem.Click += new System.EventHandler( this.linearHslFiltersItem_Click );
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 5;
            this.menuItem28.Text = "-";
            // 
            // filteringHslFiltersItem
            // 
            this.filteringHslFiltersItem.Index = 6;
            this.filteringHslFiltersItem.Text = "HSL &Filtering";
            this.filteringHslFiltersItem.Click += new System.EventHandler( this.filteringHslFiltersItem_Click );
            // 
            // hueHslFiltersItem
            // 
            this.hueHslFiltersItem.Index = 7;
            this.hueHslFiltersItem.Text = "&Hue Modifier";
            this.hueHslFiltersItem.Click += new System.EventHandler( this.hueHslFiltersItem_Click );
            // 
            // ycbcrFiltersItem
            // 
            this.ycbcrFiltersItem.Index = 3;
            this.ycbcrFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.linearYCbCrFiltersItem,
            this.filteringYCbCrFiltersItem,
            this.menuItem37,
            this.extracYFiltersItem,
            this.extracCbFiltersItem,
            this.extracCrFiltersItem,
            this.menuItem38,
            this.replaceYFiltersItem,
            this.replaceCbFiltersItem,
            this.replaceCrFiltersItem} );
            this.ycbcrFiltersItem.Text = "&YCbCr Color space";
            // 
            // linearYCbCrFiltersItem
            // 
            this.linearYCbCrFiltersItem.Index = 0;
            this.linearYCbCrFiltersItem.Text = "YCbCr Linear";
            this.linearYCbCrFiltersItem.Click += new System.EventHandler( this.linearYCbCrFiltersItem_Click );
            // 
            // filteringYCbCrFiltersItem
            // 
            this.filteringYCbCrFiltersItem.Index = 1;
            this.filteringYCbCrFiltersItem.Text = "YCbCr Filtering";
            this.filteringYCbCrFiltersItem.Click += new System.EventHandler( this.filteringYCbCrFiltersItem_Click );
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 2;
            this.menuItem37.Text = "-";
            // 
            // extracYFiltersItem
            // 
            this.extracYFiltersItem.Index = 3;
            this.extracYFiltersItem.Text = "Extract Y Channel";
            this.extracYFiltersItem.Click += new System.EventHandler( this.extracYFiltersItem_Click );
            // 
            // extracCbFiltersItem
            // 
            this.extracCbFiltersItem.Index = 4;
            this.extracCbFiltersItem.Text = "Extract Cb Channel";
            this.extracCbFiltersItem.Click += new System.EventHandler( this.extracCbFiltersItem_Click );
            // 
            // extracCrFiltersItem
            // 
            this.extracCrFiltersItem.Index = 5;
            this.extracCrFiltersItem.Text = "Extract Cr Channel";
            this.extracCrFiltersItem.Click += new System.EventHandler( this.extracCrFiltersItem_Click );
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 6;
            this.menuItem38.Text = "-";
            // 
            // replaceYFiltersItem
            // 
            this.replaceYFiltersItem.Index = 7;
            this.replaceYFiltersItem.Text = "Replace Y Channel";
            this.replaceYFiltersItem.Click += new System.EventHandler( this.replaceYFiltersItem_Click );
            // 
            // replaceCbFiltersItem
            // 
            this.replaceCbFiltersItem.Index = 8;
            this.replaceCbFiltersItem.Text = "Replace Cb Channel";
            this.replaceCbFiltersItem.Click += new System.EventHandler( this.replaceCbFiltersItem_Click );
            // 
            // replaceCrFiltersItem
            // 
            this.replaceCrFiltersItem.Index = 9;
            this.replaceCrFiltersItem.Text = "Replace Cr Channel";
            this.replaceCrFiltersItem.Click += new System.EventHandler( this.replaceCrFiltersItem_Click );
            // 
            // binaryFiltersItem
            // 
            this.binaryFiltersItem.Index = 4;
            this.binaryFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.thresholdBinaryFiltersItem,
            this.menuItem15,
            this.thresholdCarryBinaryFiltersItem,
            this.orderedDitherBinaryFiltersItem,
            this.bayerDitherBinaryFiltersItem,
            this.menuItem14,
            this.floydBinaryFiltersItem,
            this.burkesBinaryFiltersItem,
            this.stuckiBinaryFiltersItem,
            this.jarvisBinaryFiltersItem,
            this.sierraBinaryFiltersItem,
            this.menuItem31,
            this.sisThresholdBinaryFiltersItem,
            this.otsuThresholdMenuItem} );
            this.binaryFiltersItem.Text = "&Binarization";
            // 
            // thresholdBinaryFiltersItem
            // 
            this.thresholdBinaryFiltersItem.Index = 0;
            this.thresholdBinaryFiltersItem.Text = "&Threshold";
            this.thresholdBinaryFiltersItem.Click += new System.EventHandler( this.thresholdBinaryFiltersItem_Click );
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "-";
            // 
            // thresholdCarryBinaryFiltersItem
            // 
            this.thresholdCarryBinaryFiltersItem.Index = 2;
            this.thresholdCarryBinaryFiltersItem.Text = "Threshold with Error &Carry";
            this.thresholdCarryBinaryFiltersItem.Click += new System.EventHandler( this.thresholdCarryBinaryFiltersItem_Click );
            // 
            // orderedDitherBinaryFiltersItem
            // 
            this.orderedDitherBinaryFiltersItem.Index = 3;
            this.orderedDitherBinaryFiltersItem.Text = "&Ordered Dither";
            this.orderedDitherBinaryFiltersItem.Click += new System.EventHandler( this.orderedDitherBinaryFiltersItem_Click );
            // 
            // bayerDitherBinaryFiltersItem
            // 
            this.bayerDitherBinaryFiltersItem.Index = 4;
            this.bayerDitherBinaryFiltersItem.Text = "Ba&yer Ordered Dither";
            this.bayerDitherBinaryFiltersItem.Click += new System.EventHandler( this.bayerDitherBinaryFiltersItem_Click );
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 5;
            this.menuItem14.Text = "-";
            // 
            // floydBinaryFiltersItem
            // 
            this.floydBinaryFiltersItem.Index = 6;
            this.floydBinaryFiltersItem.Text = "&Floyd-Steinberg";
            this.floydBinaryFiltersItem.Click += new System.EventHandler( this.floydBinaryFiltersItem_Click );
            // 
            // burkesBinaryFiltersItem
            // 
            this.burkesBinaryFiltersItem.Index = 7;
            this.burkesBinaryFiltersItem.Text = "&Burkes";
            this.burkesBinaryFiltersItem.Click += new System.EventHandler( this.burkesBinaryFiltersItem_Click );
            // 
            // stuckiBinaryFiltersItem
            // 
            this.stuckiBinaryFiltersItem.Index = 8;
            this.stuckiBinaryFiltersItem.Text = "&Stucki";
            this.stuckiBinaryFiltersItem.Click += new System.EventHandler( this.stuckiBinaryFiltersItem_Click );
            // 
            // jarvisBinaryFiltersItem
            // 
            this.jarvisBinaryFiltersItem.Index = 9;
            this.jarvisBinaryFiltersItem.Text = "&Jarvis-Judice-Ninke";
            this.jarvisBinaryFiltersItem.Click += new System.EventHandler( this.jarvisBinaryFiltersItem_Click );
            // 
            // sierraBinaryFiltersItem
            // 
            this.sierraBinaryFiltersItem.Index = 10;
            this.sierraBinaryFiltersItem.Text = "Sie&rra";
            this.sierraBinaryFiltersItem.Click += new System.EventHandler( this.sierraBinaryFiltersItem_Click );
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 11;
            this.menuItem31.Text = "-";
            // 
            // sisThresholdBinaryFiltersItem
            // 
            this.sisThresholdBinaryFiltersItem.Index = 12;
            this.sisThresholdBinaryFiltersItem.Text = "SIS Threshold";
            this.sisThresholdBinaryFiltersItem.Click += new System.EventHandler( this.sisThresholdBinaryFiltersItem_Click );
            // 
            // otsuThresholdMenuItem
            // 
            this.otsuThresholdMenuItem.Index = 13;
            this.otsuThresholdMenuItem.Text = "Otsu Threshold";
            this.otsuThresholdMenuItem.Click += new System.EventHandler( this.otsuThresholdMenuItem_Click );
            // 
            // morphologyFiltersItem
            // 
            this.morphologyFiltersItem.Index = 5;
            this.morphologyFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.erosionMorphologyFiltersItem,
            this.dilatationMorphologyFiltersItem,
            this.openingMorphologyFiltersItem,
            this.closingMorphologyFiltersItem,
            this.tophatMorphologyFiltersItem,
            this.bottomMorphologyFiltersItem,
            this.menuItem9,
            this.customMorphologyFiltersItem,
            this.menuItem27,
            this.hitAndMissFiltersItem} );
            this.morphologyFiltersItem.Text = "&Morphology";
            // 
            // erosionMorphologyFiltersItem
            // 
            this.erosionMorphologyFiltersItem.Index = 0;
            this.erosionMorphologyFiltersItem.Text = "&Erosion";
            this.erosionMorphologyFiltersItem.Click += new System.EventHandler( this.erosionMorphologyFiltersItem_Click );
            // 
            // dilatationMorphologyFiltersItem
            // 
            this.dilatationMorphologyFiltersItem.Index = 1;
            this.dilatationMorphologyFiltersItem.Text = "&Dilatation";
            this.dilatationMorphologyFiltersItem.Click += new System.EventHandler( this.dilatationMorphologyFiltersItem_Click );
            // 
            // openingMorphologyFiltersItem
            // 
            this.openingMorphologyFiltersItem.Index = 2;
            this.openingMorphologyFiltersItem.Text = "&Opening";
            this.openingMorphologyFiltersItem.Click += new System.EventHandler( this.openingMorphologyFiltersItem_Click );
            // 
            // closingMorphologyFiltersItem
            // 
            this.closingMorphologyFiltersItem.Index = 3;
            this.closingMorphologyFiltersItem.Text = "&Closing";
            this.closingMorphologyFiltersItem.Click += new System.EventHandler( this.closingMorphologyFiltersItem_Click );
            // 
            // tophatMorphologyFiltersItem
            // 
            this.tophatMorphologyFiltersItem.Index = 4;
            this.tophatMorphologyFiltersItem.Text = "&Top hat";
            this.tophatMorphologyFiltersItem.Click += new System.EventHandler( this.tophatMorphologyFiltersItem_Click );
            // 
            // bottomMorphologyFiltersItem
            // 
            this.bottomMorphologyFiltersItem.Index = 5;
            this.bottomMorphologyFiltersItem.Text = "&Bottom hat";
            this.bottomMorphologyFiltersItem.Click += new System.EventHandler( this.bottomMorphologyFiltersItem_Click );
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 6;
            this.menuItem9.Text = "-";
            // 
            // customMorphologyFiltersItem
            // 
            this.customMorphologyFiltersItem.Index = 7;
            this.customMorphologyFiltersItem.Text = "Cus&tom";
            this.customMorphologyFiltersItem.Click += new System.EventHandler( this.customMorphologyFiltersItem_Click );
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 8;
            this.menuItem27.Text = "-";
            // 
            // hitAndMissFiltersItem
            // 
            this.hitAndMissFiltersItem.Index = 9;
            this.hitAndMissFiltersItem.Text = "Hit And Miss, Thickening, Thinning";
            this.hitAndMissFiltersItem.Click += new System.EventHandler( this.hitAndMissFiltersItem_Click );
            // 
            // convolutionFiltersItem
            // 
            this.convolutionFiltersItem.Index = 6;
            this.convolutionFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.meanConvolutionFiltersItem,
            this.blurConvolutionFiltersItem,
            this.sharpenConvolutionFiltersItem,
            this.edgesConvolutionFiltersItem,
            this.menuItem12,
            this.customConvolutionFiltersItem,
            this.menuItem33,
            this.gaussianConvolutionFiltersItem,
            this.sharpenExConvolutionFiltersItem} );
            this.convolutionFiltersItem.Text = "Co&nvolution && Correlation";
            // 
            // meanConvolutionFiltersItem
            // 
            this.meanConvolutionFiltersItem.Index = 0;
            this.meanConvolutionFiltersItem.Text = "&Mean";
            this.meanConvolutionFiltersItem.Click += new System.EventHandler( this.meanConvolutionFiltersItem_Click );
            // 
            // blurConvolutionFiltersItem
            // 
            this.blurConvolutionFiltersItem.Index = 1;
            this.blurConvolutionFiltersItem.Text = "&Blur";
            this.blurConvolutionFiltersItem.Click += new System.EventHandler( this.blurConvolutionFiltersItem_Click );
            // 
            // sharpenConvolutionFiltersItem
            // 
            this.sharpenConvolutionFiltersItem.Index = 2;
            this.sharpenConvolutionFiltersItem.Text = "&Sharpen";
            this.sharpenConvolutionFiltersItem.Click += new System.EventHandler( this.sharpenConvolutionFiltersItem_Click );
            // 
            // edgesConvolutionFiltersItem
            // 
            this.edgesConvolutionFiltersItem.Index = 3;
            this.edgesConvolutionFiltersItem.Text = "&Edges";
            this.edgesConvolutionFiltersItem.Click += new System.EventHandler( this.edgesConvolutionFiltersItem_Click );
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "-";
            // 
            // customConvolutionFiltersItem
            // 
            this.customConvolutionFiltersItem.Index = 5;
            this.customConvolutionFiltersItem.Text = "&Custom";
            this.customConvolutionFiltersItem.Click += new System.EventHandler( this.customConvolutionFiltersItem_Click );
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 6;
            this.menuItem33.Text = "-";
            // 
            // gaussianConvolutionFiltersItem
            // 
            this.gaussianConvolutionFiltersItem.Index = 7;
            this.gaussianConvolutionFiltersItem.Text = "&Gaussian";
            this.gaussianConvolutionFiltersItem.Click += new System.EventHandler( this.gaussianConvolutionFiltersItem_Click );
            // 
            // sharpenExConvolutionFiltersItem
            // 
            this.sharpenExConvolutionFiltersItem.Index = 8;
            this.sharpenExConvolutionFiltersItem.Text = "Sharpen Ex";
            this.sharpenExConvolutionFiltersItem.Click += new System.EventHandler( this.sharpenExConvolutionFiltersItem_Click );
            // 
            // twosrcFiltersItem
            // 
            this.twosrcFiltersItem.Index = 7;
            this.twosrcFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.mergeTwosrcFiltersItem,
            this.intersectTwosrcFiltersItem,
            this.menuItem21,
            this.addTwosrcFiltersItem,
            this.subtractTwosrcFiltersItem,
            this.menuItem22,
            this.differenceTwosrcFiltersItem,
            this.moveTowardsTwosrcFiltersItem,
            this.morphTwosrcFiltersItem} );
            this.twosrcFiltersItem.Text = "Two source filters";
            // 
            // mergeTwosrcFiltersItem
            // 
            this.mergeTwosrcFiltersItem.Index = 0;
            this.mergeTwosrcFiltersItem.Text = "&Merge";
            this.mergeTwosrcFiltersItem.Click += new System.EventHandler( this.mergeTwosrcFiltersItem_Click );
            // 
            // intersectTwosrcFiltersItem
            // 
            this.intersectTwosrcFiltersItem.Index = 1;
            this.intersectTwosrcFiltersItem.Text = "&Intersect";
            this.intersectTwosrcFiltersItem.Click += new System.EventHandler( this.intersectTwosrcFiltersItem_Click );
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 2;
            this.menuItem21.Text = "-";
            // 
            // addTwosrcFiltersItem
            // 
            this.addTwosrcFiltersItem.Index = 3;
            this.addTwosrcFiltersItem.Text = "&Add";
            this.addTwosrcFiltersItem.Click += new System.EventHandler( this.addTwosrcFiltersItem_Click );
            // 
            // subtractTwosrcFiltersItem
            // 
            this.subtractTwosrcFiltersItem.Index = 4;
            this.subtractTwosrcFiltersItem.Text = "&Subtract";
            this.subtractTwosrcFiltersItem.Click += new System.EventHandler( this.subtractTwosrcFiltersItem_Click );
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 5;
            this.menuItem22.Text = "-";
            // 
            // differenceTwosrcFiltersItem
            // 
            this.differenceTwosrcFiltersItem.Index = 6;
            this.differenceTwosrcFiltersItem.Text = "&Difference";
            this.differenceTwosrcFiltersItem.Click += new System.EventHandler( this.differenceTwosrcFiltersItem_Click );
            // 
            // moveTowardsTwosrcFiltersItem
            // 
            this.moveTowardsTwosrcFiltersItem.Index = 7;
            this.moveTowardsTwosrcFiltersItem.Text = "&Move Towards";
            this.moveTowardsTwosrcFiltersItem.Click += new System.EventHandler( this.moveTowardsTwosrcFiltersItem_Click );
            // 
            // morphTwosrcFiltersItem
            // 
            this.morphTwosrcFiltersItem.Index = 8;
            this.morphTwosrcFiltersItem.Text = "Mo&rph";
            this.morphTwosrcFiltersItem.Click += new System.EventHandler( this.morphTwosrcFiltersItem_Click );
            // 
            // edgeFiltersItem
            // 
            this.edgeFiltersItem.Index = 8;
            this.edgeFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.homogenityEdgeFiltersItem,
            this.differenceEdgeFiltersItem,
            this.sobelEdgeFiltersItem,
            this.cannyEdgeFiltersItem} );
            this.edgeFiltersItem.Text = "&Edge detectors";
            // 
            // homogenityEdgeFiltersItem
            // 
            this.homogenityEdgeFiltersItem.Index = 0;
            this.homogenityEdgeFiltersItem.Text = "&Homogenity";
            this.homogenityEdgeFiltersItem.Click += new System.EventHandler( this.homogenityEdgeFiltersItem_Click );
            // 
            // differenceEdgeFiltersItem
            // 
            this.differenceEdgeFiltersItem.Index = 1;
            this.differenceEdgeFiltersItem.Text = "&Difference";
            this.differenceEdgeFiltersItem.Click += new System.EventHandler( this.differenceEdgeFiltersItem_Click );
            // 
            // sobelEdgeFiltersItem
            // 
            this.sobelEdgeFiltersItem.Index = 2;
            this.sobelEdgeFiltersItem.Text = "&Sobel";
            this.sobelEdgeFiltersItem.Click += new System.EventHandler( this.sobelEdgeFiltersItem_Click );
            // 
            // cannyEdgeFiltersItem
            // 
            this.cannyEdgeFiltersItem.Index = 3;
            this.cannyEdgeFiltersItem.Text = "&Canny";
            this.cannyEdgeFiltersItem.Click += new System.EventHandler( this.cannyEdgeFiltersItem_Click );
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 9;
            this.menuItem35.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.susanCornersDetectorMenuItem,
            this.moravecCornersDetectorMenuItem} );
            this.menuItem35.Text = "Corners detectors";
            // 
            // susanCornersDetectorMenuItem
            // 
            this.susanCornersDetectorMenuItem.Index = 0;
            this.susanCornersDetectorMenuItem.Text = "SUSAN";
            this.susanCornersDetectorMenuItem.Click += new System.EventHandler( this.susanCornersDetectorMenuItem_Click );
            // 
            // moravecCornersDetectorMenuItem
            // 
            this.moravecCornersDetectorMenuItem.Index = 1;
            this.moravecCornersDetectorMenuItem.Text = "Moravec";
            this.moravecCornersDetectorMenuItem.Click += new System.EventHandler( this.moravecCornersDetectorMenuItem_Click );
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 10;
            this.menuItem13.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.filterBlobsMenuItem,
            this.extractBiggestBlobMenuItem,
            this.blobExtractorFiltersItem,
            this.menuItem30,
            this.labelingFiltersItem} );
            this.menuItem13.Text = "Blobs processing";
            // 
            // filterBlobsMenuItem
            // 
            this.filterBlobsMenuItem.Index = 0;
            this.filterBlobsMenuItem.Text = "Filter Blobs";
            this.filterBlobsMenuItem.Click += new System.EventHandler( this.filterBlobsMenuItem_Click );
            // 
            // extractBiggestBlobMenuItem
            // 
            this.extractBiggestBlobMenuItem.Index = 1;
            this.extractBiggestBlobMenuItem.Text = "Extract Biggest Blob";
            this.extractBiggestBlobMenuItem.Click += new System.EventHandler( this.extractBiggestBlobMenuItem_Click );
            // 
            // blobExtractorFiltersItem
            // 
            this.blobExtractorFiltersItem.Index = 2;
            this.blobExtractorFiltersItem.Text = "&Blob Extractor";
            this.blobExtractorFiltersItem.Click += new System.EventHandler( this.blobExtractorFiltersItem_Click );
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 3;
            this.menuItem30.Text = "-";
            // 
            // labelingFiltersItem
            // 
            this.labelingFiltersItem.Index = 4;
            this.labelingFiltersItem.Text = "Connected Components Labeling";
            this.labelingFiltersItem.Click += new System.EventHandler( this.labelingFiltersItem_Click );
            // 
            // noiseFiltersItem
            // 
            this.noiseFiltersItem.Index = 11;
            this.noiseFiltersItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.additiveNoiseFiltersItem,
            this.saltNoiseFiltersItem} );
            this.noiseFiltersItem.Text = "&Noise generation";
            // 
            // additiveNoiseFiltersItem
            // 
            this.additiveNoiseFiltersItem.Index = 0;
            this.additiveNoiseFiltersItem.Text = "&Additive";
            this.additiveNoiseFiltersItem.Click += new System.EventHandler( this.additiveNoiseFiltersItem_Click );
            // 
            // saltNoiseFiltersItem
            // 
            this.saltNoiseFiltersItem.Index = 1;
            this.saltNoiseFiltersItem.Text = "&Salt and Pepper";
            this.saltNoiseFiltersItem.Click += new System.EventHandler( this.saltNoiseFiltersItem_Click );
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 12;
            this.menuItem24.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.adaptiveSmoothingFiltersItem,
            this.conservativeSmoothingFiltersItem,
            this.medianFiltersItem,
            this.menuItem34,
            this.perlinNoiseFiltersItem,
            this.oilPaintingFiltersItem,
            this.jitterFiltersItem,
            this.pixellateFiltersItem,
            this.simpleSkeletonizationFiltersItem,
            this.shrinkFiltersItem,
            this.simplePosterizatonMenuItem} );
            this.menuItem24.Text = "Other";
            // 
            // adaptiveSmoothingFiltersItem
            // 
            this.adaptiveSmoothingFiltersItem.Index = 0;
            this.adaptiveSmoothingFiltersItem.Text = "&Adaptive Smoothing";
            this.adaptiveSmoothingFiltersItem.Click += new System.EventHandler( this.adaptiveSmoothingFiltersItem_Click );
            // 
            // conservativeSmoothingFiltersItem
            // 
            this.conservativeSmoothingFiltersItem.Index = 1;
            this.conservativeSmoothingFiltersItem.Text = "&ConservativeSmoothing";
            this.conservativeSmoothingFiltersItem.Click += new System.EventHandler( this.conservativeSmoothingFiltersItem_Click );
            // 
            // medianFiltersItem
            // 
            this.medianFiltersItem.Index = 2;
            this.medianFiltersItem.Text = "Me&dian";
            this.medianFiltersItem.Click += new System.EventHandler( this.medianFiltersItem_Click );
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 3;
            this.menuItem34.Text = "-";
            // 
            // perlinNoiseFiltersItem
            // 
            this.perlinNoiseFiltersItem.Index = 4;
            this.perlinNoiseFiltersItem.Text = "Perlin Noise";
            this.perlinNoiseFiltersItem.Click += new System.EventHandler( this.perlinNoiseFiltersItem_Click );
            // 
            // oilPaintingFiltersItem
            // 
            this.oilPaintingFiltersItem.Index = 5;
            this.oilPaintingFiltersItem.Text = "&Oil Painting";
            this.oilPaintingFiltersItem.Click += new System.EventHandler( this.oilPaintingFiltersItem_Click );
            // 
            // jitterFiltersItem
            // 
            this.jitterFiltersItem.Index = 6;
            this.jitterFiltersItem.Text = "&Jitter";
            this.jitterFiltersItem.Click += new System.EventHandler( this.jitterFiltersItem_Click );
            // 
            // pixellateFiltersItem
            // 
            this.pixellateFiltersItem.Index = 7;
            this.pixellateFiltersItem.Text = "&Pixellate";
            this.pixellateFiltersItem.Click += new System.EventHandler( this.pixellateFiltersItem_Click );
            // 
            // simpleSkeletonizationFiltersItem
            // 
            this.simpleSkeletonizationFiltersItem.Index = 8;
            this.simpleSkeletonizationFiltersItem.Text = "Simple &Skeletonization";
            this.simpleSkeletonizationFiltersItem.Click += new System.EventHandler( this.simpleSkeletonizationFiltersItem_Click );
            // 
            // shrinkFiltersItem
            // 
            this.shrinkFiltersItem.Index = 9;
            this.shrinkFiltersItem.Text = "Shrink";
            this.shrinkFiltersItem.Click += new System.EventHandler( this.shrinkFiltersItem_Click );
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 13;
            this.menuItem23.Text = "-";
            // 
            // resizeFiltersItem
            // 
            this.resizeFiltersItem.Index = 14;
            this.resizeFiltersItem.Text = "&Resize";
            this.resizeFiltersItem.Click += new System.EventHandler( this.resizeFiltersItem_Click );
            // 
            // rotateFiltersItem
            // 
            this.rotateFiltersItem.Index = 15;
            this.rotateFiltersItem.Text = "Ro&tate";
            this.rotateFiltersItem.Click += new System.EventHandler( this.rotateFiltersItem_Click );
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 16;
            this.menuItem26.Text = "-";
            // 
            // levelsFiltersItem
            // 
            this.levelsFiltersItem.Index = 17;
            this.levelsFiltersItem.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.levelsFiltersItem.Text = "&Levels";
            this.levelsFiltersItem.Click += new System.EventHandler( this.levelsFiltersItem_Click );
            // 
            // contrastStretchMenuItem
            // 
            this.contrastStretchMenuItem.Index = 18;
            this.contrastStretchMenuItem.Text = "Contrast Stretch ";
            this.contrastStretchMenuItem.Click += new System.EventHandler( this.contrastStretchMenuItem_Click );
            // 
            // histogramEqualizationMenuItem
            // 
            this.histogramEqualizationMenuItem.Index = 19;
            this.histogramEqualizationMenuItem.Text = "Histogram Equalization";
            this.histogramEqualizationMenuItem.Click += new System.EventHandler( this.histogramEqualizationMenuItem_Click );
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 20;
            this.menuItem25.Text = "-";
            // 
            // fourierFiltersItem
            // 
            this.fourierFiltersItem.Index = 21;
            this.fourierFiltersItem.Text = "&Fourier Transformation";
            this.fourierFiltersItem.Click += new System.EventHandler( this.fourierFiltersItem_Click );
            // 
            // simplePosterizatonMenuItem
            // 
            this.simplePosterizatonMenuItem.Index = 10;
            this.simplePosterizatonMenuItem.Text = "Simple Posterization";
            this.simplePosterizatonMenuItem.Click += new System.EventHandler( this.simplePosterizatonMenuItem_Click );
            // 
            // ImageDoc
            // 
            this.AllowedStates = WeifenLuo.WinFormsUI.ContentStates.Document;
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
            this.ClientSize = new System.Drawing.Size( 528, 417 );
            this.Menu = this.mainMenu;
            this.Name = "ImageDoc";
            this.Text = "Image";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ImageDoc_MouseUp );
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.ImageDoc_MouseDown );
            this.MouseLeave += new System.EventHandler( this.ImageDoc_MouseLeave );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.ImageDoc_MouseMove );
            this.ResumeLayout( false );

        }
        #endregion

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
                    Bitmap newImage = (Bitmap) Bitmap.FromFile( fileName );

                    // Release current image
                    image.Dispose( );
                    // set document image to just loaded
                    image = newImage;

                    // format image
                    AForge.Imaging.Image.FormatImage( ref image );
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

                if ( !filterInfo.FormatTransalations.ContainsKey( image.PixelFormat ) )
                {
                    if ( filterInfo.FormatTransalations.ContainsKey( PixelFormat.Format24bppRgb ) )
                    {
                        MessageBox.Show( "The selected image processing routine may be applied to color image only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                    else
                    {
                        MessageBox.Show( "The selected image processing routine may be applied to grayscale or binary image only.\n\nUse grayscale (and threshold filter if required) before.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
            ApplyFilter( new GrayscaleBT709( ) );
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
                        new GrayscaleBT709( ),
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
                        new GrayscaleBT709( ),
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
                        new GrayscaleBT709( ),
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
            if ( CheckIfBinary( "Blob extractor" ) )
            {
                BlobCounter blobCounter = new BlobCounter( image );
                Blob[] blobs = blobCounter.GetObjects( image, false );

                foreach ( Blob blob in blobs )
                {
                    host.NewDocument( blob.Image );
                }
            }
        }

        // Filter blobs by size
        private void filterBlobsMenuItem_Click( object sender, EventArgs e )
        {
            if ( CheckIfBinary( "Blobs' filtering" ) )
            {
                BlobsFilteringForm form = new BlobsFilteringForm( );

                form.Image = image;

                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
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
