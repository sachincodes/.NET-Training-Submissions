namespace AjaxTask.Models
{
    public class SocialMediaPost
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string PostContent { get; set; } = String.Empty;
        public DateTime Timestamp { get; set; }
        public int Likes { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string ProfileImageUrl { get; set; } = String.Empty;


    }

}
