using RedStream.DataAccessLayer.Entities;
using System;

namespace RedStream.YouTubeService.Entities
{
    //TODO: add thumbnail
    public class YouTubeVideo : BaseEntity
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string ChannelId { get; set; }
        public virtual YouTubeChannel Channel { get; set; }
    }
}
