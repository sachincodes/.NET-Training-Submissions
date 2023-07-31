using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class User
    {

        //Q1 Number should lie between 30 and 100
        public static void NumberRange()
        {
            Console.WriteLine("enter size of list");
            int size = int.Parse(Console.ReadLine());
            List<int> li = new List<int>(size);
            for(int i=0;i<size;i++){
                int numbers = int.Parse(Console.ReadLine());
                li.Add(numbers);
            }
            var result = li.Where(x => x > 30 && x<100);
            foreach(var x in result)
            {
                Console.WriteLine(x);
            }
        }

        // Q2. Minimum 5 alphabets in a word and also in UpperCase 
        public static void MininmumLength()
        {
            Console.WriteLine("enter the numbers of words in the list you want");
            int size = int.Parse(Console.ReadLine());
            List<string> li = new List<string>(size);
            for (int i = 0; i < size; i++)
            {
                string words = Console.ReadLine();
                li.Add(words);
            }

            var length5words = li.Where(x => x.Length > 5).Select(s => s.ToUpper());
            foreach (string word in length5words)
            {
                Console.WriteLine(word);
            }
        }
        // Q3. Select word starts with 'a' and end with 'm'
        public static void SelectWord()
        {
            Console.WriteLine("enter the numbers of words in the list you want");
            int size = int.Parse(Console.ReadLine());
            List<string> li = new List<string>(size);
            for (int i = 0; i < size; i++)
            {
                string word = Console.ReadLine();
                li.Add(word);
            }
            Console.WriteLine();
            var result = li.Where(x => x.StartsWith('a') && x.EndsWith('m'));
            foreach (string word in result)
            { Console.WriteLine(word); }
        }
        // Q4. Top 5 numbers in a list
        public static void TopFive()
        {
            Console.WriteLine("Enter the size of list");
            int size = int.Parse(Console.ReadLine());
            List<int> li = new List<int>(size);
            Console.WriteLine("Enter the items");
            for (int i = 0; i < size; i++)
            {
                int num = int.Parse(Console.ReadLine());
                li.Add(num);
            }
            Console.WriteLine();
            var result = li.OrderByDescending(x => x).Take(5);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }

        // Q5. Square greater than 20
        public static void SquareGreat20()
        {
            List<int> li = new List<int>() { 7, 3, 30 };
            var numbers = li.Where(x => x * x > 20);
            foreach (var item in numbers)
            {
                Console.Write($"{item}-{item * item}, ");
            }
        }

        // Q6. Replace substring
        public static void ReplaceSubstring()
        {
            List<string> list = new List<string>() { "learn", "current", "deal" };
            var k = list.Select(x => x.Contains("ea") ? x.Replace("ea", "*") : x);
            foreach (var item in k)
            {
                Console.Write(item + " ");
            }
        }

        // Q7. Last Word Containing
        public static void LastWord()
        {
            List<string> li = new List<string>() { "plane", "ferry", "car", "bike" };
            var result = li.OrderBy(x => x).LastOrDefault(x => x.Contains("e"));
            Console.WriteLine($"{result}");
        }

        // Q8. Shuffle an array
        public static void ShuffleArray()
        {
            Console.WriteLine("Enter the size of array");
            int size = int.Parse(Console.ReadLine());
            List<int> li = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                int number = int.Parse(Console.ReadLine());
                li.Add(number);
            }
            var d = new Random();
            var k = li.OrderBy(x => d.Next());
            foreach (var item in k)
            {
                Console.Write($"{item} ");
            }

        }

        // Q9. Decrypte the Encrypted string
        public static void Decrypt()
        {
            char[] arr = { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };
            Console.WriteLine("Enter the string in encrypted form like %^*(");
            var encrypt = Console.ReadLine();
            var dec = string.Join("", encrypt.Select(c => Array.IndexOf(arr, c)));
            foreach (var x in dec)
            {
                Console.Write(x);
            }
            Console.WriteLine();
        }

        // Q10. Most frequent character in a word
        public static void MostFrequent()
        {
            Console.WriteLine("enter the word");
            string word = Console.ReadLine();
            var res = word.GroupBy(x => x).OrderByDescending(x => x.Count()).First();
            Console.WriteLine(res.Key);

        }

        // Q11. Unique Values in a list of words
        public static void UniqueValue()
        {
            Console.WriteLine("enter the numbers of words in the list you want");
            int.TryParse(Console.ReadLine(), out int size);
            List<string> li = new List<string>(size);
            for (int i = 0; i < size; i++)
            {
                string? word = Console.ReadLine();
                if(!string.IsNullOrEmpty(word))
                {
                   li.Add(word);
                }
            }
            Console.WriteLine();
            var resultword = li.GroupBy(x=> x).Where(x => x.Count() == 1).ToList();
            foreach (var result in resultword)
            {
                Console.WriteLine(result.Key);
            }
        }

        // Q12. Uppercase only
        public static void UpperCaseWords()
        {
            Console.WriteLine("enter the numbers of words in the list you want");
            int size = int.Parse(Console.ReadLine());
            List<string> li = new List<string>(size);
            for (int i = 0; i < size; i++)
            {
                string word = Console.ReadLine();
                li.Add(word);
            }
            Console.WriteLine();
            var words = li.Where(x => x.Contains(x.ToUpper()));
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
        // Q13. Array Dot product
        public static void ArrayDotProduct()
        {
            int[] array1 = new int[] {7,-9,3,-5 };
            int[] array2 = new int[] { 9,1,0,-4};
            int arraydotproduct = array1.Zip(array2,(a,b)=> a*b).Sum();
            Console.WriteLine(arraydotproduct);
        }

        // Q14. Frequency of Letters
        public static void FrequencyOfLetter()
        {
            Console.WriteLine("Enter the word");
            string word = Console.ReadLine();
            var result = word.GroupBy(x => x);
            foreach (var item in result)
            {
                Console.WriteLine($"Letter {item.Key} occurs {item.Count()} times");
            }
        }
    }
}
