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
            _inputKey = Console.ReadKey();
            
            
            switch (_inputKey.Key) {
              /*  case ConsoleKey.Escape:
                    return 4;
                case ConsoleKey.Spacebar:
                    return 5;*/
                case ConsoleKey.UpArrow:
                    if(lastDirection != 0)
                        return 0;
                    return -1;
                case ConsoleKey.RightArrow :
                    if(lastDirection != 1)
                    return 1;
                    return -1;
                case ConsoleKey.DownArrow:
                    if(lastDirection != 2)
                    return 2;
                    return -1;
                case ConsoleKey.LeftArrow:
                    if(lastDirection != 3)
                    return 3;
                    return -1;

                default:
                    return -1;

                   
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
            /* if (cki.Key == ConsoleKey.Escape)
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



