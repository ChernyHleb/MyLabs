using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Program
    {
        public static int overWeightedLuggage = 0;
        public static int deniedLuggage = 0;
        public static int luggageWeightLimit = 4500;

        static FirstClass firstClass;
        static BusinessClass businessClass;
        static EconomyClass economyClass;

        public enum passengerType { FC, BC, EC }

        public static void DenyPassenger(int index, Unit container)
        {
                container.removeUnit(index);
        }

        public static void WriteLuggageWeight(Unit passenger, int lim, passengerType type, int index, Unit container)
        {   // business and economy classes 
            // green - ok, red - overweight, dark magenta - denied
            int weight = passenger.getLuggageWeight();
            luggageWeightLimit -= weight;

            if (type == passengerType.EC && luggageWeightLimit < 0)
            {
                deniedLuggage++;
                if (container != null) 
                    container.removeUnit(index);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else
            if(weight > lim && type != passengerType.FC)
            {
                overWeightedLuggage++;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write(String.Format("{0}\t", weight));
        }

        static void Main(string[] args)
        {
            //PILOTS SEATS
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PILOTS SEATS");
            for (int i = 0; i < Pilot.passengerAmountLimit; i++)
            {
                WriteLuggageWeight(new Pilot(), 0, passengerType.FC, i, null);
            }
            Console.WriteLine();

            //STEWARDESS SEATS
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSTEWARDESS SEATS");
            for (int i = 0; i < Stewardess.passengerAmountLimit; i++)
            {
                WriteLuggageWeight(new Stewardess(), 0, passengerType.FC, i, null);
            }
            Console.WriteLine();

            //FIRST CLASS 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nFIRST CLASS");
            firstClass = new FirstClass();
            for (int i = 0; i < FirstClass.passengerSeatsLimit; i++)
            {
                if (i % 6 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }
                Passenger passenger = new Passenger();
                firstClass.addUnit(passenger);
                WriteLuggageWeight(passenger, 0, passengerType.FC, i, firstClass);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\ntotal: " + firstClass.getLuggageWeight().ToString());


            //BUSINESS CLASS 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nBUSINESS CLASS");
            businessClass = new BusinessClass();
            for (int i = 0; i < BusinessClass.passengerSeatsLimit; i++)
            {
                if (i % 6 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }
                Passenger passenger = new Passenger();
                businessClass.addUnit(passenger);
                WriteLuggageWeight(passenger, BusinessClass.luggageWeightLimit, passengerType.BC, i, businessClass);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\ntotal: " + businessClass.getLuggageWeight().ToString());



            //ECONOMY CLASS 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nECONOMY CLASS");
            economyClass = new EconomyClass();
            for (int i = 0; i < EconomyClass.passengerSeatsLimit; i++)
            {
                if (i % 6 == 0 && i != 0)
                {
                    Console.WriteLine("\n");
                }
                Passenger passenger = new Passenger();
                economyClass.addUnit(passenger);
                if (i == 6) DenyPassenger(6, economyClass);
                WriteLuggageWeight(passenger, EconomyClass.luggageWeightLimit, passengerType.EC, i, economyClass);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\ntotal: " + economyClass.getLuggageWeight().ToString());

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("DENIED LUGGAGE\n UNITS: " + Program.deniedLuggage.ToString());
            if(Program.luggageWeightLimit < 0)
            {
                Console.WriteLine(" OVERWEIGHT:" + (Program.luggageWeightLimit * -1).ToString());
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PASSENGERS WITH EXTRA LUGGAGE:" + Program.overWeightedLuggage.ToString());


            Console.ReadLine();
        }
    }
}
