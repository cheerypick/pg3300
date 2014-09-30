using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

// This handles output

namespace SnakeMess {
    internal class ScreenHandler  {

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

        public void DrawBorder() {
            border = new Border();
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






        public static void DrawGameOverMenu(int showScore){
            // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            
			Console.Write("\tHighScore: " + Game.LastHighscore + "\t\tScore: " + showScore);
            Console.Write("\n\n\tYou lost lol\n\n\tTry again? y/n\n\n\t");
        }

        public void DrawInGameScore(int showScore){
            // Viser score på skjermen
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            Console.Write("\tHighScore: " + Game.LastHighscore + "\t\tScore: " + showScore);
        }
		public static bool GameOverMenu(SnakeGame snake)
		{
			/*		HighScore		*/
			// Sjekker om forrige highscore er større en nåværende score.
			// Om nåværende score er høyere, så vil den erstatte highscore
			if (SnakeGame.ShowScore > Game.LastHighscore)
			{
				// Kilder:
				//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
				File.WriteAllText(@"..\..\score.txt", "" + SnakeGame.ShowScore);
				Game.LastHighscore = SnakeGame.ShowScore;
			}

			DrawGameOverMenu(SnakeGame.ShowScore);

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
				Console.WriteLine("\n\n\tSee you later!");
				Console.ReadKey(true);
				return false;
			}
			// Viss du skriver feil.
			return GameOverMenu(snake);
		}
    }
}
