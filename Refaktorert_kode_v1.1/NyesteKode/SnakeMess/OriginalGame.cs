using System;

namespace SnakeMess {

    class OriginalGame {
        private ScreenHandler screen;
        private InputHandler _inputHandler;
        private int lastDirectionMoved, newDir, boardW, boardH;
        private Snake snake;
        private Pellet pellet;
        private System.Diagnostics.Stopwatch timer;
        private Boolean runGame;
        private Coordinate newHead;

        public void runOriginlGame(){
            runGame = true;

            // Gamemaster
            _inputHandler = new InputHandler();

            // Screen (output handler)
            screen = new ScreenHandler();

            // Get width and height from screen handler
            boardW = screen.GetWidth();
            boardH = screen.GetHeight();

            // Create snake
            snake = new Snake();

            // Create pellet
            pellet = new Pellet(0, 0);

            // Add 4 bodies to snake
            snake.addBody(4, 10, 10);

            // place pellet in world
            pellet.PlacePellet(snake, boardH, boardW);

            // Create a stopwatch for thread-waiting
            timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            while (runGame) {

                // Change direction if key is pressed
                //newDir = _inputHandler.ReadKeys(lastDirectionMoved);
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
                if (CheckIfBorderCrash() || snake.CheckSelfCannibalism(_inputHandler, newHead)) break;

                // Update screen

                screen.UpdateScreen(snake, pellet, newHead);

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
             if (!pellet.CheckIfEatingPellet(snake)) return;
             // Grow snake
             snake.grow = true;
             // Place new pellet
             pellet.PlacePellet(snake, boardH, boardW);
         }
    }
}
