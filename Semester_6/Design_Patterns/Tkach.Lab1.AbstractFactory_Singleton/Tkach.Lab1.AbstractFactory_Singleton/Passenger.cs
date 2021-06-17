using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class Passenger
    {
        public static int counter = 0;
        public static List<Passenger> passengers = new List<Passenger>();
        public string name;

        public Passenger()
        {
            counter++;
            this.name = "P" + counter.ToString();
            Passenger.passengers.Add(this);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
