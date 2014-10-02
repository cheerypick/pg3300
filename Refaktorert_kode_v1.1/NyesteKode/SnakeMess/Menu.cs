using System;
using System.IO;
using  System.Windows.Forms;

namespace SnakeMess {
    class Menu {



	    public static void GameStartMenu()
	    {
		    while (true)
		    {
			    Console.ForegroundColor = ConsoleColor.White;
			    Console.SetCursorPosition(15, 5);
			    Console.Write("Welcome to Snake Game. It's not messy anymore. At all.\n");
			    Console.SetCursorPosition(25, 7);
			    Console.WriteLine("Press P to {Play}");
			    Console.SetCursorPosition(25, 8);
			    Console.WriteLine("Press X to {Exit}");
			    Console.SetCursorPosition(25, 9);
			    Console.WriteLine("Press H to see {Highscore}");
			    Console.SetCursorPosition(25, 10);
				Console.WriteLine("Press R to read {Rules}");
				Console.SetCursorPosition(25, 11);
				Console.WriteLine("Press A to read {About}");
				Console.SetCursorPosition(25, 12);


			    String input = Console.ReadLine();
			    Console.Clear();

				//Exit
			    if (string.Equals(input, "X", StringComparison.OrdinalIgnoreCase))
			    {
				    Game.RunGame = false;
					Environment.Exit(1);
			    }

				//Play
			    else if (string.Equals(input, "P", StringComparison.OrdinalIgnoreCase))
			    {
				    Game.RunGame = true;
			    }

				//See Highscore
			    else if (string.Equals(input, "H", StringComparison.OrdinalIgnoreCase))
			    {
				    MessageBox.Show("Highscore: " + Game.LastHighscore.ToString());
				    continue;
			    }

				//Read Rules
				else if (string.Equals(input, "R", StringComparison.OrdinalIgnoreCase))
				{
					Console.Clear();
					Game.RunGame = false;
					MessageBox.Show(
						"Use arrows to move snake. \n Special pellet appears randomly and gives random point amount. \nSpeed increases each level.");
					GameStartMenu();
				}

				else if (string.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
				{
					Game.RunGame = false;
					MessageBox.Show(
						"Westerdals Snake. \nCreated by Kim Frode Flaethe, Idar Tjomstøl Vassdal, Katrine Orlova\n(c)2014");
					GameStartMenu();
				}

			    else
			    {
				    continue;
			    }
			    break;
		    }
	    }


	    /*		Score  Game Over meny		*/

		// Score som blir vist in-game
		public static void DrawInGameScore(int showScore, int level){
			Console.SetCursorPosition(1, 1);
			Console.Write("\tHighScore: {0}\t\tScore: {1}\t\tLevel: {2} ", Game.LastHighscore, showScore, level);
		}

		// Game Over Menu
	    public static bool GameOver(GameEngine snake)
	    {
		    while (true)
		    {
			    // Checks if High
			    CheckForHighScore();
			    MessageBox.Show("You lost. Your score: " + GameEngine.Score + "\n Highscore: " + Game.LastHighscore);

			    // Tegner menyen som kommer når det er gameover
			    Console.Clear();
			    GameStartMenu();
		    }
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
