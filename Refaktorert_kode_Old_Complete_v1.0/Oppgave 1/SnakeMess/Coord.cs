
namespace SnakeMess
{
	// Controls the coords.
	public class Coord
	{

		public int X;
		public int Y;

		public Coord(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Coord(Coord input)
		{
			X = input.X;
			Y = input.Y;
		}
	}
}
