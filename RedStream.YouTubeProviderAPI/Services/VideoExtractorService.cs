using RedStream.YouTubeProviderAPI.Helpers;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Services
{
    public class VideoExtractorService
    {
        private PlaylistHelper playlistHelper;
        private FilterHelper filterHelper;
        private DownloadHelper downloadHelper;
        private readonly IYouTubeServiceWrapper _youtubeService;

        public VideoExtractorService(IYouTubeServiceWrapper youtubeService)
        {
            playlistHelper = new PlaylistHelper(youtubeService);
            filterHelper = new FilterHelper();
            downloadHelper = new DownloadHelper();
            _youtubeService = youtubeService;
        }

        //Test method
        public async Task Run()
        {
            try
            {
                var youtubeService = _youtubeService.GetYouTubeServiceWrapper();

                var channelsListRequest = youtubeService.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                var channelsListResponse = await channelsListRequest.ExecuteAsync();

                foreach (var channel in channelsListResponse.Items)
                {
                    var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
                    await playlistHelper.AcquireAsync(uploadsListId);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetVideo(string searchPhrase)
        {
            try
            {
                var youtubeService = _youtubeService.GetYouTubeServiceWrapper();
                var search = youtubeService.Search.List("snippet");
                search.Q = searchPhrase;
                search.MaxResults = 50;
                var searchListResponse = await search.ExecuteAsync();
                var videos = filterHelper.GetAllVideos(searchListResponse);
                downloadHelper.Download(videos[0]);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

