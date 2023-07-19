using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Calculator
    {
        public static void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"The sum of {a} and {b} is: {result}");
        }

        public static void Subtract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine($"The difference between {a} and {b} is: {result}");
        }

        public static void Multiply(int a, int b)
        {
            int result = a * b;
            Console.WriteLine($"The product of {a} and {b} is: {result}");
        }

        public static void Divide(int a, int b)
        {
            if (b != 0)
            {
                int result = a / b;
                Console.WriteLine($"The division of {a} by {b} is: {result}");
            }
            else
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
    }
}
