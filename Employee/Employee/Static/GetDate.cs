namespace Employee.Static
{
    public static class TodayDate
    {
        static void TodaysDate()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.ToString());
        }
    }
}
