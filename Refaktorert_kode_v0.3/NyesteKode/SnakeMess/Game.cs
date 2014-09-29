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
            SnakeGame snake = new SnakeGame();
            // Starter det første spillet
            snake.RunGame();
            GameMenu(snake);

        }

        // Metoden som snakker til bruker. Spør om han vil spille på nytt ect.
        public static void GameMenu(SnakeGame snake)
        {

            // Skal skrive ut til fil når det blir gameover

            // Finn ut mer!


            // Tømmer skjermen før teksten kommer
            Console.Clear();
            // Setter utgangspunk for teksten som skal komme
            Console.SetCursorPosition(1, 1);
            // Skriver ut highscore og litt tekst
            Console.Write("\tHighScore: " + SnakeGame.ShowScore + "\n");
            Console.Write("\tYou lost lol\n\n\tTry again? y/n\n\n\t");

            // Tar imot input, og gjør det bruker sier.
            string input = Console.ReadLine();
            if (input.Equals("y"))
            {
                // Må resette score for hver runde.
                SnakeGame.ShowScore = 0;
                Console.Clear();
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

