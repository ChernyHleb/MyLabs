using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class BoardTaxi : BoardAnyCar
    {
        public static readonly int passengerPlaces = 3;
        public static readonly int driverPlaces = 1;
        public BoardTaxi()
        {

        }

        public override int Board(int passengersAmount)
        {
            int boardedPassengers = 0;
            int boardedDrivers = 0;
            boardedDrivers += BoardDriver();
            boardedPassengers += BoardPassengers(passengersAmount);

            if (boardedDrivers == 0)
            {
                Console.WriteLine("Cant departure without driver");
            }

            if (boardedPassengers == 0)
            {
                Console.WriteLine("Cant departure without passengers");
            }

            return boardedPassengers + boardedDrivers;
        }

        protected override int BoardDriver()
        {
            Driver tD = TaxiDriver.GetNewDriver();
            if (tD == null)
                return 0;
            else
            {
                Console.WriteLine(tD);
            }
            return 1;
        }

        protected override int BoardPassengers(int amount)
        {
            int boardedPassengers = 0;
            if (amount <= BoardTaxi.passengerPlaces)
                boardedPassengers = amount;
            else
                boardedPassengers = BoardTaxi.passengerPlaces;
                
            
            Console.WriteLine("passengers boarded:");
            for (int i = 0; i < boardedPassengers; i++)
                Console.Write((new Passenger()).ToString() + " ");
            Console.WriteLine();

            if (amount - boardedPassengers != 0)
            {
                Console.WriteLine("Taxi is filled, cant board more");
            }

            return boardedPassengers;
        }
    }
}
