using DropGrid.Logic;
using DropGrid.Models;

namespace DropGrid.Extensions
{
    public static class GridExtensions
    {
        public static GridModel ToGridModel(this Grid grid, Guid? uuid = null)
        {
            return new GridModel(grid.Current, uuid == null ? null : uuid.ToString());
        }
    }
}
