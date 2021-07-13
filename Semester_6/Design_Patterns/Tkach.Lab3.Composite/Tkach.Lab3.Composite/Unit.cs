using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab3.Composite
{
    abstract class Unit
    {
        protected List<Unit> parts;
        protected  static Random rnd = new Random();
        public virtual int getLuggageWeight()
        {
            throw new NotImplementedException();
        }

        public virtual void addUnit(Unit unit)
        {
            throw new NotImplementedException();
        }

        public virtual void removeUnit(int index)
        {
            throw new NotImplementedException();
        }
    }
}
