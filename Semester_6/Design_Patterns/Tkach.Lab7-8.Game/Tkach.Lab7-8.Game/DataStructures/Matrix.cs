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

        public Matrix<T> DeepCopy()
        {
            Matrix<T> newmatrix = new Matrix<T>();
            newmatrix.dimentions = new Point(dimentions.X, dimentions.Y);
            newmatrix.matrix = new T[dimentions.Y, dimentions.X];

            for (int y = 0; y < newmatrix.dimentions.Y; y++)
            {
                for (int x = 0; x < newmatrix.dimentions.X; x++)
                {
                    newmatrix.matrix[y, x] = matrix[y, x];
                }
            }

            return newmatrix;
        }
    }
}
