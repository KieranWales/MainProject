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
        

        static void Main(string[] args)
        {
            string snake = "";
            int[] pos = { 5, 5 };

            Setup();

            while (pos[0] < 9 && pos[1] > 0)
            {
                Screen();
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
    }
}

