using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.GameWorldRepresentators
{
    class GameWorldRepresentator
    {
        private IGameWorldRepresentator representationAlgorythm;
        private FrameMaker.FrameMaker frameMaker;
        private Matrix<char> currentFrame;

        public Matrix<char> DrawFrame()
        {
            currentFrame = frameMaker.Draw(new Matrix<char>());
            return currentFrame;
        }

        public void DisplayRepresentation()
        {
            representationAlgorythm.Represent(currentFrame);
        }
    }
}
