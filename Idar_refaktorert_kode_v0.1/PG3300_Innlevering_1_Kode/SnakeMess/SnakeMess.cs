using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code though! And I can now (proudly?) say that this is the uggliest short piece of code I've ever worked with! :-)
//          (And yes, it could have been a lot ugglier! But the idea wasn't to make it fuggly-uggly, just funny-uggly, sweet-uggly, or whatever you want to call it.)
//
//          -Tomas
//

namespace SnakeMess
{
    /* partial class Coord{
		//public const string Ok = "Ok";

		public int X;
        public int Y;

	    public Coord(int x = 0, int y = 0){
	        X = x; 
            Y = y;
	    }

	    public Coord(Coord input){
	        X = input.X; 
            Y = input.Y;
	    }
    }*/

    internal class SnakeMess
    {
        public static void Main(string[] arguments)
        {

            bool gg = false, pause = false, inUse = false;
            int newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
            GameMaster gm = new GameMaster();
            screenController screen = new screenController();

            int lastDirectionMoved = newDir;
            int boardW = screen.getWidth(), boardH = screen.getHeight();

            Coord newTail;


            //Random rng = new Random();

            Coord app = new Coord();
            // List<Coord> snake = new List<Coord>();
            Snake snake = new Snake();
            pellet pellet = new pellet(0, 0);

            snake.addBody(4, 10, 10);

            /*TO SCREENCONTROLLER
             * 
             * Console.CursorVisible = false; 
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.SetCursorPosition( 10, 10 ); 
            Console.Write( "@" );*/
            screen.writeStartUp();


            // place ¨pellet in world
            pellet.placePellet(snake, boardH, boardW);
            /*while ( true ){
				app.X = rng.Next( 0, boardW ); 
                app.Y = rng.Next( 0, boardH );
				bool spot = true;

				foreach ( Coord i in snake.getCoords() )
					if ( i.X == app.X && i.Y == app.Y ){
						spot = false;
						break;
					}
				if ( spot ){
					Console.ForegroundColor = ConsoleColor.Red; 
                    Console.SetCursorPosition( app.X, app.Y );          // ????
                    Console.Write( "$" );
					break;
				}
			}*/

            Stopwatch t = new Stopwatch();
            t.Start();

            while (!gg)
            {

               /* if (Console.KeyAvailable)
                    newDir = gm.ReadKeys();*/
                snake.setDirection( gm.ReadKeys(lastDirectionMoved) );

                /*
					if ( cki.Key == ConsoleKey.Escape )
						gg = true;

					else if ( cki.Key == ConsoleKey.Spacebar )
						pause = !pause;

					else if ( cki.Key == ConsoleKey.UpArrow && last != 2 )
						newDir = 0;

					else if ( cki.Key == ConsoleKey.RightArrow && last != 3 )
						newDir = 1;

					else if ( cki.Key == ConsoleKey.DownArrow && last != 0 )
						newDir = 2;

					else if ( cki.Key == ConsoleKey.LeftArrow && last != 1 )
						newDir = 3;*/

                if (!pause)
                {
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();

                    Coord newHead = snake.getNewHead();


                    /*Coord tail = new Coord(snake.getCoords().First());
					Coord head = new Coord(snake.getCoords().Last());
					Coord newH = new Coord(head);
					switch ( newDir ){
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						// case 3:
						default:
							newH.X -= 1;
							break;
					}*/


                    //snake.move();

                    // Sets game over if snake collided with board
                    gm.setGameOver(snake.checkBoardCollision(boardH, boardW));
                    if (gm.getGameOver())
                        break;
                    /*	if ( newH.X < 0 || newH.X >= boardW )
						gg = true;

					else if ( newH.Y < 0 || newH.Y >= boardH )
						gg = true;*/

                    if (pellet.checkIfEatingPellet(newHead)){
                        pellet.placePellet(snake, boardH, boardW);
                    }
                    /*if ( newHead.X == app.X && newHead.Y == app.Y ){
						if ( snake.getCoords().Count + 1 >= boardW * boardH )
							// No more room to place apples -- game over.
							gg = true;

						else{
							while ( true ){
								app.X = rng.Next( 0, boardW ); 
                                app.Y = rng.Next( 0, boardH );
								bool found = true;

								foreach ( Coord i in snake.getCoords() )
									if ( i.X == app.X && i.Y == app.Y ){
										found = false;
										break;
									}
								if ( found ){
									inUse = true;
									break;
								}
							}
						}
					}*/
                    snake.checkSelfCannibalism(gm, newHead);
                    /*if ( !inUse ){
						snake.getCoords().RemoveAt( 0 );
						foreach ( Coord x in snake.getCoords() )
							if ( x.X == newHead.X && x.Y == newHead.Y ){
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}*/

                    screen.updateScreen(snake, pellet, newHead, newDir);
                    /*if ( !gg ){
						Console.ForegroundColor = ConsoleColor.Green; 
                        Console.SetCursorPosition( head.X, head.Y ); 
                        Console.Write( "O" );

						if ( !inUse ){
							Console.SetCursorPosition( tail.X, tail.Y ); 
                            Console.Write( " " );
						}
						else{
							Console.ForegroundColor = ConsoleColor.Red; Console.SetCursorPosition( app.X, app.Y ); 
                            Console.Write( "$" );
							inUse = false;
						}
						snake.getCoords().Add( newH );
						Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition( newH.X, newH.Y ); 
                        Console.Write( "@" );

						last = newDir;
					}*/

                    lastDirectionMoved = newDir;
                }
            }
        }
    }
}
		
	
