using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Program
    { 
        static void Pizza()
        {
            // create a variable to store the integer value of the number of pizzas
            int numPizzas;
            Console.WriteLine("How many pizzas would you like to eat?");

            // take the user input for how many pizzas they would like
            numPizzas = int.Parse(Console.ReadLine());

            // create a loop so that each console message has them eat a different pizza up to their chosen amount
            for (int i = 0; i < numPizzas; i++)
            {
                Console.WriteLine("Eat pizza number " + (i + 1));
            }

            Console.WriteLine("\nPress enter to exit");
            Console.ReadLine();
        }
    }
}
