﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

/*
 * VERY VERSION ALPHA PLZ HANDLE WITH CARE THANK YOU
 */

namespace SnakeMess
{
    internal class screenController
    {

        private int lastDir = 2;

        public void writeStartUp(){
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
        }

        public void updateScreen(Snake snake, pellet pellet, Coord newHead, int newDir) {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snake.getHead().X, snake.getHead().Y);
            Console.Write("O");

            if (snake.grow != true) {
                snake.getCoords().RemoveAt(0);
                Console.SetCursorPosition(snake.getTail().X, snake.getTail().Y);
                Console.Write(" ");
                
            }
            else{
                snake.getCoords().Add(newHead);
                Console.SetCursorPosition(snake.getTail().X, snake.getTail().Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("0");
                snake.grow = false;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(pellet.GetCoords().X, pellet.GetCoords().Y);
            Console.Write("$");

            
            snake.getCoords().Add(newHead);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");

            lastDir = newDir;
        }


        public int getHeight(){
            return Console.WindowHeight;
        }

        public int getWidth(){
            return Console.WindowWidth;
        }
    }
}