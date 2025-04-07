using MediaToolkit.Model;
using MediaToolkit;
using System.IO;

namespace VideoToGifConverter.Helper
{
    public class Mp4ToGifHelper
    {
        private readonly string GIF_EXT = ".gif";

        /// <summary>
        /// Converts a single MP4 file to GIF format.
        /// </summary>
        /// <param name="fileName">The name of the input MP4 file.</param>
        /// <param name="filePath">The full path to the input MP4 file.</param>
        /// <param name="outputDir">The directory where the GIF file will be saved.</param>
        /// <returns>True if the conversion was successful; otherwise, false.</returns>
        public bool ConvertVideoToGIf(string fileName, string filePath, string outputDir)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(fileName))
            {
                string gifFileName = fileName + GIF_EXT;
                string gifFilePath = Path.Combine(outputDir, gifFileName);

                if (File.Exists(gifFilePath))
                {
                    File.Delete(gifFilePath);
                }

                MediaFile inputFile = new MediaFile { Filename = filePath };
                MediaFile outputFile = new MediaFile { Filename = gifFilePath };

                using (Engine engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    engine.Convert(inputFile, outputFile);
                }
                return true;
            }
            return false;
        }

    }
}
