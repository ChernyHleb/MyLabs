using System.Collections.Generic;
using Figgle;
using Tkach.Lab7_8.Game.FrameMaker;
using Tkach.Lab7_8.Game.GameWorldRepresentators;
using Tkach.Lab7_8.Game.LevelManagement;

namespace Tkach.Lab7_8.Game
{
    class Game
    {
        private LevelManager levelManager;
        private GameWorldRepresentator gameWorldRepresentator;

        public static bool IsPositionWalkable(int x, int y)
        {
            //check world bounds
            if (x < 0 || y < 0 || x >= cols || y >= rows)
            {
                return false;
            }

            //ceck if the tile is walkable
            return grid[y, x] == " " || grid[y, x] == "X";
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


            //world = new World(grid);

            maze = new Maze();
            player = new Player(1, 1);
            FrameMaker.FrameMaker frameMaker = new FrameMaker.FrameMaker(
                maze, 
                player, 
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
