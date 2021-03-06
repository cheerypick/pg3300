﻿using System;
using System.Linq;

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
            return (snake.GetNewHead().X == pelletCoord.X && snake.GetNewHead().Y == pelletCoord.Y);
        }


        // Place new pellet
        public void placePellet(Snake snake, int boardH, int boardW) {
            var random = new Random();

            // Try to place in a new spot
            while (true) {
                X = random.Next(1, boardW - 1);
                Y = random.Next(4, boardH - 1);

                // This made itself, rofl, idk. Kinda makes sense
                var foundSpot = snake.getCoords().All(coord => X != coord.X || Y != coord.Y);

                // Place if spot is safe, place pellet
                if (!foundSpot) continue;
                ScreenHandler.DrawPellet(new Coord(X,Y));
                pelletCoord = new Coord(X, Y);
                break;
            }
        }

        // u get the idea
        public Coord GetCoords() {
            return pelletCoord;
        }
    }

}
