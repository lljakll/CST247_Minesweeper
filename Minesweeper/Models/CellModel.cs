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

            // 20% chance for each cell to be live not 20% of cells live
            // i ran into the issue where no cells were live due to this.
            // corrected in the BoardModel Class Activate() method.
            // SetIsLive();
            
        }

        private void SetIsLive()
        {
            Random rand = new Random();
            double chance = rand.NextDouble();
            if (chance < .5)
                IsLive = true;
            else
                IsLive = false;
        }
    }
}