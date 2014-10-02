namespace SnakeMess
{
	internal class NewHead
	{
		public static Coord GetNewHead(Coord head, int direction)
		{
			var newHead = new Coord(head);

			// Where new head is created is decided by direction
			switch (direction)
			{
				case 0:
					newHead.Y -= 1; // Move down
					break;
				case 1:
					newHead.X += 1; // Right
					break;
				case 2:
					newHead.Y += 1; // Up
					break;
				case 3:
					newHead.X -= 1; // Left
					break;
			}
			return newHead;
		}
	}
}