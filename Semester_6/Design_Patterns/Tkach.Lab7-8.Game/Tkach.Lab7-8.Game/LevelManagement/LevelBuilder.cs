using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.WorldMatrix;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    abstract class LevelBuilder
    {
        protected Matrix<char> worldMatrix;
        protected Level level;

        protected IWorldMatrixCreator worldMatrixCreationAlgorythm;

        public virtual void CreateLevel() { }
        public virtual void CreatePlayer() { }
        public virtual void CreateEnemies() { }
        public virtual void CreateItems() { }
        public virtual void CreateMaze() { }
        public virtual void CreateTraps() { }
        public virtual void CreateDoors() { }
        public virtual void CreateMissionManager() { }

        public virtual Level GetLevel()
        {
            return level;
        }
    }
}
