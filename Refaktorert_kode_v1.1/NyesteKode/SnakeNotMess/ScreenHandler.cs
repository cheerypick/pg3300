// This handles output
using System;

namespace SnakeNotMess
{
	internal class ScreenHandler
	{
		// Blir brukt til å telle opp til 3 da du spiser en special pellet.
		private int _count;
		// Method for preparing
		public void WriteStartUp()
		{
			Console.CursorVisible = false; // Dont want to see the cursor
			Console.ForegroundColor = ConsoleColor.Green; // Console color
			Console.SetCursorPosition(10, 10); // Set start poisition
		}

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

			// Finner ut om snake har spist en normal eller special pellet.
			// Skal vokse 2 om den spiser special og 1 om den spiser normal.
			if (GameEngine.SpecialPelletExtraGrow)
			{
				_count++;
				if (_count == GameEngine.SpecialPelletNumber)
					// Vokser 3 ganger når du spiser en special pellet, pga du får 3 poeng for hver special pellet.
				{
					_count = 0;
					snake.Grow = false;
					GameEngine.SpecialPelletExtraGrow = false;
				}
			}
				// Viss du spiser vanlig pellet, så slutter snake å vokse etter 1 runde med voksing.
			else if (GameEngine.SpecialPelletExtraGrow == false)
			{
				snake.Grow = false;
			}
		}


		// smoke some weed
		public int GetHeight()
		{
			return Console.WindowHeight;
		}

		// .. and eat a burga
		public int GetWidth()
		{
			return Console.WindowWidth;
		}

		// Tegner vanlig Pellet
		public static void DrawPellet(Coordinate coordinate)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(coordinate.X, coordinate.Y);
			Console.Write("$");
			Console.ForegroundColor = ConsoleColor.Green;
		}


		// Tegner special Pellet
		public static void DrawSpecialPellet(Coordinate coordinate)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(coordinate.X, coordinate.Y);
			Console.Write("#");
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}