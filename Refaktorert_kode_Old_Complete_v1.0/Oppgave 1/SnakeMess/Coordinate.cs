
namespace SnakeMess
{
	public class Coordinate
	{
		public int X;
		public int Y;

		public Coordinate(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Coordinate(Coordinate input)
		{
			X = input.X;
			Y = input.Y;
		}
	}
}