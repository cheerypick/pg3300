namespace SnakeNotMess
{
	internal class Game
	{
		// The main method. Starts the game.
		public static void Main(string[] arguments)
		{
			var snake = new GameEngine();
			snake.RunGame();
		}
	}
}