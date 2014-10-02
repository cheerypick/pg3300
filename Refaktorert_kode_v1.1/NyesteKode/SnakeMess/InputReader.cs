using System;

namespace SnakeMess
{
	// Game master is master of gamez
	public class InputReader
	{
		private ConsoleKeyInfo _inputKey;

		// Method for reading keys
		public int ReadKeys(int lastDirection, GameEngine gameEngine)
		{
			// If key is pressed, read it
			if (Console.KeyAvailable)
			{
				_inputKey = Console.ReadKey(true);
				if (_inputKey.Key == ConsoleKey.Spacebar) gameEngine.isPaused = !gameEngine.isPaused;
				Console.CursorVisible = false; // Dont want to see the cursor
			}

			// Return diffrent ints for different inputs from different keys, different
			switch (_inputKey.Key)
			{
				case ConsoleKey.Escape: // THIS IS FOR ESCAPE DO NOT REMOVE ME
					Environment.Exit(1);
					return lastDirection;
				case ConsoleKey.UpArrow: // 0
					return lastDirection != 2 ? 0 : lastDirection;

				case ConsoleKey.RightArrow: // 1
					return lastDirection != 3 ? 1 : lastDirection;

				case ConsoleKey.DownArrow: // 2
					return lastDirection != 0 ? 2 : lastDirection;

				case ConsoleKey.LeftArrow: // 3
					return lastDirection != 1 ? 3 : lastDirection;

				default:
					return lastDirection;
			}
		}
	}
}