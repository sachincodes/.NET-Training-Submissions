namespace Employee_Records.Models
{
    public class Workers
    {
        private static int nextId = 1;
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string Branch { get; set; }
        public string City { get; set; }

        public Workers()
        {
            WorkerId = nextId++;
        }
    }
}
