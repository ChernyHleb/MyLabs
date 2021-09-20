using System.Collections.Generic;
using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;

namespace Tkach.Lab7_8.Game.GameWorldItems
{
    class Door : IDrawable
    {
        public bool isActive;
        public Point position;
        public char symbol;
        private List<IObserver> observers;

        public Door(int x, int y)
        {
            position = new Point(x, y);
            isActive = true;
            symbol = 'D';
            observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            canvas.matrix[position.Y, position.X] = symbol;
            return canvas;
        }

        public string Draw()
        {
            return "D";
        }

        public bool IsActive()
        {
            return isActive;
        }
    }
}
