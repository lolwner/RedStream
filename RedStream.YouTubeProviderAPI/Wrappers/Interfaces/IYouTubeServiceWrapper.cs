using Google.Apis.Auth.OAuth2;
using Google.Apis.YouTube.v3;

namespace RedStream.YouTubeProviderAPI.Wrappers.Interfaces
{
    public interface IYouTubeServiceWrapper
    {
        YouTubeService GetYouTubeServiceWrapper(UserCredential credential);
    }
}
