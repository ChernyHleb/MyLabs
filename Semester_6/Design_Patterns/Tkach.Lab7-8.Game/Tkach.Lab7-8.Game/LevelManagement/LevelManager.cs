using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    class LevelManager
    {
        private LevelBuilder builder;
        private Level level;

        public LevelManager()
        {

        }

        public void CreateLevel()
        {
            builder.CreateLevel();
            builder.CreateMaze();
            builder.CreatePlayer();
            builder.CreateItems();
            builder.CreateEnemies();
            builder.CreateTraps();

            level = builder.GetLevel();
        }

        public void SetLevelBuilder(LevelBuilder levelBuilder)
        {
            builder = levelBuilder;
        }

        public Level GetLevel()
        {
            return level;
        }
    }
}
