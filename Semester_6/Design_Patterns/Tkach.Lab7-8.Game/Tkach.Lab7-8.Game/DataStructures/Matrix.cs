namespace Tkach.Lab7_8.Game.DataStructures
{
    class Matrix <T>
    {
        public T[,] matrix;
        public Point dimentions;

        public Matrix(T[,] matrix, Point dimentions)
        {
            this.dimentions = dimentions;
            this.matrix = matrix;
        }

        public Matrix()
        {

        }
    }
}
