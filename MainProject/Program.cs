using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPizzas;
            Console.WriteLine("How many pizzas would you like to eat?");
            numPizzas = int.Parse(Console.ReadLine());

            for (int i = 0; i < numPizzas; i++)
            {
                Console.WriteLine("Eat pizza number " + (i + 1));
            }

            Console.WriteLine("\nPress enter to exit");
            Console.ReadLine();
        }
    }
}
