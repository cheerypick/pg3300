namespace SnakeMess
{

	// Keeps track of the coordinates in the game
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