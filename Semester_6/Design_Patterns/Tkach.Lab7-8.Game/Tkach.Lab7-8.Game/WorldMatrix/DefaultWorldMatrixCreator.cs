using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.WorldMatrix
{
    class DefaultWorldMatrixCreator : IWorldMatrixCreator
    {
        char[,] worldMatrix = {
            { '█', '█', '█', '█', '█', '█', '█', '█', '█', '█'},
            { '█', 'P', ' ', '█', ' ', ' ', ' ', ' ', ' ', '█'},
            { '█', ' ', ' ', '█', ' ', ' ', '█', ' ', ' ', '█'},
            { '█', ' ', ' ', '█', ' ', '█', '█', 'o', ' ', '█'},
            { '█', ' ', ' ', '█', ' ', ' ', '█', ' ', ' ', '█'},
            { '█', ' ', 'o', '█', ' ', ' ', '█', '█', '█', '█'},
            { '█', ' ', ' ', '█', '█', 'o', '█', ' ', ' ', '█'},
            { '█', ' ', ' ', ' ', ' ', ' ', ' ', 'o', ' ', 'D'},
            { '█', ' ', ' ', '█', ' ', ' ', '█', ' ', ' ', '█'},
            { '█', '█', '█', '█', '█', '█', '█', '█', '█', '█'}
        };

        Matrix<char> IWorldMatrixCreator.CreateWorldMatrix()
        {
            Point dimentions = new Point(10, 10);
            return new Matrix<char>(worldMatrix, dimentions);
        }
    }
}
