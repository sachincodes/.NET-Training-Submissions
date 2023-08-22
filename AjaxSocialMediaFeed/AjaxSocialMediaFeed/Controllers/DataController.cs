using AjaxTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class DataController : Controller
{
    private List<Post> allPosts;

    public DataController()
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
                Content = ".NET is a framework to develop software applications. It is designed and developed by Microsoft and the first beta version released in 2000.It is used to develop applications for web, Windows, phone. Moreover, it provides a broad range of functionalities and support.This framework contains a large number of class libraries known as Framework Class Library (FCL). The software programs written in .NET are executed in the execution environment, which is called CLR (Common Language Runtime). These are the core and essential parts of the .NET framework."
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
