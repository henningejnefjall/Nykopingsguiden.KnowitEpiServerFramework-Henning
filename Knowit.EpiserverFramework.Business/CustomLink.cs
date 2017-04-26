using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowit.EpiserverFramework.Business
{
    using System.Web.Routing;

    public class CustomLink
    {
        public bool IsActivePage { get; set; }

        public string LinkText { get; set; }

        public string Url { get; set; }

        public RouteValueDictionary Route { get; set; }
    }
}
