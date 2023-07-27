using ajaxtask.Models;
using Microsoft.EntityFrameworkCore;

namespace ajaxtask
{
    public class AjaxDbContext:DbContext
    {
        public AjaxDbContext(DbContextOptions<AjaxDbContext> options) : base(options)
        {

        }
        DbSet<InstaFeeds> Instafeeds { get; set; }
    }
}
