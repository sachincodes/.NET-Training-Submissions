using AjaxSocialMediaFeed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class FeedController : Controller
{
    private List<Post> allPosts;

    public FeedController()
    {
        allPosts = GeneratePosts(1000); 
    }

    public IActionResult Index()
    {
        return View();
    }

    private List<Post> GeneratePosts(int count)
    {
        var posts = new List<Post>();

        for (int i = 1; i <= count; i++)
        {
            posts.Add(new Post
            {
                Title = "Post " + i,
                Content = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus."
            });
        }

        return posts;
    }

    public IActionResult LoadMorePosts(int offset, int count = 5)
    {
        var posts = allPosts.Skip(offset).Take(count).ToList();
        return Json(posts);
    }


}
