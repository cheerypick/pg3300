using System;
using System.IO;

namespace SnakeMess
{
	internal class Game
	{
		//	public static bool runGame = true;
		// Henter fila med highscore.
		private static readonly string _getHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
		public static bool RunGame { get; set; }
		// Score player har nå.
		public static int LastHighscore { get; set; }

		public static void Main(string[] arguments)
		{
			// Oppgave 1
			//     OriginalGame game = new OriginalGame();
			//     game.runOriginlGame();


			//	 Oppgave 2

			LastHighscore = Convert.ToInt32(_getHighscoreFromFile);
			// Starter det første spillet
			RunGame = true;
			Menu.GameStartMenu();

			while (RunGame)
			{
				var gameEngine = new GameEngine();
				gameEngine.RunGame();
				RunGame = Menu.GameOver(gameEngine);
			}
		}
	}
}