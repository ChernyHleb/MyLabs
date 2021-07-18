using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab6.Observer
{
    class Deanery : IObserver, IObservable
    {
        private List<Report> currentReports;
        private List<Teacher> currentBadTeachers;
        private List<Teacher> teachers;
        private List<IObserver> observers;

        public Deanery(List<Teacher> teachers)
        {
            currentReports = new List<Report>();
            currentBadTeachers = new List<Teacher>();
            this.teachers = teachers;
            observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(currentBadTeachers);
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
            currentReports.Add((Report)obj);
        }

        public void CheckTeachersReports()
        {
            foreach (Teacher teacher in teachers)
            {
                bool isBad = true;
                foreach (Report report in currentReports)
                {
                    if(report.author.id.Equals(teacher.id))
                    {
                        isBad = false;
                        break;
                    }
                }

                if (isBad)
                {
                    currentBadTeachers.Add(teacher);
                }   
            }

            NotifyObservers();
            currentBadTeachers.Clear();
            currentReports.Clear();
        }
    }
}
