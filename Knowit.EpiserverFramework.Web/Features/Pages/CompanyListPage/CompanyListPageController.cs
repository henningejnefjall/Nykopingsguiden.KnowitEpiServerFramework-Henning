using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyListPage
{
    /// <summary>
    /// Company list page controller
    /// </summary>
    public class CompanyListPageController : PageBaseController<CompanyListPageModel>
    {
        public ActionResult Index(CompanyListPageModel currentPage)
        {
            var user = EPiServer.Personalization.EPiServerProfile.Current;

            if (user.IsAnonymous)
            {
                return Redirect("/login/");
            }

            var model = new CompanyListPageViewModel(currentPage);

            return View(model);
        }

        public ActionResult CreateCompany(CompanyListPageModel currentPage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);

            PageReference parent = settingsPage.CompanyContainerPage;
            CompanyPageModel companyPage = contentRepository.GetDefault<CompanyPageModel>(parent);
            companyPage.PageName = Guid.NewGuid().ToString();
            companyPage.Owner = EPiServer.Personalization.EPiServerProfile.Current.UserName;

            contentRepository.Save(companyPage, SaveAction.Save, AccessLevel.Create);

            return Redirect(UrlResolver.Current.GetUrl(settingsPage.CompanyCreateContainer) + "?companyid=" + companyPage.ContentLink.ID);
        }

        public ActionResult CreateEvent(CompanyListPageModel currentPage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var start = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(start.SettingsPage);

            PageReference parent = settingsPage.EventContainerPage;
            EventPageModel eventPage = contentRepository.GetDefault<EventPageModel>(parent);
            eventPage.PageName = Guid.NewGuid().ToString();
            eventPage.Owner = EPiServer.Personalization.EPiServerProfile.Current.UserName;

            contentRepository.Save(eventPage, SaveAction.Save, AccessLevel.Create);

            return Redirect(UrlResolver.Current.GetUrl(settingsPage.EventCreateContainer) + "?eventid=" + eventPage.ContentLink.ID);
        }
    }
}