using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using RedStream.YouTubeProviderAPI.Helpers;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Services
{
    public class VideoExtractorService
    {
        private PlaylistHelper playlistHelper;

        public VideoExtractorService(IYouTubeServiceWrapper youtubeService)
        {
            playlistHelper = new PlaylistHelper(youtubeService);
        }

        public async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });

            var channelsListRequest = youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;
            
            var channelsListResponse = await channelsListRequest.ExecuteAsync();

            foreach (var channel in channelsListResponse.Items)
            {
                
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
                await playlistHelper.AcquireAsync(uploadsListId);

                //var nextPageToken = "";
                //while (nextPageToken != null)
                //{
                //    var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                //    playlistItemsListRequest.PlaylistId = uploadsListId;
                //    playlistItemsListRequest.MaxResults = 50;
                //    playlistItemsListRequest.PageToken = nextPageToken;
                    
                //    var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                //    foreach (var playlistItem in playlistItemsListResponse.Items)
                //    {
                        
                //    }

                //    nextPageToken = playlistItemsListResponse.NextPageToken;
                //}
            }
        }
    }
}

