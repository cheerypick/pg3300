using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class Pellet {
	    private int X { get; set; }
	    private int Y { get; set; }
     
        private Coord pelletCoord; 

        // Constructor
        public Pellet(int x, int y) {
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
                X = random.Next(0, boardW);
                Y = random.Next(0, boardH);

                // This made itself, rofl, idk. Kinda makes sense
                var foundSpot = snake.GetCoords().All(coord => X != coord.X || Y != coord.Y);

                // Place if spot is safe, place pellet
                if (foundSpot) {
                    Board.DrawPellet(new Coord(X,Y));
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
