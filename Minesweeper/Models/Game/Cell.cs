using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models.Game
{
    public class Cell
    {
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }

        public Cell(int x = -1, int y = -1)
        {
            Reset(x, y);
        }

        public Cell(string id, int x, int y, int liveNeighbors, bool visited, bool live)
        {
            Id = id;
            X = x;
            Y = y;
            LiveNeighbors = liveNeighbors;
            Visited = visited;
            Live = live;
        }

        public void Reset(int x, int y)
        {
            X = x;
            Y = y;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }
    }
}