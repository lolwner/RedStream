using System;

namespace RedStream.DataAccessLayer.Entities
{
    //TODO: add thumbnail
    public class YouTubeVideo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int ChannelId { get; set; } 
        public virtual YouTubeChannel Channel { get; set; }
    }
}
