using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    abstract class StationBuilder
    {
        protected static readonly Random rnd = new Random();
        protected Station station;

        public virtual void CreateStation() { }

        public virtual void CreateBuses() { }

        public virtual void CreateTaxies() { }
                       
        public virtual void CreateBusDrivers() { }              
                       
        public virtual void CreateTaxiDrivers() { }

        public virtual void CreateMaturePassengers() { }

        public virtual void CreateChildPassengers() { }

        public virtual void CreateLgotnyPassengers() { }

        public virtual Station GetStation()
        {
            return station;
        }
    }
}
