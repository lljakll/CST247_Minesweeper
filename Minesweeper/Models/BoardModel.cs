using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public CellModel[,] GameBoard;

        public BoardModel(int size)
        {
            Size = size;
            SetUpBoard();
            ActivateLiveCells();
            SetLiveNeighbors();
        }

        private void SetUpBoard()
        {
            GameBoard = new CellModel[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    GameBoard[i, j] = new CellModel();
                }
            }
        }

        private void ActivateLiveCells()
        {
            Random rnd = new Random();

            for (int i = 0; i < .2 * GameBoard.Length; i++)
            {
                int rndRow = rnd.Next(0, GameBoard.GetLength(0));
                int rndCol = rnd.Next(0, GameBoard.GetLength(1));

                if (GameBoard[rndRow, rndCol].IsLive == false)
                    GameBoard[rndRow, rndCol].IsLive = true;
                else
                    i--;
            }
        }

        private void SetLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    int count = 0;

                    count += CheckNeighbor(i + 1, j + 1);
                    count += CheckNeighbor(i + 1, j);
                    count += CheckNeighbor(i + 1, j - 1);
                    count += CheckNeighbor(i, j + 1);
                    count += CheckNeighbor(i, j - 1);
                    count += CheckNeighbor(i - 1, j + 1);
                    count += CheckNeighbor(i - 1, j);
                    count += CheckNeighbor(i - 1, j - 1);

                    GameBoard[i, j].LiveNeighbors = count;
                }
            }
        }

        private int CheckNeighbor(int e, int d)
        {
            if (e == -1 || e == Size || d == -1 || d == Size)
                return 0;

            if (GameBoard[e, d].IsLive)
            {
                return 1;
            }
            return 0;
        }

        private int ChangeIcon()
        {
            int icon = 0;

            return icon;
        }

        public void Cascade(int row, int col)
        {
            GameBoard[row, col].Visited = true;

            if (GameBoard[row, col].LiveNeighbors == 0)
            {
                // iterate through each neighbor
                for (int i = -1; i < 2; i++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        // make sure to stay inbounds
                        if (row + i >= 0 && row + i < GameBoard.GetLength(0) && col + k >= 0 && col + k < GameBoard.GetLength(1))
                        {
                            // if a neighbor has not been visited
                            if (GameBoard[row + i, col + k].Visited == false)
                            {
                                // recursiely check that cell's neighbors...
                                Cascade(row + i, col + k);
                            }
                        }
                    }
                }
            }
            else
                // if the cell has neighbors, back out of the recursion iteration
                return;
        }
    }
}