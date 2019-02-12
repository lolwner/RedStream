using Microsoft.AspNetCore.Mvc;
using RedStream.YouTubeProviderAPI.Models.RequestModels;
using RedStream.YouTubeProviderAPI.Services;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;

namespace RedStream.YouTubeProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IYouTubeServiceWrapper _youtubeService;
        private VideoExtractorService _videoExtractorService;

        public VideoController(IYouTubeServiceWrapper youtubeService)
        {
            _youtubeService = youtubeService;
            _videoExtractorService = new VideoExtractorService(_youtubeService);
        }

        [HttpPost]
        public async void Download([FromBody] VideoDownloadRequestModel search)
        {
            await _videoExtractorService.GetVideo(search.SearchPhrase);


        }
    }
}