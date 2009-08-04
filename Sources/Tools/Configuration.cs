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
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Application configuration
    /// </summary>
    public class Configuration
    {
        public Point mainWindowLocation = new Point( 100, 50 );
        public Size mainWindowSize = new Size( 800, 600 );

        public bool histogramVisible = false;
        public bool statisticsVisible = false;

        public bool openInNewDoc = false;
        public bool rememberOnChange = false;

        // Constructor
        public Configuration( )
        {
        }

        // Save configureation to file
        public void Save( string fileName )
        {
            // open file
            FileStream fs = new FileStream( fileName, FileMode.Create );
            // create XML writer
            XmlTextWriter xmlOut = new XmlTextWriter( fs, Encoding.Unicode );

            // use indenting for readability
            xmlOut.Formatting = Formatting.Indented;

            // start document
            xmlOut.WriteStartDocument( );
            xmlOut.WriteComment( "IPLab configuration file" );

            // main node
            xmlOut.WriteStartElement( "IPLab" );

            // position node
            xmlOut.WriteStartElement( "Position" );
            xmlOut.WriteAttributeString( "x", mainWindowLocation.X.ToString( ) );
            xmlOut.WriteAttributeString( "y", mainWindowLocation.Y.ToString( ) );
            xmlOut.WriteAttributeString( "width", mainWindowSize.Width.ToString( ) );
            xmlOut.WriteAttributeString( "height", mainWindowSize.Height.ToString( ) );
            xmlOut.WriteEndElement( );

            // settings node
            xmlOut.WriteStartElement( "Settings" );
            xmlOut.WriteAttributeString( "histogram", histogramVisible.ToString( ) );
            xmlOut.WriteAttributeString( "statistics", statisticsVisible.ToString( ) );
            xmlOut.WriteAttributeString( "newOnChange", openInNewDoc.ToString( ) );
            xmlOut.WriteAttributeString( "rememberOnChange", rememberOnChange.ToString( ) );
            xmlOut.WriteEndElement( );

            xmlOut.WriteEndElement( );

            // close file
            xmlOut.Close( );
        }

        // Load configureation from file
        public bool Load( string fileName )
        {
            bool ret = false;

            // check file existance
            if ( File.Exists( fileName ) )
            {
                FileStream fs = null;
                XmlTextReader xmlIn = null;

                try
                {
                    // open file
                    fs = new FileStream( fileName, FileMode.Open );
                    // create XML reader
                    xmlIn = new XmlTextReader( fs );

                    xmlIn.WhitespaceHandling = WhitespaceHandling.None;
                    xmlIn.MoveToContent( );

                    // check for main node
                    if ( xmlIn.Name != "IPLab" )
                        throw new ApplicationException( "" );

                    // move to next node
                    xmlIn.Read( );
                    if ( xmlIn.NodeType == XmlNodeType.EndElement )
                        xmlIn.Read( );

                    // check for position node
                    if ( xmlIn.Name != "Position" )
                        throw new ApplicationException( "" );

                    // read main window position
                    int x = Convert.ToInt32( xmlIn.GetAttribute( "x" ) );
                    int y = Convert.ToInt32( xmlIn.GetAttribute( "y" ) );
                    int width = Convert.ToInt32( xmlIn.GetAttribute( "width" ) );
                    int height = Convert.ToInt32( xmlIn.GetAttribute( "height" ) );

                    mainWindowLocation = new Point( x, y );
                    mainWindowSize = new Size( width, height );

                    // move to next node
                    xmlIn.Read( );
                    if ( xmlIn.NodeType == XmlNodeType.EndElement )
                        xmlIn.Read( );

                    // check for position node
                    if ( xmlIn.Name != "Settings" )
                        throw new ApplicationException( "" );

                    histogramVisible = Convert.ToBoolean( xmlIn.GetAttribute( "histogram" ) );
                    statisticsVisible = Convert.ToBoolean( xmlIn.GetAttribute( "statistics" ) );
                    openInNewDoc = Convert.ToBoolean( xmlIn.GetAttribute( "newOnChange" ) );
                    rememberOnChange = Convert.ToBoolean( xmlIn.GetAttribute( "rememberOnChange" ) );

                    ret = true;
                }
                catch
                {
                }
                finally
                {
                    if ( xmlIn != null )
                        xmlIn.Close( );
                }
            }
            return ret;
        }
    }
}
