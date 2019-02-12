using System.Collections.Generic;
using Google.Apis.YouTube.v3.Data;
using RedStream.DataAccessLayer.Entities;

namespace RedStream.Shared.Helpers
{
    public class FilterHelper
    {
        public List<YouTubeVideo> MapVideos(SearchListResponse data)
        {
            if (data == null)
            {
                throw new System.NullReferenceException();
            }
            List<YouTubeVideo> videos = new List<YouTubeVideo>();
            foreach (var searchResult in data.Items)
            {
                if (searchResult.Id.Kind == "youtube#video")
                {
                    videos.Add(new YouTubeVideo
                    {
                        VideoId = searchResult.Id.VideoId,
                        Title = searchResult.Snippet.Title,
                        Description = searchResult.Snippet.Description,
                        PublishDate = searchResult.Snippet.PublishedAt,
                        ChannelId = searchResult.Snippet.ChannelId
                    });
                }
            }
            return videos;
        }

    }
}
