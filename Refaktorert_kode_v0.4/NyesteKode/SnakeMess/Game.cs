using System;
using System.IO;

namespace SnakeMess{
    internal class Game
    {

		private static string GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
        // Lag property
        private static int _lastHighscore;
        public static int LastHighscore{get { return _lastHighscore; } set { _lastHighscore = value; }}
        public static void Main(string[] arguments) {
           Boolean runGame = true;
           
           LastHighscore = Convert.ToInt32(GetHighscoreFromFile);

           
            // Starter det første spillet
            while (runGame)  {
                var snake = new SnakeGame();
                snake.RunGame();
                runGame = ScreenHandler.GameOverMenu(snake);
            }

        }
    }
}

