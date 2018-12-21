using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using RedStream.YouTubeProviderAPI.Configs;
using RedStream.YouTubeProviderAPI.Configs.YouTube;
using RedStream.YouTubeProviderAPI.Wrappers.Interfaces;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Wrappers
{
    public class YouTubeServiceWrapper : IYouTubeServiceWrapper
    {
        public YouTubeService GetYouTubeServiceWrapper()
        {
            UserCredential credential = YouTubeCredentialsReader.GetCredentials();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Config.Path
            });
            return youtubeService;
        }
    }
}
