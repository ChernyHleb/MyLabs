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
        private Teacher currentBadTeacher;
        private List<Teacher> teachers;
        private List<IObserver> observers;

        public Deanery(List<Teacher> teachers)
        {
            currentReports = new List<Report>();
            this.teachers = teachers;
            observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(currentBadTeacher);
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
            Console.WriteLine("Deanery: Report from " + ((Report)obj).author.id);
        }

        public void CheckTeachersReports()
        {
            foreach (Teacher teacher in teachers)
            {
                bool isBad = true;
                foreach (Report report in currentReports)
                {
                    if(report.author.id == teacher.id)
                    {
                        isBad = false;
                        break;
                    }
                }

                if (isBad)
                {
                    currentBadTeacher = teacher;
                    NotifyObservers();
                }   
            }

            currentReports.Clear();
        }
    }
}
