using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public partial class Grid
    {
        private int[,] _grid; 
        public Grid(int width, int height)
        {
            _grid = new int[width, height];
        }

        public int[,] Current
        {
            get {  return _grid.Copy(); }
        }
    }
}
