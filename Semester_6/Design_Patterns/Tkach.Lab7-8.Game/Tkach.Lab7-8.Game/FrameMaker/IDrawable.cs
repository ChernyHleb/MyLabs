using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.FrameMaker
{
    interface IDrawable
    {
        Matrix<char> Draw(Matrix<char> canvas);
        bool isActive();
    }
}
