using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.ImageMedia
{
    /// <summary>
    /// Image media view model
    /// </summary>
    public class ImageMediaViewModel
    {
        public ImageMediaViewModel(ImageMediaModel currentMedia)
        {
            ImageMedia = currentMedia;
        }

        public ImageMediaModel ImageMedia { get; private set; }
    }
}