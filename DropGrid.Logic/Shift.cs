namespace DropGrid.Logic
{
    public partial class Grid
    {
        public Grid Fall()
        {
            var width  = _grid.GetLength(0);
            var height = _grid.GetLength(1);

            bool changed = false;

            var stacks = new List<List<int>>();

            for(var x = 0; x < width; x++)
            {
                stacks.Add(new List<int>());

                bool dropFound = false;

                for (var y = 0; y < height; y++)
                {
                    bool drop = false; // used to ensure we only change the grid after Save()

                    if (_grid[x, y] > 0) // if it's a non-zero
                    {
                        drop = dropFound = true; // mark a drop this iteration and a drop this column

                        stacks[x].Add(_grid[x, y]); // add it to the stack
                    }

                    if (!changed && dropFound && _grid[x, y] == 0)
                    {   // if we haven't detected a change and a zero is found after a drop
                        changed = true;
                        Save();
                    }

                    if (drop)
                    {
                        _grid[x, y] = 0; // clear the position
                    }
                }
            }

            for (var s = 0; s < stacks.Count; s++)
            {
                var stack = stacks[s];
                var topPosition = height - stack.Count;

                for(var d = 0; d < stack.Count; d++)
                {
                    _grid[s, topPosition + d] = stack[d];
                }
            }

            return this;
        }
    }
}