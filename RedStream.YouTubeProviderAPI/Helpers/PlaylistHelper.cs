using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class PlaylistHelper
    {
        //TODO - need to make some kind of wrapper for youtube services
        public async Task<List<PlaylistItem>> AcquireAsync(string listId, IYouTubeServiceWrapper youtubeService)
        {
            //here i`ll need creds that i don`t want to pass here
            //var a = youtubeService.GetYouTubeServiceWrapper();

            List<PlaylistItem> playlists = new List<PlaylistItem>();
            var nextPageToken = "";
            while (nextPageToken != null)
            {
                var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
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
