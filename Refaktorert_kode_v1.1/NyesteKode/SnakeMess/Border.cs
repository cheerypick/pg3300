using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    class Border
    {
        private List<Coordinate> border;

        public Border()
        {
            border = new List<Coordinate>();

            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                border.Add(new Coordinate(i, 3));
                border.Add(new Coordinate(i, Console.WindowHeight - 1));
            }

            for (int i = 3; i < Console.WindowHeight - 1; i++)
            {
                border.Add(new Coordinate(0, i));
                border.Add(new Coordinate(Console.WindowWidth - 1, i));
            }
        }
        public void write(){

            foreach(Coordinate borderCoord in border)
            {
                Console.SetCursorPosition(borderCoord.X, borderCoord.Y);
                Console.Write("*");
            }
        }

      public List<Coordinate> GetBorder()
      {
          return border;
      }

        public Boolean checkCollision(Coordinate newHead)
        {
            return border.Any(borderCoord => newHead.X == borderCoord.X && newHead.Y == borderCoord.Y);
        }
    }
}
