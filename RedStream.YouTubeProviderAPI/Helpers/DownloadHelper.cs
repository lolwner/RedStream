using MediaToolkit;
using MediaToolkit.Model;
using RedStream.Entities;
using System;
using System.IO;
using VideoLibrary;
using YouTubeVideo = RedStream.Entities.YouTubeVideo;

namespace RedStream.YouTubeProviderAPI.Helpers
{
    public class DownloadHelper
    {
        //TODO - refactor this method
        public void Download(YouTubeVideo video)
        {
            try
            {
                var source = @"D:\";
                var youtube = YouTube.Default;
                var vid = youtube.GetVideo("https://www.youtube.com/watch?v=" + video.Id);
                File.WriteAllBytes(source + vid.FullName, vid.GetBytes());

                var inputFile = new MediaFile { Filename = source + vid.FullName };
                var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    engine.Convert(inputFile, outputFile);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
