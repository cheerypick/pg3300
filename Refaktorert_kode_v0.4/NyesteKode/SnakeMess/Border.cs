using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess {
    class Border {
        public Border()
        {
            List < Coord > border= new List<Coord>;

            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                border.Add(new Coord(i , 3));
                border.Add(new Coord(i, ));
            }
        }
    }
}
