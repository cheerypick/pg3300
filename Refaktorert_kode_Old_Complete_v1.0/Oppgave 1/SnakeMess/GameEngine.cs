using System.Diagnostics;

namespace SnakeMess
{

	// Execute the game. 
	internal class GameEngine
	{
		private readonly int _lastDirectionMoved;
		private readonly int _boardW;
		private readonly int _boardH;
		private readonly Snake _snake;
		private readonly Pellet _pellet;
		private readonly Coord _newHead;

		public static void Main(string[] arguments)
		{
			new GameEngine();
		}


		public GameEngine()
		{
			// Gamemaster
			var inputReader = new InputReader();

			// Screen (output handler)
			var screen = new ScreenHandler();

			// Get width and height from screen handler
			_boardW = screen.GetWidth();
			_boardH = screen.GetHeight();

			// Create snake
			_snake = new Snake();

			// Create pellet
			_pellet = new Pellet(0, 0);

			// Add 4 bodies to snake
			_snake.AddBody(4, 10, 10);

			// place pellet in world
			_pellet.PlacePellet(_snake, _boardH, _boardW);

			// Create a stopwatch for thread-waiting
			var timer = new Stopwatch();
			timer.Start();

			// The loop that runs the game
			while (true)
			{
				// Change direction if key is pressed
				int newDir = inputReader.ReadKeys(_lastDirectionMoved);
				// Set direction of snake
				_snake.SetDirection(newDir);

				// newDir = 5 betyr pause. We are still in alpha
				if (newDir == 5) continue;

				// Wait 100 millis
				if (timer.ElapsedMilliseconds < 100) continue;

				// Restart counter
				timer.Restart();

				// Get new snakehead
				_newHead = _snake.GetNewHead();

				// Check if snake is eating pellet, do stuff if it is
				CheckIfEatingPellet();

				// Check if snake is crashing in border
				if (CheckIfBorderCrash() || _snake.CheckSelfCannibalism(inputReader, _newHead)) break;

				// Update screen
				screen.UpdateScreen(_snake, _pellet, _newHead);

				// Update last direction. Shark bois 4ever
				_lastDirectionMoved = newDir;
			}

		}
		// Checking if the snake is colliding with the border.
		public bool CheckIfBorderCrash()
		{
			// Må være boardH - 1
			if (_newHead.X < 0 || _newHead.X > _boardW - 1 || _newHead.Y < 0 || _newHead.Y > _boardH - 1)
				return true;
			return false;
		}

		// Checking if snake eats a pellet
		public void CheckIfEatingPellet()
		{
			if (!_pellet.CheckIfEatingPellet(_snake)) return;
			// Grow snake
			_snake.Grow = true;
			// Place new pellet
			_pellet.PlacePellet(_snake, _boardH, _boardW);
		}
	}
}