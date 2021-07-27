using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab7_8.Game
{
    class Item
    {
        public Point position;
        public Item(int x, int y)
        {
            position = new Point(x, y);
        }
    }
}
