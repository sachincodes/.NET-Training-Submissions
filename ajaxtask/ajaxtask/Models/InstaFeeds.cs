namespace ajaxtask.Models
{
    public class InstaFeeds
    {
        public   Guid Id { get; set; }  
        public string  Post { get; set; }
        public  int  Likes { get; set; }  
        public int Shares { get; set; }
        public string Image { get; set; }
    }
}
