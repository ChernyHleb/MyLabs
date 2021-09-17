using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class TaxiStationAbstractFactory : IStationAbstractFactory
    {
        public BoardAnyCar BoardAnyCar()
        {
            return new BoardTaxi();
        }

        public Driver CreateDriver()
        {
            return TaxiDriver.GetNewDriver();
        }
    }
}
