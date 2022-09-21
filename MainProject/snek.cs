using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Snek
    {
        // map = [9, 9];
        static string direction = "right";
        static System.Timers.Timer overallTimer = new System.Timers.Timer();

        static void Main(string[] args)
        {
            overallTimer.Interval = 1000;
            overallTimer.Enabled = true;

            string snake = "";
            int[] pos = { 5, 5 };

            Setup();

            while (pos[0] < 9 && pos[1] > 0)
            {
                Screen();
                Update(pos, direction);
            }
        }

        static void Setup()
        {
            Console.WriteLine("#######################################################################################################################");
            for (int i = 0; i < 27; i++)
            {
                Console.WriteLine("#                                                                                                                     #");
            }
            Console.WriteLine("#######################################################################################################################");

            Console.CursorVisible = false;
        }
            
        static void Screen()
        {
            if (Console.WindowWidth != 120 || Console.WindowHeight != 30)
            {
                Console.WindowWidth = 120;
                Console.WindowHeight = 30;
                Console.SetBufferSize(120, 30);
            }
        }

        static void gameplay()
        {
            Console.ReadLine();
        }

        static void Update(int[] pos, string direction)
        {
            Console.SetCursorPosition(pos[0], pos[1]);
            Console.Write("0");
            string.Concat(Enumerable.Repeat("", 2));

            if (direction == "up")
            {
                pos[1] += 1;
            }
            else if (direction == "down")
            {
                pos[1] -= 1;
            }
            else if (direction == "left")
            {
                pos[0] -= 1;
            }
            else if (direction == "right")
            {
                pos[0] += 1;
            }
        }
    }
}

