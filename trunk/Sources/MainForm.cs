// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using WeifenLuo.WinFormsUI;
using rpaulo.toolbar;
using AForge.Imaging;

namespace IPLab
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public partial class MainForm : System.Windows.Forms.Form, IDocumentsHost
	{
        /// <summary>
        /// Specifies the action the application performs upon starting.
        /// </summary>
        protected enum AutoOpenMode
        {
            None,
            Clipboard,
            File
        }

        // configuration files
        private static string configFile = Path.Combine( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "app.config" );
        private static string dockManagerConfigFile = Path.Combine( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "DockManager.config" );

		private int unNamedNumber = 0;
		private Configuration config = new Configuration();
		private HistogramWindow histogramWin = new HistogramWindow();
		private ImageStatisticsWindow statisticsWin = new ImageStatisticsWindow();
		private ToolBarManager toolBarManager;

        private AutoOpenMode autoOpenMode;
        private string autoOpenParam;

        protected MainForm( AutoOpenMode autoOpenMode, string autoOpenParam )
		{
            this.autoOpenMode  = autoOpenMode;
            this.autoOpenParam = autoOpenParam;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			toolBarManager = new ToolBarManager(this, this);

			// add toolbars
			ToolBarDockHolder holder;

			// main tool bar
			mainToolBar.Text = "Main Tool Bar";
			holder = toolBarManager.AddControl(mainToolBar);
			holder.AllowedBorders = AllowedBorders.Top | AllowedBorders.Left | AllowedBorders.Right;

			// image toolbar
			imageToolBar.Text = "Image Tool Bar";
			holder = toolBarManager.AddControl(imageToolBar);
			holder.AllowedBorders = AllowedBorders.Top | AllowedBorders.Left | AllowedBorders.Right;

			histogramWin.DockStateChanged += new EventHandler(histogram_DockStateChanged);
			statisticsWin.DockStateChanged += new EventHandler(statistics_DockStateChanged);

			histogramWin.VisibleChanged += new EventHandler( histogram_VisibleChanged );
			statisticsWin.VisibleChanged += new EventHandler( statistics_VisibleChanged );
		}


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args ) 
		{
            // parse the command line
            bool showUsage = false;
            AutoOpenMode autoOpenMode = AutoOpenMode.None;
            string autoOpenParam = string.Empty;

            if ( args.Length >= 1 )
            {
                if ( string.Compare( args[0], "/paste", true ) == 0 )
                {
                    autoOpenMode = AutoOpenMode.Clipboard;
                    if ( args.Length >= 2 )
                    {
                        showUsage = true;
                    }
                }
                else if ( string.Compare( args[0], "/open", true ) == 0 )
                {
                    autoOpenMode = AutoOpenMode.File;
                    if ( args.Length == 2 )
                    {
                        autoOpenParam = args[1];
                    }
                    else
                    {
                        showUsage = true;
                    }
                }
                else if ( File.Exists( args[0] ) )
                {
                    // handle the case where somebody just drops the file on the application icon
                    autoOpenMode  = AutoOpenMode.File;
                    autoOpenParam = args[0];
                }
                else
                {
                    showUsage = true;
                }
            }

            if ( showUsage )
            {
                MessageBox.Show( "Usage:\tiplab.exe [/paste | /open <fileName>]\r\n\r\nOptions:\t/paste\tPaste the contents of the clipboard.\r\n\t/open\tOpen the specified file.\r\n", "Image Processing Lab", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                Application.Run( new MainForm( autoOpenMode, autoOpenParam ) );
            }
		}

		#region IDocumentsHost implementation

		// Create new document on change on existent or modify it
		public bool CreateNewDocumentOnChange
		{
			get { return config.openInNewDoc; }
		}

		// Remember or not an image, so we can back one step
		public bool RememberOnChange
		{
			get { return config.rememberOnChange; }
		}

		// Create new document
		public bool NewDocument(Bitmap image)
		{
			unNamedNumber++;

			ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unNamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			// set events
			SetupDocumentEvents(imgDoc);

			return true;
		}

		// Create new document for ComplexImage
		public bool NewDocument(ComplexImage image)
		{
			unNamedNumber++;

			FourierDoc imgDoc = new FourierDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unNamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			return true;
		}

		// Get an image with specified dimension and pixel format
		public Bitmap GetImage(object sender, String text, Size size, PixelFormat format)
		{
			ArrayList	names = new ArrayList();
			ArrayList	images = new ArrayList();

			foreach (Content doc in dockManager.Documents)
			{
				if ((doc != sender) && (doc is ImageDoc))
				{
					Bitmap img = ((ImageDoc) doc).Image;

					// check pixel format, width and height
					if ((img.PixelFormat == format) &&
						((size.Width == -1) ||
						((img.Width == size.Width) && (img.Height == size.Height))))
					{
						names.Add(doc.Text);
						images.Add(img);
					}
				}
			}

			SelectImageForm form = new SelectImageForm();

			form.Description = text;
			form.ImageNames = names;

			// allow user to select an image
			if ((form.ShowDialog() == DialogResult.OK) && (form.SelectedItem != -1))
			{
				return (Bitmap) images[form.SelectedItem];
			}

			return null;
		}

		#endregion

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// close all files
			foreach (Content c in dockManager.Documents)
				c.Close();

			// save configuration
			config.mainWindowLocation = this.Location;
			config.mainWindowSize = this.Size;
			config.Save(configFile);
			// save dock manager configuration
			dockManager.SaveAsXml(dockManagerConfigFile);
		}

		// On form load
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// load configuration
			if (config.Load(configFile))
			{
				this.Location = config.mainWindowLocation;
				this.Size = config.mainWindowSize;
			}

			try
			{
				// load dock manager configuration
				if (File.Exists(dockManagerConfigFile))
					dockManager.LoadFromXml(dockManagerConfigFile, new GetContentCallback(GetContentFromPersistString));
			}
			catch (Exception)
			{
			}

			// show histogram
			ShowHistogram(config.histogramVisible);

            switch (autoOpenMode)
            {
                case AutoOpenMode.Clipboard:
                    PasteFromClipboard( );
                    break;

                case AutoOpenMode.File:
                    OpenFile( autoOpenParam );
                    break;
            }
		}

		// Callback for loading Dock Manager
		private Content GetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(HistogramWindow).ToString())
				return histogramWin;
			if (persistString == typeof(ImageStatisticsWindow).ToString())
				return statisticsWin;

			return null;
		}

		// Main tool bar clicked
		private void mainToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.ImageIndex)
			{
				case 0:		// open an image
					OpenFile();
					break;
				case 1:		// save file
					SaveFile();
					break;
				case 2:		// copy
					CopyToClipboard();
					break;
				case 3:		// paste
					PasteFromClipboard();
					break;
				case 4:		// show histogram window
					ShowHistogram(!config.histogramVisible);
					break;
				case 5:		//about
					About();
					break;
			}
		}

		// active document changed
		private void dockManager_ActiveDocumentChanged(object sender, System.EventArgs e)
		{
			Content		doc = dockManager.ActiveDocument;
			ImageDoc	imgDoc = (doc is ImageDoc) ? (ImageDoc) doc : null;

			UpdateHistogram(imgDoc);
			UpdateStatistics(imgDoc);
			UpdateZoomStatus(imgDoc);

			UpdateSizeStatus(doc);
		}

		// About
		private void About()
		{
			AboutForm	about = new AboutForm();

			about.ShowDialog();
		}

		// On "Help->About"
		private void aboutHelpItem_Click(object sender, System.EventArgs e)
		{
			About();
		}

		// on File item popum - set state ot child menu items
		private void fileItem_Popup(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;
			bool	docOpened = (doc != null);

			closeFileItem.Enabled = docOpened;
			closeAllFileItem.Enabled = (dockManager.Documents.Length > 0);
			reloadFileItem.Enabled = ((docOpened) && (doc is ImageDoc) && (((ImageDoc) doc).FileName != null));

			saveFileItem.Enabled = docOpened;
			copyFileItem.Enabled = docOpened;
			pasteFileItem.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));

			printFileItem.Enabled = docOpened;
			printPreviewFileItem.Enabled = docOpened;
		}

		// Exit application
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// Setup events
		private void SetupDocumentEvents(ImageDoc doc)
		{
			doc.DocumentChanged += new System.EventHandler(this.document_DocumentChanged);
			doc.ZoomChanged += new System.EventHandler(this.document_ZoomChanged);
			doc.MouseImagePosition += new ImageDoc.SelectionEventHandler(this.document_MouseImagePosition);
			doc.SelectionChanged += new ImageDoc.SelectionEventHandler(this.document_SelectionChanged);
		}

		// Open file
		private void OpenFile( )
		{
			if ( ofd.ShowDialog( ) == DialogResult.OK )
			{
                OpenFile( ofd.FileName );
			}		
		}

        // Open specified file
        private void OpenFile( string fileName )
        {
            ImageDoc imgDoc = null;

            try
            {
                // create image document
                imgDoc = new ImageDoc( fileName, (IDocumentsHost) this );
                imgDoc.Text = Path.GetFileName( fileName );

            }
            catch ( ApplicationException ex )
            {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

            if ( imgDoc != null )
            {
                imgDoc.Show( dockManager );
                imgDoc.Focus( );

                // set events
                SetupDocumentEvents( imgDoc );
            }
        }

		// Show/hide histogram
		private void ShowHistogram(bool show)
		{
			config.histogramVisible = show;

			histogramViewItem.Checked = show;
			histogramButton.Pushed = show;

			if (show)
			{
				histogramWin.Show(dockManager);
			}
			else
			{
				histogramWin.Hide();
			}
		}

		// Show/hide statistics
		private void ShowStatistics(bool show)
		{
			config.statisticsVisible = show;

			statisticsViewItem.Checked = show;

			if ( show )
			{
				statisticsWin.Show( dockManager );
			}
			else
			{
				statisticsWin.Hide( );
			}
		}



		// On "File->Open" item clicked
		private void OpenItem_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		// Reload file
		private void reloadFileItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
			{
				try
				{
					((ImageDoc) doc).Reload();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Save file
		private void SaveFile()
		{
			Content	doc = dockManager.ActiveDocument;

			if ( doc != null )
			{
				// set initial file name
				if ( ( doc is ImageDoc ) && ( ( (ImageDoc) doc ).FileName != null ) )
				{
					sfd.FileName = Path.GetFileName( ( (ImageDoc) doc ).FileName );
				}
				else
				{
					sfd.FileName = doc.Text + ".png";
				}

				sfd.FilterIndex = 0;

				// show dialog
				if ( sfd.ShowDialog( this ) == DialogResult.OK )
				{
					ImageFormat format = ImageFormat.Jpeg;

					// resolve file format
					switch ( Path.GetExtension( sfd.FileName ).ToLower( ) )
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
						default:
							MessageBox.Show( this, "Unsupported image format was specified", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error );
							return;
					}

					// save the image
					try
					{
						if ( doc is ImageDoc )
						{
							( (ImageDoc) doc ).Image.Save( sfd.FileName, format );
						}
						if (doc is FourierDoc)
						{
							( (FourierDoc) doc ).Image.Save( sfd.FileName, format );
						}
					}
					catch ( Exception )
					{
						MessageBox.Show( this, "Failed writing image file", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error );
					}
				}
			}
		}

		// On "File->Save" - save the file
		private void saveFileItem_Click(object sender, System.EventArgs e)
		{
			SaveFile( );
		}

		// Copy image to clipboard
		private void CopyToClipboard()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					Clipboard.SetDataObject(((ImageDoc) doc).Image, true);
				}
				if (doc is FourierDoc)
				{
					Clipboard.SetDataObject(((FourierDoc) doc).Image, true);
				}
			}
		}

		// On "File->Copy" - copy image to clipboard
		private void copyFileItem_Click(object sender, System.EventArgs e)
		{
			CopyToClipboard();
		}

		// Paste image from clipboard
		private void PasteFromClipboard()
		{
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
			{
				ImageDoc imgDoc = new ImageDoc((Bitmap) Clipboard.GetDataObject().GetData(DataFormats.Bitmap), (IDocumentsHost) this);

				imgDoc.Text = "Image " + unNamedNumber.ToString();
				imgDoc.Show(dockManager);
				imgDoc.Focus();

				// set events
				SetupDocumentEvents(imgDoc);
			}
		}

		// On "File->Paste" - paste image from clipboard
		private void pasteFileItem_Click(object sender, System.EventArgs e)
		{
			PasteFromClipboard();
		}

		// Close file
		private void closeFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
				dockManager.ActiveDocument.Close();
		}

		// Close all files
		private void closeAllFileItem_Click(object sender, System.EventArgs e)
		{
			foreach (Content c in dockManager.Documents)
				c.Close();
		}

		// Page setup
		private void pageSetupFileItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				pageSetupDialog.Document = printDocument;
				pageSetupDialog.ShowDialog();
			}
			catch (InvalidPrinterException)
			{
				MessageBox.Show(this, "Failed accessing printer device", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Print image
		private void printFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printDialog.Document = printDocument;
					if (printDialog.ShowDialog() == DialogResult.OK)
					{
						printDocument.Print();
					}
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Print preview
		private void printPreviewFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printPreviewDialog.Document = printDocument;
					printPreviewDialog.ShowDialog();
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}		
		}

		// On "Options" popup
		private void optionsItem_Popup(object sender, System.EventArgs e)
		{
			this.openInNewOptionsItem.Checked = config.openInNewDoc;
			this.rememberOptionsItem.Checked = config.rememberOnChange;
		}

		// On "Options->Open in new Document" click
		private void openInNewOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.openInNewDoc = !config.openInNewDoc;
		}

		// On "Options->Remember on change" click
		private void rememberOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.rememberOnChange = !config.rememberOnChange;
		}

		// On "View" popup
		private void viewItem_Popup(object sender, System.EventArgs e)
		{
			centerViewItem.Enabled = ((dockManager.ActiveDocument != null) && (dockManager.ActiveDocument is ImageDoc));

			ToolBarDockHolder holder;
			// Main tool bar
			holder = toolBarManager.GetHolder(mainToolBar);
			mainBarViewItem.Checked = holder.Visible;
			// Image tool bar
			holder = toolBarManager.GetHolder(imageToolBar);
			imageBarViewItem.Checked = holder.Visible;
		}

		// On "View->Histogram" - show histogram
		private void histogramViewItem_Click(object sender, System.EventArgs e)
		{
			ShowHistogram( !config.histogramVisible );
		}

		// On "View->Statistics" - show histogram
		private void statisticsViewItem_Click(object sender, System.EventArgs e)
		{
			ShowStatistics( !config.statisticsVisible );
		}

		// Histogram visibility changed		
		private void histogram_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.Visible )
				histogramWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// Statistics visibility changed		
		private void statistics_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.Visible )
				statisticsWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// On "View->Center" - center image
		private void centerViewItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
				((ImageDoc) doc).Center();
		}

		// Switch histogram to red channel
		private void redHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(0);
		}

		// Switch histogram to green channel
		private void greenHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(1);
		}

		// Switch histogram to blue channel
		private void blueHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(2);
		}

		// On document changed
		private void document_DocumentChanged(object sender, System.EventArgs e)
		{
			UpdateHistogram((ImageDoc) sender);
			UpdateStatistics((ImageDoc) sender);
			UpdateSizeStatus((ImageDoc) sender);
		}

		// On zoom factor changed
		private void document_ZoomChanged(object sender, System.EventArgs e)
		{
			UpdateZoomStatus((ImageDoc) sender);
		}

		// On mouse position over image changed
		private void document_MouseImagePosition(object sender, SelectionEventArgs e)
		{
			if (e.Location.X >= 0)
			{
				this.selectionPanel.Text = string.Format( "({0}, {1})", e.Location.X, e.Location.Y );

				// get current color
				Bitmap image = ((ImageDoc) sender).Image;
				if (image.PixelFormat == PixelFormat.Format24bppRgb)
				{
					Color	color = image.GetPixel(e.Location.X, e.Location.Y);
					RGB		rgb = new RGB( color );
                    YCbCr	ycbcr = AForge.Imaging.YCbCr.FromRGB( rgb );

					// RGB
					this.colorPanel.Text = string.Format( "RGB: {0}; {1}; {2}", color.R, color.G, color.B );
					// HSL
					this.hslPanel.Text = string.Format( "HSL: {0}; {1:F3}; {2:F3}", (int) color.GetHue(), color.GetSaturation(), color.GetBrightness() );
					// YCbCr
					this.ycbcrPanel.Text = string.Format( "YCbCr: {0:F3}; {1:F3}; {2:F3}", ycbcr.Y, ycbcr.Cb, ycbcr.Cr );
				}
				else if (image.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					Color color = image.GetPixel(e.Location.X, e.Location.Y);
					this.colorPanel.Text	= "Gray: " + color.R.ToString();
					this.hslPanel.Text		= "";
					this.ycbcrPanel.Text	= "";
				}
			}
			else
			{
				this.selectionPanel.Text	= "";
				this.colorPanel.Text		= "";
				this.hslPanel.Text			= "";
				this.ycbcrPanel.Text		= "";
			}
		}

		// On selection changed
		private void document_SelectionChanged(object sender, SelectionEventArgs e)
		{
			this.selectionPanel.Text = string.Format( "({0}, {1}) - {2} x {3}", e.Location.X, e.Location.Y, e.Size.Width, e.Size.Height );
		}

		// Update histogram
		private void UpdateHistogram(ImageDoc imgDoc)
		{
            if ( config.histogramVisible )
				histogramWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

        // Update statistics
		private void UpdateStatistics( ImageDoc imgDoc )
		{
            if ( config.statisticsVisible )
				statisticsWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

		// Update size status
		private void UpdateSizeStatus(Content doc)
		{
			if (doc != null)
			{
				int w = 0, h = 0;

				if (doc is ImageDoc)
				{
					w = ((ImageDoc) doc).ImageWidth;
					h = ((ImageDoc) doc).ImageHeight;
				}
				else if (doc is FourierDoc)
				{
					w = ((FourierDoc) doc).ImageWidth;
					h = ((FourierDoc) doc).ImageHeight;
				}

				sizePanel.Text = w.ToString() + " x " + h.ToString();
			}
			else
			{
				sizePanel.Text = String.Empty;
			}
		}

		// Update zoom status
		private void UpdateZoomStatus(ImageDoc imgDoc)
		{
			if (imgDoc != null)
			{
				int zoom = (int)(imgDoc.Zoom * 100);
				zoomPanel.Text = zoom.ToString() + "%";
			}
			else
			{
				zoomPanel.Text = String.Empty;
			}
		}

		// On image toolbar clicked
		private void imageToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					ImageDocCommands[] cmd = new ImageDocCommands[]
					{
						ImageDocCommands.Clone, ImageDocCommands.Crop,
						ImageDocCommands.ZoomIn, ImageDocCommands.ZoomOut,
						ImageDocCommands.ZoomOriginal, ImageDocCommands.FitToSize,
						ImageDocCommands.Levels, ImageDocCommands.Grayscale,
						ImageDocCommands.Threshold, ImageDocCommands.Morphology,
						ImageDocCommands.Convolution, ImageDocCommands.Resize,
						ImageDocCommands.Rotate, ImageDocCommands.Saturation,
						ImageDocCommands.Fourier
					};

					((ImageDoc) doc).ExecuteCommand(cmd[e.Button.ImageIndex]);
				}
			}
		}

		// On "View->Main Tool bar" menu item click
		private void mainBarViewItem_Click(object sender, System.EventArgs e)
		{
			ToolBarDockHolder holder = toolBarManager.GetHolder(mainToolBar);
			toolBarManager.ShowControl(mainToolBar, !holder.Visible);
		}

		// On "View->Image Tool bar" menu item click
		private void imageBarViewItem_Click(object sender, System.EventArgs e)
		{
			ToolBarDockHolder holder = toolBarManager.GetHolder(imageToolBar);
			toolBarManager.ShowControl(imageToolBar, !holder.Visible);
		}

		// Histogram docking state changed
		private void histogram_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.DockState != DockState.Unknown )
			{
				bool visible = (histogramWin.DockState != DockState.Hidden);

				// save to config
				config.histogramVisible = visible;

				// update menu & tool bar
				histogramViewItem.Checked = visible;
				histogramButton.Pushed = visible;
			}
		}

		// Statistics docking state changed
		private void statistics_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.DockState != DockState.Unknown )
			{
				bool visible = (statisticsWin.DockState != DockState.Hidden);

				// save to config
				config.statisticsVisible = visible;

				// update menu & tool bar
				statisticsViewItem.Checked = visible;
			}
		}

		// Print document page
		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				Bitmap image = null;

				// get an image to print
				if (doc is ImageDoc)
				{
					image = ((ImageDoc) doc).Image;
				}
				else if (doc is FourierDoc)
				{
					image = ((FourierDoc) doc).Image;
				}

				System.Diagnostics.Debug.WriteLine("X: " + e.MarginBounds.Left + ", Y = " + e.MarginBounds.Top + ", width = " + e.MarginBounds.Width + ", height = " + e.MarginBounds.Height);
				System.Diagnostics.Debug.WriteLine("X: " + e.PageBounds.Left + ", Y = " + e.PageBounds.Top + ", width = " + e.PageBounds.Width + ", height = " + e.PageBounds.Height);

				int		width = image.Width;
				int		height = image.Height;

				if ((width > e.MarginBounds.Width) || (height > e.MarginBounds.Height))
				{
					float f = Math.Min((float) e.MarginBounds.Width / width, (float) e.MarginBounds.Height / height);

					width = (int)(f * width);
					height = (int)(f * height);
				}

				e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top, width, height);
			}
		}
	}
}
