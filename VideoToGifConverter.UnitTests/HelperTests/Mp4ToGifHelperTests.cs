using VideoToGifConverter.Helper;

namespace VideoToGifConverter.UnitTests
{
    /// <summary>
    /// Unit tests for the <see cref="Mp4ToGifHelper"/> class.
    /// </summary>
    [TestFixture]
    public class Mp4ToGifHelperTests
    {
        /// <summary>
        /// Tests the <see cref="Mp4ToGifHelper.ConvertVideoToGIf"/> method when the file name is null, empty, or whitespace.
        /// </summary>
        /// <param name="fileName">The file name to test.</param>
        /// <param name="expectedResult">The expected result: false if the file name is null, empty, or whitespace.</param>
        [Test]
        [TestCase(" ", false)]    // Test case with a space (invalid file name)
        [TestCase("", false)]     // Test case with an empty string (invalid file name)
        [TestCase(null, false)]   // Test case with null (invalid file name)
        public void ConvertVideoToGIf_WhenFileNameIsEmpty_ReturnsFalse(string? fileName, bool expectedResult)
        {
            // Arrange: Setup the input values and the helper class instance
            string defaultFilePath = @"C:\Users\soura\Videos\Captures\BannerImage - Microsoft Visual Studio 2024-01-28 11-48-29 - Copy (2).mp4";
            string outputPath = @"C:\Users\soura\Videos\Captures\Output\";
            Mp4ToGifHelper mp4ToGifHelper = new Mp4ToGifHelper();

            // Act: Call the method under test
            bool result = mp4ToGifHelper.ConvertVideoToGIf(fileName, defaultFilePath, outputPath);

            // Assert: Verify that the result matches the expected outcome
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Tests the <see cref="Mp4ToGifHelper.ConvertVideoToGIf"/> method when the file path is null, empty, or whitespace.
        /// </summary>
        /// <param name="filePath">The file path to test.</param>
        /// <param name="expectedResult">The expected result: false if the file path is null, empty, or whitespace.</param>
        [Test]
        [TestCase(" ", false)]    // Test case with a space (invalid file path)
        [TestCase("", false)]     // Test case with an empty string (invalid file path)
        [TestCase(null, false)]   // Test case with null (invalid file path)
        public void ConvertVideoToGif_WhenFilePathIsEmpty_ReturnsFalse(string? filePath, bool expectedResult)
        {
            // Arrange: Setup the input values and the helper class instance
            string defaultFileName = @"BannerImage - Microsoft Visual Studio 2024-01-28 11-48-29 - Copy (2).mp4";
            string outputPath = @"C:\Users\soura\Videos\Captures\Output\";
            Mp4ToGifHelper mp4ToGifHelper = new Mp4ToGifHelper();

            // Act: Call the method under test
            bool result = mp4ToGifHelper.ConvertVideoToGIf(defaultFileName, filePath, outputPath);

            // Assert: Verify that the result matches the expected outcome
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
