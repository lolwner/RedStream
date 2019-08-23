using Google.Apis.Auth.OAuth2;
using Google.Apis.YouTube.v3;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Wrappers.Interfaces
{
    public interface IYouTubeServiceWrapper
    {
        Google.Apis.YouTube.v3.YouTubeService GetYouTubeServiceWrapper();
    }
}
