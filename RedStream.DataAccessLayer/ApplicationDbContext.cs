using Microsoft.EntityFrameworkCore;
using RedStream.DataAccessLayer.Entities;

namespace RedStream.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<YouTubeChannel> YouTubeChannels { get; set; }
        //public DbSet<YouTubeVideo> YouTubeVideos { get; set; }

        public ApplicationDbContext() : this(new DbContextOptions<ApplicationDbContext>())
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
