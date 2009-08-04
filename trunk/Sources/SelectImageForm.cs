// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IPLab
{
	/// <summary>
	/// Summary description for SelectImageForm.
	/// </summary>
	public class SelectImageForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListView imagesList;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label descriptionLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// Description property
		public string Description
		{
			set { descriptionLabel.Text = value; }
		}
		// ImageNames property
		public ArrayList ImageNames
		{
			set
			{
				imagesList.Items.Clear();

				if (value != null)
				{
					foreach (String name in value)
					{
						imagesList.Items.Add(name);
					}
				}

				okButton.Enabled = false;
			}
		}
		// SelectedItem property
		public int SelectedItem
		{
			get
			{
				return (imagesList.SelectedIndices.Count == 0) ? -1 : imagesList.SelectedIndices[0];
			}
		}


		// Constructor
		public SelectImageForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.imagesList = new System.Windows.Forms.ListView();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.descriptionLabel});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(294, 60);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Location = new System.Drawing.Point(0, 60);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(294, 1);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// imagesList
			// 
			this.imagesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1});
			this.imagesList.FullRowSelect = true;
			this.imagesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.imagesList.Location = new System.Drawing.Point(10, 70);
			this.imagesList.MultiSelect = false;
			this.imagesList.Name = "imagesList";
			this.imagesList.Size = new System.Drawing.Size(274, 235);
			this.imagesList.TabIndex = 2;
			this.imagesList.View = System.Windows.Forms.View.Details;
			this.imagesList.DoubleClick += new System.EventHandler(this.imagesList_DoubleClick);
			this.imagesList.SelectedIndexChanged += new System.EventHandler(this.imagesList_SelectedIndexChanged);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Enabled = false;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okButton.Location = new System.Drawing.Point(65, 320);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 3;
			this.okButton.Text = "Ok";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(155, 320);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Images";
			this.columnHeader1.Width = 230;
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.Location = new System.Drawing.Point(10, 10);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(274, 40);
			this.descriptionLabel.TabIndex = 0;
			// 
			// SelectImageForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(294, 353);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.imagesList,
																		  this.pictureBox1,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectImageForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Image";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		// Selection changed in list view
		private void imagesList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			okButton.Enabled = (imagesList.SelectedIndices.Count != 0);
		}

		// Double click in list view
		private void imagesList_DoubleClick(object sender, System.EventArgs e)
		{
			if (imagesList.SelectedIndices.Count != 0)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
