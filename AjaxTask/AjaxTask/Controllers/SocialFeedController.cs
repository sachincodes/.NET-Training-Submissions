using AjaxTask.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AjaxTask.Controllers
{
    public class SocialFeedController : Controller
    {
        private readonly ISocialMediaPostRepository _socialMediaPost;
        public SocialFeedController(ISocialMediaPostRepository socialMediaPostRepository, IWebHostEnvironment webHostEnvironment)
        {
            _socialMediaPost = socialMediaPostRepository;
        }
        public IActionResult Index()
        {
            var initialPosts = _socialMediaPost.GetPosts(0, 5);
            return View(initialPosts);
        }

        [HttpPost]
        public IActionResult IncreaseLikes(int postId)
        {
            var post = _socialMediaPost.GetPosts(0,5).FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.Likes = post.Likes + 1;
                return Json(new { likes = post.Likes });
            }

            return BadRequest("Post not found.");
        }

        [HttpGet]
        public IActionResult LoadMore(int skipCount)
        {
            var posts = _socialMediaPost.GetPosts(skipCount, 5);
            return Json(posts);
        }
    }
}
