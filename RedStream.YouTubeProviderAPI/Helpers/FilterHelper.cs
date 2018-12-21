using Google.Apis.YouTube.v3.Data;
using RedStream.Entities;
using System.Collections.Generic;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class FilterHelper
    {
        public List<YouTubeVideo> GetAllVideos(SearchListResponse data)
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
                        Id = searchResult.Id.VideoId,
                        Title = searchResult.Snippet.Title
                    });
                }
            }
            return videos;
        }

    }
}