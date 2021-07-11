using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    class BusStationBuilder : StationBuilder
    {
        public BusStationBuilder() { }

        public override void CreateStation()
        {
            base.station = new Station();
        }

        public override void CreateBuses()
        {
            base.station.busesAmount = rnd.Next(0, 10);
        }

        public override void CreateBusDrivers()
        {
            base.station.busDriversAmount = rnd.Next(0, 10);
        }

        public override void CreateMaturePassengers()
        {
            base.station.maturePassengersAmount = rnd.Next(0, 500);
        }

        public override void CreateChildPassengers()
        {
            base.station.childPassengersAmount = rnd.Next(0, 250);
        }

        public override void CreateLgotnyPassengers()
        {
            base.station.lgotnyPassengersAmount = rnd.Next(0, 250);
        }
    }
}
