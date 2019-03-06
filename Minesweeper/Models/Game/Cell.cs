using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models.Game
{
    public class Cell
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }

        // Handle ID?

        public Cell(int x = -1, int y = -1)
        {
            Reset(x, y);
        }

        public void Reset(int x, int y)
        {
            X = x;
            Y = y;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }


        // May not need this
        public void Reveal()
        {
            if (LiveNeighbors == 0)
            {

            }
        }
    }
}