using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public partial class Grid
    {
        private int[,] _match; // this represents a mask of the _grid for highlighting matches

        public Grid Match()
        {
            if(_match == null) _match = new int[_grid.GetLength(0), _grid.GetLength(1)];

            // TODO: add match check code

            return this;
        }
    }
}
