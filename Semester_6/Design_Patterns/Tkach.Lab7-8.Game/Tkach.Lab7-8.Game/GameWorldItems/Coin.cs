using System.Collections.Generic;
using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;

namespace Tkach.Lab7_8.Game
{
    class Coin : Item, IDrawable, IObservable
    {
        private List<IObserver> observers;

        public Coin(int initialX, int initialY) : base(initialX, initialY)
        {
            symbol = 'o';
            isActive = true;
            observers = new List<IObserver>();
        }
        public Matrix<char> Draw(Matrix<char> canvas)
        {
            canvas.matrix[position.Y, position.X] = symbol;
            return canvas;
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

        bool IDrawable.IsActive()
        {
            return isActive;
        }
    }
}
