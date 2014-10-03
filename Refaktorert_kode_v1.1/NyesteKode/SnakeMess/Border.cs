using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeNotMess
{
	internal class Border
	{
		private readonly List<Coordinate> _border;

		public Border()
		{
			_border = new List<Coordinate>();

			for (int i = 0; i < Console.WindowWidth - 1; i++)
			{
				_border.Add(new Coordinate(i, 3));
				_border.Add(new Coordinate(i, Console.WindowHeight - 1));
			}

			for (int i = 3; i < Console.WindowHeight - 1; i++)
			{
				_border.Add(new Coordinate(0, i));
				_border.Add(new Coordinate(Console.WindowWidth - 1, i));
			}
		}

		public void write()
		{
			foreach (Coordinate borderCoord in _border)
			{
				Console.SetCursorPosition(borderCoord.X, borderCoord.Y);
				Console.Write("*");
			}
		}

		public List<Coordinate> GetBorder()
		{
			return _border;
		}

		public Boolean CheckCollision(Coordinate newHead)
		{
			return _border.Any(borderCoord => newHead.X == borderCoord.X && newHead.Y == borderCoord.Y);
		}
	}
}