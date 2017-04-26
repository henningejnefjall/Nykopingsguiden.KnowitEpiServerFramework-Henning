using System;

namespace Knowit.EpiserverFramework.EpiCore.Features.CategoryHandler
{
    /// <summary>
    /// Remove category property attribute, UI descriptor attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RemoveCategoryAttribute : Attribute
    {
    } 
}
