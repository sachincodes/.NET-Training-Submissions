using Microsoft.AspNetCore.Mvc;
using ajaxtask.staticarrray;
namespace ajaxtask.Controllers
{
    public class InstaFeeds : Controller
    {
        public IActionResult GetInstaFeeds(int start, int end)
        {
            var feeds = InstaUsersData.InstaFeeds;
            int len = feeds.Count;

            if (start >= len)
            {
                return Ok("asljdfsadlfjlk");
            }
            else if (len <= (start+4))
            {
                feeds = feeds.GetRange(start,  len-start);
                return Json(feeds)
;
            }
            else if (start >= len)
            {

                return Ok("no found");
            }
            else
            {
              
                    feeds = feeds.GetRange(start, 5);

                    return Json(feeds);
              
            }
        }
    }
}
