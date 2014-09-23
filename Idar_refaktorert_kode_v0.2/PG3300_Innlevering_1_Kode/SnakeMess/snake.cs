using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    // TSSSSSSSSSSZZZZZZZZZ
    public class Snake {


        // Direction
        private int direction;

        // Snake body
        private List<Coord> snakeBody;

        // Coords for head and new Head
        private Coord head, newHead;

        // Boolean for letting snake grow
        public bool grow;

        // Constructor
        public Snake() {
            snakeBody = new List<Coord>();
            grow = true;
        }

        // Setdirection. Catches bad input
        public void setDirection(int newDir) {
            if(newDir != -1)
             direction = newDir;
        }

        // Add bodies to snake
        public void addBody(int bodies, int xPosition, int yPosition) {
            for (int i = 0; i < bodies; i++) {
                snakeBody.Add(new Coord(xPosition, yPosition));
            }
        }

        // Return snakes coords
        public List<Coord> getCoords() {
            return snakeBody;
        }

        // BJ lulz
        public Coord getHead() {
            return snakeBody.Last();
        }

        // Get tail, is this even used?
        public Coord getTail() {
            return snakeBody.First();
        }

        // Check if snake has sniffed fuel
        public void checkSelfCannibalism(GameMaster gm, Coord newHead) {

            foreach (Coord x in getCoords())
                if (x.X == newHead.X && x.Y == newHead.Y) {
                    // Death by accidental self-cannibalism.
                    gm.setGameOver(true);
                    break;
                }

        }

        // Method for adding new head to the right side and direction of snake
        public Coord getNewHead() {
            // Get head
            head = new Coord(snakeBody.Last());
            // Set new head as head
            newHead = new Coord(head);

            // Where head is created is decided by direction
            switch (direction) {
                case 0:
                    newHead.Y -= 1;
                    break;
                case 1:
                    newHead.X += 1;
                    break;
                case 2:
                    newHead.Y += 1;
                    break;
                // case 3:
                default:
                    newHead.X -= 1;
                    break;
            }

            return newHead;

        }

        // Check if head is colliding
        public bool checkBoardCollision(int boardH, int boardW) {
            return (newHead.X < 0 || newHead.X >= boardW || newHead.Y < 0 || newHead.Y >= boardH);
        }
    }
}
