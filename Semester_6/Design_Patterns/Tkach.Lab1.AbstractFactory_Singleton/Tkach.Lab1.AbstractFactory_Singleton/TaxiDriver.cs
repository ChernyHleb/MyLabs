using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class TaxiDriver : Driver
    {
        private static List<TaxiDriver> taxiDriver;
        private static readonly int limit = 1;
        public override List<Driver> GetDrivers()
        {
            
        }
    }
}
