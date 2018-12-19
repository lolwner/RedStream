using System.IO;

namespace RedStream.YouTubeProviderAPI.Configs
{
    public class Config
    {
        public static string Path { get; private set; }

        static Config()
        {
            Path = Directory.GetCurrentDirectory();
        }
    }
}
