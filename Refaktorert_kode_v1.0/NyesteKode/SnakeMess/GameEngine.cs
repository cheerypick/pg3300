using System;
using System.Diagnostics;

namespace SnakeMess {

    internal class GameEngine {
        private ScreenHandler screen;
        private InputReader _inputReader;
        private int _lastDirectionMoved, _newDir, boardW, boardH;
        private Snake snake;
        private Pellet pellet;
        private Stopwatch timer;
        private Boolean runGame;
        private Coord _newHead;
        private Border border;

		// For å finne ut om man spiser normal eller special pellet
	    private bool _specialPellet = false;

		// Hvor mange poeng og hvor mye snake skal vokse når du spiser en special pellet.
		public static int SpecialPelletNumber { get; set; }


	    private int _normalPelletsEatenUntilSpecial;
		Random random = new Random();
        public GameEngine() {
			
			/*		Default verdier		*/
			// Første gang spillet skal bestemme når en special pellet skal spawne.
			_normalPelletsEatenUntilSpecial = random.Next(1, 10);
	        SpecialPelletNumber = 3;

            // Cre
            border = new Border();
            border.write();
            ShowScore = 0;
            // Boolean for running the game
            runGame = true;

            // Gamemaster
            _inputReader = new InputReader();

            // Screen (output handler)
            screen = new ScreenHandler();

            // Get width and height from screen handler
            boardW = screen.GetWidth();
            boardH = screen.GetHeight();

            // Create snake
            snake = new Snake();

            // Create pellet
            pellet = new Pellet(0, 0);

            // Add 4 bodies to snake
            snake.addBody(4, 10, 10);


            // place pellet in world
            pellet.PlacePellet(snake, boardH, boardW);


            // Create a stopwatch for thread-waiting
            timer = new Stopwatch();
            timer.Start();
        }

        // Skal være static method
        public static int ShowScore { get; set; }

       // StreamWriter writer = new StreamWriter("test.txt");
        public void RunGame() {

            // Running the game
            while (runGame) {
                
                // Change direction if key is pressed
                _newDir = _inputReader.ReadKeys(_lastDirectionMoved);
                // Set direction of snake
                snake.setDirection(_newDir);

                // newDir = 5 betyr pause. We are still in alpha
                if (_newDir == 5) continue;
                
                // Wait 100 millis
                if (timer.ElapsedMilliseconds < 100)  continue;
                
                // Restart counter
                timer.Restart();

                // Get new snakehead
                _newHead = snake.GetNewHead();

                Menu.DrawInGameScore(ShowScore);

                // Check if snake is eating pellet, do stuff if it is
                CheckIfEatingPellet();

                // Check if snake is crashing in border
                if (border.checkCollision(_newHead) || snake.CheckSelfCannibalism(_inputReader, _newHead)) break;

                // Update screen

                screen.UpdateScreen(snake, pellet, _newHead);

                // Update last direction. Shark bois 4ever
                _lastDirectionMoved = _newDir;
            }
        }

        // Check if snake is crashing in borders
        public bool CheckIfBorderCrash()  {
            foreach (Coord borderCoord in border.GetBorder())  {
            if (borderCoord.Equals(_newHead)) return true;
        }

    return false;
        }

        // Check is snake is eating pellet/apple
        public void CheckIfEatingPellet() {
            if (!pellet.CheckIfEatingPellet(snake)) return;

			// Setter forskjellig score når du spiser normal og special pellet

	        if (_specialPellet)
	        {
				ShowScore += SpecialPelletNumber;
				SpecialPelletExtraGrow = true;
	        }
	        else
	        {
		        ShowScore++;
	        }
		        
            // Grow snake
            snake.grow = true;
			
			// Special kommer hvert random poeng.
			if (ShowScore % _normalPelletsEatenUntilSpecial == 0)
	        {
				// Generer nytt tall hver gang du spiser en special pellet
				_normalPelletsEatenUntilSpecial = random.Next(1, 10);
		        _specialPellet = true;
		        
		        pellet.PlaceSpecialPellet(snake, boardH, boardW);
	        }
	        else
	        {
		        _specialPellet = false;
		        pellet.PlacePellet(snake, boardH, boardW);
	        }

        }

	    public static bool SpecialPelletExtraGrow = false;
    }
}
