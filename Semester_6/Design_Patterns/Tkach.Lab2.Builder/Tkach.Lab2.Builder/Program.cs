using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            StationBuilder busStationBuilder = new BusStationBuilder();
            Director stationDirector = new Director(busStationBuilder);
            Station busStation = stationDirector.CreateStation();
            Console.WriteLine("BUS " + busStation.ToString());

            StationBuilder taxiStationBuilder = new TaxiStationBuilder();
            stationDirector.SetStationBuilder(taxiStationBuilder);
            Station taxiStation = stationDirector.CreateStation();
            Console.WriteLine("TAXI " + taxiStation.ToString());

            Console.ReadLine();
        }
    }
}
