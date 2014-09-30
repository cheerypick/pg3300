using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

using System.Threading;

namespace SnakeMess {

    internal class SnakeGame {
        private Board screen;
        private GameMaster gm;
        private int lastDirectionMoved, newDir, boardW, boardH;
        private Snake snake;
        private Pellet pellet;
        private Stopwatch timer;
        private Boolean runGame;
        private Coord newHead;
	    private Command lastCommand;
	    public static bool isPaused = false;


        public SnakeGame() {
            ShowScore = 0;
            // Boolean for running the game
            runGame = true;

            // Gamemaster
            gm = new GameMaster();

            // Screen (output handler)
            screen = new Board();

            // Get width and height from screen handler
            boardW = screen.GetWidth();
            boardH = screen.GetHeight();

            // Create snake
            snake = new Snake();

            // Create Pellet
            pellet = new Pellet(0, 0);

            // Add 4 bodies to snake
            snake.AddBody(4, 10, 10);

            // place Pellet in world
            pellet.placePellet(snake, boardH, boardW);

            // Create a stopwatch for thread-waiting
            timer = new Stopwatch();
            timer.Start();
        }

        // Skal være static method
        public static int ShowScore { get; set; }

       // StreamWriter writer = new StreamWriter("test.txt");
        public void RunGame() {

            // Running the game
            while (runGame) {
                // Change direction if key is pressed
                newDir = (int)gm.ReadKeys(lastCommand);
                // Set direction of snake
                snake.SetDirection(newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (!isPaused) {
                    // Wait 100 millis
                    if (timer.ElapsedMilliseconds < 100) {
                        continue;
                    }
                    // Restart counter
                    timer.Restart();

                    // Get new snakehead
                    newHead = snake.GetNewHead();

                    // Check if snake is eating Pellet
                    checkIfEatingPellet();

                    // Check if snake is crashing in border
                    if (checkIfBorderCrash() || snake.CheckSelfCannibalism(gm, newHead)) break;

                    // Update screen

                    screen.updateScreen(snake, pellet, newHead);

                    // Update last direction. Shark bois 4ever
                    lastCommand = (Command)newDir;

                }
            }
        }

        public bool checkIfBorderCrash()
        {
            return snake.GetHead().X <= 0 || snake.GetHead().X >= boardW - 1 ||
                   snake.GetHead().Y <= 0 || snake.GetHead().Y >= boardH - 1;
        }

        public void checkIfEatingPellet()
        {
            if (!pellet.checkIfEatingPellet(snake)) return;
            ShowScore++;
            // Grow snake
            snake.Grow = true;
            // Place new Pellet
            pellet.placePellet(snake, boardH, boardW);
        }
    }
}
