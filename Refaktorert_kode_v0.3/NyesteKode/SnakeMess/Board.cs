using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// This handles output

namespace SnakeMess {
    internal class Board {

        // Method for preparing
        public void InitialState() {
            Console.CursorVisible = false; // Dont want to see the cursor
            Console.ForegroundColor = ConsoleColor.Green; // Console color
            Console.SetCursorPosition(10, 10); // Set start poisition
        }

        // Update screen
        public void updateScreen(Snake snake, Pellet pellet, Coord newHead) {

            // Write over head
            Console.SetCursorPosition(snake.GetHead().X, snake.GetHead().Y);
            Console.Write("O");
            
            // If snake is not growing, write over tail
            if (!snake.Grow) {
                Console.SetCursorPosition(snake.GetTail().X, snake.GetTail().Y);
                Console.Write(" ");
                snake.GetCoords().RemoveAt(0);
            }

            // Add new head to snake 
            snake.GetCoords().Add(newHead);
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            // dont grow after 1 grow update
            snake.Grow = false;
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
