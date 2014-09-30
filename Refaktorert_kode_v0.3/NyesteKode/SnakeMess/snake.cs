using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
	// TSSSSSSSSSSZZZZZZZZZ
	public class Snake
	{
		// Direction

		// Snake body
		private readonly List<Coord> _snakeBody;
		private int _direction;
		public bool Grow;

		// Coords for head and new Head
		private Coord _head, _newHead;

		// Boolean for letting snake grow

		// Constructor
		public Snake()
		{
			_snakeBody = new List<Coord>();
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
				_snakeBody.Add(new Coord(xPosition, yPosition));
			}
		}

		// Return snakes coords
		public List<Coord> GetCoords()
		{
			return _snakeBody;
		}

		// BJ lulz
		public Coord GetHead()
		{
			return _snakeBody.Last();
		}

		// Get tail, is this even used?
		public Coord GetTail()
		{
			return _snakeBody.First();
		}

		// Check if snake has sniffed fuel
		public Boolean CheckSelfCannibalism(GameMaster gm, Coord newHead)
		{
			return GetCoords().Any(x => x.X == newHead.X && x.Y == newHead.Y);
		}

		// Method for adding new head to the right side and direction of snake
		public Coord GetNewHead()
		{
			// Get head
			_head = new Coord(_snakeBody.Last());
			// Set new head as head
			_newHead = new Coord(_head);

			// Where head is created is decided by direction
			switch (_direction)
			{
				case 0:
					_newHead.Y -= 1; // Move down
					break;
				case 1:
					_newHead.X += 1; // Right
					break;
				case 2:
					_newHead.Y += 1; // Up
					break;
				case 3:
					_newHead.X -= 1; // Left
					break;
			}
			return _newHead;
		}

		


		// Check if head is colliding
		public bool CheckBoardCollision(int boardH, int boardW)
		{
			return !(_newHead.X < 0 || _newHead.X >= boardW || _newHead.Y < 0 || _newHead.Y >= boardH);
		}
	}
}