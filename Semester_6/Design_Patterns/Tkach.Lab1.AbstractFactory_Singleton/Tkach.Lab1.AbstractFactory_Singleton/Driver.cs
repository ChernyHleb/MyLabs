using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    abstract class Driver
    {   
        public int experience;
        public String name;
        public int id;
        protected static Random rnd = new Random();
    }
}
