using System.Collections.Generic;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.MissionManager
{
    class GatherItemsMission<T> : Mission, IObservable, IObserver, FrameMaker.IDrawable
    {
        private List<IObserver> observers;
        public List<T> items;

        public GatherItemsMission(string name)
        {
            this.name = name;
            this.currentScore = 0;
            observers = new List<IObserver>();
            items = new List<T>();
            isActive = true;
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in observers)
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

        public void Update(object obj)
        {
            items.Remove((T)obj);
            if (items.Count == 0)
                NotifyObservers();
        }

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            throw new System.Exception();
        }

        public string Draw()
        {
            return string.Format("{0}: {1}/{2}\n", name, currentScore, score);
        }

        public bool IsActive()
        {
            return isActive;
        }
    }
}
