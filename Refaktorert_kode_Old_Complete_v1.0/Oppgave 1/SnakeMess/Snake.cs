using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
	// Building snake
	public class Snake
	{
		// Direction
		private int _direction;

		// Snake body
		private readonly List<Coordinate> _snakeBody;

		// Boolean for letting snake grow
		public bool Grow { get; set; }

		// Constructor
		public Snake()
		{
			_snakeBody = new List<Coordinate>();
			Grow = true;
		}

		// Setdirection. Catches bad input
		public void SetDirection(int newDir)
		{
			_direction = newDir;
		}

		// Add bodies to snake
		public void AddBody(int bodies, int xPosition, int yPosition)
		{
			for (int i = 0; i < bodies; i++)
			{
				_snakeBody.Add(new Coordinate(xPosition, yPosition));
			}
		}

		// Return snakes coords
		public List<Coordinate> GetCoords()
		{
			return _snakeBody;
		}

		// Snake is getting head
		public Coordinate GetHead()
		{
			return _snakeBody.Last();
		}

		// Finding the tail of the snake
		public Coordinate GetTail()
		{
			return _snakeBody.First();
		}

		// Check if snake collides in itself.
		public Boolean CheckSelfCannibalism(InputHandler gm, Coordinate newHead)
		{
			return GetCoords().Any(x => x.X == newHead.X && x.Y == newHead.Y);
		}


		// Method for adding new head to the right side and direction of snake
		public Coordinate GetNewHead()
		{
			// Get head
			return NewHead.GetNewHead(_snakeBody.Last(), _direction);

		}
	}
}
