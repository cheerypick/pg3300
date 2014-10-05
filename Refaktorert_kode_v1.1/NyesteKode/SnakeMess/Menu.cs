using System;
using System.IO;
using System.Windows.Forms;

namespace SnakeNotMess{
	
	// Class the keeps control of the menus
	internal class Menu{
		public static void GameStartMenu()	{
			while (true){
				//Write start menu
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

				//Reads user input
				string input = Console.ReadLine();
				Console.Clear();

				//Ignore null input issues
				if (input == null) continue;
				switch (input.ToLower()){
                        // Exit
					case "x": {
						Game.RunGame = false;
						Environment.Exit(1);
						continue;
					}
                    //Play
					case "p": {
						Game.RunGame = true;
						break;
					}
                    //Highscore
					case "h": {
						MessageBox.Show("Highscore: " + Game.LastHighscore);
						continue;
					}
                    //Rules
					case "r": {
						Console.Clear();
						Game.RunGame = false;
						MessageBox.Show(
							"Use arrows to move snake. \nSpecial pellet appears randomly and gives 3 points. \nSpeed increases each level.");
						continue;
					}
                    //About
					case "a": {
						MessageBox.Show(
							"Westerdals Snake. \nCreated by Kim Frode Flaethe, Idar Tjomstøl Vassdal, Katrine Orlova\n(c)2014");
					}
						break;
					default:
						continue;
				}
				break;
			}
		}

		// Panel with score, highscore and level
		public static void UpperScorePanel(int showScore, int level)
		{
			Console.SetCursorPosition(1, 1);
			Console.Write("\tHighScore: {0}\t\tScore: {1}\t\tLevel: {2} ", Game.LastHighscore, showScore, level);
		}

		// Game Over Method
		public static void GameOver(GameEngine snake)
		{
			CheckForHighScore();
			MessageBox.Show("You lost. Your score: " + GameEngine.Score + "\n Highscore: " + Game.LastHighscore);
			Console.Clear();
			GameStartMenu();
		}


		//HighScore		
		private static void CheckForHighScore()
		{
			//Checks if current score is bigger than highscore, if so, replaces it
			if (GameEngine.Score <= Game.LastHighscore) return;
			File.WriteAllText(@"..\..\score.txt", "" + GameEngine.Score);
			Game.LastHighscore = GameEngine.Score;
		}
	}
}