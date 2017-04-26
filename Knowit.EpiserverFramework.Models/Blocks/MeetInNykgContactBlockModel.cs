using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Validation;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.LocalBlocks;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Meet In Nykoping Contact Block
    /// </summary>
    [ContentType(
        GUID = "7ec12f77-32c7-418f-8b7e-34ebbc86fb8a", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ContactBlock)]
    public class MeetInNykgContactBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual ImageBlockModel Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string Phone { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual ContentArea Forms { get; set; }
    }

    public class MeetInNykgContactBlockValidator : IValidate<MeetInNykgContactBlockModel>
    {
        IEnumerable<ValidationError> IValidate<MeetInNykgContactBlockModel>.Validate(MeetInNykgContactBlockModel instance)
        {
            if (instance.Forms.Count > 1)
            {
                return new[]
                    {
                        new ValidationError()
                            {
                                ErrorMessage = "Ett kontaktblock kan endast innehålla ett formulär",
                                PropertyName = "Forms",
                                Severity = ValidationErrorSeverity.Error,
                                ValidationType = ValidationErrorType.AttributeMatched
                            }
                    };
            }

            return new ValidationError[0];
        }
    }
}