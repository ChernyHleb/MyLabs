using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tkach.Lab7_8.Game.DataStructures;

namespace Tkach.Lab7_8.Game.FrameMaker
{
    class FrameMaker : IDrawable
    {
        public FrameMaker(IDrawable maze, IDrawable player, List<IDrawable> items)
        {
            this.maze = maze;
            this.items = items;
            this.player = player;
        }

        private IDrawable maze;
        private IDrawable player;
        private List<IDrawable> items;

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            if (maze.IsActive())
            {
                canvas = maze.Draw(canvas);
            }   
            
            if (player.IsActive())
            {
                canvas = player.Draw(canvas);
            }  
            
            foreach(IDrawable item in items)
            {
                if (item.IsActive())
                {
                    canvas = item.Draw(canvas);
                }
            }

            return canvas;
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }
    }
}
