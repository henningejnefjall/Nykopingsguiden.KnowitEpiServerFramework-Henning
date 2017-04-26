using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.DefaultMedia
{
    /// <summary>
    /// Default media view model
    /// </summary>
    public class DefaultMediaViewModel
    {
        public DefaultMediaViewModel(DefaultMediaModel currentMedia)
        {
            DefaultMedia = currentMedia;
        }

        public DefaultMediaModel DefaultMedia { get; private set; }
    }
}