using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeNotMess{
	internal class Border{
		private readonly List<Coordinate> _border;

        // Creates a border around the console, leaving space for in-game menu
		public Border(){
			_border = new List<Coordinate>();

            for (var i = 3; i < Console.WindowHeight - 1; i++) {
                _border.Add(new Coordinate(0, i));
                _border.Add(new Coordinate(Console.WindowWidth - 1, i));
            }

			for (var i = 0; i < Console.WindowWidth - 1; i++){
				_border.Add(new Coordinate(i, 3));
				_border.Add(new Coordinate(i, Console.WindowHeight - 1));
			}

			
		}

        // Method for writing hte border
		public void write(){
			foreach (Coordinate borderCoord in _border){
				Console.SetCursorPosition(borderCoord.X, borderCoord.Y);
				Console.Write("*");
			}
		}

		public Boolean CheckCollision(Coordinate newHead)	{
			return _border.Any(borderCoord => newHead.X == borderCoord.X && newHead.Y == borderCoord.Y);
		}
	}
}