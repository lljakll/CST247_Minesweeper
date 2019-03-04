using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models.Game
{
    /// <summary>
    /// Cell Class
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     Cell class that handles the Cells
    /// 
    /// Authors:    Jay Wilson
    ///             Chase Hausman
    ///             Jacki Adair
    ///             Nathan Ford
    ///             Richard Boyd
    ///             
    /// Date:       02/21/19
    /// Version:    1.0.0
    /// </remarks>
    public class Cell
    {
        /** Cell model class **/

        private int id;
        private int x;
        private int y;
        private int liveNeighbors;
        private Boolean visited;
        private Boolean bomb;
        


        public Cell()
        {
            id = -1;
            x = -1;
            y = -1;
            liveNeighbors = 0;
            visited = false;
            bomb = false;
        }

        public Cell(int x, int y)
        {
            id = -1;
            this.x = x;
            this.y = y;
            liveNeighbors = 0;
            visited = false;
            bomb = false;
        }

        public int Id { get => id; set => id = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int LiveNeighbors { get => liveNeighbors; set => liveNeighbors = value; }
        public bool Visited { get => visited; set => visited = value; }
        public bool Bomb { get => bomb; set => bomb = value; }
    }
}