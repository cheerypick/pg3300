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
        // Lag property
        private static int _lastHighscore;
        public static int LastHighscore{get { return _lastHighscore; } set { _lastHighscore = value; }}
        public static void Main(string[] arguments) {
           Boolean runGame = true;
           GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
           LastHighscore = Convert.ToInt32(GetHighscoreFromFile);
            // Oppretter et object av spillet.
           
            // Starter det første spillet
            while (runGame)  {
                var snake = new SnakeGame();
                snake.RunGame();
                runGame = GameMenu(snake);
            }

        }

        // Metoden som snakker til bruker. Spør om han vil spille på nytt ect.
        public static bool GameMenu(SnakeGame snake){
            // Sjekker om forrige highscore er større en nåværende score.
            if (SnakeGame.ShowScore > LastHighscore) {
                /*			Fiks til Relative Path!!		*/
                // Kilder:
                //http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
                File.WriteAllText(@"..\..\score.txt", "" + SnakeGame.ShowScore);
                LastHighscore = SnakeGame.ShowScore;
            }

            ScreenHandler.DrawMenu();

            // Tar imot input, og gjør det bruker sier.
            String input = Console.ReadLine();
            if (input != null && input.Equals("y")) { 
                Console.Clear();
                // Må resette score for hver runde.
                SnakeGame.ShowScore = 0;
                return true;
            }

            Console.Write("\n\tbb");
            Console.ReadKey(true);
            return false;
        }
    }
}

