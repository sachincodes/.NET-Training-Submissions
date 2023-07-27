using Microsoft.AspNetCore.Mvc;
using ajaxtask.staticarrray;
namespace ajaxtask.Controllers
{
    public class InstaFeeds : Controller
    {
        public IActionResult GetInstaFeeds(int start ,int end)
        {
           var feeds = InstaUsersData.InstaFeeds;
            int len = feeds.Count;
            if (len <= end)
            {
                feeds = feeds.GetRange(start, len - 1);
                return Json(feeds)
;            }
            else if (start >= len)
            {
                return Ok("no found");
            }

            Console.WriteLine(start);
            Console.WriteLine(end);
            feeds = feeds.GetRange(start,end);

            return  Json(feeds);
        }
    }
}
