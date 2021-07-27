using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Tkach.Lab7_8.Game
{
    class World
    {
        private string[,] grid;
        private int rows;
        private int cols;

        public World(string[,] grid)
        {
            this.grid = grid;
            rows = grid.GetLength(0);
            cols = grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    string element = grid[y, x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return grid[y, x];
        }

        public bool IsPositionWalkable(int x, int y)
        {
            //check world bounds
            if(x < 0 || y < 0 || x >= cols || y >= rows)
            {
                return false;
            }

            //ceck if the tile is walkable
            return grid[y, x] == " " || grid[y, x] == "X";
        }
    }
}
