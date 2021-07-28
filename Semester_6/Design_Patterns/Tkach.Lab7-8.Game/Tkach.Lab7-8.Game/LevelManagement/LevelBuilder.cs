using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    abstract class LevelBuilder
    {
        protected Level level;

        public virtual void CreateLevel() { }
        public virtual void CreatePlayer() { }
        public virtual void CreateEnemies() { }
        public virtual void CreateItems() { }
        public virtual void CreateMaze() { }
        public virtual void CreateTraps() { }

        public virtual Level GetLevel()
        {
            return level;
        }
    }
}
