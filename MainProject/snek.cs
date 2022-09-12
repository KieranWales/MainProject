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
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string snake = "";
            int[] pos = { 5, 5 };

            while (pos[0] < 9 && pos[1]> 0)
            {
                Console.Clear();

                Console.WriteLine("#######################################################################################################################");
                for(int i = 0; i < 27; i++)
                {
                    Console.WriteLine("#                                                                                                                     #");
                }
                Console.WriteLine("#######################################################################################################################");

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
