// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

namespace IPLab
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	using AForge.Imaging;

	/// <summary>
	/// IDocumentsHost interface
	/// Provides connectione between documents and the main widnow
	/// </summary>
	public interface IDocumentsHost
	{
		bool CreateNewDocumentOnChange{get;}
		bool RememberOnChange{get;}

		bool NewDocument(Bitmap image);
		bool NewDocument(ComplexImage image);

		Bitmap GetImage(object sender, String text, Size size, PixelFormat format);
	}
}
