using System;

namespace Knowit.EpiserverFramework.EpiCore.Features.CategoryHandler
{
    /// <summary>
    /// Hide category property attribute, UI descriptor attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class HideCategoryAttribute : Attribute
    {
    } 
}
