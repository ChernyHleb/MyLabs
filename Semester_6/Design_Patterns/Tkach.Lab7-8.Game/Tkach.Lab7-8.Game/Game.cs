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
            //ReadKey();

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

            levelManager = new LevelManager();
            levelManager.SetLevelBuilder(new EasyLevelBuilder());
            levelManager.CreateLevel();
            Level level = levelManager.GetLevel();

            FrameMaker.FrameMaker frameMaker = new FrameMaker.FrameMaker(
                level.maze, 
                level.player, 
                new List<IDrawable>()
            );
            gameWorldRepresentator = new GameWorldRepresentator(
                frameMaker, 
                new ConsoleRepresentator()
            );

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

        //private void HandlePlayerInput()
        //{
        //    
        //}

        private void RunGameLoop()
        {
            while(true)
            {
                //draw everything
                gameWorldRepresentator.DrawFrame();
                gameWorldRepresentator.DisplayRepresentation();
                //GitlerNiVChemNeVinovat();

                //check player input and move player
                //HandlePlayerInput();

                //check if the player reached the exit
                //string elementPlayerPos = world.GetElementAt(
                //    player.position.X, player.position.Y); 
                //if(elementPlayerPos == "X") {
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
