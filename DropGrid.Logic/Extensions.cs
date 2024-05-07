using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public static class Extensions
    {
        public static int[,] Copy(this int[,] source)
        {
            if (source != null)
            {
                return (int[,])source.Clone();
            }

            throw new Exception("attempted to Clone() int[,] source but source was null!");
        }

        public static bool Same(this int[,] source, int[,] target)
        {
            if (source != null && target != null // only check if they are present and the same dimensions
                && source.GetLength(0) == target.GetLength(0)
                && source.GetLength(1) == target.GetLength(1))
            {
                for(int x = 0; x < source.GetLength(0); x++)
                {
                    for(int y = 0; y < source.GetLength(1); y++)
                    {
                        if (source[x,y] != target[x, y])
                        {
                            return false; // as soon as you find a non-match, return false
                        }
                    }
                }
            }

            return true; // exact match
        }

        public static bool Has(this int[,] source, Vector2 at)
        {
            return at.X >= 0 && at.X < source.GetLength(0) 
                && at.Y >= 0 && at.Y < source.GetLength(1);
        }
    }
}
