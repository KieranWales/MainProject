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
            string snake = "";
            int[] pos = { 5, 5 };

            while (pos[0] < 9 && pos[1]> 0)
            {
                for (int a = 0; a < 20; a++)
                {
                    Console.WriteLine("\n");
                }

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
