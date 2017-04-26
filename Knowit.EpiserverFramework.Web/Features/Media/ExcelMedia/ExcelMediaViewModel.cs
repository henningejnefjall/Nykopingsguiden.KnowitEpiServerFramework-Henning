using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.ExcelMedia
{
    /// <summary>
    /// Excel media view model
    /// </summary>
    public class ExcelMediaViewModel
    {
        public ExcelMediaViewModel(ExcelMediaModel currentMedia)
        {
            ExcelMedia = currentMedia;
        }

        public ExcelMediaModel ExcelMedia { get; private set; }
    }
}