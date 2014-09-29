using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Diagnostics;

using System.Threading;

namespace SnakeMess
{
    internal class Game
    {
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



			/*			Fiks til Relative Path!!		*/
			// Kilder:
			//http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
			System.IO.File.WriteAllText(@"D:\Skule - NITH\2. År\1. Programvarearkitektur\Innlevering 1\SmartGit\Refaktorert_kode_v0.3\NyesteKode\SnakeMess\score.txt", "asdf");


	        // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            Console.Write("\tHighScore: " + SnakeGame.ShowScore + "\n");
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

