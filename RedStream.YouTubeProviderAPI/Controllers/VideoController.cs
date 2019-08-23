using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStream.YouTubeProviderAPI.Services;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;

namespace RedStream.YouTubeProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private VideoExtractorService _videoExtractorService;
        private readonly IYouTubeServiceWrapper _youtubeService;

        public VideoController(IYouTubeServiceWrapper youtubeService)
        {
            _youtubeService = youtubeService;
            _videoExtractorService = new VideoExtractorService(_youtubeService);
        }

        [HttpGet]
        public async void Download()
        {
            await _videoExtractorService.GetVideo("");


        }
    }
}