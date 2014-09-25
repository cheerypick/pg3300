using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



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
	internal class Position
	{
		//public const string Ok = "Ok";

		public int X;
		public int Y;

		public Position(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Position(Position input)
		{
			X = input.X;
			Y = input.Y;
		}
	}

	internal class SnakeNotMess
	{
		public static void Main(string[] arguments)
		{
			bool gameOver = false, pause = false, inUse = false;
			short newDirection = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDirection;
			int boardWidth = Console.WindowWidth, boardHeight = Console.WindowHeight;
			var randomNumberGenerator = new Random();
			var app = new Position();
			var snake = new List<Position>
			{
				new Position(10, 10),
				new Position(10, 10),
				new Position(10, 10),
				new Position(10, 10)
			};
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10, 10);
			Console.Write("@");
			while (true)
			{
				app.X = randomNumberGenerator.Next(0, boardWidth);
				app.Y = randomNumberGenerator.Next(0, boardHeight);
				bool spot = snake.All(i => i.X != app.X || i.Y != app.Y);
				if (spot)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.SetCursorPosition(app.X, app.Y);
					Console.Write("$");
					break;
				}
			}

			var timer = new Stopwatch();
			timer.Start();
			while (!gameOver)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
					
					{
							
					}
					if (consoleKeyInfo.Key == ConsoleKey.Escape)
						gameOver = true;
					else if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (consoleKeyInfo.Key == ConsoleKey.UpArrow && last != 2)
						newDirection = 0;
					else if (consoleKeyInfo.Key == ConsoleKey.RightArrow && last != 3)
						newDirection = 1;
					else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && last != 0)
						newDirection = 2;
					else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow && last != 1)
						newDirection = 3; 
				}
				if (!pause)
				{
					if (timer.ElapsedMilliseconds < 100)
						continue;
					timer.Restart();
					var tail = new Position(snake.First());
					var head = new Position(snake.Last());
					var newHead = new Position(head);
					switch (newDirection)
					{
						case 0:
							newHead.Y -= 1;
							break;
						case 1:
							newHead.X += 1;
							break;
						case 2:
							newHead.Y += 1;
							break;
						case 3:
						default:
							newHead.X -= 1;
							break;
					}
					if (newHead.X < 0 || newHead.X >= boardWidth)
						gameOver = true;
					else if (newHead.Y < 0 || newHead.Y >= boardHeight)
						gameOver = true;
					if (newHead.X == app.X && newHead.Y == app.Y)
					{
						if (snake.Count + 1 >= boardWidth*boardHeight)
							// No more room to place apples -- game over.
							gameOver = true;
						else
						{
							while (true)
							{
								app.X = randomNumberGenerator.Next(0, boardWidth);
								app.Y = randomNumberGenerator.Next(0, boardHeight);
								bool found = true;
								foreach (Position i in snake)
									if (i.X == app.X && i.Y == app.Y)
									{
										found = false;
										break;
									}
								if (found)
								{
									inUse = true;
									break;
								}
							}
						}
					}
					if (!inUse)
					{
						snake.RemoveAt(0);
						foreach (Position x in snake)
							if (x.X == newHead.X && x.Y == newHead.Y)
							{
								// Death by accidental self-cannibalism.
								gameOver = true;
								break;
							}
					}
					if (!gameOver)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.SetCursorPosition(head.X, head.Y);
						Console.Write("O");
						if (!inUse)
						{
							Console.SetCursorPosition(tail.X, tail.Y);
							Console.Write(" ");
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.SetCursorPosition(app.X, app.Y);
							Console.Write("$");
							inUse = false;
						}
						snake.Add(newHead);
						Console.ForegroundColor = ConsoleColor.Green;
						Console.SetCursorPosition(newHead.X, newHead.Y);
						Console.Write("@");
						last = newDirection;
					}
				}
			}
		}
	}
}