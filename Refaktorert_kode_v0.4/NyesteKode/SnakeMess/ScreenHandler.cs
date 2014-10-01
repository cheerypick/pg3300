using System;

// This handles output

namespace SnakeMess {
    internal class ScreenHandler  {

        // Method for preparing
        public void WriteStartUp() {
            Console.CursorVisible = false; // Dont want to see the cursor
            Console.ForegroundColor = ConsoleColor.Green; // Console color
            Console.SetCursorPosition(10, 10); // Set start poisition
        }

        // Update screen
        public void UpdateScreen(Snake snake, pellet pellet, Coord newHead) {

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

            // dont grow after 1 grow update
            snake.grow = false;
        }


        // smoke some weed
        public int GetHeight() {
            return Console.WindowHeight;
        }

        // .. and eat a burga
        public int GetWidth() {
            return Console.WindowWidth;
        }

        public static void DrawPellet(Coord coord){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Green;
        }




    }
}
