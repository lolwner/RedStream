using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStream.YouTubeProviderAPI.Services;

namespace RedStream.YouTubeProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private VideoExtractorService _videoExtractorService;

        public VideoController()
        {
            _videoExtractorService = new VideoExtractorService();
        }

        [HttpGet]
        public async void Download()
        {
            await _videoExtractorService.GetVideo("");


        }
    }
}