using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.GameWorldRepresentators
{
    interface IGameWorldRepresentator
    {
        // семейство алгоритмов, отвечающих за репрезентацию
        // матрицы игрового мира (лабиринт, игрок, предметы, тд)
        // на экране (например в ASCII формате или в виде тайлов)
        void Represent(Matrix<char> gameWorldCanvas);
    }
}
