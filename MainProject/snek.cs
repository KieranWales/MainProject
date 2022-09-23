using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MainProject
{
    class Snek
    {
        // map = [9, 9];
        static string direction = "right";
        static string snake = "";
        static int[] pos = { 5, 5 };
        static System.Timers.Timer overallTimer = new System.Timers.Timer();
        static List<int[]> oldPos = new List<int[]>();

        static void Main(string[] args)
        {
            overallTimer.Interval = 100;
            overallTimer.Enabled = true;
            overallTimer.Elapsed += Update;
            overallTimer.Elapsed += Screen;

            Setup();

            while (pos[0] < Console.WindowWidth && pos[0] > 0 && pos[1] < Console.WindowHeight && pos[1] > 0){}
            overallTimer.Enabled = false;
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
            
        static void Screen(object source, ElapsedEventArgs e)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.SetBufferSize(120, 30);
        }

        static void gameplay()
        {
            Console.ReadLine();
        }

        static void Update(object source, ElapsedEventArgs e)
        {
            while (oldPos.Count() > snake.Length)
            {
                Console.SetCursorPosition(oldPos[0][0], oldPos[0][1]);
                Console.Write(" ");
                oldPos.RemoveAt(0);
            }

            foreach (int[] position in oldPos)
            {
                Console.SetCursorPosition(position[0], position[1]);
                Console.Write("0");
            }

            Console.SetCursorPosition(pos[0], pos[1]);
            Console.Write("0");
            oldPos.Add(new int[] {pos[0], pos[1]});

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

        static void GetInput()
        {

        }
    }
}

