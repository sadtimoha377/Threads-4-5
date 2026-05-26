using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleGame
{
    internal class Program
    {
        static int playerX = 40;
        static int playerY = 20;

        static bool pause = false;

        static bool gameOver = false;

        static object locker = new object();

        static Random random = new Random();

        static List<(int x, int y)> snowflakes =
            new List<(int x, int y)>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.SetWindowSize(100, 30);

            Thread snowThread = new Thread(SnowAnimation);

            snowThread.Start();

            while (!gameOver)
            {
                if (!pause)
                {
                    DrawScene();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key =
                        Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        pause = !pause;
                    }

                    if (!pause)
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.W:

                                if (playerY > 1)
                                {
                                    playerY--;
                                }

                                break;

                            case ConsoleKey.S:

                                if (playerY < 26)
                                {
                                    playerY++;
                                }

                                break;

                            case ConsoleKey.A:

                                if (playerX > 1)
                                {
                                    playerX--;
                                }

                                break;

                            case ConsoleKey.D:

                                if (playerX < 95)
                                {
                                    playerX++;
                                }

                                break;
                        }
                    }
                }

                Thread.Sleep(50);
            }
        }

        static void SnowAnimation()
        {
            while (!gameOver)
            {
                if (!pause)
                {
                    lock (locker)
                    {
                        for (int i = 0; i < snowflakes.Count; i++)
                        {
                            snowflakes[i] =
                            (
                                snowflakes[i].x,
                                snowflakes[i].y + 1
                            );
                        }

                        snowflakes.RemoveAll
                        (
                            s => s.y > 28
                        );

                        snowflakes.Add
                        (
                            (
                                random.Next(1, 98),
                                1
                            )
                        );
                    }
                }

                Thread.Sleep(100);
            }
        }

        static void DrawScene()
        {
            lock (locker)
            {
                Console.Clear();

                DrawBorder();

                DrawGround();

                DrawSnow();

                DrawPlayer();

                if (pause)
                {
                    Console.SetCursorPosition(45, 10);

                    Console.Write("PAUSE");
                }
            }
        }

        static void DrawPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);

            Console.Write("@");
        }

        static void DrawSnow()
        {
            foreach (var snow in snowflakes)
            {
                Console.SetCursorPosition
                (
                    snow.x,
                    snow.y
                );

                Console.Write("*");
            }
        }

        static void DrawGround()
        {
            for (int i = 1; i < 99; i++)
            {
                Console.SetCursorPosition(i, 27);

                Console.Write("=");
            }
        }

        static void DrawBorder()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(i, 0);

                Console.Write("#");

                Console.SetCursorPosition(i, 29);

                Console.Write("#");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(0, i);

                Console.Write("#");

                Console.SetCursorPosition(99, i);

                Console.Write("#");
            }
        }
    }
}