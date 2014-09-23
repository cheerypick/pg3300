using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    public class Snake {


        // private Direction direction; ** FIX PLZ **
        private int direction;
        private List<Coord> snakeBody;
        private Coord tail, head, newHead;
        public bool grow;

        public Snake() {
            snakeBody = new List<Coord>();
            grow = false;
            //direction = new Direction();
        }

        public void setDirection(int newDir) {
            direction = newDir;
        }

        public void addBody(int bodies, int xPosition, int yPosition) {
            for (int i = 0; i < bodies; i++) {
                snakeBody.Add(new Coord(xPosition, yPosition));
            }
        }

        public List<Coord> getCoords() {
            return snakeBody;
        }

        

        public Coord getHead() {
            return snakeBody.Last();
        }

        public Coord getTail() {
            return (Coord) snakeBody.First();
        }

        public void checkSelfCannibalism(GameMaster gm, Coord newHead) {

            foreach (Coord x in getCoords())
                if (x.X == newHead.X && x.Y == newHead.Y) {
                    // Death by accidental self-cannibalism.
                    gm.setGameOver(true);
                    break;
                }

        }

        public Coord getNewHead() {
            tail = new Coord(snakeBody.First());
            head = new Coord(snakeBody.Last());
            newHead = new Coord(head);

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

        public bool checkBoardCollision(int boardH, int boardW) {
            if (newHead.X < 0 || newHead.X >= boardW || newHead.Y < 0 || newHead.Y >= boardH)
                return true;
            return false;
        }
    }
}
