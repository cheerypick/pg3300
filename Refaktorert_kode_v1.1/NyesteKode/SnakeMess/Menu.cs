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
			    if (input == null) continue;
			    switch (input.ToLower())
			    {
				    case "x": //Exit
				    {
					    Game.RunGame = false;
					    Environment.Exit(1);
					    continue;
				    }
				    case "p" : //Play
				    { 
					    Game.RunGame = true;
						break;
				    }

				    case "h": //Highscore
					{
						MessageBox.Show("Highscore: " + Game.LastHighscore.ToString());
						continue;
					}

				    case "r": //Rules
				    {
					    Console.Clear();
					    Game.RunGame = false;
					    MessageBox.Show(
						"Use arrows to move snake. \nSpecial pellet appears randomly and gives random point amount. \nSpeed increases each level.");
					    GameStartMenu();
					    continue;
				    }
				    case "a": //About
				    {
					    MessageBox.Show(
						 "Westerdals Snake. \nCreated by Kim Frode Flaethe, Idar Tjomstøl Vassdal, Katrine Orlova\n(c)2014");
					    GameStartMenu();
				    }
					    break;
				    default: continue;
				} break;

		    }

	    }


	    /*		Score  Game Over meny		*/

		// Score som blir vist in-game
		public static void DrawInGameScore(int showScore, int level){
			Console.SetCursorPosition(1, 1);
			Console.Write("\tHighScore: {0}\t\tScore: {1}\t\tLevel: {2} ", Game.LastHighscore, showScore, level);
		}

		// Game Over Menu
	    public static void GameOver(GameEngine snake)
	    {
		   		CheckForHighScore();
			    MessageBox.Show("You lost. Your score: " + GameEngine.Score + "\n Highscore: " + Game.LastHighscore);
				Console.Clear();
			    GameStartMenu();
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
