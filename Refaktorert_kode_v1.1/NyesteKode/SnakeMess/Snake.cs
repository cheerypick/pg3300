using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeNotMess{
	public class Snake{

		// Snake body
		private readonly List<Coordinate> _snakeBody;

		// Boolean for letting snake grow
		public bool Grow;

        // Direction of snakes movement
		private int _direction;

		// Constructor
		public Snake(){
			_snakeBody = new List<Coordinate>();
			Grow = true;
		}

		// Setdirection. Catches bad input
		public void SetDirection(int newDir){
			_direction = newDir;
		}

		// Add bodies to snake
		public void AddBody(int bodies, int xPosition, int yPosition){
			for (var i = 0; i < bodies; i++){
				_snakeBody.Add(new Coordinate(xPosition, yPosition));
			}
		}

		// Return snakes coords
		public List<Coordinate> GetCoords(){
			return _snakeBody;
		}

		// Get Head
		public Coordinate GetHead(){
			return _snakeBody.Last();
		}

		// Get tail
		public Coordinate GetTail(){
			return _snakeBody.First();
		}

		// Check if snake eats itself
		public Boolean CheckSelfCannibalism(InputHandler gm, Coordinate newHead){
			return GetCoords().Any(x => x.X == newHead.X && x.Y == newHead.Y);
		}

		// Method for adding new head to the right side and direction of snake
		public Coordinate GetNewHead(){
			// Get head
			return NewHead.GetNewHead(_snakeBody.Last(), _direction);
		}
	}
}