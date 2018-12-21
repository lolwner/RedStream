using Microsoft.AspNetCore.Mvc;
using RedStream.YouTubeProviderAPI.Services;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System.Collections.Generic;

namespace RedStream.YouTubeProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IYouTubeServiceWrapper _youtubeService;

        public ValuesController(IYouTubeServiceWrapper youtubeService)
        {
            _youtubeService = youtubeService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            VideoExtractorService a = new VideoExtractorService(_youtubeService);
            a.GetVideo("Home Alone Again with the Google Assistant");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
