using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    class Border
    {
        private readonly List<Coord> _border;

        public Border()
        {
            _border = new List<Coord>();

            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                _border.Add(new Coord(i, 3));
                _border.Add(new Coord(i, Console.WindowHeight - 1));
            }

            for (int i = 3; i < Console.WindowHeight - 1; i++)
            {
                _border.Add(new Coord(0, i));
                _border.Add(new Coord(Console.WindowWidth - 1, i));
            }
        }
        public void Write(){

            foreach(Coord borderCoord in _border)
            {
                Console.SetCursorPosition(borderCoord.X, borderCoord.Y);
                Console.Write("*");
            }
        }

      public List<Coord> GetBorder()
      {
          return _border;
      }

        public Boolean CheckCollision(Coord newHead)
        {
            return _border.Any(borderCoord => newHead.X == borderCoord.X && newHead.Y == borderCoord.Y);
        }
    }
}
