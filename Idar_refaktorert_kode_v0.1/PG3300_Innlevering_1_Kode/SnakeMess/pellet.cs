using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class pellet{
        private int X, Y;
        private Coord pelletCoord;

        public pellet(int x, int y){
            this.X = x;
            this.Y = y;
            pelletCoord = new Coord(x, y);
        }

        public Boolean checkIfEatingPellet(Coord newHead) {
            if (newHead.Equals(GetCoords())) {
                return true;
            }
            return false;

        }

        

        public void placePellet(Snake snake, int boardH, int boardW){
            Random random = new Random();
            snake.grow = true;
            while (true) {
                X = random.Next(0, boardW);
                Y = random.Next(0, boardH);

                bool foundSpot = true;

                foreach (Coord coord in snake.getCoords())
                    if (X == coord.X && Y == coord.Y) {
                        foundSpot = false;
                        break;
                    }
                if (foundSpot) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(X, Y);          // ????
                    Console.Write("$");
                    break;
                }
            }
        }

        public Coord GetCoords(){
            return pelletCoord;
        }
    }

       /* private void checkIfFull(Snake snake, int boardW, int boardH) {
            if (snake.getCoords().Equals(pelletCoord)){
						if ( snake.getCoords().Count + 1 >= boardW * boardH )
							// No more room to place apples -- game over.
							gg = true;
            }
        }*/
    
}
