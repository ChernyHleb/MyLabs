using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab2.Builder
{
    class Director
    {
        private StationBuilder builder;
        public Director(StationBuilder builder) 
        { 
            this.builder = builder; 
        }

        public Station CreateStation()
        {
            builder.CreateStation();
            builder.CreateBuses();
            builder.CreateTaxies();
            builder.CreateDrivers();
            builder.CreateExtraEquipment();
            builder.CreateMaturePassengers();
            builder.CreateChildPassengers();
            builder.CreateLgotnyPassengers();
        
            return builder.GetStation();
        }

        public void SetStationBuilder(StationBuilder builder)
        {
            this.builder = builder;
        }
    }
}
