using System;
using System.Collections.Generic;
using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.LevelManagement;

namespace Tkach.Lab7_8.Game.FrameMaker
{
    class FrameMaker : IDrawable
    {
        public FrameMaker(Level level)
        {
            this.maze = level.maze;
            this.items = new List<IDrawable>();
            foreach(Item item in level.items)
            {
                this.items.Add(item);
            }
            this.player = level.player;
            missions = new List<IDrawable>();
            foreach(IDrawable mission in level.missionManager.missions)
            {
                this.missions.Add(mission);
            }
        }

        private IDrawable maze;
        private IDrawable player;
        private List<IDrawable> items;
        private List<IDrawable> missions;

        public Matrix<char> Draw(Matrix<char> canvas)
        {
            if (maze.IsActive())
            {
                canvas = maze.Draw(canvas);
            }   
            
            foreach(IDrawable item in items)
            {
                if (item.IsActive())
                {
                    canvas = item.Draw(canvas);
                }
            }

            if (player.IsActive())
            {
                canvas = player.Draw(canvas);
            }

            return canvas;
        }

        public List<string> Draw()
        {
            List<string> output = new List<string>();
            foreach(IDrawable mission in missions)
            {
                output.Add(mission.Draw());
            }
            return output;
        }

        public Matrix<char> MakeFrame()
        {
            return Draw(new Matrix<char>());
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        string IDrawable.Draw()
        {
            throw new NotImplementedException();
        }

        public string DrawMissions()
        {
            string output = "";
            foreach(IDrawable mission in missions)
            {
                if (!mission.IsActive())
                    continue;
                output += mission.Draw() + "\n";
            }
            return output;
        }
    }
}
