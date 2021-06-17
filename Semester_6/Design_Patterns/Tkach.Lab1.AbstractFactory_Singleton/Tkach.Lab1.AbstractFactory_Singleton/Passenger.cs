using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class Passenger
    {
        static int counter = 0;
        string name;

        public Passenger()
        {
            this.name = "P" + counter.ToString();
        }

        public override string ToString()
        {
            return name;
        }
    }
}
