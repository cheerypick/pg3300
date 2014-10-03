using System;
using System.IO;

namespace SnakeMess
{
	internal class Game
	{
		// Get highscore
		private static readonly string GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
		public static bool RunGame { get; set; }
		public static int LastHighscore { get; set; }

		public static void Main(string[] arguments)
		{
			// Oppgave 1
			//     OriginalGame game = new OriginalGame();
			//     game.runOriginlGame();


			//	 Oppgave 2

			LastHighscore = Convert.ToInt32(GetHighscoreFromFile);
			// Starter det første spillet
			RunGame = true;
			Menu.GameStartMenu();

			while (RunGame)
			{
				var gameEngine = new GameEngine();
				gameEngine.RunGame();
				Menu.GameOver(gameEngine);
			}
		}
	}
}