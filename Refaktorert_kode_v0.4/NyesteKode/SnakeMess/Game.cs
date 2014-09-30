using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Diagnostics;

using System.Threading;

namespace SnakeMess{
    internal class Game
    {

        private static string GetHighscoreFromFile;

        public static void Main(string[] arguments) {
           Boolean runGame = true;
           GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
           ScreenHandler.LastHighscore = Convert.ToInt32(GetHighscoreFromFile);
            // Oppretter et object av spillet.
           
            // Starter det første spillet
            while (runGame)  {
                var snake = new SnakeGame();
                snake.RunGame();
                runGame = ScreenHandler.GameOverMenu(snake);
            }
        }
    }
}

