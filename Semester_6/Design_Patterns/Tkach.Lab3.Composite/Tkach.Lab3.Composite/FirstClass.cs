using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class FirstClass : Unit
    {
        public static readonly int passengerSeatsLimit = 10;
        public FirstClass()
        {
            this.parts = new List<Unit>();
        }
        public override int getLuggageWeight()
        {
            int sum = 0;
            foreach (Unit elem in parts)
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
            parts.RemoveAt(index);
        }
    }
}
