using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

using System.Threading;

namespace SnakeMess {

    internal class SnakeGame {
        private screenController screen;
        private GameMaster gm;
        private int lastDirectionMoved, newDir, boardW, boardH;
        private Snake snake;
        private pellet pellet;
        private Stopwatch timer;
        private Boolean runGame;


        public SnakeGame() {
            ShowScore = 0;
            // Boolean for running the game
            runGame = true;

            // Gamemaster
            gm = new GameMaster();

            // Screen (output handler)
            screen = new screenController();

            // Get width and height from screen handler
            boardW = screen.getWidth();
            boardH = screen.getHeight();

            // Create snake
            snake = new Snake();

            // And pellet (Katrine: food)
            pellet = new pellet(0, 0);

            // Add 4 bodies to snake
            snake.addBody(4, 10, 10);

            // place pellet in world
            pellet.placePellet(snake, boardH, boardW);

            // Create a stopwatch for thread-waiting
            timer = new Stopwatch();
            timer.Start();
        }
        // Skal være static method
        public static int ShowScore { get; set; }

        StreamWriter writer = new StreamWriter("test.txt");
        public void RunGame() {

            // Running the game
            while (runGame) {
                // Change direction if key is pressed
                newDir = gm.ReadKeys(lastDirectionMoved);
                // Set direction of snake
                snake.setDirection(newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (newDir != 5) {
                    // Wait 100 millis
                    if (timer.ElapsedMilliseconds < 100) {
                        continue;
                    }
                    // Restart counter
                    timer.Restart();

                    // Get new snakehead
                    var newHead = snake.getNewHead();

                    // Check if snake is eating pellet
                    if (pellet.checkIfEatingPellet(snake)) {
                        ShowScore++;
                        // Grow snake
                        snake.grow = true;
                        // Place new pellet
                        pellet.placePellet(snake, boardH, boardW);
                    }

                    // Check if snake eats himself, currenty disabled
                    snake.checkSelfCannibalism(gm, newHead);
                    if (gm.getGameOver()) {
                        break;
                    }

                    // Kræsjer i boarder
                    /*if (snake.getHead().X <= 0 || snake.getHead().X >= boardW - 1 ||
                        snake.getHead().Y <= 0 || snake.getHead().Y >= boardH - 1)
                    {
                        break;
                    }*/
                    runGame = snake.checkBoardCollision(boardH, boardW);

                    // Update screen
                    screen.updateScreen(snake, pellet, newHead);

                    // Update last direction. Shark bois 4ever
                    lastDirectionMoved = newDir;

                }
            }
        }
    }
}


