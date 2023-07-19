using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string run;
            do {

                Console.WriteLine("Enter two numbers:");
                Console.Write("Number 1: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Number 2: ");
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.Write("Enter your choice (1-4): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Calculator.Add(num1, num2);
                        break;
                    case 2:
                        Calculator.Subtract(num1, num2);
                        break;
                    case 3:
                        Calculator.Multiply(num1, num2);
                        break;
                    case 4:
                        Calculator.Divide(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                Console.WriteLine("run program again y/n");
                run = Console.ReadLine();
                run.ToLower();
            } while (run == "y");

            Console.WriteLine("----Exit-----");
            }
    }
}

