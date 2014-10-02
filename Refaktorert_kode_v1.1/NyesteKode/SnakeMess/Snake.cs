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
        private List<Coordinate> snakeBody;

        // Coords for head and new Head
        private Coordinate head, newHead;

        // Boolean for letting snake grow
        public bool grow;

        // Constructor
        public Snake() {
            snakeBody = new List<Coordinate>();
            grow = true;
        }

        // Setdirection. Catches bad input
        public void setDirection(int newDir) {
                direction = newDir;
        }

        // Add bodies to snake
        public void addBody(int bodies, int xPosition, int yPosition) {
            for (int i = 0; i < bodies; i++) {
                snakeBody.Add(new Coordinate(xPosition, yPosition));
            }
        }

        // Return snakes coords
        public List<Coordinate> getCoords() {
            return snakeBody;
        }

        // BJ lulz
        public Coordinate getHead() {
            return snakeBody.Last();
        }

        // Get tail, is this even used?
        public Coordinate getTail() {
            return snakeBody.First();
        }

        // Check if snake has sniffed fuel
        public Boolean CheckSelfCannibalism(InputReader gm, Coordinate newHead) {
            return getCoords().Any(x => x.X == newHead.X && x.Y == newHead.Y);
        }

        // Method for adding new head to the right side and direction of snake
        public Coordinate GetNewHead() {
            // Get head
            return NewHead.GetNewHead(snakeBody.Last(), direction);

        }

        // Check if head is colliding
        public bool CheckBoardCollision(List<Coordinate> boardList ) {
            foreach (Coordinate borderCoord in boardList)
                if (borderCoord.Equals(newHead)) return true;
            return false;
        }

        
    }
}
