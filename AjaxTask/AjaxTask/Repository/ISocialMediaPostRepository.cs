using AjaxTask.Models;

namespace AjaxTask.Repository
{
    public interface ISocialMediaPostRepository
    {
        List<SocialMediaPost> GenerateMockPosts(int numberOfPosts);
        List<SocialMediaPost> GetPosts(int skipCount, int takeCount);
    }
}
