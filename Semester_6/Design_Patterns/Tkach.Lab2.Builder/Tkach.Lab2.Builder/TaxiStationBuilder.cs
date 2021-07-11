using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    class TaxiStationBuilder : StationBuilder
    {
        public TaxiStationBuilder() { }

        public override void CreateStation()
        {
            base.station = new Station();
        }

        public override void CreateTaxies()
        {
            base.station.taxiesAmount = rnd.Next(0, 10);
        }

        public override void CreateTaxiDrivers()
        {
            base.station.taxiDriversAmount = rnd.Next(0, 10);
        }

        public override void CreateMaturePassengers()
        {
            base.station.maturePassengersAmount = rnd.Next(0, 500);
        }

        public override void CreateChildPassengers()
        {
            base.station.childPassengersAmount = rnd.Next(0, 250);
        }
    }
}
