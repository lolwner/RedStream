using Microsoft.EntityFrameworkCore;
using RedStream.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace RedStream.DataAccessLayer.Repositories
{
    public class YouTubeVideoRepository : BaseRepository<YouTubeVideo>
    {
        protected override DbSet<YouTubeVideo> DbSet => DbContext.YouTubeVideos;


    }
}
