using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.VideoMedia
{
    /// <summary>
    /// Video media view model
    /// </summary>
    public class VideoMediaViewModel
    {
        public VideoMediaViewModel(VideoMediaModel currentContent)
        {
            VideoMedia = currentContent;
        }

        public VideoMediaModel VideoMedia { get; private set; }
    }
}