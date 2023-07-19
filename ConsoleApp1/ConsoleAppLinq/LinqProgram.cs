using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLinq
{
    class Linq
    {
        static void Main(string[] args)
        {
            string run;
            do
            {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Array Integer");
            Console.WriteLine("2. Most Frequent Character");
            Console.WriteLine("3. 7 week Days");
            Console.Write("Enter your choice (1-3): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();


            switch (choice)
            {
                case 1:
                    LinqOperations.ArrayInteger();
                    break;

                case 2:
                    LinqOperations.MostFrequentCharacter();
                    break;

                case 3:
                    LinqOperations.WeekDays();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
                Console.WriteLine();
                Console.WriteLine("Run Program Again y/n");
                run = Console.ReadLine();
                run.ToLower();
                Console.WriteLine();
            } while (run == "y");

            Console.WriteLine("----Exit-----");
        }
    }
    
}
