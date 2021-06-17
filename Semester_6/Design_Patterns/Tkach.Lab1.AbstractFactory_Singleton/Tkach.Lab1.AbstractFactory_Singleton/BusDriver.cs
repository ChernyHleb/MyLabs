using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class BusDriver : Driver
    {
        private static List<Driver> busDrivers = null;
        private static readonly int limit = 2;
        public static int busDriverCounter = 0;
        private BusDriver()
        {
            BusDriver.busDriverCounter++;

            this.id = BusDriver.busDriverCounter;
            this.name = "BusDriver" + this.id.ToString();
            this.experience = (Driver.rnd).Next(1, 57);

        }

        public static List<Driver> GetDrivers()
        { 
            return BusDriver.busDrivers;
        }

         public static Driver GetNewDriver()
        {
            if(BusDriver.busDriverCounter == BusDriver.limit)
            {
                Console.WriteLine("There are no more free bus drivers!");
                return null;
            }
            else
            if(BusDriver.busDriverCounter == 0)
            {
                BusDriver.busDrivers = new List<Driver>();
            }
            
            BusDriver bD = new BusDriver();
            BusDriver.busDrivers.Add(bD);

            return bD;
        }

        public override string ToString()
        {
            return String.Format("BUSDRIVER id:{0} name:{1} exp:{2}",
                this.id.ToString(), this.name, this.experience.ToString());
        }
    }
}
