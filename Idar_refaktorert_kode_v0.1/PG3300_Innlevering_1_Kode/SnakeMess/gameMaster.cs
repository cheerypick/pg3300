using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    public class GameMaster{
        private ConsoleKeyInfo _inputKey;
        private Boolean gameOver;

        public GameMaster() { }
        

        public int ReadKeys(int lastDirection)  {

            if(Console.KeyAvailable)
             _inputKey = Console.ReadKey();
            
           
            switch (_inputKey.Key) {
              /*  case ConsoleKey.Escape:
                    return 4;*/
                case ConsoleKey.Spacebar:
                    return 5;
                case ConsoleKey.UpArrow: // 0
                    if(lastDirection != 2)
                        return 0;
                    return lastDirection;

                case ConsoleKey.RightArrow: // 1
                    if(lastDirection != 3)
                        return 1;
                    return lastDirection;

                case ConsoleKey.DownArrow: // 2
                    if(lastDirection != 0)
                        return 2;
                    return lastDirection;

                case ConsoleKey.LeftArrow: // 3
                    if(lastDirection != 1)
                        return 3;
                    return lastDirection;

                default:
                    return lastDirection;

                   
            }
        }

        public void setGameOver(Boolean gameState){
            gameOver = gameState;
            //Environment.Exit(1);
        }

        public bool getGameOver() {
            return gameOver;
        }

       /* public static int readKeys(int last)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
             if (cki.Key == ConsoleKey.Escape)
                // set game over

            else if (cki.Key == ConsoleKey.Spacebar)
                pause = !pause;

            if (cki.Key == ConsoleKey.UpArrow && last != 2)
                return 0;

            else if (cki.Key == ConsoleKey.RightArrow && last != 3)
                return 1;

            else if (cki.Key == ConsoleKey.DownArrow && last != 0)
                return 2;

            else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
                return 3;
            else return 9;
        }*/
    }
 }



