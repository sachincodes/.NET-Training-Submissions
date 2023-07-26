using System;

namespace Calc
{
    class Program
    {
        public static double Addition(double d, double f)
        {
            return d + f;
        }
        public static double Subtraction(double d, double f)
        {
            return d - f;
        }
        public static double Multiplication(double d,double f)
        {
            return d * f;
        }
        public static double Division(double d, double f)
        {
            return d / f;
        }
        public static void TakeInput(int ch)
        {
            double a, b;
            bool flag1=true, flag2 = true;
            Console.WriteLine("Enter first number");
            string sd = Console.ReadLine();
            bool sf= double.TryParse(sd, out a);
            if( sf )
            {

            }
            else
            {
                flag1 = false;
            }
            Console.WriteLine("Enter second number");
            string sg = Console.ReadLine();
            bool sf2 = double.TryParse(sg, out b);
            if (sf2)
            {

            }
            else
            {
                    flag2 = false;
            }
            double g = 0.0D;
            if (flag1 && flag2)
            {
                if (ch == 1)
                {
                    g = Addition(a, b);
                    g = Math.Round(g, 6);
                    Console.WriteLine($"Answer is {g}");
                }
                else if (ch == 2)
                {
                    g = Subtraction(a, b);
                    g = Math.Round(g, 6);
                    Console.WriteLine($"Answer is {g}");
                }
                else if (ch == 3)
                {
                    g = Multiplication(a, b);
                    g = Math.Round(g, 6);
                    Console.WriteLine($"Answer is {g}");
                }
                else if (ch == 4)
                {
                    g = Division(a, b);
                    g = Math.Round(g, 6);
                    Console.WriteLine($"Answer is {g}");
                }
            }
            else
            {
                Console.WriteLine("Wrong Choice enter only numbers not strings");
            }

        }
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("****Calculator****");
                Console.WriteLine("Press 1 for Addition");
                Console.WriteLine("Press 2 for Subtraction");
                Console.WriteLine("Press 3 for Multiplication");
                Console.WriteLine("Press 4 for Division");
                Console.WriteLine("Press 5 for Exit");
                Console.WriteLine("Enter your choice");
                string ch1 = Console.ReadLine();
                int ch;
                bool success = int.TryParse(ch1, out ch);
                if (success)
                {

                }
                else
                {
                    ch = 6;
                }
                int a, b, c = 0;
                double v,r,n = 0.0D;
                switch (ch)
                {
                    case 1:                     
                        TakeInput(ch);
                        break;

                    case 2:
                        TakeInput(ch);
                        break;

                    case 3:
                        TakeInput(ch);
                        break;

                    case 4:

                        TakeInput(ch);
                        break;

                    case 5:
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Wrong choice please choose correctly");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}