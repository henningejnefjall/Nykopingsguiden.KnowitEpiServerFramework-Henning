using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Filters;
using EPiServer.Framework.Blobs;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.EventCreatePage
{
    /// <summary>
    /// Event create page controller
    /// </summary>
    public class EventCreatePageController : PageController<EventCreatePageModel>
    {
        public ActionResult Index(string eventid, EventCreatePageModel currentPage)
        {
            // Create repositories
            CategoryRepository categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);

            // Event categories
            List<SelectListItem> eventCats = new List<SelectListItem>();
            if (currentPage.EventCategories != null)
            {
                foreach (int category in currentPage.EventCategories)
                {
                    Category thisCat = categoryRepository.Get(category);
                    eventCats.Add(new SelectListItem { Text = thisCat.Name, Value = thisCat.ID.ToString() });
                }
            }

            ViewBag.EventCategory = eventCats;

            //// Attractions categories
            List<SelectListItem> attractionsCats = new List<SelectListItem>();
            if (currentPage.AttractionsCategories != null)
            {
                foreach (int category in currentPage.AttractionsCategories)
                {
                    Category thisCat = categoryRepository.Get(category);
                    attractionsCats.Add(new SelectListItem { Text = thisCat.Name, Value = thisCat.ID.ToString() });
                }
            }

            ViewBag.AttractionsCategory = attractionsCats;

            ViewBag.FormHeader = "Skapa evenemang";

            // Event user companies
            List<SelectListItem> eventCompanies = new List<SelectListItem>();
            IEnumerable<PageData> filteredChildren = new List<PageData>();
            if (settingsPage.CompanyContainerPage != null)
            {
                PageDataCollection allChildren = DataFactory.Instance.GetChildren(settingsPage.CompanyContainerPage);
                if (allChildren.Count != 0)
                {
                    filteredChildren =
                        FilterForVisitor.Filter(allChildren)
                            .Where(
                                p =>
                                    p.IsVisibleOnSite() &&
                                    p.Property["Owner"].Value as string ==
                                    EPiServer.Personalization.EPiServerProfile.Current.UserName);
                }
            }

            eventCompanies.Add(new SelectListItem
            {
                Text = "--Ingen verksamhet--",
                Value = "0"
            });

            foreach (var pageData in filteredChildren)
            {
                var item = (CompanyPageModel)pageData;
                eventCompanies.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ContentLink.ID.ToString()
                });
            }

            ViewBag.Companies = eventCompanies;

            // Event user places
            List<SelectListItem> eventPlaces = new List<SelectListItem>();
            IEnumerable<PageData> filteredPlaces = new List<PageData>();
            if (settingsPage.PlacesContainerPage != null)
            {
                PageDataCollection allPlaces = DataFactory.Instance.GetChildren(settingsPage.PlacesContainerPage);
                if (allPlaces.Count != 0)
                {
                    filteredPlaces =
                        FilterForVisitor.Filter(allPlaces)
                            .Where(
                                p =>
                                    p.IsVisibleOnSite() &&
                                    p["Inactive"] == null);
                }

                eventPlaces.Add(new SelectListItem
                {
                    Text = "--Välj lokal--",
                    Value = "0"
                });

                foreach (var item in filteredPlaces)
                {
                    if (item is MeetInNykgFacilityPageModel)
                    {
                        eventPlaces.Add(new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.ContentLink.ID.ToString()
                        });
                    }
                }

                eventPlaces.Add(new SelectListItem
                {
                    Text = "Annan lokal",
                    Value = "Annan"
                });
            }

            ViewBag.Places = eventPlaces;

            ViewBag.Latitude = "58.75";
            ViewBag.Longitude = "17";

            // Load data if in "editmode"
            if (eventid != null)
            {
                EventPageModel eventPage = contentRepository.Get<EventPageModel>(new PageReference(eventid));

                // Redirect if you dont have access
                if (eventPage.Owner != EPiServer.Personalization.EPiServerProfile.Current.UserName)
                {
                    return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
                }

                if (eventPage.Category != null)
                {
                    // Loop through categories on page and print them to the viewbag for use in front 
                    foreach (int catId in eventPage.Category)
                    {
                        Category cat = categoryRepository.Get(catId);
                        if (cat.Parent.ID == int.Parse(System.Configuration.ConfigurationManager.AppSettings["CategoryEvents"]))
                        {
                           ViewBag.EventCategoryString += catId + ","; 
                        }
                        else if (cat.Parent.ID ==
                                 int.Parse(System.Configuration.ConfigurationManager.AppSettings["CategorySeGora"]))
                        {
                            ViewBag.AttractionsCategoryString += catId + ",";
                        }                       
                    }
                }

                ViewBag.FormHeader = "Redigera evenemang";
                ViewBag.Header = eventPage.Header;
                ViewBag.Extract = eventPage.Extract;
                ViewBag.MainBody = eventPage.MainBody;
                if (eventPage.Company != null)
                {
                    ViewBag.Company = eventPage.Company.ID;
                }

                if (eventPage.Place == null)
                {
                    if (eventPage.OtherPlace != null)
                    {
                        ViewBag.Place = "Annan";
                    }
                    else
                    {
                        ViewBag.Place = "0";
                    }
                }
                else
                {
                    ViewBag.Place = eventPage.Place;
                }

                ViewBag.Access = eventPage.Access;
                ViewBag.Facebook = eventPage.FacebookPage;
                ViewBag.Email = eventPage.Email;
                ViewBag.BookingUrl = eventPage.BookingUrl;
                ViewBag.Organizer = eventPage.Organizer;
                ViewBag.OrganizerUrl = eventPage.OrganizerUrl;
                ViewBag.OtherPlace = eventPage.OtherPlace;
                ViewBag.Price = eventPage.Price;

                if (eventPage.Latitude.IsNullOrEmpty() && eventPage.Latitude.IsNullOrEmpty())
                {
                    ViewBag.Latitude = "58.75";
                    ViewBag.Longitude = "17";
                }
                else
                {
                    ViewBag.Latitude = eventPage.Latitude;
                    ViewBag.Longitude = eventPage.Longitude;
                }
            }

            ViewBag.PageId = eventid;

            var model = new EventCreatePageViewModel(currentPage);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitPage(EventCreatePageModel currentPage, IEnumerable<string> eventCategory, IEnumerable<string> attractionsCategory, string header, string extract, string mainBody, string pageId, string companies, string places, string otherPlace, string price, string access, string organizer, string organizerUrl, string bookingUrl, string imagefile1, HttpPostedFileBase image1, HttpPostedFileBase file1, string facebook, string email, string latitude, string longitude, string command)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);

            PageReference parent = settingsPage.EventContainerPage;

            // Create a new page of type EventPage under the parent page
            EventPageModel eventPage = contentRepository.GetDefault<EventPageModel>(parent);

            if (!pageId.IsNullOrEmpty())
            {
                eventPage.PageId = pageId;
                eventPage = contentRepository.Get<EventPageModel>(new ContentReference(pageId)).CreateWritableClone() as EventPageModel;
            }

            CategoryList eventCatList = new CategoryList();

            // Add categories to list for the new page
            if (eventCategory != null)
            {
                foreach (string id in eventCategory)
                {
                    eventCatList.Add(int.Parse(id));
                }
            }

            if (attractionsCategory != null)
            {
                foreach (string id in attractionsCategory)
                {
                    eventCatList.Add(int.Parse(id));
                }
            }

            // Save values
            eventPage.PageName = header;
            eventPage.Header = header;
            eventPage.Category = eventCatList;
            eventPage.Extract = new XhtmlString(extract);
            eventPage.MainBody = new XhtmlString(mainBody);

            eventPage.Owner = EPiServer.Personalization.EPiServerProfile.Current.UserName;

            contentRepository.Save(eventPage, SaveAction.Save, AccessLevel.Create);

            ViewBag.PageId = eventPage.PageLink.ID;

            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var mediaDataResolver = ServiceLocator.Current.GetInstance<ContentMediaResolver>();
            var blobFactory = ServiceLocator.Current.GetInstance<IBlobFactory>();

            var contentAssetHelper = ServiceLocator.Current.GetInstance<ContentAssetHelper>();

            //// get an existing content asset folder or create a new one
            var assetsFolder = contentAssetHelper.GetOrCreateAssetFolder(eventPage.ContentLink);

            if (!string.IsNullOrEmpty(imagefile1))
            {
                imagefile1 = imagefile1.Substring(22);
                var imagefile1byte = Convert.FromBase64String(imagefile1);
                MemoryStream streamByte1 = new MemoryStream(imagefile1byte);

                string image1Extension = ".png";  // ex. .jpg or .txt

                //// Get a suitable MediaData type from extension
                var mediaType1 = mediaDataResolver.GetFirstMatching(image1Extension);
                var contentType1 = contentTypeRepository.Load(mediaType1);

                //// Get a new empty file data
                var media1 = contentRepository.GetDefault<MediaData>(assetsFolder.ContentLink, contentType1.ID);
                media1.Name = eventPage.Header + "_" + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + image1Extension;
                var blob1 = blobFactory.CreateBlob(media1.BinaryDataContainer, image1Extension);
                blob1.Write(streamByte1);

                //// Assign to file and publish changes
                media1.BinaryData = blob1;
                var file1ID = contentRepository.Save(media1, SaveAction.Publish, AccessLevel.Create);
                eventPage.Image1 = file1ID;
            }

            if (file1 != null)
            {
                string file1Extension = Path.GetExtension(file1.FileName);
                var mediaType4 = mediaDataResolver.GetFirstMatching(file1Extension);
                var contentType4 = contentTypeRepository.Load(mediaType4);
                var media4 = contentRepository.GetDefault<MediaData>(assetsFolder.ContentLink, contentType4.ID);
                media4.Name = file1.FileName;
                var blob4 = blobFactory.CreateBlob(media4.BinaryDataContainer, file1Extension);
                blob4.Write(file1.InputStream);
                media4.BinaryData = blob4;
                var file4ID = contentRepository.Save(media4, SaveAction.Publish, AccessLevel.Create);
                eventPage.Document = file4ID;
            }

            //// Save values to new page
            if (companies != "0")
            {
                eventPage.Company = new PageReference(int.Parse(companies));
            }

            if (places == "Annan")
            {
                eventPage.OtherPlace = otherPlace;
            }
            else
            {
                eventPage.Place = new PageReference(int.Parse(places));
            }

            eventPage.Price = new XhtmlString(price);
            eventPage.Organizer = organizer;
            eventPage.OrganizerUrl = organizerUrl;
            eventPage.BookingUrl = bookingUrl;
            eventPage.FacebookPage = facebook;
            eventPage.Email = email;
            eventPage.Access = new XhtmlString(access);
            eventPage.Latitude = latitude;
            eventPage.Longitude = longitude;

            if (command.Equals("Spara"))
            {
                contentRepository.Save(eventPage, SaveAction.Save, AccessLevel.Create);
            }
            else
            {
                contentRepository.Save(eventPage, SaveAction.Publish, AccessLevel.Create);
            }

            return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
        }

        [HttpPost]
        public ActionResult DeleteAction(string pageId, EventCreatePageModel currentPage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            if (pageId != null)
            {
                var eventPage = new ContentReference(pageId);

                contentRepository.MoveToWastebasket(eventPage, EPiServer.Personalization.EPiServerProfile.Current.UserName);
            }

            return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
        }
    }
}