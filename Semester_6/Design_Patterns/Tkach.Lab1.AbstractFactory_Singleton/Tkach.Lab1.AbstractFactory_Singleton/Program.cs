using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                TaxiDriver.GetNewDriver();
            }

            foreach(TaxiDriver bd in TaxiDriver.GetDrivers())
            {
                Console.WriteLine(bd.ToString());
            }

            Console.ReadLine();
        }
    }
}
