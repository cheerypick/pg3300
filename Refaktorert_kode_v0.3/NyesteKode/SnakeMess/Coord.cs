namespace SnakeMess
{
	// Easy
	// HJALMAR HJILLHJOLL
	public class Coord
	{
		public int X { get; set; }
		public int Y{ get; set; }

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