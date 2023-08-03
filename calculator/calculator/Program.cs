namespace calculator
{
    public class Program
    {
      
        public static void Main()
        {
            string run;
            do
            {
                Calcifunction calci = new Calcifunction();
                double num1, num2;
                Console.Write("Enter the first number: ");
                num1 = double.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                num2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Select an operation (+, -, *, /): ");
                char operat = char.Parse(Console.ReadLine());
                double result;

                switch (operat)
                {
                    case '+':
                        result = calci.Add(num1, num2);
                        Console.WriteLine($"Result: {num1} + {num2} = {result}");
                        break;

                    case '-':
                        result = calci.Sub(num1, num2);
                        Console.WriteLine($"Result: {num1} - {num2} = {result}");
                        break;

                    case '*':
                        result = calci.Mul(num1, num2);
                        Console.WriteLine($"Result: {num1} * {num2} = {result}");
                        break;

                    case '/':
                        if (num2 != 0)
                        {
                            result = calci.Div(num1, num2);
                            Console.WriteLine($"Result: {num1} / {num2} = {result}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Cannot divide by zero!");
                        }
                        break;

                    default:
                        Console.WriteLine("Error: Invalid operation!");
                        break;
                }

                Console.WriteLine("Do you want to continue? (Y/N):");
                run = Console.ReadLine();
                run.ToLower();

            } while (run.Equals("y"));

            Console.WriteLine("---Exit----");



        }
    }
}
