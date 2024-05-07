using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public partial class Grid
    {
        public Grid Drop(int value, int column = 0)
        {
            if(column >= 0 && column < _grid.GetLength(0)) // valid column
            {
                if (_grid[column, 0] != 0)
                {
                    throw new Exception($"No open spot for drop in column {column}!");
                }

                var landing = -1;

                for(var y = 0; y < _grid.GetLength(1); y++)
                {
                    if (_grid[column, y] == 0) // empty spot for incoming drop?
                    {
                        landing = y;
                    } 
                    else // non-empty spot
                    {
                        break;
                    }
                }

                _grid[column, landing] = value;
            }

            return this;
        }
    }
}
