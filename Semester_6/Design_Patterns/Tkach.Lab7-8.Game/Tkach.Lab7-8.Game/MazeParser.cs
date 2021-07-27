using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tkach.Lab7_8.Game
{
    class MazeParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y]; 
                for (int x = 0; x < cols; x++)
                {
                    char sym = line[x];
                    if(sym == '|' || sym == '-' || sym == '+')
                    {
                        sym = '█';
                    }
                    grid[y, x] = sym.ToString();
                }
            }

            return grid;
        }
    }
}
