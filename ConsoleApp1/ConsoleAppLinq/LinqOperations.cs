using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLinq
{

    public class LinqOperations
    {
        //Given an array of integers, write a query that returns list of numbers greater than 30 and
        //less than 100.
        public static void ArrayInteger()
        {
            Console.WriteLine("Write a query by using LINQ that returns list of numbers greater than 30 and less than 100.:");
            int[] numbers = { 10, 40, 50, 70, 80, 110 };

            var result = numbers.Where(n => n > 30 && n < 100).ToList();

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        public static void MostFrequentCharacter()
        {
            Console.WriteLine("Input some word by using LINQ to check Most Frequent Character:");
            string input = Console.ReadLine();

            char mostFrequentCharacter = input
                .Where(char.IsLetter) // Consider only letters
                .GroupBy(char.ToLower) // Group by lowercase character
                .OrderByDescending(group => group.Count()) // Order by count in descending order
                .Select(group => group.Key) // Select the character from each group
                .FirstOrDefault(); // Get the first character

            Console.WriteLine("The most frequent character is: " + mostFrequentCharacter);
        }

        

        public static void WeekDays()
        {
            Console.WriteLine("Write a query in c# using LINQ that returns names of days.:");
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            var dayNamesQuery = from day in daysOfWeek select day;

            foreach (var dayName in dayNamesQuery)
            {
                Console.WriteLine(dayName);
            }
        }

    }

}
