using Google.Apis.YouTube.v3.Data;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class PlaylistHelper
    {
        private readonly IYouTubeServiceWrapper _youtubeService;

        public PlaylistHelper(IYouTubeServiceWrapper youtubeService)
        {
            _youtubeService = youtubeService;
        }

        public async Task<List<PlaylistItem>> AcquireAsync(string listId)
        {
            //TODO - make more adequate exception handling
            try
            {
                var service = await _youtubeService.GetYouTubeServiceWrapperAsync();

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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}