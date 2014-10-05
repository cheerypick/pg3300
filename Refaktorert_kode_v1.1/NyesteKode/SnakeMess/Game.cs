using System;
using System.IO;

namespace SnakeNotMess{

    // This is a before-game-starts class, similar to a launcher.

	internal class Game{
		// Get highscore
		private static readonly string GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
		public static bool RunGame { get; set; }
		public static int LastHighscore { get; set; }

		public static void Main(string[] arguments){
			//Convert highscore String from file to Int
			LastHighscore = Convert.ToInt32(GetHighscoreFromFile);
			// Starts first game
			RunGame = true;
			Menu.GameStartMenu();

            // Keep running 
			while (RunGame){
				var gameEngine = new GameEngine();
				gameEngine.RunGame();
				Menu.GameOver(gameEngine);
			}
		}
	}
}