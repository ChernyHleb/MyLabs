using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;

namespace Tkach.Lab7_8.Game
{
    class Player : Item, IDrawable
    {
        public Player(int initialX, int initialY) : base(initialX, initialY)
        {
            symbol = 'P';
            isActive = true;
        }
        public Matrix<char> Draw(Matrix<char> canvas)
        {
            canvas.matrix[position.Y, position.X] = symbol;
            return canvas;
        }

        bool IDrawable.IsActive()
        {
            return isActive;
        }
    }
}
