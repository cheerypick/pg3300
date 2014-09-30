using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Diagnostics;

using System.Threading;

namespace SnakeMess
{
    internal class Game
    {
		/*
 * Må først hente scoren fra fila for å sjekke om det blir ny highscore.
 * Henter highscore, og converterer den til int.
 */
		private static string getHighscoreFromFile = System.IO.File.ReadAllText(@"D:\Skule - NITH\2. År\1. Programvarearkitektur\Innlevering 1\Kopi\Refaktorert_kode_v0.3\NyesteKode\SnakeMess\score.txt");
		// Lag property
		public static int LastHighscore = Convert.ToInt32(getHighscoreFromFile);

        public static void Main(string[] arguments)
        {

            // Oppretter et object av spillet.
           
            // Starter det første spillet
           
            var snake = new SnakeGame();
            snake.RunGame();
            GameMenu(snake);
            


    }

        // Metoden som snakker til bruker. Spør om han vil spille på nytt ect.
        public static void GameMenu(SnakeGame snake){
            // Skal skrive ut til fil når det blir gameover

            // Finn ut mer!


			// Sjekker om forrige highscore er større en nåværende score.
	        if (SnakeGame.ShowScore > LastHighscore)
	        {
				/*			Fiks til Relative Path!!		*/
				// Kilder:
				//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
				System.IO.File.WriteAllText(@"D:\Skule - NITH\2. År\1. Programvarearkitektur\Innlevering 1\Kopi\Refaktorert_kode_v0.3\NyesteKode\SnakeMess\score.txt", "" + SnakeGame.ShowScore);
				LastHighscore = SnakeGame.ShowScore;
	        }


	        // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
			Console.Write("\tHighScore: " + LastHighscore + "\n");
            Console.Write("\tYou lost lol\n\n\tTry again? y/n\n\n\t");

            // Tar imot input, og gjør det bruker sier.
            string input = Console.ReadLine();
            if (input.Equals("y")) { 
                 Console.Clear();
                // Må resette score for hver runde.
                snake = new SnakeGame();
                
                SnakeGame.ShowScore = 0;
                
                snake.RunGame();
                GameMenu(snake);
            }
            else
            {
                Console.Write("\n\tbb");
                Console.ReadKey(true);
            }


        }
    }
}

