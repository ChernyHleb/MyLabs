using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Passenger : Unit
    {
        private static readonly int passengerAmountLimit = 180;
        public Passenger() { }
        public override int getLuggageWeight()
        {
            return Unit.rnd.Next(5, 60);
        }
    }
}
