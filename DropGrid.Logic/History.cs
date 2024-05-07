using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropGrid.Logic
{
    public partial class Grid
    {
        private List<int[,]> _history { get; set; }

        public Grid Save()
        {
            if (_grid == null) return this;

            if(_history == null) _history = new List<int[,]>();

            _history.Add(_grid.Copy());

            return this;
        }

        public List<int[,]> Last(int count = 0)
        {
            if (_history == null) throw new Exception("No history found.");

            if (count == 0 || count > _history.Count)
            {
                return _history.ToList();
            } 
            else
            {
                return _history.TakeLast(count).ToList();
            }
        }
    }
}
