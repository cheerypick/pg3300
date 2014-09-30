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
        private Coord newHead;


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

            // Create pellet
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

       // StreamWriter writer = new StreamWriter("test.txt");
        public void RunGame() {

            // Running the game
            while (runGame) {

				/*		Rydd opp. Bør kanskje ikke være i denne klassen? Kanskje i en meny klasse?		*/
				// Viser score på skjermen
				Console.SetCursorPosition(1, 1);
				// Skriver ut highscore og litt tekst
				Console.Write("HighScore: " + Game.LastHighscore +  "\t\tScore: " + ShowScore);




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
                    newHead = snake.getNewHead();

                    // Check if snake is eating pellet
                    checkIfEatingPellet();

                    // Check if snake is crashing in border
                    if (checkIfBorderCrash() || snake.CheckSelfCannibalism(gm, newHead)) break;

                    // Update screen

                    screen.updateScreen(snake, pellet, newHead);

                    // Update last direction. Shark bois 4ever
                    lastDirectionMoved = newDir;

                }
            }
        }

        public bool checkIfBorderCrash()
        {
            return snake.getHead().X <= 0 || snake.getHead().X >= boardW - 1 ||
                   snake.getHead().Y <= 0 || snake.getHead().Y >= boardH - 1;
        }

        public void checkIfEatingPellet()
        {
            if (!pellet.checkIfEatingPellet(snake)) return;
            ShowScore++;
            // Grow snake
            snake.grow = true;
            // Place new pellet
            pellet.placePellet(snake, boardH, boardW);
        }
    }
}
