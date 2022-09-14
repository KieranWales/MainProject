using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class snek
    {
        // map = [9, 9];
        public string snake = "";
        public int[] pos = { 5, 5 };
        static void Main(string[] args)
        {
            Setup();
            while (pos[0] < 9 && pos[1] > 0)
            {

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
            

        static void gameplay()
        {
            Console.ReadLine();
        }
    }
}

