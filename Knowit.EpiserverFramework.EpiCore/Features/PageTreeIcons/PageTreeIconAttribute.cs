using System;

namespace Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons
{
    /// <summary>
    /// Content icon attribute, UI descriptor attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PageTreeIconAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageTreeIconAttribute"/> class. 
        /// Content icon attribute
        /// </summary>
        /// <param name="iconClass">Icon class</param>
        public PageTreeIconAttribute(string iconClass)
        {
            IconClass = iconClass;
        }

        /// <summary>
        /// Gets or sets css class to apply to the icon
        /// </summary>
        public string IconClass { get; set; }
    } 
}
