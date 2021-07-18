using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab6.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание и инициализация объектов
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(0),
                new Teacher(1),
                new Teacher(2)
            };
            Deanery deanery = new Deanery(teachers);
            Faculty faculty = new Faculty();

            // Оформление подписок
            foreach (Teacher teacher in teachers)
            {
                teacher.RegisterObserver(deanery);
            }
            deanery.RegisterObserver(faculty);

            // тестирование
            Console.WriteLine("WEEK1");
            teachers[0].CreateReport();
            teachers[2].CreateReport();
            deanery.CheckTeachersReports();
            faculty.PostBadTeachers();

            Console.WriteLine("\nWEEK2");
            deanery.CheckTeachersReports();
            faculty.PostBadTeachers();

            Console.WriteLine("\nWEEK3");
            teachers[0].CreateReport();
            teachers[1].CreateReport();
            teachers[2].CreateReport();
            deanery.CheckTeachersReports();
            faculty.PostBadTeachers();

            Console.ReadKey();
        }
    }
}
