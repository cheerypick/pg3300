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
	internal class Coord
	{
		public const string Ok = "Ok";

		public int X;
		public int Y;

		public Coord(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Coord(Coord input)
		{
			X = input.X;
			Y = input.Y;
		}
	}

	internal class SnakeMess
	{
		public static void Main(string[] arguments)
		{
			bool gameOver = false, pause = false, inUse = false;
			short newDirection = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDirection;
			int boardWidth = Console.WindowWidth, boardHeight = Console.WindowHeight;
			var randomNumberGenerator = new Random();
			var app = new Coord();
			var snake = new List<Coord>();
			snake.Add(new Coord(10, 10));
			snake.Add(new Coord(10, 10));
			snake.Add(new Coord(10, 10));
			snake.Add(new Coord(10, 10));
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(10, 10);
			Console.Write("@");
			while (true)
			{
				app.X = randomNumberGenerator.Next(0, boardWidth);
				app.Y = randomNumberGenerator.Next(0, boardHeight);
				bool spot = true;
				foreach (Coord i in snake)
					if (i.X == app.X && i.Y == app.Y)
					{
						spot = false;
						break;
					}
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
					var tail = new Coord(snake.First());
					var head = new Coord(snake.Last());
					var newH = new Coord(head);
					switch (newDirection)
					{
						case 0:
							newH.Y -= 1;
							break;
						case 1:
							newH.X += 1;
							break;
						case 2:
							newH.Y += 1;
							break;
						case 3:
						default:
							newH.X -= 1;
							break;
					}
					if (newH.X < 0 || newH.X >= boardWidth)
						gameOver = true;
					else if (newH.Y < 0 || newH.Y >= boardHeight)
						gameOver = true;
					if (newH.X == app.X && newH.Y == app.Y)
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
								foreach (Coord i in snake)
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
						foreach (Coord x in snake)
							if (x.X == newH.X && x.Y == newH.Y)
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
						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Green;
						Console.SetCursorPosition(newH.X, newH.Y);
						Console.Write("@");
						last = newDirection;
					}
				}
			}
		}
	}
}