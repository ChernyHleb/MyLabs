using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class EconomyClass : Unit
    {
        public static readonly int luggageWeightLimit = 20;
        public static readonly int passengerSeatsLimit = 150;

        public EconomyClass()
        {
            this.parts = new List<Unit>();
        }
        public override int getLuggageWeight()
        {
            int sum = 0;
            foreach(Unit elem in parts)
            {
                sum += elem.getLuggageWeight();
            }
            return sum;
        }

        public override void addUnit(Unit unit)
        {
            parts.Add(unit);
        }

        public override void removeUnit(int index)
        {
            denyUnit(index - delta);
            parts.RemoveAt(index - delta);
            delta++;
        }

        int delta = 0;
        public override void denyUnit(int index)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Passenger " + (index + delta) + " denied");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
