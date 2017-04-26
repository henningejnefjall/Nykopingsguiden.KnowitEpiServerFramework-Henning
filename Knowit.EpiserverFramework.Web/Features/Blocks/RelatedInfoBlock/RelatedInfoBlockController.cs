using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.RelatedInfoBlock
{
    /// <summary>
    /// Related info block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class RelatedInfoBlockController : BlockController<RelatedInfoBlockModel>
    {
        public override ActionResult Index(RelatedInfoBlockModel currentBlock)
        {
            var model = new RelatedInfoBlockViewModel(currentBlock);

            var pageTypeName = currentBlock.ListPageType;

            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

            var pageType = contentTypeRepository.Load<PageData>();
            var pageType2 = contentTypeRepository.Load<PageData>();

            if (pageTypeName == RelatedInfoBlockModel.PagetypeChoice.BesoksmalOchVerkamheter)
            {
                pageType = contentTypeRepository.Load<CompanyPageModel>();
                pageType2 = contentTypeRepository.Load<VisitPageModel>();
            }
            else if (pageTypeName == RelatedInfoBlockModel.PagetypeChoice.Evenemang)
            {
                pageType = contentTypeRepository.Load<EventPageModel>();
            }

            // get usages, this also includes versions
            var contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
            var usages = contentModelUsage.ListContentOfContentType(pageType);
            var usages2 = contentModelUsage.ListContentOfContentType(pageType2);

            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var categories = ((ICategorizable)currentBlock).Category;

            if (pageTypeName == RelatedInfoBlockModel.PagetypeChoice.BesoksmalOchVerkamheter)
            {
                var categoryPages = usages.Concat(usages2).Select(u => repository.Get<IContent>(u.ContentLink))
                    .Where(x =>

                        // ...filter published
                        (x as IVersionable).Status.Equals(VersionStatus.Published)

                        // remove deleted
                        && !x.IsDeleted)

                        // Cast to pagedata and check if they've got correct categories 
                    .Cast<PageData>().Where(x => 
                    x.Category != null && x.Category.Intersect(categories).Any() && x.Property["SuperInactive"].Value as bool? != true && x.Property["Inactive"].Value as bool? != true);

                model.CategoryPages = categoryPages.Shuffle().Take(currentBlock.MaxItems);
            }
            else if (pageTypeName == RelatedInfoBlockModel.PagetypeChoice.Evenemang)
            {
                // Todo - Add date
                model.CategoryPages = usages.Concat(usages2).Select(u => repository.Get<IContent>(u.ContentLink))
                    .Where(x =>

                        // ...filter published
                        (x as IVersionable).Status.Equals(VersionStatus.Published)

                            // remove deleted
                        && !x.IsDeleted)

                    // Cast to pagedata and check if they've got correct categories 
                    .Cast<EventPageModel>().Where(x =>
                        x.Category != null && x.Category.Intersect(categories).Any()).OrderByDescending(x =>
                                x.Flag).Take(currentBlock.MaxItems);
            }

            return PartialView(model);
        }
    }
}
