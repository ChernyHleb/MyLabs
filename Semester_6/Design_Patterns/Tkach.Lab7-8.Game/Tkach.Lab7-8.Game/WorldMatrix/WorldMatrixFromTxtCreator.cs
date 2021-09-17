using System;
using System.IO;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.WorldMatrix
{
    class WorldMatrixFromTxtCreator : IWorldMatrixCreator
    {
        string filePath = "map easy lvl.txt";

        public WorldMatrixFromTxtCreator() { }
        public Matrix<char> CreateWorldMatrix()
        {
            if (filePath == null) throw new Exception("party!");
            return ParseTxtFileToMatrix(filePath);
        }

        private Matrix<char> ParseTxtFileToMatrix(string filePath)
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
                    if (sym == '|' || sym == '-' || sym == '+')
                    {
                        sym = '█';
                    }
                    grid[y, x] = sym;
                }
            }

            Matrix<char> matrix = new Matrix<char>(grid, new Point(cols, rows));

            return matrix;
        }

        public void setFilePath(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
