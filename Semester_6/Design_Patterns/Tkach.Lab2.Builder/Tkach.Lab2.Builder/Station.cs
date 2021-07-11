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
        public int busDriversAmount;
        public int taxiDriversAmount;
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
                "busesAmount: {0}\n" +
                "taxiesAmount: {1}\n" +
                "busDriversAmount: {2}\n" +
                "taxiDriversAmount: {3}\n" +
                "maturePassengersAmount: {4}\n" +
                "childPassengersAmount: {5}\n" +
                "lgotnyPassengersAmount: {6}\n",
                busesAmount,
                taxiesAmount,
                busDriversAmount,
                taxiDriversAmount,
                maturePassengersAmount,
                childPassengersAmount,
                lgotnyPassengersAmount
                );
        }
    }
}
