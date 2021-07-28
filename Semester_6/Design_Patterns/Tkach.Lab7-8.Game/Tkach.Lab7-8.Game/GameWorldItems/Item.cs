using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game
{
    abstract class Item
    {
        public bool isActive;
        public Point position;
        public char symbol;

        public Item(int x, int y)
        {
            position = new Point(x, y);
        }
    }
}
