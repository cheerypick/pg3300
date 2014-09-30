using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Menu {
        public static void writeMenu()  {
            
            // plz static void
        }






		/*		Score og Game Over meny		*/


		// Score som blir vist in-game
		public static void DrawInGameScore(int showScore)
		{
			// Viser score på skjermen
			Console.SetCursorPosition(1, 1);
			// Skriver ut highscore og litt tekst
			Console.Write("\tHighScore: " + Game.LastHighscore + "\t\tScore: " + showScore);
		}

		// Menyen som kommer når det blir gameover
		public static bool GameOverMenu(SnakeGame snake)
		{
			// Sjekker først om det ble ny highscore
			checkForHighScore();

			// Tegner menyen som kommer når det er gameover
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


		// Menyen som blir tegna når det er gameover
		public static void DrawGameOverMenu(int showScore)
		{
			// Tømmer skjermen før teksten kommer
			Console.Clear();
			// Setter utgangspunk for teksten som skal komme
			Console.SetCursorPosition(1, 1);
			// Skriver ut highscore og litt tekst

			Console.Write("\tHighScore: " + Game.LastHighscore + "\t\tScore: " + showScore);
			Console.Write("\n\n\tYou lost lol\n\n\tTry again? y/n\n\n\t");
		}

		/*		HighScore		*/
		private static void checkForHighScore()
		{
			// Sjekker om forrige highscore er større en nåværende score.
			// Om nåværende score er høyere, så vil den erstatte highscore
			if (SnakeGame.ShowScore > Game.LastHighscore)
			{
				// Kilder:
				//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
				File.WriteAllText(@"..\..\score.txt", "" + SnakeGame.ShowScore);
				Game.LastHighscore = SnakeGame.ShowScore;
			}
		}
    }
}
