using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {

    class OriginalGame {
        private ScreenHandler screen;
        private InputReader _inputReader;
        private int lastDirectionMoved, newDir, boardW, boardH;
        private Snake snake;
        private pellet pellet;
        private System.Diagnostics.Stopwatch timer;
        private Boolean runGame;
        private Coord newHead;

        public void runOriginlGame(){
            runGame = true;

            // Gamemaster
            _inputReader = new InputReader();

            // Screen (output handler)
            screen = new ScreenHandler();

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
            timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            while (runGame) {

                // Change direction if key is pressed
                newDir = _inputReader.ReadKeys(lastDirectionMoved);
                // Set direction of snake
                snake.setDirection(newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (newDir == 5) continue;

                // Wait 100 millis
                if (timer.ElapsedMilliseconds < 100) continue;

                // Restart counter
                timer.Restart();

                // Get new snakehead
                newHead = snake.GetNewHead();

                // Check if snake is eating pellet, do stuff if it is
                CheckIfEatingPellet();

                // Check if snake is crashing in border
                if (CheckIfBorderCrash() || snake.CheckSelfCannibalism(_inputReader, newHead)) break;

                // Update screen

                screen.updateScreen(snake, pellet, newHead);

                // Update last direction. Shark bois 4ever
                lastDirectionMoved = newDir;
            }

        }
         public bool CheckIfBorderCrash(){
             if (newHead.X < 0 || newHead.X > boardW || newHead.Y < 0 || newHead.Y > boardH)
                 return true;
             return false;
         }

         public void CheckIfEatingPellet() {
             if (!pellet.checkIfEatingPellet(snake)) return;
             // Grow snake
             snake.grow = true;
             // Place new pellet
             pellet.placePellet(snake, boardH, boardW);
         }
    }
}
