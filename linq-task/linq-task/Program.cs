namespace LinqTask 
{
    public class Program
    {
        static void Main()
        {
            // Given an array of integers, write a query that returns list of numbers greater than 30 and less than 100
            List<int> list = new List<int> { 12, 45, 89, 35, 68 };
            var sortNum = list.Where(x => x > 30).Where(x => x < 100);
            foreach (var item in sortNum)
            {
                Console.WriteLine(item);
            }


            //Write a query that returns words at least 5 characters long and make them uppercase.
            List<string> NameList = new List<string> { "aman", "manisha", "shrish", "gulshan", "shivam" };
            var name = NameList.Where(x => x.Length > 5).Select(x => x.ToUpper());
            foreach (var item in name)
            {
                Console.WriteLine(item);
            }


            //Write a query that returns words starting with letter 'a' and ending with letter 'm'.
            List<string> NameList1 = new List<string> { "aman", "manisha", "shrish", "gulshan", "shivam" };
            var wordList = NameList1.Where(x => x.StartsWith("a")).Where(x=>x.EndsWith("m"));
            foreach (var item in wordList)
            {
                Console.WriteLine(item);
            }

            //Write a query that returns top 5 numbers from the list of integers in descending order.
            List<int> NumList = new List<int> {23,65,43,67,34,56,-34,-23};
            var sorNum = NumList.OrderByDescending(x => x).Take(5).ToList();
            foreach (var item in sorNum)
            {
                Console.WriteLine(item);
            }

            //Write a query that returns list of numbers and their squares only if square is greater than 20
            List<int> Numlist1 = new List<int> { 5,1,6,2,45};
            var number = Numlist1.Where(x => x * x > 20);
            foreach (var item in number)
            {
                Console.WriteLine(item + "-" + item * item);
            }

            //Write a query that replaces 'ea' substring with astersik(*) in given list of words.
            List<string> list1 = new List<string> { "learn","current","deal" };
            var repname = list1.Select(x => x.Contains("ea") ? x.Replace("ea", "*") : x);
            foreach (var a in repname)
            {
                Console.WriteLine(a);
            }

            //Given a non - empty list of words, sort it alphabetically and return a word that contains letter 'e'.
            List<string> list2 = new List<string> { "plane", "ferry", "car", "bike" };
            var replname = list2.OrderBy(x => x).LastOrDefault(x => x.Contains("e"));
            foreach (var a in replname)
            {
                Console.WriteLine(a);
            }


            //Write a query that shuffles sorted array.
            var rdm = new Random();
            var arr = new[] { 3, 54, 4, 6, 3, 54 };

            var xyz = arr.OrderBy(i => rdm.Next());
            foreach (var item in xyz)
            {
                Console.WriteLine(item);
            }

            //Write a query that returns most frequent character in string.Assume that there is only one such character.
            string words = "gfdgdgfgrt5trgfg565yg";
            var arrnge = words.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                Console.WriteLine(arrnge);
      

            ////Given a non - empty list of strings, return a list that contains only unique(non - duplicate) strings.
            List<string> itemlist = new List<string> { "plane", "ferry", "car", "bike" ,"bike","ferry"};
            var unique= itemlist.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).ToList();
            foreach (var a in unique)
            {
                Console.WriteLine(a);
            }

            //Write a query that returns only uppercase words from string.
            string mystr = "This is a GOOD Place";
            var contain =mystr.Split(' ').Where(x => String.Equals(x, x.ToUpper()));
            foreach (var a in contain)
            {
                Console.WriteLine(a);
           }
        }
    }
}
