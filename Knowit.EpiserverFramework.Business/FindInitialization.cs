using System;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Find.Framework;
using EPiServer.Find.UnifiedSearch;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Business
{
    using Models.Pages;

    [ModuleDependency(typeof(EPiServer.Find.Cms.Module.IndexingModule))]
    public class FindInitialization : IInitializableModule
    {
        private bool ShouldIndexPagedata(PageData page)
        {
            //Check if the page is published and not marked as noindex
            var shouldIndex = page.CheckPublishedStatus(PagePublishedStatus.Published)
                && !page.GetPropertyValue<bool>("NoIndex");

            return shouldIndex;
        }

        public void Initialize(InitializationEngine context)
        {
            var acceptedFileExtensions = new List<string>() { "doc", "docx", "ppt", "pptx", "pdf", "xls", "xlsx" };

            // Include all in indexing
            ContentIndexer.Instance.Conventions.ForInstancesOf<IContent>().ShouldIndex(x => true);

            ExcludeContentTypesFromIndexing();

            ContentIndexer.Instance.Conventions.ForInstancesOf<IContentMedia>().ShouldIndex(x =>
            {
                if (!acceptedFileExtensions.Contains(x.SearchFileExtension().ToLowerInvariant()))
                {
                    return false;
                }

                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var contentSoftLinkRepository = ServiceLocator.Current.GetInstance<IContentSoftLinkRepository>();

                var softLinks = contentSoftLinkRepository.Load(x.ContentLink, true);

                try
                {
                    foreach (var softLink in softLinks)
                    {

                        if (softLink.SoftLinkType == ReferenceType.ExternalReference || softLink.SoftLinkType == ReferenceType.PageLinkReference)
                        {
                            var content = contentRepository.Get<IContent>(softLink.OwnerContentLink);

                            if (content == null)
                                continue;

                            var shouldIndex = ContentIndexer.Instance.Conventions.ShouldIndexConvention.ShouldIndex(content);
                            if (shouldIndex != null && !shouldIndex.Value) // don't index referenced file if content is marked as not indexed
                            {
                                continue;
                            }

                            // only index if content is published
                            var publicationStatus = content.PublishedInLanguage()[(softLink.OwnerLanguage != null ? softLink.OwnerLanguage.Name : "sv")];

                            if (publicationStatus != null &&
                                (publicationStatus.StartPublish == null ||
                                 publicationStatus.StartPublish < DateTime.Now) &&
                                (publicationStatus.StopPublish == null ||
                                 DateTime.Now < publicationStatus.StopPublish))
                            {
                                return true;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    var logger = LogManager.GetLogger();
                    logger.Error("Error on indexing file", exception);
                }

                return false;
            });
        }


        private void ExcludeContentTypesFromIndexing()
        {
            ContentIndexer.Instance.Conventions.ForInstancesOf<PageData>().ShouldIndex(x => x.ContentLink.ID != ContentReference.WasteBasket.ID && !x.Ancestors().Contains(ContentReference.WasteBasket.ID.ToString()));

            var NoindexLink = ConfigurationManager.AppSettings.Get("NoindexLink");
            if (!string.IsNullOrWhiteSpace(NoindexLink))
            {
                string[] NoindexStrings = NoindexLink.Split(',');
                foreach (string NoindexString in NoindexStrings)
                {
                    ContentIndexer.Instance.Conventions.ForInstancesOf<PageData>().ShouldIndex(x => x.ContentLink.ToString() != NoindexString && !x.Ancestors().Contains(NoindexString.ToString()));
                }
            }
            ContentIndexer.Instance.Conventions.ForInstancesOf<RssFeedPageModel>().ShouldIndex(x => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<CategoryImagePageModel>().ShouldIndex(x => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<SearchEpiserverFindPageModel>().ShouldIndex(x => false);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}