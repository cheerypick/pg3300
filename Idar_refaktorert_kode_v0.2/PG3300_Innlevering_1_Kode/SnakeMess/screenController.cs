using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*
 * VERY VERSION ALPHA PLZ HANDLE WITH CARE THANK YOU
 */

namespace SnakeMess {
    internal class screenController {

        public void writeStartUp() {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
        }

        public void updateScreen(Snake snake, pellet pellet, Coord newHead) {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.getHead().X, snake.getHead().Y);
            Console.Write("O");


            Console.SetCursorPosition(snake.getTail().X, snake.getTail().Y);
            if (!snake.grow) {
                Console.Write(" ");
                snake.getCoords().RemoveAt(0);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(pellet.GetCoords().X, pellet.GetCoords().Y);
            Console.Write("$");


            snake.getCoords().Add(newHead);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            snake.grow = false;

        }


        public int getHeight() {
            return Console.WindowHeight;
        }

        public int getWidth() {
            return Console.WindowWidth;
        }
    }
}
