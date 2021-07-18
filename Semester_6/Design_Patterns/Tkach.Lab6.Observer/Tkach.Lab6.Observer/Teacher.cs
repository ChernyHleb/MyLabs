using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab6.Observer
{
    class Teacher : IObservable
    {
        public string id;
        private List<IObserver> observers;
        private Report CurrentReport;

        public Teacher(string name)
        {
            observers = new List<IObserver>();
            this.id = name;
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(CurrentReport);
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

        public void CreateReport()
        {
            CurrentReport = new Report("some report", this);
            NotifyObservers();
        }
    }
}
