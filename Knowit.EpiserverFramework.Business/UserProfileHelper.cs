using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowit.EpiserverFramework.Business
{
    public class UserProfileHelper
    {
        public class Profile
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string ZipCode { get; set; }
            public string Locality { get; set; }
            public string Company { get; set; }
            public string Password { get; set; }
        }

        public static void UpdateUserProfile(Profile p)
        {
            EPiServer.Personalization.EPiServerProfile user = EPiServer.Personalization.EPiServerProfile.Get(p.Email);
            
            user.Email = p.Email;
            user.FirstName = p.FirstName;
            user.LastName = p.LastName;
            user.Company = p.Company;
            user["Address"] = p.Address;
            user["ZipCode"] = p.ZipCode;
            user["Locality"] = p.Locality;

            user.Save();
        }
    }
}