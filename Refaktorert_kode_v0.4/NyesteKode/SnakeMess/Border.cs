using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace SnakeMess {
    class Border
    {
        private List<Coord> border;

        public Border()
        {
            border = new List<Coord>();

            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                border.Add(new Coord(i, 3));
                border.Add(new Coord(i, Console.WindowHeight - 1));
            }

            for (int i = 3; i < Console.WindowHeight - 1; i++)
            {
                border.Add(new Coord(0, i));
                border.Add(new Coord(Console.WindowWidth - 1, i));
            }
        }
        public void write(){

            foreach(Coord borderCoord in border)
            {
                Console.SetCursorPosition(borderCoord.X, borderCoord.Y);
                Console.Write("*");
            }
        }

      public List<Coord> GetBorder()
      {
          return border;
      }

        public Boolean checkCollision(Coord newHead)
        {
            foreach (var borderCoord in border)
            {
                if (newHead.X == borderCoord.X && newHead.Y == borderCoord.Y)
                    return true;
                
            }
            return false;
        }
    }
}
