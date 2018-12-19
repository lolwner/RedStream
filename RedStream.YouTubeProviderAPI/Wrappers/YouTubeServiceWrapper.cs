using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;

namespace RedStream.YouTubeProviderAPI.Wrappers
{
    //TODO - fix namings
    public class YouTubeServiceWrapper : IYouTubeServiceWrapper
    {
        public YouTubeService YouTubeService { get; private set; }

        public YouTubeService GetYouTubeServiceWrapper(UserCredential credential)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });
            return youtubeService;
        }
    }
}
