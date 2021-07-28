using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Tkach.Lab7_8.Game
{
    class Player
    {
        public Point position;
        public string PlayerMarker;
        public ConsoleColor PlayerColor;

        public Player(int initialX, int initialY)
        {
            position = new Point(initialX, initialY);
            PlayerMarker = "P";
            PlayerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            
        }
    }
}
