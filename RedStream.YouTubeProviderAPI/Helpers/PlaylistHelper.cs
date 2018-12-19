using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class PlaylistHelper
    {
        public async Task<List<PlaylistItem>> AcquireAsync(string listId, IYouTubeServiceWrapper youtubeService)
        {
            var service = await youtubeService.GetYouTubeServiceWrapperAsync();

            List<PlaylistItem> playlists = new List<PlaylistItem>();
            var nextPageToken = "";
            while (nextPageToken != null)
            {
                var playlistItemsListRequest = service.PlaylistItems.List("snippet");
                playlistItemsListRequest.PlaylistId = listId;
                playlistItemsListRequest.MaxResults = 50;
                playlistItemsListRequest.PageToken = nextPageToken;

                var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
                playlists.AddRange(playlistItemsListResponse.Items);
                nextPageToken = playlistItemsListResponse.NextPageToken;
            }
            return playlists;
        }
    }
}
