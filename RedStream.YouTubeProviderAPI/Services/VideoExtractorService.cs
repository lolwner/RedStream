using RedStream.YouTubeProviderAPI.Helpers;
using System.Threading.Tasks;
using RedStream.Shared.Helpers;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;

namespace RedStream.YouTubeProviderAPI.Services
{
    public class VideoExtractorService
    {
        private readonly PlaylistHelper playlistHelper;
        private FilterHelper filterHelper;
        private DownloadHelper downloadHelper;
        private readonly IYouTubeServiceWrapper _youtubeService;

        public VideoExtractorService(IYouTubeServiceWrapper youtubeService)
        {
            playlistHelper = new PlaylistHelper(youtubeService);
            filterHelper = new FilterHelper();
            _youtubeService = youtubeService;
            downloadHelper = new DownloadHelper();
        }

        public async Task GetVideo(string searchPhrase)
        {
            var youtubeService = _youtubeService.GetYouTubeServiceWrapper();
            var search = youtubeService.Search.List("snippet");
            search.Q = searchPhrase;
            search.MaxResults = 50;
            var searchListResponse = await search.ExecuteAsync();
            var videos = filterHelper.MapVideos(searchListResponse);
            downloadHelper.Download(videos[0].VideoId);
        }
    }
}

