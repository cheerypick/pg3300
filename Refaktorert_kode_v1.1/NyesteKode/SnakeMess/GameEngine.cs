using System;
using System.Diagnostics;

namespace SnakeNotMess
{
	public class GameEngine
	{
		public static bool SpecialPelletExtraGrow = false;
		private readonly int _boardHeight;
		private readonly int _boardWidth;
		private readonly Border _border;
		private readonly InputHandler _inputHandler;
		private readonly Pellet _pellet;
		private readonly Random _random = new Random();
		private readonly Boolean _runGame;
		private readonly ScreenHandler _screen;
		private readonly Snake _snake;
		private readonly Stopwatch _timer;
		public Boolean IsPaused = false;
		private int _lastDirectionMoved;
		private int _level = 1;
		private int _newDir;
		private Coordinate _newHead;
		private int _normalPelletsEatenUntilSpecial;
		private bool _specialPellet; //unusual pellets
		private int _speed = 100;

		public GameEngine()
		{
			/*		Default  	*/
			//First time game decides when the special pellet will come
			_normalPelletsEatenUntilSpecial = _random.Next(1, 10);
			SpecialPelletNumber = 3;

			// Create border
			_border = new Border();
			_border.write();
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

		public static int Score { get; set; }

		// Hvor mange poeng og hvor mye snake skal vokse når du spiser en special pellet.
		public static int SpecialPelletNumber { get; set; }


		public void RunGame()
		{
			// Running the game
			while (_runGame)
			{
				// Change direction if key is pressed
				_newDir = _inputHandler.ReadKeys(_lastDirectionMoved, this);

				// Set direction of snake
				if (_newDir < 4) _snake.SetDirection(_newDir);

				if (IsPaused) continue;
				// Wait _speed  millis
				if (_timer.ElapsedMilliseconds < _speed) continue;

				// Restart counter
				_timer.Restart();

				// Get new snakehead
				_newHead = _snake.GetNewHead();

				Menu.UpperScorePanel(Score, _level);

				// Check if snake is eating pellet
				CheckIfEatingPellet();

				// Check if snake is crashing in border
				if (_border.CheckCollision(_newHead) || _snake.CheckSelfCannibalism(_inputHandler, _newHead)) break;

				// Update screen

				_screen.UpdateScreen(_snake, _pellet, _newHead);

				// Update last direction
				_lastDirectionMoved = _newDir;
			}
		}

		// Check is snake is eating pellet/apple
		public void CheckIfEatingPellet()
		{
			if (!_pellet.CheckIfEatingPellet(_snake)) return;

			// Sets different scores for normal and special pellets

			if (_specialPellet)
			{
				Score += SpecialPelletNumber;
				SpecialPelletExtraGrow = true;
			}
			else
			{
				Score++;
			}

			// Grow snake
			_snake.Grow = true;

			// Level up every 10 pellets
			_level = Score/10 + 1;

			//Increase speed with 10ms each level, starting with 100
			_speed = 110 - _level*10;

			//Special pellets appear at random times
			if (Score%_normalPelletsEatenUntilSpecial == 0)
			{
				// New random number generates after special pellet is eaten
				_normalPelletsEatenUntilSpecial = _random.Next(1, 10);
				_specialPellet = true;

				_pellet.PlaceSpecialPellet(_snake, _boardHeight, _boardWidth);
			}
			else
			{
				_specialPellet = false;
				_pellet.PlacePellet(_snake, _boardHeight, _boardWidth);
			}
		}
	}
}