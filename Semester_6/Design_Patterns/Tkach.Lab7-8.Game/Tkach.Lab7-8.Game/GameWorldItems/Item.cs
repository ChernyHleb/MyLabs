using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;

namespace Tkach.Lab7_8.Game
{
    abstract class Item : IDrawable
    {
        public bool isActive;
        public Point position;
        public char symbol;

        public Item(int x, int y)
        {
            position = new Point(x, y);
        }

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            throw new System.NotImplementedException();
        }

        public bool IsActive()
        {
            throw new System.NotImplementedException();
        }
    }
}
