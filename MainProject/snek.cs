using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace MainProject
{
    class Snek
    {
        static ConsoleKey direction = ConsoleKey.RightArrow;
        static int snakeLen = 3;
        static int[] pos = { 5, 5 };
        static System.Timers.Timer overallTimer = new System.Timers.Timer();
        static List<int[]> oldPos = new List<int[]>();
        static List<int[]> apples = new List<int[]>();
        static Random randNum = new Random();
        static int[] increase = { 0, 0 };
        static ConsoleKey prevKey = ConsoleKey.RightArrow;
        static bool quit = false;
        static bool paused = false;
        static ConsoleKey storedKey;
        static bool exit;

        static void Main(string[] args)
        {
            while (!(exit))
            {
                overallTimer.Interval = 100;
                overallTimer.Enabled = true;
                overallTimer.Elapsed += Update;
                overallTimer.Elapsed += Screen;

                Setup();

                while (pos[0] < Console.WindowWidth - 3 && pos[0] > 0 && pos[1] < Console.WindowHeight - 1 && pos[1] > 0 && !(quit) && !(exit)) { GetInput(); }
                overallTimer.Enabled = false;
                Reset();
            }
        }

        static void Setup()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("#######################################################################################################################");
            for (int i = 0; i < 28; i++)
            {
                Console.WriteLine("#                                                                                                                     #");
            }
            Console.Write("#######################################################################################################################");
            Console.ResetColor();

            for (int i = 0; i < 4; i++)
            {
                SpawnApple();
            }
        }
            
        static void Screen(object source, ElapsedEventArgs e)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            try
            {
                Console.SetBufferSize(120, 30);
            }
            catch (Exception error){}
            Console.CursorVisible = false;
        }

        static void Update(object source, ElapsedEventArgs e)
        {
            bool spawn = false;
            int[] removeApple = { };
            
            while (oldPos.Count() >= snakeLen)
            {
                Console.SetCursorPosition(oldPos[0][0], oldPos[0][1]);
                Console.Write(" ");
                try
                {
                    oldPos.RemoveAt(0);
                }
                catch(Exception error){}
            }

            foreach (int[] position in oldPos)
            {
                if (pos[0] == position[0] && pos[1] == position[1])
                {
                    quit = true;
                }
                Console.SetCursorPosition(position[0], position[1]);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" ");
                Console.ResetColor();
            }

            foreach (int[] apple in apples)
            {
                if (apple[0] == pos[0] && apple[1] == pos[1])
                {
                    removeApple = apple;
                    snakeLen += 1;
                    spawn = true;
                }
            }

            apples.Remove(removeApple);

            if (spawn)
            {
                SpawnApple();
            }

            if (!(pos[0] < Console.WindowWidth - 3 && pos[0] > 0 && pos[1] < Console.WindowHeight - 1 && pos[1] > 0))
            {
                quit = true;
            }

            if (quit)
            {
                overallTimer.Enabled = false;
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, (Console.WindowHeight / 2) - 3);
                Console.Write("You LOSE");
                Console.SetCursorPosition((Console.WindowWidth - 22) / 2, (Console.WindowHeight / 2) - 2);
                Console.Write("Press any key to exit.");
                return;
            }

            Console.SetCursorPosition(pos[0], pos[1]);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("'");
            Console.ResetColor();
            oldPos.Add(new int[] {pos[0], pos[1]});

            if (direction == ConsoleKey.UpArrow && prevKey != ConsoleKey.DownArrow)
            {
                increase[0] = 0;
                increase[1] = -1;
                overallTimer.Interval = 200;
                prevKey = direction;
            }
            else if (direction == ConsoleKey.DownArrow && prevKey != ConsoleKey.UpArrow)
            {
                increase[0] = 0;
                increase[1] = 1;
                overallTimer.Interval = 200;
                prevKey = direction;
            }
            else if (direction == ConsoleKey.LeftArrow && prevKey != ConsoleKey.RightArrow)
            {
                increase[0] = -1;
                increase[1] = 0;
                overallTimer.Interval = 100;
                prevKey = direction;
            }
            else if (direction == ConsoleKey.RightArrow && prevKey != ConsoleKey.LeftArrow)
            {
                increase[0] = 1;
                increase[1] = 0;
                overallTimer.Interval = 100;
                prevKey = direction;
            }

            pos[0] += increase[0];
            pos[1] += increase[1];
        }

        static void GetInput()
        {
            direction = System.Console.ReadKey(true).Key;
            
            if (direction == ConsoleKey.P)
            {
                direction = ConsoleKey.RightArrow;
                overallTimer.Enabled = !(overallTimer.Enabled);
                paused = !(paused);
                if (paused)
                {
                    storedKey = prevKey;
                    Console.SetCursorPosition((Console.WindowWidth - 12) / 2, (Console.WindowHeight / 2) - 3);
                    Console.Write("Game Paused.");
                    Console.SetCursorPosition((Console.WindowWidth - 18) / 2, (Console.WindowHeight / 2) - 2);
                    Console.Write("Press P to unpause");
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - 12) / 2, (Console.WindowHeight / 2) - 3);
                    Console.Write("            ");
                    Console.SetCursorPosition((Console.WindowWidth - 18) / 2, (Console.WindowHeight / 2) - 2);
                    Console.Write("                  ");

                    foreach (int[] applePos in apples)
                    {
                        Console.SetCursorPosition(applePos[0], applePos[1]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("&");
                        Console.ResetColor();
                    }

                    direction = storedKey;
                }
            }
            else if (direction == ConsoleKey.Escape)
            {
                exit = true;
            }
        }

        static void SpawnApple()
        {
            int[] prevPos = pos;
            int appPos1 = randNum.Next(1, Console.WindowWidth - 3);
            int appPos2 = randNum.Next(1, Console.WindowHeight - 1);
            while (apples.Contains(new int[] {appPos1, appPos2 }) || oldPos.Contains(new int[] { appPos1, appPos2 }))
            {
                appPos1 = randNum.Next(1, Console.WindowWidth - 3);
                appPos2 = randNum.Next(1, Console.WindowHeight - 1);
            }
            apples.Add(new int[] {appPos1, appPos2});
            Console.SetCursorPosition(appPos1, appPos2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("&");
            Console.ResetColor();
            Console.SetCursorPosition(prevPos[0], prevPos[1]);
        }

        static void Reset()
        {
            direction = ConsoleKey.RightArrow;
            snakeLen = 3;
            pos = new int[] { 5, 5 };
            overallTimer = new System.Timers.Timer();
            oldPos = new List<int[]>();
            apples = new List<int[]>();
            randNum = new Random();
            increase = new int[] { 0, 0 };
            prevKey = ConsoleKey.RightArrow;
            quit = false;
            paused = false;
            storedKey = ConsoleKey.RightArrow;
        }
    }
}

