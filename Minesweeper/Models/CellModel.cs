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
            SetIsLive();
        }

        private void SetIsLive()
        {
            Random rand = new Random();
            double chance = rand.NextDouble();
            if (chance < .2)
                IsLive = true;
            else
                IsLive = false;
        }
    }
}