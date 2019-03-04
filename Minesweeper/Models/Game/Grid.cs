using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models.Game
{
    /// <summary>
    /// Grid Class
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     Handles the Grid
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
    public class Grid
    {
        private int id;
        private int rows;
        private int cols;
        private int userid;
        private Boolean gameOver;
        private Cell[,] cells;

        /** Grid model class **/

        public Grid(int id, int rows, int cols, int userid, bool gameOver)
        {
            this.id = id;
            this.rows = rows;
            this.cols = cols;
            this.userid = userid;
            this.gameOver = gameOver;
        }

        public int Id { get => id; set => id = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }
        public int Userid { get => userid; set => userid = value; }
        public bool GameOver { get => gameOver; set => gameOver = value; }
        public Cell[,] Cells { get => cells; set => cells = value; }
    }
}