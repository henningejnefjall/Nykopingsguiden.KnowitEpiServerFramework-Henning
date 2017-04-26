using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.PdfMedia
{
    /// <summary>
    /// PDF media view model
    /// </summary>
    public class PdfMediaViewModel
    {
        public PdfMediaViewModel(PdfMediaModel currentContent)
        {
            PdfMedia = currentContent;
        }

        public PdfMediaModel PdfMedia { get; private set; }
    }
}