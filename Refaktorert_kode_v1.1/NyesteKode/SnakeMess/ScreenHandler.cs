// This handles output
using System;

namespace SnakeNotMess{
	internal class ScreenHandler{

		// Used for counting to 3 when you eat a special pellet.
		private int _count;

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

			// Find out if you ate a normal or a special pellet.
			// Will grow 3 if special, and 1 if normal.
			if (GameEngine.SpecialPelletExtraGrow)
			{
				_count++;
				if (_count == GameEngine.SpecialPelletNumber)
					// Snake grow by 3 when you eat a special pellet. Its the same as the amout of point it gives.
				{
					_count = 0;
					snake.Grow = false;
					GameEngine.SpecialPelletExtraGrow = false;
				}
			}
				// If you eat a normal pellet, then the snake will grow only by 1.
			else if (GameEngine.SpecialPelletExtraGrow == false)
			{
				snake.Grow = false;
			}
		}


		public int GetHeight()
		{
			return Console.WindowHeight;
		}

		public int GetWidth()
		{
			return Console.WindowWidth;
		}

		// Draw normal pellet
		public static void DrawPellet(Coordinate coordinate)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(coordinate.X, coordinate.Y);
			Console.Write("$");
			Console.ForegroundColor = ConsoleColor.Green;
		}


		// Draw special pellet
		public static void DrawSpecialPellet(Coordinate coordinate)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(coordinate.X, coordinate.Y);
			Console.Write("#");
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}