using Tkach.Lab7_8.Game.MissionManager;
using Tkach.Lab7_8.Game.WorldMatrix;

namespace Tkach.Lab7_8.Game.LevelManagement
{
    class EasyLevelBuilder : LevelBuilder
    {
        public EasyLevelBuilder() 
        {
            worldMatrixCreationAlgorythm = new WorldMatrixFromTxtCreator();
            //worldMatrixCreationAlgorythm = new DefaultWorldMatrixCreator();
            worldMatrix = worldMatrixCreationAlgorythm.CreateWorldMatrix();
        }

        public override void CreateLevel()
        {
            base.level = new Level();
        }

        public override void CreateMaze()
        {
            base.level.maze = new GameWorldItems.Maze(worldMatrix);
        }

        public override void CreatePlayer()
        {
            base.level.player = new Player(0, 0);

            for (int x = 0; x < worldMatrix.dimentions.X; x++)
            {
                for (int y = 0; y < worldMatrix.dimentions.Y; y++)
                {
                    if(worldMatrix.matrix[y, x] == base.level.player.symbol)
                    {
                        base.level.player.position.X = x;
                        base.level.player.position.Y = y;
                        worldMatrix.matrix[y, x] = ' ';
                        return;
                    }
                }
            }
        }

        public override void CreateItems()
        {
            for (int x = 0; x < worldMatrix.dimentions.X; x++)
            {
                for (int y = 0; y < worldMatrix.dimentions.Y; y++)
                {
                    if (worldMatrix.matrix[y, x] == 'o')
                    {
                        base.level.items.Add(new Coin(x, y));
                        worldMatrix.matrix[y, x] = ' ';
                    }
                }
            }
        }

        public override void CreateMissionManager()
        {
            /// По хорошему нужен другой билдер для миссий
            base.level.missionManager = new MissionManager.MissionManager();
            GatherItemsMission<Coin> mission = new MissionManager.GatherItemsMission<Coin>("Collect coins");
            
            base.level.missionManager.missions.Add(mission);
            mission.RegisterObserver(base.level.missionManager);

            foreach (Item item in base.level.items)
            {
                if(item.symbol == 'o')
                {
                    Coin coin = (Coin)item;
                    mission.items.Add(coin);
                    mission.score++;
                    coin.RegisterObserver(mission);
                }
            }
        }
    }
}
