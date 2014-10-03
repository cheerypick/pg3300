using System.Diagnostics;

namespace SnakeMess
{
	// Execute the game. 
	public class GameEngine
	{
		private readonly int _boardHeight;
		private readonly int _boardWidth;
		private readonly Pellet _pellet;
		private readonly ScreenHandler _screen;
		private readonly Snake _snake;
		private readonly InputHandler _inputHandler;
		private int _lastDirectionMoved;
		private Coordinate _newHead;
		private Stopwatch _timer;

		public GameEngine()
		{
			// Gamemaster
			_inputHandler = new InputHandler();

			// Screen (output handler)
			_screen = new ScreenHandler();

			IsPaused = false;
			// Get width and height from screen handler
			_boardWidth = _screen.GetWidth();
			_boardHeight = _screen.GetHeight();

			// Create snake
			_snake = new Snake();

			// Create pellet
			_pellet = new Pellet(0, 0);

			// Add 4 bodies to snake
			_snake.AddBody(4, 10, 10);

			// place pellet in world
			_pellet.PlacePellet(_snake, _boardHeight, _boardWidth);

			_timer = new Stopwatch();

			_timer.Start();

		}

		public bool IsPaused { get; set; }

		public void RunGame()
		{
			// The loop that runs the game
			while (true)
			{
				

				//This loop runs as fast as possible, constantly checking input
				int newDir = _inputHandler.ReadKeys(_lastDirectionMoved, this);

				//if newDir is a valid Direction, set it to snake
				if (newDir < 4) _snake.SetDirection(newDir);

				//Inverted if-loop. Code after executes only if game is not paused
				if (IsPaused) continue;

				// 100 ms iteration waiting time equals one snake move
				if (_timer.ElapsedMilliseconds < 100) continue;

				// Restart counter
				_timer.Restart();

				// Get new snakehead
				_newHead = _snake.GetNewHead();

				// Check if snake is eating pellet, do stuff if it is
				CheckIfEatingPellet();

				// Check if snake is crashing in border
				if (CheckIfBorderCrash() || _snake.CheckSelfCannibalism(_inputHandler, _newHead)) break;

				// Update screen
				_screen.UpdateScreen(_snake, _pellet, _newHead);

				// Update last direction. Shark bois 4ever
				_lastDirectionMoved = newDir;
			}
		}


		public static void Main(string[] arguments)
		{
			var snake = new GameEngine();
			snake.RunGame();
		}

		// Checking if the snake is colliding with the border.
		public bool CheckIfBorderCrash()
		{
			return _newHead.X < 0 || _newHead.X > _boardWidth - 1 || _newHead.Y < 0 || _newHead.Y > _boardHeight - 1;
		}

		// Checking if snake eats a pellet
		public void CheckIfEatingPellet()
		{
			if (!_pellet.CheckIfEatingPellet(_snake)) return;
			// Grow snake
			_snake.Grow = true;
			// Place new pellet
			_pellet.PlacePellet(_snake, _boardHeight, _boardWidth);
		}
	}
}