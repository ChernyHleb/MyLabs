using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    class EasyLevelBuilder : LevelBuilder
    {
        public EasyLevelBuilder() { }

        public override void CreateLevel()
        {
            base.level = new Level();
        }

        public override void CreateMaze()
        {
            base.level.maze = new Maze();
        }

        public override void CreatePlayer()
        {
            base.level.player = new Player(1, 1);
        }
    }
}
