using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public partial class Grid
    {
        public Grid Remove(params Vector2[] at)
        {
            if (at == null) return this; // no change

            bool changed = false;

            foreach(var pos in at)
            {
                if(_grid.Has(pos) && _grid[(int)pos.X, (int)pos.Y] != 0) // index is valid and a non-zero tile is at the position
                {
                    if (!changed) // no change has yet occurred but one is about to occur
                    {
                        changed = true; // flag so we only save history once
                        Save();         // save _grid to history prior to any change
                    }

                    _grid[(int)pos.X, (int)pos.Y] = 0;
                } 
                else
                {
                    Console.WriteLine($"Can't remove from position ({pos.X},{pos.Y}) because it falls outside of the grid.");
                }
            }

            if(!changed)
            {
                Console.WriteLine($"No change occurred during call to Remove(at)...");
            }

            return this;
        }
    }
}
