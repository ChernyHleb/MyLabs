using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;

namespace Tkach.Lab7_8.Game
{
    class Maze : IDrawable
    {
        public bool isActive;
        public Matrix<char> matrix;

        public Maze()
        {
            isActive = true;
            matrix = MazeParser.ParseFileToArray("map easy lvl.txt");
        }

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            // use deep copy!

            return matrix.DeepCopy();
        }

        public bool IsActive()
        {
            return isActive;
        }
    }
}
