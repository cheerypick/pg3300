using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// This handles output

namespace SnakeMess {
    internal class screenController {

        // Method for preparing
        public void writeStartUp() {
            Console.CursorVisible = false; // Can u see the cursor?
            Console.ForegroundColor = ConsoleColor.Green; // Green colorz 420
            Console.SetCursorPosition(10, 10); // Set start poisition
            //Console.Write("@");// Write head
        }

        // Update screen
        public void updateScreen(Snake snake, pellet pellet, Coord newHead) {

            // Write a "body-0" where head was last update
            //Console.ForegroundColor = ConsoleColor.Green;
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
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            // dont grow after 1 grow update
            snake.grow = false;
        }

        // smoke some weed
        public int getHeight() {
            return Console.WindowHeight;
        }

        // .. and eat a burga
        public int getWidth() {
            return Console.WindowWidth;
        }

        public static void drawPellet(Coord coord){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
