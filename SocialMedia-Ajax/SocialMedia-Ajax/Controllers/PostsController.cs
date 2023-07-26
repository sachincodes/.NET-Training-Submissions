using Microsoft.AspNetCore.Mvc;
using SocialMedia_Ajax.Models;

namespace SocialMedia_Ajax.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            List<SocialMediaPostModel> posts = SocialMedia_Ajax.Data.postsdata.getAllPosts();
            return View(posts);
        }
    }
}
