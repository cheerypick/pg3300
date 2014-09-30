using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

// This handles output

namespace SnakeMess {
    internal class ScreenHandler {
		// Lag property
		private static int _lastHighscore;
		public static int LastHighscore { get { return _lastHighscore; } set { _lastHighscore = value; } }

        // Method for preparing
        public void WriteStartUp() {
            Console.CursorVisible = false; // Dont want to see the cursor
            Console.ForegroundColor = ConsoleColor.Green; // Console color
            Console.SetCursorPosition(10, 10); // Set start poisition
        }

        // Update screen
        public void updateScreen(Snake snake, pellet pellet, Coord newHead) {

            // Write over head
            Console.SetCursorPosition(snake.getHead().X, snake.getHead().Y);
            Console.Write("O");
            
            // If snake is not growing, write over tail
            if (!snake.grow) {
                Console.SetCursorPosition(snake.getTail().X, snake.getTail().Y);
                Console.Write(" ");
                snake.getCoords().RemoveAt(0);
            }

            // Add new head to snake 
            snake.getCoords().Add(newHead);
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            // dont grow after 1 grow update
            snake.grow = false;
        }

        // smoke some weed
        public int getHeight() {
            return Console.WindowHeight;
        }

        // .. and eat a burga
        public int getWidth() {
            return Console.WindowWidth;
        }

        public static void drawPellet(Coord coord){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void DrawMenu(int showScore){
            // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
			Console.Write("\tHighScore: " + LastHighscore);
            Console.Write("\tScore: " + showScore  + "\n\n");
            Console.Write("\tGame Over\n\n\tTry again? y/n\n\n\t");
        }

        public void DrawScore(int showScore)
        {
            // Viser score på skjermen
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            Console.Write("\tHighScore: " + LastHighscore + "\t\tScore: " + showScore);
        }


		// Metoden som holder styr på menyen som kommer når det blir Game Over
		public static bool GameOverMenu(SnakeGame snake)
		{
			// Sjekker om forrige highscore er større en nåværende score.
			if (SnakeGame.ShowScore > LastHighscore)
			{
				/*			Fiks til Relative Path!!		*/
				// Kilder:
				//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
				File.WriteAllText(@"..\..\score.txt", "" + SnakeGame.ShowScore);
				LastHighscore = SnakeGame.ShowScore;
			}

			ScreenHandler.DrawMenu(SnakeGame.ShowScore);

			// Tar imot input, og gjør det bruker sier.
			String input = Console.ReadLine();
			if (input != null && input.Equals("y"))
			{
				Console.Clear();
				// Må resette score for hver runde.
				SnakeGame.ShowScore = 0;
				return true;
			}
			if (input != null && input.Equals("n"))
			{
				Console.Clear();
				Console.Write("\n\n\tHave a nice day buddy!");
				Console.ReadKey(true);
				return false;
			}
			// Viss du skriver feil (ikke y eller n)
			GameOverMenu(snake);
			return true;
		}
    }
}
