using System.Collections.Generic;
using Tkach.Lab7_8.Game.GameWorldItems;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    class Level
    {
        public Maze maze;
        public Player player;
        public List<Item> items;
        public List<Enemy> enemies;
        public List<Trap> traps;
        public List<Door> doors;
        public MissionManager.MissionManager missionManager;

        public Level()
        {
            items = new List<Item>();
            doors = new List<Door>();
        }
    }
}
