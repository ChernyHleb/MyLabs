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
            builder.CreatePlayer();
            builder.CreateItems();
            builder.CreateEnemies();
            builder.CreateTraps();
            builder.CreateDoors();
            builder.CreateMaze();
            builder.CreateMissionManager();

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
