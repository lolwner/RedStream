using RedStream.YouTubeProviderAPI.Helpers;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System.Threading.Tasks;

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
            downloadHelper = new DownloadHelper();
            _youtubeService = youtubeService;
        }

        public async Task GetVideo(string searchPhrase)
        {
            var youtubeService = _youtubeService.GetYouTubeServiceWrapper();
            var search = youtubeService.Search.List("snippet");
            search.Q = searchPhrase;
            search.MaxResults = 50;
            var searchListResponse = await search.ExecuteAsync();
            var videos = filterHelper.GetAllVideos(searchListResponse);
            downloadHelper.Download(videos[0]);
        }
    }
}

