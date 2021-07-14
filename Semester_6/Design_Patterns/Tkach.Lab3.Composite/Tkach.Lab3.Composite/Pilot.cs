﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    class Pilot : Unit
    {
        public static readonly int passengerAmountLimit = 2;
        public Pilot() 
        {
            weight = Unit.rnd.Next(5, 60);
        }
        public override int getLuggageWeight()
        {
            return weight;
        }
    }
}
