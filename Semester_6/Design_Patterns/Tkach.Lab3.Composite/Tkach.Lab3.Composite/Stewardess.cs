using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Stewardess : Unit
    {
        private static readonly int passengerAmountLimit = 6;
        public Stewardess() { }
        public override int getLuggageWeight()
        {
            return Unit.rnd.Next(5, 60);
        }
    }
}
