using System;
using System.Linq;

namespace SnakeNotMess
{
	// Class for controling the pellets
	public class Pellet : Coordinate
	{
		private Coordinate _pelletCoordinate; // Real coordinates

		// Constructor
		public Pellet(int x, int y)
		{
			X = x;
			Y = y;
			_pelletCoordinate = new Coordinate(x, y);
		}

		// Check if snake is eating pellet
		public Boolean CheckIfEatingPellet(Snake snake)
		{
			return (snake.GetNewHead().X == _pelletCoordinate.X && snake.GetNewHead().Y == _pelletCoordinate.Y);
		}


		// Place new pellet
		public void PlacePellet(Snake snake, int boardH, int boardW)
		{
			var random = new Random();

			// Try to place in a new spot
			while (true)
			{
				X = random.Next(1, boardW - 1);
				Y = random.Next(4, boardH - 1);

				// This made itself, rofl, idk. Kinda makes sense
				var foundSpot = snake.GetCoords().All(coord => Y != coord.X || Y != coord.Y);

				// Place if spot is safe, place pellet
				if (!foundSpot) continue;
				ScreenHandler.DrawPellet(new Coordinate(X, Y));

				_pelletCoordinate = new Coordinate(X, Y);
				break;
			}
		}
	}
}
