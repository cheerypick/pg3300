using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class pellet {
        private int X, Y; // Coordinates, these may be removed
        private Coord pelletCoord; // Real coordinates

        // Constructor
        public pellet(int x, int y) {
            X = x;
            Y = y;
            pelletCoord = new Coord(x, y);
        }

        // Check if snake is eating pellet
        public Boolean checkIfEatingPellet(Snake snake) {
            return (snake.getNewHead().X == pelletCoord.X && snake.getNewHead().Y == pelletCoord.Y);
        }


        // Place new pellet
        public void placePellet(Snake snake, int boardH, int boardW) {
            var random = new Random();

            // Set snake to grow if a pellet is being placed. I recommend moving this
            snake.grow = true;

            // Try to place in a new spot
            while (true) {
                X = random.Next(0, boardW);
                Y = random.Next(0, boardH);

                // This made itself, rofl, idk. Kinda makes sense
                var foundSpot = snake.getCoords().All(coord => X != coord.X || Y != coord.Y);

                // Place if spot is safe, place pellet
                if (foundSpot) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(X, Y);          // ????
                    Console.Write("$");
                    pelletCoord = new Coord(X, Y);
                    break;
                }
            }
        }

        // u get the idea
        public Coord GetCoords() {
            return pelletCoord;
        }
    }

}
