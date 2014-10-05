namespace SnakeNotMess{

	// Keeps control of the level of the game.
	// The dificulty will increase for each level.
	class Level{
		public const int InitialSpeed = 100;
		public const int PelletsToNewLevel = 10;
		public const int MsSpeedDifference = 3;


		public Level(int number){
			LevelNumber = number;
		}
		public int LevelNumber { get; set; }
	}
}
