using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    class Station
    {
        public static readonly int busPassengersLimit = 29;
        public static readonly int taxiPassengersLimit = 4;

        public int busesAmount;
        public int taxiesAmount;
        public int driversAmount;
        public int extraEquipmentAmount;
        public int maturePassengersAmount;
        public int childPassengersAmount;
        public int lgotnyPassengersAmount;

        public Station() { }

        public void Test()
        {

        }

        public override string ToString()
        {
            return String.Format("STATION INFO:\n" +
                "buses: {0}\n" +
                "taxies: {1}\n" +
                "drivers: {2}\n" +
                "extra equipment: {3}\n" +
                "mature passengers: {4}\n" +
                "child passengers: {5}\n" +
                "lgotny passengers: {6}\n",
                busesAmount,
                taxiesAmount,
                driversAmount,
                extraEquipmentAmount,
                maturePassengersAmount,
                childPassengersAmount,
                lgotnyPassengersAmount
                );
        }
    }
}
