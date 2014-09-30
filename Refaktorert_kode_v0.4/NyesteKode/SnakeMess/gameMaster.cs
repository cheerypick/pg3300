using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    // Game master is master of gamez
    public class GameMaster{
        private ConsoleKeyInfo _inputKey;
        private Boolean gameOver;

	    public GameMaster()
	    {
		    
	    }
		
	    // Method for reading keys
        public int ReadKeys(int lastDirection)  {

            // If key is pressed, read it
            if (Console.KeyAvailable)
                _inputKey = Console.ReadKey(true);


                // Return diffrent ints for different inputs from different keys, different
                switch (_inputKey.Key){
                        /*  case ConsoleKey.Escape: // THIS IS FOR ESCAPE DO NOT REMOVE ME
                    return 4;*/
                    case ConsoleKey.Spacebar:
                        return 5;
                    case ConsoleKey.UpArrow: // 0
                        return lastDirection != 2 ? 0 : lastDirection;

                    case ConsoleKey.RightArrow: // 1
                        return lastDirection != 3 ? 1 : lastDirection;

                    case ConsoleKey.DownArrow: // 2
                        return lastDirection != 0 ? 2 : lastDirection;

                    case ConsoleKey.LeftArrow: // 3
                        return lastDirection != 1 ? 3 : lastDirection;

                    default:
                        return lastDirection;


                }
        }

        // Set game over
        public void setGameOver(Boolean gameState){

            this.gameOver = gameState;
            //Environment.Exit(1); // FOR EXITING GAME
        }

	    public bool getGameOver()
	    {
		    return gameOver;
	    }
    }
 }



