using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tkach.Lab4.Proxy
{
    class TestImage : IBox
    {
        public void Draw(Canvas canvas, double x, double y)
        {
            throw new NotImplementedException();
        }
    }
}
