using System;

namespace SnakeMess {

    class OriginalGame {
        private ScreenHandler _screen;
        private InputReader _inputReader;
        private int _lastDirectionMoved, _newDir, _boardW, _boardH;
        private Snake _snake;
        private Pellet _pellet;
        private System.Diagnostics.Stopwatch _timer;
        private Boolean _runGame;
        private Coord _newHead;

        public void RunOriginlGame(){
            _runGame = true;

            // Gamemaster
            _inputReader = new InputReader();

            // Screen (output handler)
            _screen = new ScreenHandler();

            // Get width and height from screen handler
            _boardW = _screen.GetWidth();
            _boardH = _screen.GetHeight();

            // Create snake
            _snake = new Snake();

            // Create pellet
            _pellet = new Pellet(0, 0);

            // Add 4 bodies to snake
            _snake.addBody(4, 10, 10);

            // place pellet in world
            _pellet.PlacePellet(_snake, _boardH, _boardW);

            // Create a stopwatch for thread-waiting
            _timer = new System.Diagnostics.Stopwatch();
            _timer.Start();

            while (_runGame) {

                // Change direction if key is pressed
                _newDir = _inputReader.ReadKeys(_lastDirectionMoved);
                // Set direction of snake
                _snake.setDirection(_newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (_newDir == 5) continue;

                // Wait 100 millis
                if (_timer.ElapsedMilliseconds < 100) continue;

                // Restart counter
                _timer.Restart();

                // Get new snakehead
                _newHead = _snake.GetNewHead();

                // Check if snake is eating pellet, do stuff if it is
                CheckIfEatingPellet();

                // Check if snake is crashing in border
                if (CheckIfBorderCrash() || _snake.CheckSelfCannibalism(_inputReader, _newHead)) break;

                // Update screen

                _screen.UpdateScreen(_snake, _pellet, _newHead);

                // Update last direction. Shark bois 4ever
                _lastDirectionMoved = _newDir;
            }

        }
         public bool CheckIfBorderCrash(){
             if (_newHead.X < 0 || _newHead.X > _boardW || _newHead.Y < 0 || _newHead.Y > _boardH)
                 return true;
             return false;
         }

         public void CheckIfEatingPellet() {
             if (!_pellet.CheckIfEatingPellet(_snake)) return;
             // Grow snake
             _snake.grow = true;
             // Place new pellet
             _pellet.PlacePellet(_snake, _boardH, _boardW);
         }
    }
}
