
namespace AIMonkeysDev.Gpt.Models
{
    public class ImageContentPart
    {
        /// <summary>
        /// Either a URL of the image or the base64 encoded image data.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Creates an ImageContentPart
        /// </summary>
        /// <param name="url">
        /// Either a URL of the image or the base64 encoded image data.
        /// </param>
        public ImageContentPart(string url) 
        {
            Url = url;
        }


        /// <summary>
        ///  Specifies the detail level of the image.
        /// </summary>
        public string Detail { get; set; } = "auto";

    }
}