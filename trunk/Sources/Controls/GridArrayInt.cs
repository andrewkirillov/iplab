namespace IPLab
{
    using System;
    using System.Drawing;

    using SourceGrid2;
    using SourceGrid2.Cells.Real;

    // Events arguments
    public class GridEventArgs : EventArgs
    {
        private int col, row;

        // Constructor
        public GridEventArgs( int col, int row )
        {
            this.col = col;
            this.row = row;
        }

        // Col property
        public int Col
        {
            get { return col; }
        }
        // Row property
        public int Row
        {
            get { return row; }
        }
    }


    /// <summary>
    /// GridArrayInt
    /// </summary>
    public class GridArrayInt : SourceGrid2.Grid
    {
        private Array array;
        private CellBehavior behavior;

        // events
        public delegate void GridEventHandler( object sender, GridEventArgs e );
        public event GridEventHandler CellClicked;
        public event GridEventHandler ValueChanged;

        // Constructor
        public GridArrayInt( )
        {
        }

        // Load data
        public void LoadData( Array array )
        {
            //
            this.array = array;

            behavior = new CellBehavior( array );


            // set column and row headers
            FixedRows = 1;
            FixedColumns = 1;

            // Redim the grid
            Redim( array.GetLength( 0 ) + FixedRows, array.GetLength( 1 ) + FixedColumns );

            // Header
            this[0, 0] = new Header( );

            // Column headers
            for ( int i = 1; i < this.ColumnsCount; i++ )
            {
                ColumnHeader header = new ColumnHeader( i.ToString( ) );
                header.EnableSort = false;
                this[0, i] = header;
            }
            // Row headers
            for ( int i = 1; i < this.RowsCount; i++ )
            {
                this[i, 0] = new RowHeader( i.ToString( ) );
            }

            // Data cells
            Type type = array.GetValue( 0, 0 ).GetType( );
            for ( int i = 1, ia = 0; i < this.RowsCount; i++, ia++ )
            {
                for ( int j = 1, ja = 0; j < this.ColumnsCount; j++, ja++ )
                {
                    Cell cell = new Cell( array.GetValue( ia, ja ), type );
                    cell.Behaviors.Add( behavior );
                    this[i, j] = cell;
                }
            }

            Colorize( );
        }

        // Colorize cells
        public void Colorize( )
        {
            int n = array.GetLength( 0 );
            int k = array.GetLength( 1 );
            int min = int.MaxValue;
            int max = int.MinValue;
            int v = 0;

            // find min and max values
            for ( int i = 0; i < n; i++ )
            {
                for ( int j = 0; j < k; j++ )
                {
                    v = (int) Convert.ChangeType( array.GetValue( i, j ), typeof( int ) );

                    if ( v > max )
                        max = v;
                    if ( v < min )
                        min = v;
                }
            }

            // Update cells color
            for ( int i = 1, ia = 0; i < this.RowsCount; i++, ia++ )
            {
                for ( int j = 1, ja = 0; j < this.ColumnsCount; j++, ja++ )
                {
                    Cell cell = (Cell) this[i, j];
                    v = (int) Convert.ChangeType( cell.Value, typeof( int ) );

                    if ( v > 0 )
                    {
                        int c = 63 + 192 * ( max - v ) / max;

                        cell.BackColor = Color.FromArgb( 255, c, c );
                    }
                    else if ( v < 0 )
                    {
                        int c = 63 + 192 * ( min - v ) / min;

                        cell.BackColor = Color.FromArgb( 255, 255, c );
                    }
                    else
                        cell.BackColor = Color.White;
                }
            }
        }

        // On cell clicked
        protected virtual void OnCellClicked( int col, int row )
        {
            if ( CellClicked != null )
                CellClicked( this, new GridEventArgs( col, row ) );
        }

        // On value changed
        protected virtual void OnValueChanged( int col, int row )
        {
            if ( ValueChanged != null )
                ValueChanged( this, new GridEventArgs( col, row ) );
        }

        // Cell behavior
        private class CellBehavior : SourceGrid2.BehaviorModels.Common
        {
            private Array array;

            // Constructor
            public CellBehavior( Array array )
            {
                this.array = array;
            }

            // On mouse click
            public override void OnClick( PositionEventArgs e )
            {
                ( (GridArrayInt) e.Grid ).OnCellClicked( e.Position.Column - 1, e.Position.Row - 1 );
            }
            // On value changed
            public override void OnValueChanged( PositionEventArgs e )
            {
                array.SetValue( e.Cell.GetValue( e.Position ), e.Position.Row - 1, e.Position.Column - 1 );
                ( (GridArrayInt) e.Grid ).Colorize( );
                ( (GridArrayInt) e.Grid ).OnValueChanged( e.Position.Column - 1, e.Position.Row - 1 );
            }
        }
    }
}
