using System;
using System.Linq;

namespace SnakeMess {

    public class Pellet {
        private int _x, _y; // Coordinates, these may be removed
        private Coordinate _pelletCoordinate; // Real coordinates

        // Constructor
        public Pellet(int x, int y) {
            _x = x;
            _y = y;
            _pelletCoordinate = new Coordinate(x, y);
        }

        // Check if snake is eating pellet
        public Boolean CheckIfEatingPellet(Snake snake) {
            return (snake.GetNewHead().X == _pelletCoordinate.X && snake.GetNewHead().Y == _pelletCoordinate.Y);
        }


        // Place new pellet
        public void PlacePellet(Snake snake, int boardH, int boardW) {
            var random = new Random();

            // Try to place in a new spot
            while (true) {
                _x = random.Next(1, boardW - 1);
                _y = random.Next(4, boardH - 1);

                // This made itself, rofl, idk. Kinda makes sense
                var foundSpot = snake.getCoords().All(coord => _x != coord.X || _y != coord.Y);

                // Place if spot is safe, place pellet
                if (!foundSpot) continue;
				ScreenHandler.DrawPellet(new Coordinate(_x, _y));

                _pelletCoordinate = new Coordinate(_x, _y);
                break;
            }
        }
		public void PlaceSpecialPellet(Snake snake, int boardH, int boardW)
		{
			var random = new Random();

			// Try to place in a new spot
			while (true)
			{
				_x = random.Next(1, boardW - 1);
				_y = random.Next(4, boardH - 1);

				var foundSpot = snake.getCoords().All(coord => _x != coord.X || _y != coord.Y);

				// Place if spot is safe, place pellet
				if (!foundSpot) continue;
				ScreenHandler.DrawSpecialPellet(new Coordinate(_x, _y));

				_pelletCoordinate = new Coordinate(_x, _y);
				break;
			}
		}

        // u get the idea
        public Coordinate GetCoords() {
            return _pelletCoordinate;
        }
    }

}
