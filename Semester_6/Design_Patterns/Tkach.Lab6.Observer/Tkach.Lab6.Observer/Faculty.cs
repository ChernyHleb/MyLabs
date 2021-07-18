using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab6.Observer
{
    class Faculty : IObserver
    {
        public List<Teacher> currentBadTeachers;
        public Faculty()
        {
            currentBadTeachers = new List<Teacher>();
        }
        public void Update(object obj)
        {
            currentBadTeachers.Add((Teacher)obj);
        }

        public void PostBadTeachers()
        {
            Console.WriteLine("BAD TEACHERS OF THE WEEK:");
            foreach(Teacher teacher in currentBadTeachers)
            {
                Console.WriteLine("TEACHER " + teacher.id.ToString());
            }
            currentBadTeachers.Clear();
        }
    }
}
