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
	public class MainForm : System.Windows.Forms.Form, IDocumentsHost
	{
        private static string configFile = Path.Combine( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "app.config" );
        private static string dockManagerConfigFile = Path.Combine( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "DockManager.config" );

		private int unnamedNumber = 0;
		private Configuration config = new Configuration();
		private HistogramWindow histogramWin = new HistogramWindow();
		private ImageStatisticsWindow statisticsWin = new ImageStatisticsWindow();

		private ToolBarManager toolBarManager;
		private WeifenLuo.WinFormsUI.DockManager dockManager;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem fileItem;
		private System.Windows.Forms.MenuItem exitFileItem;
		private System.Windows.Forms.MenuItem OpenItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem closeFileItem;
		private System.Windows.Forms.MenuItem closeAllFileItem;
		private System.Windows.Forms.MenuItem optionsItem;
		private System.Windows.Forms.MenuItem openInNewOptionsItem;
		private System.Windows.Forms.MenuItem viewItem;
		private System.Windows.Forms.MenuItem windowItem;
		private System.Windows.Forms.MenuItem helpItem;
		private System.Windows.Forms.MenuItem histogramViewItem;
		private System.Windows.Forms.MenuItem redHistogramViewItem;
		private System.Windows.Forms.MenuItem greenHistogramViewItem;
		private System.Windows.Forms.MenuItem blueHistogramViewItem;
		private System.Windows.Forms.StatusBarPanel zoomPanel;
		private System.Windows.Forms.StatusBarPanel sizePanel;
		private System.Windows.Forms.StatusBarPanel infoPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem rememberOptionsItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem reloadFileItem;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem centerViewItem;
		private System.Windows.Forms.StatusBarPanel selectionPanel;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.StatusBarPanel colorPanel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolBar mainToolBar;
		private System.Windows.Forms.ToolBarButton openButton;
		private System.Windows.Forms.ToolBarButton sep1;
		private System.Windows.Forms.ToolBarButton histogramButton;
		private System.Windows.Forms.ToolBar imageToolBar;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ToolBarButton cloneButton;
		private System.Windows.Forms.ToolBarButton cropButton;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton zoomInButton;
		private System.Windows.Forms.ToolBarButton zoomOutButton;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton fitToScreenButton;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton aboutButton;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton levelsButton;
		private System.Windows.Forms.ToolBarButton grayscaleButton;
		private System.Windows.Forms.ToolBarButton thresholdButton;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton morphologyButton;
		private System.Windows.Forms.ToolBarButton convolutionButton;
		private System.Windows.Forms.MenuItem mainBarViewItem;
		private System.Windows.Forms.MenuItem imageBarViewItem;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.ToolBarButton resizeButton;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton rotateButton;
		private System.Windows.Forms.StatusBarPanel hslPanel;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton saturationButton;
		private System.Windows.Forms.ToolBarButton fourierButton;
		private System.Windows.Forms.MenuItem copyFileItem;
		private System.Windows.Forms.MenuItem pasteFileItem;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem saveFileItem;
		private System.Windows.Forms.MenuItem aboutHelpItem;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.ToolBarButton pasteButton;
		private System.Windows.Forms.ToolBarButton saveButton;
		private System.Windows.Forms.ToolBarButton copyButton;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.MenuItem printPreviewFileItem;
		private System.Windows.Forms.MenuItem pageSetupFileItem;
		private System.Windows.Forms.MenuItem printFileItem;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.StatusBarPanel ycbcrPanel;
		private System.Windows.Forms.MenuItem statisticsViewItem;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
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
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.fileItem = new System.Windows.Forms.MenuItem();
			this.OpenItem = new System.Windows.Forms.MenuItem();
			this.reloadFileItem = new System.Windows.Forms.MenuItem();
			this.saveFileItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.copyFileItem = new System.Windows.Forms.MenuItem();
			this.pasteFileItem = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.closeFileItem = new System.Windows.Forms.MenuItem();
			this.closeAllFileItem = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.pageSetupFileItem = new System.Windows.Forms.MenuItem();
			this.printFileItem = new System.Windows.Forms.MenuItem();
			this.printPreviewFileItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.exitFileItem = new System.Windows.Forms.MenuItem();
			this.viewItem = new System.Windows.Forms.MenuItem();
			this.mainBarViewItem = new System.Windows.Forms.MenuItem();
			this.imageBarViewItem = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.histogramViewItem = new System.Windows.Forms.MenuItem();
			this.redHistogramViewItem = new System.Windows.Forms.MenuItem();
			this.greenHistogramViewItem = new System.Windows.Forms.MenuItem();
			this.blueHistogramViewItem = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.centerViewItem = new System.Windows.Forms.MenuItem();
			this.optionsItem = new System.Windows.Forms.MenuItem();
			this.openInNewOptionsItem = new System.Windows.Forms.MenuItem();
			this.rememberOptionsItem = new System.Windows.Forms.MenuItem();
			this.windowItem = new System.Windows.Forms.MenuItem();
			this.helpItem = new System.Windows.Forms.MenuItem();
			this.aboutHelpItem = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.zoomPanel = new System.Windows.Forms.StatusBarPanel();
			this.sizePanel = new System.Windows.Forms.StatusBarPanel();
			this.selectionPanel = new System.Windows.Forms.StatusBarPanel();
			this.colorPanel = new System.Windows.Forms.StatusBarPanel();
			this.hslPanel = new System.Windows.Forms.StatusBarPanel();
			this.ycbcrPanel = new System.Windows.Forms.StatusBarPanel();
			this.infoPanel = new System.Windows.Forms.StatusBarPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dockManager = new WeifenLuo.WinFormsUI.DockManager();
			this.mainToolBar = new System.Windows.Forms.ToolBar();
			this.openButton = new System.Windows.Forms.ToolBarButton();
			this.saveButton = new System.Windows.Forms.ToolBarButton();
			this.sep1 = new System.Windows.Forms.ToolBarButton();
			this.copyButton = new System.Windows.Forms.ToolBarButton();
			this.pasteButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
			this.histogramButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.aboutButton = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.imageToolBar = new System.Windows.Forms.ToolBar();
			this.cloneButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.cropButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.zoomInButton = new System.Windows.Forms.ToolBarButton();
			this.zoomOutButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.fitToScreenButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.resizeButton = new System.Windows.Forms.ToolBarButton();
			this.rotateButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.levelsButton = new System.Windows.Forms.ToolBarButton();
			this.grayscaleButton = new System.Windows.Forms.ToolBarButton();
			this.thresholdButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.morphologyButton = new System.Windows.Forms.ToolBarButton();
			this.convolutionButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
			this.saturationButton = new System.Windows.Forms.ToolBarButton();
			this.fourierButton = new System.Windows.Forms.ToolBarButton();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.statisticsViewItem = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizePanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.colorPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hslPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
			this.panel1.SuspendLayout();
			this.dockManager.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.fileItem,
																					 this.viewItem,
																					 this.optionsItem,
																					 this.windowItem,
																					 this.helpItem});
			// 
			// fileItem
			// 
			this.fileItem.Index = 0;
			this.fileItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.OpenItem,
																					 this.reloadFileItem,
																					 this.saveFileItem,
																					 this.menuItem1,
																					 this.copyFileItem,
																					 this.pasteFileItem,
																					 this.menuItem5,
																					 this.closeFileItem,
																					 this.closeAllFileItem,
																					 this.menuItem8,
																					 this.pageSetupFileItem,
																					 this.printFileItem,
																					 this.printPreviewFileItem,
																					 this.menuItem2,
																					 this.exitFileItem});
			this.fileItem.Text = "&File";
			this.fileItem.Popup += new System.EventHandler(this.fileItem_Popup);
			// 
			// OpenItem
			// 
			this.OpenItem.Index = 0;
			this.OpenItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.OpenItem.Text = "&Open";
			this.OpenItem.Click += new System.EventHandler(this.OpenItem_Click);
			// 
			// reloadFileItem
			// 
			this.reloadFileItem.Index = 1;
			this.reloadFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.reloadFileItem.Text = "&Reload";
			this.reloadFileItem.Click += new System.EventHandler(this.reloadFileItem_Click);
			// 
			// saveFileItem
			// 
			this.saveFileItem.Index = 2;
			this.saveFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.saveFileItem.Text = "&Save";
			this.saveFileItem.Click += new System.EventHandler(this.saveFileItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// copyFileItem
			// 
			this.copyFileItem.Index = 4;
			this.copyFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.copyFileItem.Text = "&Copy";
			this.copyFileItem.Click += new System.EventHandler(this.copyFileItem_Click);
			// 
			// pasteFileItem
			// 
			this.pasteFileItem.Index = 5;
			this.pasteFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.pasteFileItem.Text = "&Paste";
			this.pasteFileItem.Click += new System.EventHandler(this.pasteFileItem_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 6;
			this.menuItem5.Text = "-";
			// 
			// closeFileItem
			// 
			this.closeFileItem.Index = 7;
			this.closeFileItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
			this.closeFileItem.Text = "C&lose";
			this.closeFileItem.Click += new System.EventHandler(this.closeFileItem_Click);
			// 
			// closeAllFileItem
			// 
			this.closeAllFileItem.Index = 8;
			this.closeAllFileItem.Text = "Close All";
			this.closeAllFileItem.Click += new System.EventHandler(this.closeAllFileItem_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 9;
			this.menuItem8.Text = "-";
			// 
			// pageSetupFileItem
			// 
			this.pageSetupFileItem.Index = 10;
			this.pageSetupFileItem.Text = "Page Setup";
			this.pageSetupFileItem.Click += new System.EventHandler(this.pageSetupFileItem_Click);
			// 
			// printFileItem
			// 
			this.printFileItem.Index = 11;
			this.printFileItem.Text = "&Print";
			this.printFileItem.Click += new System.EventHandler(this.printFileItem_Click);
			// 
			// printPreviewFileItem
			// 
			this.printPreviewFileItem.Index = 12;
			this.printPreviewFileItem.Text = "Print Preview";
			this.printPreviewFileItem.Click += new System.EventHandler(this.printPreviewFileItem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 13;
			this.menuItem2.Text = "-";
			// 
			// exitFileItem
			// 
			this.exitFileItem.Index = 14;
			this.exitFileItem.Text = "E&xit";
			this.exitFileItem.Click += new System.EventHandler(this.exitFileItem_Click);
			// 
			// viewItem
			// 
			this.viewItem.Index = 1;
			this.viewItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mainBarViewItem,
																					 this.imageBarViewItem,
																					 this.menuItem7,
																					 this.histogramViewItem,
																					 this.statisticsViewItem,
																					 this.redHistogramViewItem,
																					 this.greenHistogramViewItem,
																					 this.blueHistogramViewItem,
																					 this.menuItem3,
																					 this.centerViewItem});
			this.viewItem.MergeOrder = 1;
			this.viewItem.Text = "&View";
			this.viewItem.Popup += new System.EventHandler(this.viewItem_Popup);
			// 
			// mainBarViewItem
			// 
			this.mainBarViewItem.Index = 0;
			this.mainBarViewItem.Text = "Main tool bar";
			this.mainBarViewItem.Click += new System.EventHandler(this.mainBarViewItem_Click);
			// 
			// imageBarViewItem
			// 
			this.imageBarViewItem.Index = 1;
			this.imageBarViewItem.Text = "Image tool bar";
			this.imageBarViewItem.Click += new System.EventHandler(this.imageBarViewItem_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			// 
			// histogramViewItem
			// 
			this.histogramViewItem.Index = 3;
			this.histogramViewItem.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.histogramViewItem.Text = "&Histogram";
			this.histogramViewItem.Click += new System.EventHandler(this.histogramViewItem_Click);
			// 
			// redHistogramViewItem
			// 
			this.redHistogramViewItem.Index = 5;
			this.redHistogramViewItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
			this.redHistogramViewItem.Text = "R";
			this.redHistogramViewItem.Visible = false;
			this.redHistogramViewItem.Click += new System.EventHandler(this.redHistogramViewItem_Click);
			// 
			// greenHistogramViewItem
			// 
			this.greenHistogramViewItem.Index = 6;
			this.greenHistogramViewItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
			this.greenHistogramViewItem.Text = "G";
			this.greenHistogramViewItem.Visible = false;
			this.greenHistogramViewItem.Click += new System.EventHandler(this.greenHistogramViewItem_Click);
			// 
			// blueHistogramViewItem
			// 
			this.blueHistogramViewItem.Index = 7;
			this.blueHistogramViewItem.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
			this.blueHistogramViewItem.Text = "B";
			this.blueHistogramViewItem.Visible = false;
			this.blueHistogramViewItem.Click += new System.EventHandler(this.blueHistogramViewItem_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 8;
			this.menuItem3.Text = "-";
			// 
			// centerViewItem
			// 
			this.centerViewItem.Index = 9;
			this.centerViewItem.Shortcut = System.Windows.Forms.Shortcut.F9;
			this.centerViewItem.Text = "&Center";
			this.centerViewItem.Click += new System.EventHandler(this.centerViewItem_Click);
			// 
			// optionsItem
			// 
			this.optionsItem.Index = 2;
			this.optionsItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.openInNewOptionsItem,
																						this.rememberOptionsItem});
			this.optionsItem.MergeOrder = 2;
			this.optionsItem.Text = "&Options";
			this.optionsItem.Popup += new System.EventHandler(this.optionsItem_Popup);
			// 
			// openInNewOptionsItem
			// 
			this.openInNewOptionsItem.Index = 0;
			this.openInNewOptionsItem.Text = "Open in &new document on change";
			this.openInNewOptionsItem.Click += new System.EventHandler(this.openInNewOptionsItem_Click);
			// 
			// rememberOptionsItem
			// 
			this.rememberOptionsItem.Index = 1;
			this.rememberOptionsItem.Text = "&Remember on change";
			this.rememberOptionsItem.Click += new System.EventHandler(this.rememberOptionsItem_Click);
			// 
			// windowItem
			// 
			this.windowItem.Index = 3;
			this.windowItem.MdiList = true;
			this.windowItem.MergeOrder = 3;
			this.windowItem.Text = "&Window";
			// 
			// helpItem
			// 
			this.helpItem.Index = 4;
			this.helpItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.aboutHelpItem});
			this.helpItem.MergeOrder = 4;
			this.helpItem.Text = "&Help";
			// 
			// aboutHelpItem
			// 
			this.aboutHelpItem.Index = 0;
			this.aboutHelpItem.Text = "&About";
			this.aboutHelpItem.Click += new System.EventHandler(this.aboutHelpItem_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 511);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.zoomPanel,
																						 this.sizePanel,
																						 this.selectionPanel,
																						 this.colorPanel,
																						 this.hslPanel,
																						 this.ycbcrPanel,
																						 this.infoPanel});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(792, 22);
			this.statusBar.TabIndex = 1;
			// 
			// zoomPanel
			// 
			this.zoomPanel.ToolTipText = "Zoom coefficient";
			this.zoomPanel.Width = 50;
			// 
			// sizePanel
			// 
			this.sizePanel.ToolTipText = "Image size";
			// 
			// selectionPanel
			// 
			this.selectionPanel.ToolTipText = "Current point and selection size";
			this.selectionPanel.Width = 120;
			// 
			// colorPanel
			// 
			this.colorPanel.ToolTipText = "Current color";
			this.colorPanel.Width = 110;
			// 
			// hslPanel
			// 
			this.hslPanel.Width = 130;
			// 
			// ycbcrPanel
			// 
			this.ycbcrPanel.Width = 145;
			// 
			// infoPanel
			// 
			this.infoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.infoPanel.Width = 121;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dockManager});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 511);
			this.panel1.TabIndex = 2;
			// 
			// dockManager
			// 
			this.dockManager.ActiveAutoHideContent = null;
			this.dockManager.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.mainToolBar,
																					  this.imageToolBar});
			this.dockManager.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockManager.Name = "dockManager";
			this.dockManager.Size = new System.Drawing.Size(792, 511);
			this.dockManager.TabIndex = 2;
			this.dockManager.ActiveDocumentChanged += new System.EventHandler(this.dockManager_ActiveDocumentChanged);
			// 
			// mainToolBar
			// 
			this.mainToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.mainToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.openButton,
																						   this.saveButton,
																						   this.sep1,
																						   this.copyButton,
																						   this.pasteButton,
																						   this.toolBarButton9,
																						   this.histogramButton,
																						   this.toolBarButton4,
																						   this.aboutButton});
			this.mainToolBar.Divider = false;
			this.mainToolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.mainToolBar.DropDownArrows = true;
			this.mainToolBar.ImageList = this.imageList;
			this.mainToolBar.Location = new System.Drawing.Point(256, 32);
			this.mainToolBar.Name = "mainToolBar";
			this.mainToolBar.ShowToolTips = true;
			this.mainToolBar.Size = new System.Drawing.Size(24, 199);
			this.mainToolBar.TabIndex = 2;
			this.mainToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.mainToolBar_ButtonClick);
			// 
			// openButton
			// 
			this.openButton.ImageIndex = 0;
			this.openButton.ToolTipText = "Open an image ";
			// 
			// saveButton
			// 
			this.saveButton.ImageIndex = 1;
			this.saveButton.ToolTipText = "Save";
			// 
			// sep1
			// 
			this.sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// copyButton
			// 
			this.copyButton.ImageIndex = 2;
			this.copyButton.ToolTipText = "Copy to clipboard";
			// 
			// pasteButton
			// 
			this.pasteButton.ImageIndex = 3;
			this.pasteButton.ToolTipText = "Paste from clipboard";
			// 
			// toolBarButton9
			// 
			this.toolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// histogramButton
			// 
			this.histogramButton.ImageIndex = 4;
			this.histogramButton.ToolTipText = "Show histogram";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// aboutButton
			// 
			this.aboutButton.ImageIndex = 5;
			this.aboutButton.ToolTipText = "About";
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageToolBar
			// 
			this.imageToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.imageToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							this.cloneButton,
																							this.toolBarButton1,
																							this.cropButton,
																							this.toolBarButton2,
																							this.zoomInButton,
																							this.zoomOutButton,
																							this.toolBarButton3,
																							this.fitToScreenButton,
																							this.toolBarButton5,
																							this.resizeButton,
																							this.rotateButton,
																							this.toolBarButton7,
																							this.levelsButton,
																							this.grayscaleButton,
																							this.thresholdButton,
																							this.toolBarButton6,
																							this.morphologyButton,
																							this.convolutionButton,
																							this.toolBarButton8,
																							this.saturationButton,
																							this.fourierButton});
			this.imageToolBar.Divider = false;
			this.imageToolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.imageToolBar.DropDownArrows = true;
			this.imageToolBar.ImageList = this.imageList2;
			this.imageToolBar.Location = new System.Drawing.Point(144, 312);
			this.imageToolBar.Name = "imageToolBar";
			this.imageToolBar.ShowToolTips = true;
			this.imageToolBar.Size = new System.Drawing.Size(472, 23);
			this.imageToolBar.TabIndex = 3;
			this.imageToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.imageToolBar_ButtonClick);
			// 
			// cloneButton
			// 
			this.cloneButton.ImageIndex = 0;
			this.cloneButton.ToolTipText = "Clone the image";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// cropButton
			// 
			this.cropButton.ImageIndex = 1;
			this.cropButton.ToolTipText = "Crop image";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// zoomInButton
			// 
			this.zoomInButton.ImageIndex = 2;
			this.zoomInButton.ToolTipText = "Zoom In";
			// 
			// zoomOutButton
			// 
			this.zoomOutButton.ImageIndex = 3;
			this.zoomOutButton.ToolTipText = "Zoom out";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.ImageIndex = 4;
			this.toolBarButton3.ToolTipText = "Original size";
			// 
			// fitToScreenButton
			// 
			this.fitToScreenButton.ImageIndex = 5;
			this.fitToScreenButton.ToolTipText = "Fit to window size";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// resizeButton
			// 
			this.resizeButton.ImageIndex = 11;
			this.resizeButton.ToolTipText = "Resize the image";
			// 
			// rotateButton
			// 
			this.rotateButton.ImageIndex = 12;
			this.rotateButton.ToolTipText = "Rotate the image";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// levelsButton
			// 
			this.levelsButton.ImageIndex = 6;
			this.levelsButton.ToolTipText = "Levels correction";
			// 
			// grayscaleButton
			// 
			this.grayscaleButton.ImageIndex = 7;
			this.grayscaleButton.ToolTipText = "Grayscale";
			// 
			// thresholdButton
			// 
			this.thresholdButton.ImageIndex = 8;
			this.thresholdButton.ToolTipText = "Threshold";
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// morphologyButton
			// 
			this.morphologyButton.ImageIndex = 9;
			this.morphologyButton.ToolTipText = "Custom morphology operator";
			// 
			// convolutionButton
			// 
			this.convolutionButton.ImageIndex = 10;
			this.convolutionButton.ToolTipText = "Custom convolution operator";
			// 
			// toolBarButton8
			// 
			this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// saturationButton
			// 
			this.saturationButton.ImageIndex = 13;
			this.saturationButton.ToolTipText = "Saturation (HSL)";
			// 
			// fourierButton
			// 
			this.fourierButton.ImageIndex = 14;
			this.fourierButton.ToolTipText = "Fourier Transformation";
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ofd
			// 
			this.ofd.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
				"es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
				"p)|*.bmp|GIF files (*.gif)|*.gif";
			this.ofd.Title = "Open image";
			// 
			// sfd
			// 
			this.sfd.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
			this.sfd.Title = "Save image";
			// 
			// printDocument
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(598, 15);
			this.printPreviewDialog.MaximumSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.Opacity = 1;
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			// 
			// statisticsViewItem
			// 
			this.statisticsViewItem.Index = 4;
			this.statisticsViewItem.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.statisticsViewItem.Text = "&Statistics";
			this.statisticsViewItem.Click += new System.EventHandler(this.statisticsViewItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 533);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.statusBar});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Image Processing Lab";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizePanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.colorPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hslPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
			this.panel1.ResumeLayout(false);
			this.dockManager.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
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
			unnamedNumber++;

			ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			// set events
			SetupDocumentEvents(imgDoc);

			return true;
		}

		// Create new document for ComplexImage
		public bool NewDocument(ComplexImage image)
		{
			unnamedNumber++;

			FourierDoc imgDoc = new FourierDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
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
		private void OpenFile()
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				ImageDoc imgDoc = null;
				
				try
				{
					// create image document
					imgDoc = new ImageDoc(ofd.FileName, (IDocumentsHost) this);
					imgDoc.Text = Path.GetFileName(ofd.FileName);

				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (imgDoc != null)
				{
					imgDoc.Show(dockManager);
					imgDoc.Focus();

					// set events
					SetupDocumentEvents(imgDoc);
				}
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

			if (doc != null)
			{
				// set initial file name
				if ((doc is ImageDoc) && (((ImageDoc) doc).FileName != null))
				{
					sfd.FileName = Path.GetFileName(((ImageDoc) doc).FileName);
				}
				else
				{
					sfd.FileName = doc.Text + ".jpg";
				}

				sfd.FilterIndex = 0;

				// show dialog
				if (sfd.ShowDialog(this) == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Jpeg;

					// resolve file format
					switch (Path.GetExtension(sfd.FileName).ToLower())
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						default:
							MessageBox.Show(this, "Unsupported image format was specified", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
					}

					// save the image
					try
					{
						if (doc is ImageDoc)
						{
							((ImageDoc) doc).Image.Save(sfd.FileName, format);
						}
						if (doc is FourierDoc)
						{
							((FourierDoc) doc).Image.Save(sfd.FileName, format);
						}
					}
					catch (Exception)
					{
						MessageBox.Show(this, "Failed writing image file", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		// On "File->Save" - save the file
		private void saveFileItem_Click(object sender, System.EventArgs e)
		{
			SaveFile();
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

				imgDoc.Text = "Image " + unnamedNumber.ToString();
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
