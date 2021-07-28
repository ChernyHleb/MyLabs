using System.Collections.Generic;
using Figgle;
using Tkach.Lab7_8.Game.DataStructures;
using Tkach.Lab7_8.Game.FrameMaker;
using Tkach.Lab7_8.Game.GameWorldRepresentators;
using Tkach.Lab7_8.Game.LevelManagement;

namespace Tkach.Lab7_8.Game
{
    class Game
    {
        private static LevelManager levelManager;
        private GameWorldRepresentator gameWorldRepresentator;
        private static InputHandler inputHandler; 

        public static bool IsPositionWalkable(int x, int y)
        {
            Matrix<char> matr = levelManager.GetLevel().maze.matrix;
            //check world bounds
            if (x < 0 || y < 0 || x >= matr.dimentions.X || y >= matr.dimentions.Y)
            {
                return false;
            }

            //ceck if the tile is walkable
            return matr.matrix[y, x] == ' '
                || matr.matrix[y, x] == 'D'
                || matr.matrix[y, x] == 'o';
        }

        public void Start()
        {
            //DisplayIntro();

            #region defaultMaze
            //string[,] grid = {
            //    { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█"},
            //    { "█", " ", " ", "█", " ", " ", " ", " ", " ", "█"},
            //    { "█", " ", " ", "█", " ", " ", "█", " ", " ", "█"},
            //    { "█", " ", " ", "█", " ", "█", "█", " ", " ", "█"},
            //    { "█", " ", " ", "█", " ", " ", "█", " ", " ", "█"},
            //    { "█", " ", " ", "█", " ", " ", "█", "█", "█", "█"},
            //    { "█", " ", " ", "█", "█", " ", "█", " ", " ", "█"},
            //    { "█", " ", " ", " ", " ", " ", " ", " ", " ", "X"},
            //    { "█", " ", " ", "█", " ", " ", "█", " ", " ", "█"},
            //    { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█"}
            //};
            #endregion

            // создание моделей игрового мира и самого уровня, состоящего из них
            levelManager = new LevelManager();
            levelManager.SetLevelBuilder(new EasyLevelBuilder());
            levelManager.CreateLevel();
            Level level = levelManager.GetLevel();


            // создание компоновщика моделей игрового мира в матрицу, 
            // отображающую взаимное расположение игровых объектов на карте
            // и создание репрезентатора, который будет выводить мир на экран
            // определенным образом
            FrameMaker.FrameMaker frameMaker = new FrameMaker.FrameMaker(
                level.maze, 
                level.player, 
                new List<IDrawable>()
            );
            gameWorldRepresentator = new GameWorldRepresentator(
                frameMaker, 
                new ConsoleRepresentator()
            );


            // создание обработчика нажатия клавиш
            inputHandler = new InputHandler();
            inputHandler.RegisterObserver(level.player);

            #region stuff
            /*player1 = new Player(60, 13);
            player2 = new Player(60, 13);
            player3 = new Player(60, 13);
            player4 = new Player(60, 13);
            player3.PlayerMarker = "P ";
            player4.PlayerMarker = " P";

            players = new List<Player>
            { player1, player2, player3, player4 };*/
            #endregion
            // запуск игрового процесса
            RunGameLoop();
        }

        #region trash
        //Player player1, player2, player3, player4;
        //List<Player> players;

        //private void NiVChemNeVinovat()
        //{
        //    if (player1.Y > 1) player1.Y -= 1;
        //    else
        //    {
        //        if (player1.X < 86)
        //            player1.X += 2;
        //    }
        //    if (player2.Y < 26) player2.Y += 1;
        //    else
        //    {
        //        if (player2.X > 34) 
        //            player2.X -= 2;
        //    }
        //    if (player3.X > 34) player3.X -= 2;
        //    else
        //    {
        //        if (player3.Y > 1) 
        //            player3.Y -= 1;
        //    }
        //    if (player4.X < 86) player4.X += 2;
        //    else
        //    {
        //       if (player4.Y < 26)
        //            player4.Y += 1; 
        //    }

        //    foreach (Player player in players) player.Draw();
        //}
        #endregion

        private void RunGameLoop()
        {
            while(true)
            {
                //draw everything
                gameWorldRepresentator.DrawFrame();
                gameWorldRepresentator.DisplayRepresentation();

                //check player input and move player
                inputHandler.HandleInput();

                //check if the player reached the exit
                //char elementPlayerPos = 
                //    levelManager.GetLevel().maze.matrix.matrix[
                //    levelManager.GetLevel().player.position.X,
                //    levelManager.GetLevel().player.position.Y]; 
                //if(elementPlayerPos == 'D') {
                //    break;
                //}

                // give as Console a chance to render
                System.Threading.Thread.Sleep(20);
            }
        }

        private void DisplayIntro()
        {
            //WriteLine(Figgle.FiggleFonts.Larry3d.Render("PIAPS Lab 7-8"));


        }
    }
}
