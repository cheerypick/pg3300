using System;

namespace SnakeMess
{
	public enum Command
	{
		Up = 0,
		Right,
		Down,
		Left,
		Escape,
		Pause
	}
	// Game master is master of gamez
	public class GameMaster
	{
		private ConsoleKeyInfo _inputKey;
		private Boolean gameOver;

		// Method for reading keys
		public Command ReadKeys(Command lastDirection)
		{
			// If key is pressed, read it
			if (Console.KeyAvailable)
				_inputKey = Console.ReadKey(true);


			// Return diffrent ints for different inputs from different keys, different
			switch (_inputKey.Key)
			{
				case ConsoleKey.Escape: // THIS IS FOR ESCAPE DO NOT REMOVE ME
					return Command.Escape;;
				case ConsoleKey.Spacebar:
					return Command.Pause;
				case ConsoleKey.UpArrow: // 0
					return lastDirection != Command.Up ? Command.Up : lastDirection;

				case ConsoleKey.RightArrow: // 1
					return lastDirection != Command.Right ? Command.Right : lastDirection;

				case ConsoleKey.DownArrow: // 2
					return lastDirection != Command.Down ? Command.Down : lastDirection;

				case ConsoleKey.LeftArrow: // 3
					return lastDirection != Command.Left ? Command.Left : lastDirection;

				default:
					return lastDirection;
			}
		}

		// Set game over
		public void setGameOver(Boolean gameState)
		{
			gameOver = gameState;
			//Environment.Exit(1); // FOR EXITING GAME
		}

		public bool getGameOver()
		{
			return gameOver;
		}
	}
}