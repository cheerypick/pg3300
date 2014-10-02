using System;

// This handles output

namespace SnakeMess
{
	internal class ScreenHandler
	{
		// Method for preparing
		public void WriteStartUp()
		{
			Console.CursorVisible = false; // Dont want to see the cursor
			Console.ForegroundColor = ConsoleColor.Green; // Console color
			Console.SetCursorPosition(10, 10); // Set start poisition
		}

		// Update screen
		public void UpdateScreen(Snake snake, Pellet pellet, Coord newHead)
		{

			// Write over head
			Console.SetCursorPosition(snake.GetHead().X, snake.GetHead().Y);
			Console.Write("O");

			// If snake is not growing, write over tail
			if (!snake.Grow)
			{
				Console.SetCursorPosition(snake.GetTail().X, snake.GetTail().Y);
				Console.Write(" ");
				snake.GetCoords().RemoveAt(0);
			}

			// Add new head to snake 
			snake.GetCoords().Add(newHead);
			Console.SetCursorPosition(newHead.X, newHead.Y);
			Console.Write("@");

			snake.Grow = false;
		}


		// Get height of screen
		public int GetHeight()
		{
			return Console.WindowHeight;
		}

		// Get width of screen
		public int GetWidth()
		{
			return Console.WindowWidth;
		}

		// Draw pellet
		public static void DrawPellet(Coord coord)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(coord.X, coord.Y);
			Console.Write("$");
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}
