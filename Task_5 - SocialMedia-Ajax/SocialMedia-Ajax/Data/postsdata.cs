using SocialMedia_Ajax.Models;

namespace SocialMedia_Ajax.Data
{
    public static class postsdata
    {
        public static List<SocialMediaPostModel> getAllPosts(int limit, int start)
        {
            List<SocialMediaPostModel> posts = new();
            for (int i = start; i < 100; i++)
            {
                if(--limit < 0)
                {
                    break;
                }
                posts.Add(new SocialMediaPostModel(i+1));
            }
            return posts;
        }
    }
}
