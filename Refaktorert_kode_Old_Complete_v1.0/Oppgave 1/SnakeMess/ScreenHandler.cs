using System;

// This handles output

namespace SnakeMess
{
	internal class ScreenHandler
	{
		// Update screen
		public void UpdateScreen(Snake snake, Pellet pellet, Coordinate newHead)
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

			// Make sure the snake can only grow by one each time.
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
		public static void DrawPellet(Coordinate coordinate)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(coordinate.X, coordinate.Y);
			Console.Write("$");
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}
