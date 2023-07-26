using SocialMedia_Ajax.Models;

namespace SocialMedia_Ajax.Data
{
    public static class postsdata
    {
        public static List<SocialMediaPostModel> getAllPosts()
        {
            List<SocialMediaPostModel> posts = new();
            for (int i = 0; i < 100; i++)
            {
                posts.Add(new SocialMediaPostModel(i+1));
            }
            return posts;
        }
    }
}
