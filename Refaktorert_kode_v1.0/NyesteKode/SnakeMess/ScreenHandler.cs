using System;

// This handles output

namespace SnakeMess {
    internal class ScreenHandler  {
		// Blir brukt til å telle opp til 3 da du spiser en special pellet.
		private int _count = 0;
        // Method for preparing
        public void WriteStartUp() {
            Console.CursorVisible = false; // Dont want to see the cursor
            Console.ForegroundColor = ConsoleColor.Green; // Console color
            Console.SetCursorPosition(10, 10); // Set start poisition
        }

        // Update screen
        public void UpdateScreen(Snake snake, Pellet pellet, Coord newHead) {

            // Write over head
            Console.SetCursorPosition(snake.getHead().X, snake.getHead().Y);
            Console.Write("O");
            
            // If snake is not growing, write over tail
            if (!snake.grow) {
                Console.SetCursorPosition(snake.getTail().X, snake.getTail().Y);
                Console.Write(" ");
                snake.getCoords().RemoveAt(0);
            }

            // Add new head to snake 
            snake.getCoords().Add(newHead);
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            // Finner ut om snake har spist en normal eller special pellet.
			// Skal vokse 2 om den spiser special og 1 om den spiser normal.
	        if (GameEngine.SpecialPelletExtraGrow)
	        {
		        _count++;
				if (_count == GameEngine.SpecialPelletNumber)	// Vokser 3 ganger når du spiser en special pellet, pga du får 3 poeng for hver special pellet.
		        {
			        _count = 0;
					snake.grow = false;
					GameEngine.SpecialPelletExtraGrow = false;
		        }
			}
				// Viss du spiser vanlig pellet, så slutter snake å vokse etter 1 runde med voksing.
			else if (GameEngine.SpecialPelletExtraGrow == false)
			{
				snake.grow = false;
			}
        }


        // smoke some weed
        public int GetHeight() {
            return Console.WindowHeight;
        }

        // .. and eat a burga
        public int GetWidth() {
            return Console.WindowWidth;
        }

		// Tegner vanlig Pellet
        public static void DrawPellet(Coord coord){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Green;
        }


		// Tegner special Pellet
		public static void DrawSpecialPellet(Coord coord)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(coord.X, coord.Y);
			Console.Write("#");
			Console.ForegroundColor = ConsoleColor.Green;
		}
    }
}
