﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// This handles output

namespace SnakeMess {
    internal class ScreenHandler {

        // Method for preparing
        public void WriteStartUp() {
            Console.CursorVisible = false; // Dont want to see the cursor
            Console.ForegroundColor = ConsoleColor.Green; // Console color
            Console.SetCursorPosition(10, 10); // Set start poisition
        }

        // Update screen
        public void updateScreen(Snake snake, pellet pellet, Coord newHead) {

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

        public static void DrawMenu(int showScore){
            // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
			Console.Write("\tHighScore: " + Game.LastHighscore);
            Console.Write("\tScore: " + showScore  + "\n\n");
            Console.Write("\tGame Over\n\n\tTry again? y/n\n\n\t");
        }

        public void DrawScore(int showScore)
        {
            // Viser score på skjermen
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            Console.Write("\tHighScore: " + Game.LastHighscore + "\t\tScore: " + showScore);
        }
    }
}
