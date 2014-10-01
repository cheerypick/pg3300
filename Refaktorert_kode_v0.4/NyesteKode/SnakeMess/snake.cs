using System;
using System.Collections.Generic;
using System.Linq;

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
        public Boolean CheckSelfCannibalism(InputReader gm, Coord newHead) {
            return getCoords().Any(x => x.X == newHead.X && x.Y == newHead.Y);
        }

        // Method for adding new head to the right side and direction of snake
        public Coord GetNewHead() {
            // Get head
            head = new Coord(snakeBody.Last());
            // Set new head as head
            newHead = new Coord(head);

            // Where head is created is decided by direction
            switch (direction) {
                case 0:
                    newHead.Y -= 1; // Move down
                    break;
                case 1:
                    newHead.X += 1; // Right
                    break;
                case 2:
                    newHead.Y += 1; // Up
                    break;
                case 3: 
                    newHead.X -= 1; // Left
                    break;
            }
            return newHead;

        }

        // Check if head is colliding
        public bool CheckBoardCollision(List<Coord> boardList ) {
            foreach (Coord borderCoord in boardList)
                if (borderCoord.Equals(newHead)) return true;
            return false;
        }

        
    }
}
