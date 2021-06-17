using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class TaxiDriver : Driver
    {
        private static List<Driver> taxiDrivers = null;
        public static readonly int limit = 1;
        public static int taxiDriverCounter = 0;
        private TaxiDriver()
        {
            TaxiDriver.taxiDriverCounter++;

            this.id = TaxiDriver.taxiDriverCounter;
            this.name = "TaxiDriver" + this.id.ToString();
            this.experience = (new Random()).Next(1, 57);
            TaxiDriver.taxiDrivers.Add(this);
        }

        public static List<Driver> GetDrivers()
        {
            return TaxiDriver.taxiDrivers;
        }

        public static Driver GetNewDriver()
        {
            if (TaxiDriver.taxiDriverCounter == TaxiDriver.limit)
            {
                Console.WriteLine("There are no more free taxi drivers!");
                return null;
            }
            else
            if (TaxiDriver.taxiDriverCounter == 0)
            {
                TaxiDriver.taxiDrivers = new List<Driver>();
            }

            return new TaxiDriver();
        }

        public override string ToString()
        {
            return String.Format("TAXIDRIVER id:{0} name:{1} exp:{2}",
                this.id.ToString(), this.name, this.experience.ToString());
        }
    }
}
