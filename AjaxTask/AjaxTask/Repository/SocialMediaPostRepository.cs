using AjaxTask.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AjaxTask.Repository
{
    public class SocialMediaPostRepository : ISocialMediaPostRepository
    {
        private readonly List<SocialMediaPost> _socialMediaPosts;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SocialMediaPostRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _socialMediaPosts = GenerateMockPosts(50);
        }
        public List<SocialMediaPost> GenerateMockPosts(int numberOfPosts)
        {
            var posts = new List<SocialMediaPost>();
            var random = new Random();
            int currentProfileNumber = 1; 

            for (int i = 1; i <= numberOfPosts; i++)
            {
                posts.Add(new SocialMediaPost
                {
                    Id = i,
                    Username = $"Random Profile{currentProfileNumber}", 
                    PostContent = $"Hello, this is post number {i}!",
                    Timestamp = DateTime.Now.AddDays(random.Next(1, 10)),
                    Likes = random.Next(1, 100),
                    ImageUrl = GetRandomImageUrl()
                });

                currentProfileNumber++;
            }

            return posts;
        }


        private string GetRandomImageUrl()
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var supportedExtensions = new[] { ".jpg", ".png", ".webp",".jpeg" };
            var imageFilenames = Directory.GetFiles(imagePath)
                .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLowerInvariant()))
                .Select(path => $"/images/{Path.GetFileName(path)}")
                .ToList();

            if (imageFilenames.Count == 0)
            {
                return "/images/default.jpeg"; 
            }
            var random = new Random();
            var index = random.Next(0, imageFilenames.Count);

            return imageFilenames[index];
        }
        public List<SocialMediaPost> GetPosts(int skipCount, int takeCount)
        {
            return _socialMediaPosts
                .OrderBy(x=>x.Id)               
                .Skip(skipCount)
                .Take(takeCount)
                .ToList();
        }
    }
}
