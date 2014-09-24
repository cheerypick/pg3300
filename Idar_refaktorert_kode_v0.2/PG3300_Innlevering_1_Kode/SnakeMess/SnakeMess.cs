using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// I reccomend watching this for getting a felling of the code while reading. Enjoy.
using System.Threading;

namespace SnakeMess{

    internal class SnakeMess
    {
        public static void Main(string[] arguments)
        {
            // Boolean for running the game
            const bool runGame = true;

            // Direction of movement
            var newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left

            // Gamemaster
            var gm = new GameMaster();

            // Screen (output handler)
            var screen = new screenController();

            // Direction moved at last update
            var lastDirectionMoved = newDir;

            // Get width and height from screen handler
            int boardW = screen.getWidth(), boardH = screen.getHeight();

            // Create snake
            var snake = new Snake();

            // And pellet (Katrine: food)
            var pellet = new pellet(0, 0);

            // Add 4 bodies to snake
            snake.addBody(4, 10, 10);

            // place pellet in world
            pellet.placePellet(snake, boardH, boardW);

            // Create a stopwatch for thread-waiting
            var t = new Stopwatch();
            t.Start();

            // Running the game
            while (runGame)
            {

                // Change direction if key is pressed
                newDir = gm.ReadKeys(lastDirectionMoved);
                // Set direction of snake
                snake.setDirection(newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (newDir != 5)
                {
                    // Wait 100 millis
                    if (t.ElapsedMilliseconds < 100)
                    {
                        continue;
                    }
                    // Restart counter
                    t.Restart();

                    // Get new snakehead
                    var newHead = snake.getNewHead();

                    // Check if snake is eating pellet
                    if (pellet.checkIfEatingPellet(snake))
                    {
                        // Grow snake
                        snake.grow = true;
                        // Place new pellet
                        pellet.placePellet(snake, boardH, boardW);
                    }

                    // Check if snake eats himself, currenty disabled
                    snake.checkSelfCannibalism(gm, newHead);
                    if (gm.getGameOver())
                    {
                        break;
                    }


                    // Update screen
                    screen.updateScreen(snake, pellet, newHead);

                    // Update last direction. Shark bois 4ever
                    lastDirectionMoved = newDir;

                }
            }
        }
    }
}
		
	
