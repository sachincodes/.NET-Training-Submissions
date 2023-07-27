using Microsoft.AspNetCore.Mvc;
using SocialMedia_Ajax.Models;

namespace SocialMedia_Ajax.Controllers
{
    public class PostsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<SocialMediaPostModel> GetPosts(int limit  = 5, int start = 0)
        {
            List<SocialMediaPostModel> posts = SocialMedia_Ajax.Data.postsdata.getAllPosts(limit, start);
            return posts;
        }

    }
}
