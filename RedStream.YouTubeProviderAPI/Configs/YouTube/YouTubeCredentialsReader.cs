using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RedStream.YouTubeProviderAPI.Configs.YouTube
{
    public static class YouTubeCredentialsReader
    {
        public static UserCredential GetCredentials()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = Task.Run(() => GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(Config.Path)
                )).Result;
            }
            return credential;
        }
    }
}
