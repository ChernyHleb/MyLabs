using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tkach.Lab4.Proxy
{
    interface IBox
    {
        void Draw(Canvas canvas, double x, double y);
    }
}
