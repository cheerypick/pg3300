using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeNotMess
{
	class Level
	{
		public const int InitialSpeed = 100;
		public const int PelletsToNewLevel = 10;
		public const int MsSpeedDifference = 10;


		public Level(int number)
		{
			LevelNumber = number;
		}
		public int LevelNumber { get; set; }
		

	}
}
