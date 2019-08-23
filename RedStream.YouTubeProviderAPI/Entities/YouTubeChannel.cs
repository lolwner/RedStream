using RedStream.DataAccessLayer.Entities;

namespace RedStream.YouTubeService.Entities
{
    public class YouTubeChannel : BaseEntity
    {
        public string ChannelId { get; set; }
        public string Title { get; set; }
    }
}
