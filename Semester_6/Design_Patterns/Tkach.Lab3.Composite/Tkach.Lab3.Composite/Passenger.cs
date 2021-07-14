using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Passenger : Unit
    {
        public static readonly int passengerAmountLimit = 180;
        public Passenger() 
        { 
            weight = Unit.rnd.Next(5, 60); 
        }
        public override int getLuggageWeight()
        {
            return weight;
        }
    }
}
