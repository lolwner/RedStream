using Google.Apis.YouTube.v3.Data;
using NLog;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class PlaylistHelper
    {
        private static Logger _logger;

        public PlaylistHelper()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        //TODO - change exception handling
        public async Task<List<PlaylistItem>> AcquireAsync(string listId)
        {
            try
            {
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
                _logger.Error($"{ex.Message} {ex.StackTrace}");
                return null;
            }
        }
    }
}