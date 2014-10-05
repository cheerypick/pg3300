namespace SnakeNotMess
{
	// Controls the head
	class NewHead : Coordinate
	{
		public static Coordinate GetNewHead(Coordinate head, int direction)
		{
			// Creating a new head. The head is used to see if the snake is eating itself, 
			// eating pellets og crashing into a wall.
			var newHead = new Coordinate(head);

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
