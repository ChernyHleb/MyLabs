using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab7_8.Game.GameWorldRepresentators
{
    class GameWorldRepresentator
    {
        private IGameWorldRepresentator representationAlgorythm;
        private FrameMaker frameMaker;

        public void DisplayRepresentation()
        {
            representationAlgorythm.Represent();
        }
    }
}
