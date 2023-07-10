using System;
using System.Collections.Generic;
using System.Linq;


namespace basics
{
    class Select 
        {
    public static void Main()
    {
       
        Console.WriteLine("----------------------------");
        Console.WriteLine("1. Numbers from range");
        Console.WriteLine("2. Minimum length");
        Console.WriteLine("3. Select words");
        Console.WriteLine("4. Top 5 numbers ");
        Console.WriteLine("5. Square greater than 20");
        Console.WriteLine("6. Replace substring ");
        Console.WriteLine("7. Uppercase only");
        Console.WriteLine("8. Last word containing letter");
        Console.WriteLine("9. Decrypt number");
        Console.WriteLine("10. Most frequent character");
        Console.WriteLine("11. Unique values ");
        Console.WriteLine("12. Arrays dot product");
        Console.WriteLine("13. Frequency of letters");
      
            Console.WriteLine("----------------------------");

            Console.WriteLine("Enter Choice(1-8):");
        int ch = Int32.Parse(Console.ReadLine());

        switch (ch)
        {
            case 1:
                    Console.WriteLine("Numbers from range");
                    List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                    var selected = list.Where(x => x > 3).Where(x => x < 10);

                    foreach (var item in selected)
                    {
                        Console.WriteLine($"{item}");
                    }
                    break;
            case 2:
                Console.WriteLine("Minimum length");
                    List<string> things = new List<string> { "apple", "computer", "usb" };

                    var selectedLength = things.Where(x => x.Length >= 8).Select(x => x.ToUpper());

                    foreach (var item in selectedLength)
                    {
                        Console.WriteLine($"{item}");
                    }
                    break;
            case 3:
                Console.WriteLine("Select words");
                    List<string> strings = new List<string> { "apple", "computer", "usb", "am", "atom", "arm" };

                    var selectedWords = strings.Where(x => x.StartsWith("a")).Where(x => x.EndsWith("m")).Select(x => x.ToUpper());

                    foreach (var item in selectedWords)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            case 4:
                Console.WriteLine("Top 5 numbers ");
                    List<int> numbers = new List<int> { 6, 0, 00, 88, 5, -8, 09, 55, 12, 34 };

                    var selectedFive = numbers.OrderByDescending(x => x).Take(5);

                    foreach (var item in selectedFive)
                    {
                        Console.WriteLine($"{item}");
                    }
                    break;
            case 5:
                    Console.WriteLine("Square greater than 20");
                    List<int> numbersSquare = new List<int> { 6, 0, 00, 88, 5, -8, 09, 55, 12, 34 };

                    var selectedSquare = numbersSquare.OrderByDescending(x => x).Take(5);

                    foreach (var item in selectedSquare)
                    {
                        Console.WriteLine($"{item}");
                    }
                    break;
            case 6:
                    Console.WriteLine("Replace substring ");
                    var words = new[] { "near", "bear", "bet" };

                    var substring = words.Select(x => x.Contains("ea") ? x.Replace("ea", "*") : x);

                    foreach (var item in substring)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            case 7:
                    Console.WriteLine("Uppercase only");
                    string word = "RETURN only UUPERCASE words, DND bca";

                    var uppercase = word.Split(' ').Where(x => string.Equals(x, x.ToUpper()));


                    foreach (var item in uppercase)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            case 8:
                    Console.WriteLine("Last word containing letter");
                    List<string> lastwords = new List<string> { "apple", "cake", "pen", "ball" };

                    var lastletter = lastwords.OrderBy(x => x).LastOrDefault(x => x.Contains("e"));

                    Console.WriteLine(lastletter);
                    break;
                case 9:
                    Console.WriteLine("Decrypt number");
                    var chars = new char[] { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };

                    var encryptedNumber = "#(@*%)$(&$*#&";

                    var decryptedNumber = string.Join("", encryptedNumber.Select(c => Array.IndexOf(chars, c)));

                    Console.WriteLine(decryptedNumber);
                    break;

                case 10:
                    Console.WriteLine("Most frequent character");
                    string str = "49fjs492jfJs94KfoedK0iejksKdsj3";

                    var mostFrequentCharacter = str.GroupBy(c => c).OrderByDescending(c => c.Count()).First().Key;

                    Console.Write(mostFrequentCharacter);
                    break;
                case 11:
                    Console.WriteLine("Unique values");
                    var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };
                    var uniqueValues = values
                            .GroupBy(x => x)
                            .Where(x => x.Count() == 1)
                            .Select(x => x.Key)
                            .ToList();

                    foreach (var value in uniqueValues)
                    {
                        Console.WriteLine($"{value}"); 
                    }
                    break;
                case 12:
                    Console.WriteLine("Arrays dot product");
                    int[] array1 = new int[] { 5, 8, 2, 9 };
                    int[] array2 = new int[] { 1, 7, 2, 4 };

                    int dotProduct = array1.Zip(array2, (a, b) => a * b).Sum();

                    Console.WriteLine(dotProduct);
                    break;
                case 13:
                    Console.WriteLine("Frequency of letters");
                    string sen = "abracadabra";

                    var letters = sen.GroupBy(x => x);

                    foreach (var l in letters)
                    {
                        Console.Write($"Letter {l.Key} occurs {l.Count()} time(s), ");
                    }
                   
                    break;
                default:
                Console.WriteLine("Invalid Choice");
                break;
        }

        Console.ReadKey();
    }
}

    }
