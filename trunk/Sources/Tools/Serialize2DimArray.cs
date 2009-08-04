// Image Processing Lab
// http://www.aforgenet.com/projects/iplab/
//
// Copyright © Andrew Kirillov, 2005-2009
// andrew.kirillov@aforgenet.com
//

namespace IPLab
{
    using System;
    using System.IO;

    /// <summary>
    /// Serialize2DimArray class - 2 dimensional arrays serialization
    /// </summary>
    internal class Serialize2DimArray
    {
        // Save array to file
        public static void Save( string file, Array array )
        {
            StreamWriter writer = null;

            try
            {
                int height = array.GetLength( 0 );
                int width = array.GetLength( 1 );

                // create file
                writer = File.CreateText( file );

                // write array dimensions
                writer.WriteLine( "{0} {1}", height, width );

                for ( int i = 0; i < height; i++ )
                {
                    string[] strs = new string[width];

                    for ( int j = 0; j < width; j++ )
                    {
                        strs[j] = array.GetValue( i, j ).ToString( );
                    }

                    writer.WriteLine( string.Join( " ", strs ) );
                }
            }
            catch ( Exception )
            {
                throw new ApplicationException( );
            }
            finally
            {
                // close file
                if ( writer != null )
                    writer.Close( );
            }
        }

        // Load array from file
        public static Array Load( string file, Type type )
        {
            StreamReader reader = null;
            Array array;

            try
            {
                string[] strs;
                int height;
                int width;

                // open file
                reader = File.OpenText( file );

                // read dimensions
                strs = reader.ReadLine( ).Split( ' ' );
                height = int.Parse( strs[0] );
                width = int.Parse( strs[1] );

                // create array of specified type
                array = Array.CreateInstance( type, height, width );

                for ( int i = 0; i < height; i++ )
                {
                    // read next line
                    strs = reader.ReadLine( ).Split( ' ' );
                    for ( int j = 0; j < width; j++ )
                    {
                        array.SetValue( Convert.ChangeType( strs[j], type ), i, j );
                    }
                }
            }
            catch ( Exception )
            {
                throw new ApplicationException( );
            }
            finally
            {
                // close file
                if ( reader != null )
                    reader.Close( );
            }
            return array;
        }
    }
}
