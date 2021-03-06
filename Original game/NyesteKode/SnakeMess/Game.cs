﻿using System;
using System.IO;

namespace SnakeNotMess
{
	internal class Game
	{
		// Get highscore
		private static readonly string GetHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
		public static bool RunGame { get; set; }
		public static int LastHighscore { get; set; }

		public static void Main(string[] arguments)
		{
			//Convert highscore String from file to Int
			LastHighscore = Convert.ToInt32(GetHighscoreFromFile);
			// Starts first game
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