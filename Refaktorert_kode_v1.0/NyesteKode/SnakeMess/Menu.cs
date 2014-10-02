using System;
using System.IO;

namespace SnakeMess {
    class Menu {


		/*		Menyen før gamet starter		*/
	    public static void GameStartMenu() {
		    
			Console.Write("\n\t\t*********** Snake spill of Doom ********\n\t\tSpille lol?\n\n\t\t");
		    String input = Console.ReadLine();
            Console.Clear();
		    
			// Sjekker om bruker vil spille
			 if (input != null && input.Equals("n")){
				Game.RunGame = false;
			}
             else if (input != null && input.Equals("y"))
             {

				 Game.RunGame = true;
             }
             else
             {
	             GameStartMenu();
             }
	    }

       
		/*		Score og Game Over meny		*/

		// Score som blir vist in-game
		public static void DrawInGameScore(int showScore, int level){
			// Viser score på skjermen
			Console.SetCursorPosition(1, 1);
			// Skriver ut highscore og litt tekst
			Console.Write("\tHighScore: {0}\t\tScore: {1}\t\tLevel: {2}", Game.LastHighscore, showScore, level);
		}

		// Menyen som kommer når det blir gameover
		public static bool GameOverMenu(GameEngine snake)
		{
			// Sjekker først om det ble ny highscore
			CheckForHighScore();

			// Tegner menyen som kommer når det er gameover
			DrawGameOverMenu(GameEngine.Score);

			// Tar imot input, og gjør det bruker sier.
			String input = Console.ReadLine();
			if (input != null && input.Equals("y"))
			{
				Console.Clear();
				// Må resette score for hver runde.
				GameEngine.Score = 0;
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
		private static void CheckForHighScore()
		{
			// Sjekker om forrige highscore er større en nåværende score.
			// Om nåværende score er høyere, så vil den erstatte highscore
			if (GameEngine.Score > Game.LastHighscore)
			{
				// Kilder:
				//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
				File.WriteAllText(@"..\..\score.txt", "" + GameEngine.Score);
				Game.LastHighscore = GameEngine.Score;
			}
		}
    }
}
