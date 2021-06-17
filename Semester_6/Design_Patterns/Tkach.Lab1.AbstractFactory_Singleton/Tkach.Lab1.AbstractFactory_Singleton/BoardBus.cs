using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    class BoardBus : BoardAnyCar
    {
        public static readonly int passengerPlaces = 29;
        public static readonly int driverPlaces = 1;
        public BoardBus()
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
            Driver bD = BusDriver.GetNewDriver();
            if (bD == null)
                return 0;
            else
            {
                Console.WriteLine(bD);
            }
            return 1;
        }

        protected override int BoardPassengers(int amount)
        {
            int boardedPassengers = 0;
            if (amount <= BoardBus.passengerPlaces)
                boardedPassengers = amount;
            else
                boardedPassengers = BoardBus.passengerPlaces;

            Console.WriteLine("passengers boarded:");
            for (int i = 0; i < boardedPassengers; i++)
                Console.Write((new Passenger()).ToString() + " ");
            Console.WriteLine();
            if (amount - boardedPassengers != 0)
            {
                Console.WriteLine("Bus is filled, cant board more");
            }

            return boardedPassengers;
        }
    }
}
