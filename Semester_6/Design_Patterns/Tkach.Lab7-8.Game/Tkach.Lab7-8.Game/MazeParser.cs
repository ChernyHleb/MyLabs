using System.IO;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game
{
    class MazeParser
    {
        public static Matrix<char> ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            char[,] grid = new char[rows, cols];

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
                    grid[y, x] = sym;
                }
            }

            Matrix<char> matrix = new Matrix<char>(grid, new Point(cols, rows));

            return matrix;
        }
    }
}
