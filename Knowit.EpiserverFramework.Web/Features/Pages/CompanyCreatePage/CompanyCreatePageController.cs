using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Framework.Blobs;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyCreatePage
{
    /// <summary>
    /// Company create page controller
    /// </summary>
    public class CompanyCreatePageController : PageBaseController<CompanyCreatePageModel>
    {
        // HE Added
        public static T GetNext<T>(IEnumerable<T> list, T current)
        {
            try
            {
                return list.SkipWhile(x => !x.Equals(current)).Skip(1).First();
            }
            catch
            {
                return default(T);
            }
        }

        public ActionResult Index(string companyid, CompanyCreatePageModel currentPage)
        {
            // Create repositories
            CategoryRepository theCategoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            
            List<SectionCats> seochgoraCats = new List<SectionCats>(); ////HE added
            List<SectionCats> ataCats = new List<SectionCats>(); ////HE added
            List<SectionCats> boendeCats = new List<SectionCats>(); ////HE added
            List<SectionCats> motenCats = new List<SectionCats>(); ////HE added

            var usedcats = currentPage.Category; //// kategoriegenskap som används

            if (usedcats != null)
            {
                foreach (int category in usedcats)
                {
                    Category thisCat = theCategoryRepository.Get(category);
                    ////companyCats.Add(new SelectListItem { Text = thisCat.Name, Value = thisCat.ID.ToString() });

                    switch (thisCat.Parent.Name)
                    {
                        case "Äta":
                            ataCats.Add(new SectionCats { Text = thisCat.Name, Value = thisCat.ID.ToString(), Level = thisCat.Indent });
                            break;
                        case "Bo":
                            boendeCats.Add(new SectionCats { Text = thisCat.Name, Value = thisCat.ID.ToString(), Level = thisCat.Indent });
                            break;
                        case "Möten och arenor":
                            motenCats.Add(new SectionCats { Text = thisCat.Name, Value = thisCat.ID.ToString(), Level = thisCat.Indent });
                            break;
                        default: break;
                    }

                    if (thisCat.Parent.Parent.Name == "Se och göra")
                    {
                        seochgoraCats.Add(new SectionCats { Text = thisCat.Name, Value = thisCat.ID.ToString(), Level = thisCat.Indent, Parent = thisCat.Parent.Name, ParentID = thisCat.Parent.ID.ToString() });
                    }

                    //// newCats.Add(new myCats { Text = thisCat.Name, Value = thisCat.ID.ToString(), Level = thisCat.Indent }); //HE added
                }

                // Sortera lista för Se och göra
                List<SectionCats> sortedList = seochgoraCats.OrderBy(o => o.Parent).ToList();
                seochgoraCats = sortedList;
            }

            // ViewBag.CompanyCategory = companyCats;
            // ViewBag.MyCats = newCats; //HE added
            ViewBag.AtaCats = ataCats;
            ViewBag.BoCats = boendeCats;
            ViewBag.MotenCats = motenCats;
            ViewBag.SeochgoraCats = seochgoraCats;

            ViewBag.currentpage = currentPage.SuccessTarget; //// HE added

            ViewBag.FormHeader = "Skapa verksamhet";

            // Load data if in "editmode"
            if (companyid != null)
            {
                CompanyPageModel companyPage = contentRepository.Get<CompanyPageModel>(new PageReference(companyid));

                ViewBag.PageId = companyid;

                if (companyPage.Category != null)
                {
                    // Redirect if you dont have access
                    if (companyPage.Owner != EPiServer.Personalization.EPiServerProfile.Current.UserName)
                    { 
                        return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
                    }

                    // Loop through categories on page and print them to the viewbag for use in front 
                    foreach (int catId in companyPage.Category)
                    {
                        ViewBag.CompanyCategoryString += catId + ",";
                    }

                    ViewBag.FormHeader = "Redigera verksamhet";
                    ViewBag.Header = companyPage.Header;
                    ViewBag.Extract = companyPage.Extract;
                    ViewBag.MainBody = companyPage.MainBody;
                    ViewBag.Opening = companyPage.Opening;
                    ViewBag.Access = companyPage.Access;
                    ViewBag.Address = companyPage.Address;
                    ViewBag.Phone = companyPage.Phone;
                    ViewBag.Email = companyPage.Email;
                    ViewBag.Section = companyPage.SiteSection.ToString();
                    if (companyPage.Category.Count > 0)
                    {
                        ViewBag.SelectedCompanyCategory = companyPage.Category.First().ToString(); // companyPage.CompanyCategories.First().ToString(); //tidigare
                    }else
                    {

                    }
                }
            }

            var model = new CompanyCreatePageViewModel(currentPage);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ViewResult SubmitPage(CompanyCreatePageModel currentPage, IEnumerable<string> companyCategory, string header, string extract, string mainBody, string opening, string access, string address, string phone, string email, string pageId, string defaultLat, string defaultLong, string sektion)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);
            PageReference parent = settingsPage.CompanyContainerPage;

            // Create a new page of type CompanyPage under the parent page
            Models.Pages.CompanyPageModel companyPage = contentRepository.GetDefault<Models.Pages.CompanyPageModel>(parent);

            if (!pageId.IsNullOrEmpty())
            {
                companyPage.PageId = pageId;
            }

            CategoryList companyCatList = new CategoryList();

            // Add categories to list for the new page
            foreach (string id in companyCategory)
            {
                companyCatList.Add(int.Parse(id));
            }

            // Load correct page if in "editmode"
            if (companyPage.PageId != null)
            {
                companyPage = contentRepository.Get<CompanyPageModel>(new ContentReference(companyPage.PageId)).CreateWritableClone() as CompanyPageModel;
                if (companyPage != null)
                {
                    ViewBag.WebPage = companyPage.WebPage;
                    ViewBag.BookingPage = companyPage.BookingPage; //// HE added
                    ViewBag.Facebook = companyPage.FacebookPage;
                    ViewBag.Tripadvisor = companyPage.Tripadvisor;
                }
            }

            if (companyPage != null && (companyPage.Latitude.IsNullOrEmpty() && companyPage.Latitude.IsNullOrEmpty()))
            {
                if (defaultLat != string.Empty && defaultLong != string.Empty)
                    {
                    // Check that we get relevant data back else we set Nyköping city as center
                    if (Convert.ToDouble(defaultLat, CultureInfo.InvariantCulture) > 58 &&
                        Convert.ToDouble(defaultLat, CultureInfo.InvariantCulture) < 60.1 &&
                        Convert.ToDouble(defaultLong, CultureInfo.InvariantCulture) > 16 &&
                        Convert.ToDouble(defaultLong, CultureInfo.InvariantCulture) < 18)
                    {
                        ViewBag.Latitude = defaultLat;
                        ViewBag.Longitude = defaultLong;
                    }
                    else
                    {
                        ViewBag.Latitude = "58.75";
                        ViewBag.Longitude = "17";
                    }
                }
                else
                {
                    ViewBag.Latitude = "58.75";
                    ViewBag.Longitude = "17";
                }
            }
            else
            {
                ViewBag.Latitude = companyPage.Latitude;
                ViewBag.Longitude = companyPage.Longitude;
            }

            // Save values
            companyPage.PageName = header;
            companyPage.Category = companyCatList; // byter nu till default egenskap
            companyPage.Header = header;
            companyPage.Extract = new XhtmlString(extract);
            companyPage.MainBody = new XhtmlString(mainBody);
            companyPage.Opening = new XhtmlString(opening);
            companyPage.Access = new XhtmlString(access);
            companyPage.Address = address;
            companyPage.Phone = phone;
            companyPage.Email = email;
            companyPage.Owner = EPiServer.Personalization.EPiServerProfile.Current.UserName;

            // HE added
            var sel = Models.Pages.CompanyPageModel.SectionChoice.Seochgora;

            switch (sektion)
            {
                case "0":
                    sel = Models.Pages.CompanyPageModel.SectionChoice.Seochgora;
                    break;
                case "1":
                    sel = Models.Pages.CompanyPageModel.SectionChoice.Ata;
                    break;
                case "2":
                    sel = Models.Pages.CompanyPageModel.SectionChoice.Bo;
                    break;
                case "3":
                    sel = Models.Pages.CompanyPageModel.SectionChoice.Gruppaktiviteter;
                    break;
                default:
                    sel = Models.Pages.CompanyPageModel.SectionChoice.Seochgora;
                    break;
            }

            companyPage.SiteSection = sel; // "Seochgora"; //(Nykoping.Nykopingsguiden.Web.Models.Pages.CompanyPage.SectionChoice)Int32.Parse(sektion); //(Nykoping.Nykopingsguiden.Web.Models.Pages.CompanyPage.SectionChoice)sektion; //(Nykoping.Nykopingsguiden.Web.Models.Pages.CompanyPage.SectionChoice)secenum;

            contentRepository.Save(companyPage, SaveAction.Publish, AccessLevel.Create);

            ViewBag.PageId = companyPage.PageLink.ID;

            var model = new CompanyCreatePageViewModel(currentPage);

            return View((string)"Step2", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitStep2(string pageId, Models.Pages.CompanyCreatePageModel currentPage, string imagefile1, string imagefile2, string imagefile3, HttpPostedFileBase image1, HttpPostedFileBase image2, HttpPostedFileBase image3, HttpPostedFileBase file1, string webPage, string bookingPage, string facebook, string latitude, string longitude, string tripadvisor)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var mediaDataResolver = ServiceLocator.Current.GetInstance<ContentMediaResolver>();
            var blobFactory = ServiceLocator.Current.GetInstance<IBlobFactory>();

            Models.Pages.CompanyPageModel companyPage = contentRepository.Get<Models.Pages.CompanyPageModel>(new PageReference(pageId));

            Models.Pages.CompanyPageModel newCompanyPage = companyPage.CreateWritableClone() as Models.Pages.CompanyPageModel;

            var contentAssetHelper = ServiceLocator.Current.GetInstance<ContentAssetHelper>();

            // get an existing content asset folder or create a new one
            var assetsFolder = contentAssetHelper.GetOrCreateAssetFolder(newCompanyPage.ContentLink);

            if (!string.IsNullOrEmpty(imagefile1))
            {
                imagefile1 = imagefile1.Substring(22);
                var imagefile1byte = Convert.FromBase64String(imagefile1);
                MemoryStream streamByte1 = new MemoryStream(imagefile1byte);
                
                // streamByte1.ReadToEnd();
                string image1Extension = ".png";  // ex. .jpg or .txt

                // Get a suitable MediaData type from extension
                var mediaType1 = mediaDataResolver.GetFirstMatching(image1Extension);
                var contentType1 = contentTypeRepository.Load(mediaType1);
                
                // Get a new empty file data
                var media1 = contentRepository.GetDefault<MediaData>(assetsFolder.ContentLink, contentType1.ID);
                media1.Name = newCompanyPage.Header + "_" + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + image1Extension;
                var blob1 = blobFactory.CreateBlob(media1.BinaryDataContainer, image1Extension);
                blob1.Write(streamByte1);

                // Assign to file and publish changes
                media1.BinaryData = blob1;
                var file1ID = contentRepository.Save(media1, SaveAction.Publish, AccessLevel.Create);
                newCompanyPage.Image1 = file1ID;
            }

            if (!string.IsNullOrEmpty(imagefile2))
            {
                imagefile2 = imagefile2.Substring(22);
                var imagefile2byte = Convert.FromBase64String(imagefile2);
                MemoryStream streamByte2 = new MemoryStream(imagefile2byte);
                
                // streamByte1.ReadToEnd();
                string image2Extension = ".png";  // ex. .jpg or .txt

                // Get a suitable MediaData type from extension
                var mediaType2 = mediaDataResolver.GetFirstMatching(image2Extension);
                var contentType2 = contentTypeRepository.Load(mediaType2);

                // Get a new empty file data
                var media2 = contentRepository.GetDefault<MediaData>(assetsFolder.ContentLink, contentType2.ID);
                media2.Name = newCompanyPage.Header + "_" + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + image2Extension;
                var blob2 = blobFactory.CreateBlob(media2.BinaryDataContainer, image2Extension);
                blob2.Write(streamByte2);

                // Assign to file and publish changes
                media2.BinaryData = blob2;
                var file2ID = contentRepository.Save(media2, SaveAction.Publish, AccessLevel.Create);
                newCompanyPage.Image2 = file2ID;
            }

            if (!string.IsNullOrEmpty(imagefile3))
            {
                imagefile3 = imagefile3.Substring(22);
                var imagefile3byte = Convert.FromBase64String(imagefile3);
                MemoryStream streamByte3 = new MemoryStream(imagefile3byte);

                // streamByte1.ReadToEnd();
                string image3Extension = ".png";  // ex. .jpg or .txt

                // Get a suitable MediaData type from extension
                var mediaType3 = mediaDataResolver.GetFirstMatching(image3Extension);
                var contentType3 = contentTypeRepository.Load(mediaType3);

                // Get a new empty file data
                var media3 = contentRepository.GetDefault<MediaData>(assetsFolder.ContentLink, contentType3.ID);
                media3.Name = newCompanyPage.Header + "_" + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + image3Extension;
                var blob3 = blobFactory.CreateBlob(media3.BinaryDataContainer, image3Extension);
                blob3.Write(streamByte3);

                // Assign to file and publish changes
                media3.BinaryData = blob3;
                var file3ID = contentRepository.Save(media3, SaveAction.Publish, AccessLevel.Create);
                newCompanyPage.Image3 = file3ID;
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
                newCompanyPage.Document = file4ID;
            }

            // Save values to new page
            newCompanyPage.WebPage = webPage;
            newCompanyPage.BookingPage = bookingPage;
            newCompanyPage.FacebookPage = facebook;
            newCompanyPage.Tripadvisor = tripadvisor; // new XhtmlString(Tripadvisor);
            newCompanyPage.Latitude = latitude;
            newCompanyPage.Longitude = longitude;

            contentRepository.Save(newCompanyPage, SaveAction.Publish, AccessLevel.Create);

            return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
        }

        [HttpPost]
        public ActionResult DeleteAction(string pageId, Models.Pages.CompanyCreatePageModel currentPage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            if (pageId != null)
            {
                var companyPage = new ContentReference(pageId);

                contentRepository.MoveToWastebasket(companyPage, EPiServer.Personalization.EPiServerProfile.Current.UserName);
            }

            return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
        }

        // HE added
        public ActionResult MyAction(Models.Pages.CompanyCreatePageModel currentPage, int id)
        {
            // var partialViewModel = new partialViewModel(); // PartialViewModel();
            // TODO: Populate the model (viewmodel) here using the id
            return PartialView("_MyPartial", currentPage);
        }
    }

    // HE added
    public class MyCats
    {
        public string Value
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public int Level
        {
            get; set;
        }
    }

    public class SectionCats
    {
        public string Value
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public int Level
        {
            get; set;
        }

        public string Parent
        {
            get; set;
        }

        public string ParentID
        {
            get; set;
        }
    }

    public class CategoryComparer : IComparer<Category>
    {
        public int Compare(Category x, Category y)
        {
            if (x.SortOrder == y.SortOrder)
            { 
                return 0;
            }
            else if (x.SortOrder > y.SortOrder)
            { 
                return 1;
            }
            else
            { 
                return -1;
            }
        }
    }
}