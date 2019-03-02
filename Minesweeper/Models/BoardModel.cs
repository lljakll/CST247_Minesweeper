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
    }
}