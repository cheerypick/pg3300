using System;
using System.IO;

namespace SnakeMess{
    internal class Game
    {
	//	public static bool runGame = true;
		public static bool runGame { get; set; }
		// Henter fila med highscore.
		private static string _getHighscoreFromFile = File.ReadAllText(@"..\..\score.txt");
		// Score player har nå.
	    public static int LastHighscore { get; set; }

	    public static void Main(string[] arguments) {

			// Oppgave 1
   //     OriginalGame game = new OriginalGame();
   //     game.runOriginlGame();


	
			
			  
			//	 Oppgave 2
			 	
				 
           
				LastHighscore = Convert.ToInt32(_getHighscoreFromFile);

           
			   // Starter det første spillet
				runGame = true;
			Menu.GameStartMenu();
		    
			   while (runGame)  {
				   var snake = new GameEngine();
				   snake.RunGame();
				   runGame = Menu.GameOverMenu(snake);
			   }
			 
        }
          
    }
}

