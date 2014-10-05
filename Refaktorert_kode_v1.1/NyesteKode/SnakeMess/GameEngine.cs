using System;
using System.Diagnostics;


namespace SnakeNotMess
{

	// The class that creates object and builds the game.

	public class GameEngine{
		public static bool SpecialPelletExtraGrow = false;  // Snake grows from special pellet
        private readonly int _boardHeight, _boardWidth;     // Height and width of board
		private readonly Border _border;                    // Drawn border around screen
		private readonly InputHandler _inputHandler;        // User input
		private readonly Pellet _pellet;                    // Also known as Apple
		private readonly Random _random = new Random();     // Random
		private readonly Boolean _runGame;                  // Boolean for running the game
		private readonly ScreenHandler _screen;             // Screen-handler for updating screen
		private readonly Snake _snake;                      // Snake, player controlled
		private readonly Stopwatch _timer;                  // Timer, used to update at given intervals
		public Boolean IsPaused = false;                    // Tells if game is paused
		private int _lastDirectionMoved;                    // Last direction moved when starting a new interval
		private readonly Level _level;                      // Level influences speed
		private int _newDir;                                // Direction
		private Coordinate _newHead;                        // Snakes next head, uses this to check for game overs before drawing it
		private int _normalPelletsEatenUntilSpecial;        // Controls when special pellet is spawned
		private bool _specialPellet;                        // Special pellet 
		private int _speed = 100;                           // Speed aka. screen updating interval

		public GameEngine(){

			//First time game decides when the special pellet will come
			_normalPelletsEatenUntilSpecial = _random.Next(1, 10);
			SpecialPelletNumber = 3;

			// Create border
			_border = new Border();
			_border.write();

            // Set level
			_level = new Level(1);
			Score = 0;

			// Boolean for running the game
			_runGame = true;

			// Gamemaster
			_inputHandler = new InputHandler();

			// Screen (output handler)
			_screen = new ScreenHandler();

			// Get width and height from screen handler
			_boardWidth = _screen.GetWidth();
			_boardHeight = _screen.GetHeight();

			// Create snake
			_snake = new Snake();

			// Create pellet
			_pellet = new Pellet(0, 0);

			// Add 4 bodies to snake
			_snake.AddBody(4, 10, 10);


			// place pellet on board
			_pellet.PlacePellet(_snake, _boardHeight, _boardWidth);


			// Create a stopwatch for thread-waiting
			_timer = new Stopwatch();
			_timer.Start();
		}

		// Current score.
		public static int Score { get; set; }

		// How many points and how much the snake will grown then you eat a special pellet.
		public static int SpecialPelletNumber { get; set; }


		public void RunGame(){
			// Running the game
			while (_runGame){
				// Change direction if key is pressed
				_newDir = _inputHandler.ReadKeys(_lastDirectionMoved, this);

				// Set direction of snake
				if (_newDir < 4) _snake.SetDirection(_newDir);

				if (IsPaused) continue;
				// Wait _speed millis
				if (_timer.ElapsedMilliseconds < _speed) continue;

				// Restart counter
				_timer.Restart();

				// Get new snakehead
				_newHead = _snake.GetNewHead();

                // Draw in-game score ui
				Menu.UpperScorePanel(Score, _level.LevelNumber);

				// Check if snake is eating pellet
				CheckIfEatingPellet();

				// Check if snake is crashing in border
				if (_border.CheckCollision(_newHead) || _snake.CheckSelfCannibalism(_inputHandler, _newHead)) break;

				// Update screen
				_screen.UpdateScreen(_snake, _pellet, _newHead);

				// Save last direction
				_lastDirectionMoved = _newDir;
			}
		}

		// Check is snake is eating pellet/apple
		public void CheckIfEatingPellet(){

			if (!_pellet.CheckIfEatingPellet(_snake)) return;

			// Sets different scores for normal and special pellets

			if (_specialPellet){
				Score += SpecialPelletNumber;
				SpecialPelletExtraGrow = true;
			}
			else{
				Score++;
			}

			// Grow snake
			_snake.Grow = true;

			// Level up 
			_level.LevelNumber = Score / Level.PelletsToNewLevel + 1;

			//Increase speed 
			_speed = Level.InitialSpeed - _level.LevelNumber*Level.MsSpeedDifference;

			//Special pellets appear at random times
			if (Score%_normalPelletsEatenUntilSpecial == 0){
				// New random number generates after special pellet is eaten
				_normalPelletsEatenUntilSpecial = _random.Next(1, 10);
				_specialPellet = true;

				_pellet.PlaceSpecialPellet(_snake, _boardHeight, _boardWidth);
			}
			else{
				_specialPellet = false;
				_pellet.PlacePellet(_snake, _boardHeight, _boardWidth);
			}
		}
	}
}