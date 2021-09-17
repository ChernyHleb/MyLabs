using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.AbstractFactory_Singleton
{
    interface IStationAbstractFactory
    {
        BoardAnyCar BoardAnyCar();
        Driver CreateDriver();
    }
}
