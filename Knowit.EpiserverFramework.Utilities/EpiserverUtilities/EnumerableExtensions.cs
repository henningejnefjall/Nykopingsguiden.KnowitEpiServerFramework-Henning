using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;

namespace Knowit.EpiserverFramework.Utilities.EpiserverUtilities
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Filters out content that user shouldn't see
        /// </summary>
        /// <typeparam name="T">IEnumerable type</typeparam>
        /// <param name="contents">The IEnumerable to filter</param>
        /// <param name="requirePageTemplate">Set to true if page template is required </param>
        /// <param name="requireVisibleInMenu">Set to true if page has to be visible in menu </param>
        /// <returns> Filtered collection </returns>
        public static IEnumerable<T> FilterForDisplay<T>(this IEnumerable<T> contents, bool requirePageTemplate = false, bool requireVisibleInMenu = false)
            where T : IContent
        {
            var accessFilter = new FilterAccess();
            var publishedFilter = new FilterPublished();
            contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));
            if (requirePageTemplate)
            {
                var templateFilter = ServiceLocator.Current.GetInstance<FilterTemplate>();
                templateFilter.TemplateTypeCategories = TemplateTypeCategories.Page;
                contents = contents.Where(x => !templateFilter.ShouldFilter(x));
            }

            if (requireVisibleInMenu)
            {
                contents = contents.Where(x => VisibleInMenu(x));
            }

            return contents;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (rng == null)
            {
                throw new ArgumentNullException("rng");
            }

            return source.ShuffleIterator(rng);
        }

        private static bool VisibleInMenu(IContent content)
        {
            var page = content as PageData;
            return page == null || page.VisibleInMenu;
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
