using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.GameWorldItems
{
    class Maze : IDrawable
    {
        public bool isActive;
        public Matrix<char> matrix;

        public Maze(Matrix<char> matrix)
        {
            isActive = true;
            this.matrix = matrix.DeepCopy();
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
