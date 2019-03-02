using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class CellModel
    {
        public int LiveNeighbors { get; set; }
        public bool IsLive { get; set; }
        public bool Visited { get; set; }

        public CellModel()
        {
            LiveNeighbors = 0;
            Visited = false;

        }
    }
}