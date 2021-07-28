using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;
using System;

namespace Tkach.Lab7_8.Game
{
    class Player : Item, IDrawable, IObserver
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

        public void Update(object obj)
        {
            ConsoleKey key = (ConsoleKey)obj;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (Game.IsPositionWalkable(
                        position.X,
                        position.Y - 1)
                    )
                        position.Y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (Game.IsPositionWalkable(
                        position.X,
                        position.Y + 1)
                    )
                        position.Y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (Game.IsPositionWalkable(
                         position.X - 1,
                         position.Y)
                     )
                        position.X -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    if (Game.IsPositionWalkable(
                        position.X + 1,
                        position.Y)
                    )
                        position.X += 1;
                    break;
                default:
                    break;
            }
        }

        bool IDrawable.IsActive()
        {
            return isActive;
        }
    }
}
