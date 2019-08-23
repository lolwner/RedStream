using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using RedStream.YouTubeProviderAPI.Configs;
using RedStream.YouTubeProviderAPI.Configs.YouTube;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using Google.Apis.YouTube.v3;

namespace RedStream.YouTubeProviderAPI.Wrappers
{
    public class YouTubeServiceWrapper : IYouTubeServiceWrapper
    {
        public Google.Apis.YouTube.v3.YouTubeService GetYouTubeServiceWrapper()
        {
            UserCredential credential = YouTubeCredentialsReader.GetCredentials();
            var youtubeService = new Google.Apis.YouTube.v3.YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Config.Path
            });
            return youtubeService;
        }
    }
}
