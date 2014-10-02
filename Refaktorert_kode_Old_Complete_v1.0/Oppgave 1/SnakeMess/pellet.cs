using System;
using System.Linq;

namespace SnakeMess
{
	// Class for controling the pellets
	public class Pellet
	{
		private int _x, _y; // Coordinates, these may be removed
		private Coord _pelletCoord; // Real coordinates

		// Constructor
		public Pellet(int x, int y)
		{
			_x = x;
			_y = y;
			_pelletCoord = new Coord(x, y);
		}

		// Check if snake is eating pellet
		public Boolean CheckIfEatingPellet(Snake snake)
		{
			return (snake.GetNewHead().X == _pelletCoord.X && snake.GetNewHead().Y == _pelletCoord.Y);
		}


		// Place new pellet
		public void PlacePellet(Snake snake, int boardH, int boardW)
		{
			var random = new Random();

			// Try to place in a new spot
			while (true)
			{
				_x = random.Next(1, boardW - 1);
				_y = random.Next(4, boardH - 1);

				// This made itself, rofl, idk. Kinda makes sense
				var foundSpot = snake.GetCoords().All(coord => _x != coord.X || _y != coord.Y);

				// Place if spot is safe, place pellet
				if (!foundSpot) continue;
				ScreenHandler.DrawPellet(new Coord(_x, _y));

				_pelletCoord = new Coord(_x, _y);
				break;
			}
		}
	}
}
