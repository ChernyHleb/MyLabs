using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Stewardess : Unit
    {
        public static readonly int passengerAmountLimit = 6;
        public Stewardess() 
        { 
            weight = 0; 
        }
        public override int getLuggageWeight()
        {
            return weight;
        }
    }
}
