using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace Knowit.EpiserverFramework.Utilities.EpiserverUtilities
{
    public static class UrlUtilities
    {
        /// <summary>
        /// Returns a friendly url for a EPiServer.Url
        /// </summary>
        /// <param name="pageLink">Url</param>
        /// <returns>Converted IContent</returns>
        public static string GetFriendlyUrl(this IContent pageLink)
        {
            return ServiceLocator.Current.GetInstance<UrlResolver>().GetVirtualPath(pageLink).ToString();
        }

        public static RouteValueDictionary ContentRoute(this UrlHelper urlHelper, ContentReference contentLink, object routeValues = null)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary(routeValues).Union(urlHelper.RequestContext.RouteData.Values) as RouteValueDictionary;
            dictionary[RoutingConstants.ActionKey] = "index";
            dictionary[RoutingConstants.NodeKey] = contentLink;
            return dictionary;
        }

        private static RouteValueDictionary Union(this RouteValueDictionary first, RouteValueDictionary second)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary(second);
            foreach (KeyValuePair<string, object> pair in first)
            {
                if (pair.Value != null)
                {
                    dictionary[pair.Key] = pair.Value;
                }
            }

            return dictionary;
        }
    }
}
