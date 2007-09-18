namespace IPLab
{
    using System;
    using System.ComponentModel;

    using SourceGrid2.Cells.Virtual;

    /// <summary>
    /// Summary description for GridIntArray.
    /// </summary>
    public class GridArray : SourceGrid2.GridVirtual
    {
        private CellVirtual columnHeader;
        private CellVirtual rowHeader;
        private CellVirtual cellHeader;
        private CellVirtual dataCell;
        private Array array;
        private bool readOnly = false;

        // Readonly property
        [DefaultValue( false )]
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                RefreshCellsStyle( );
            }
        }

        // Constructor
        public GridArray( )
        {
        }

        // Load data
        public void LoadData( Array array )
        {
            //
            this.array = array;

            // set column and row headers
            FixedRows = 1;
            FixedColumns = 1;

            // Redim the grid
            Redim( array.GetLength( 0 ) + FixedRows, array.GetLength( 1 ) + FixedColumns );

            // Col Header Cell Template
            columnHeader = new CellColumnHeaderTemplate( );
            columnHeader.BindToGrid( this );

            // Row Header Cell Template
            rowHeader = new CellRowHeaderTemplate( );
            rowHeader.BindToGrid( this );

            // Header Cell Template (0,0 cell)
            cellHeader = new CellHeaderTemplate( );
            cellHeader.BindToGrid( this );

            // Data Cell Template
            dataCell = new CellArrayTemplate( array ); ;
            dataCell.BindToGrid( this );

            RefreshCellsStyle( );
        }

        // Return the Cell at the specified Row and Col position
        public override SourceGrid2.Cells.ICellVirtual GetCell( int row, int col )
        {
            try
            {
                if ( array != null )
                {
                    if ( ( row < FixedRows ) && ( col < FixedColumns ) )
                        return cellHeader;
                    else if ( row < FixedRows )
                        return columnHeader;
                    else if ( col < FixedColumns )
                        return rowHeader;
                    else
                        return dataCell;
                }
                else
                    return null;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        // Set the specified cell int he specified position
        public override void SetCell( int row, int col, SourceGrid2.Cells.ICellVirtual cell )
        {
            throw new ApplicationException( "Cannot set cell for this kind of grid" );
        }

        // Refresh cells style
        private void RefreshCellsStyle( )
        {
            if ( dataCell != null )
            {
                dataCell.DataModel.EnableEdit = !readOnly;
            }
        }


        // Column header template
        private class CellColumnHeaderTemplate : SourceGrid2.Cells.Virtual.ColumnHeader
        {
            // Get the value of the cell at the specified position 
            public override object GetValue( SourceGrid2.Position position )
            {
                return position.Column - Grid.FixedColumns;
            }
            // Set the value of the cell at the specified position
            public override void SetValue( SourceGrid2.Position position, object val )
            {
                throw new ApplicationException( "Cannot change this kind of cell" );
            }
            // Get sort status
            public override SourceGrid2.SortStatus GetSortStatus( SourceGrid2.Position position )
            {
                return new SourceGrid2.SortStatus( SourceGrid2.GridSortMode.None, false );
            }
            // Set sort status
            public override void SetSortMode( SourceGrid2.Position position, SourceGrid2.GridSortMode mode )
            {
            }
        }

        // Row header template
        private class CellRowHeaderTemplate : SourceGrid2.Cells.Virtual.RowHeader
        {
            // Get the value of the cell at the specified position
            public override object GetValue( SourceGrid2.Position position )
            {
                return position.Row - Grid.FixedRows;
            }
            // Set the value of the cell at the specified position
            public override void SetValue( SourceGrid2.Position position, object val )
            {
                throw new ApplicationException( "Cannot change this kind of cell" );
            }
        }

        // Cell header template
        private class CellHeaderTemplate : SourceGrid2.Cells.Virtual.Header
        {
            // Get the value of the cell at the specified position
            public override object GetValue( SourceGrid2.Position position )
            {
                return null;
            }
            // Set the value of the cell at the specified position
            public override void SetValue( SourceGrid2.Position position, object val )
            {
                throw new ApplicationException( "Cannot change this kind of cell" );
            }
        }

        // Cell temlate
        public class CellArrayTemplate : SourceGrid2.Cells.Virtual.CellVirtual
        {
            private Array array;

            // Constructor
            public CellArrayTemplate( Array array )
            {
                this.array = array;
                DataModel = SourceGrid2.Utility.CreateDataModel( array.GetType( ).GetElementType( ) );
            }
            // Get the value of the cell at the specified position
            public override object GetValue( SourceGrid2.Position position )
            {
                return array.GetValue( position.Row - Grid.FixedRows, position.Column - Grid.FixedColumns );
            }
            // Set the value of the cell at the specified position
            public override void SetValue( SourceGrid2.Position position, object val )
            {
                array.SetValue( val, position.Row - Grid.FixedRows, position.Column - Grid.FixedColumns );
                OnValueChanged( new SourceGrid2.PositionEventArgs( position, this ) );
            }
        }
    }
}
