using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace Knowit.EpiserverFramework.EpiCore.Features.CollectionAttributes
{
    /// <summary>
    /// Custom attribute for setting a maximum allowed item count on a ContentArea or LinkItemCollection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MaxCount : ValidationAttribute
    {
        public MaxCount(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; }

        public override bool IsValid(object value)
        {
            bool isValid = false;

            if (value is ContentArea)
            {
                isValid = ValidateProperty(value as ContentArea);
            }

            if (value is LinkItemCollection)
            {
                isValid = ValidateProperty(value as LinkItemCollection);
            }
           
            return isValid;
        }

        private bool ValidateProperty(ContentArea item)
        {
            return item == null || item.Count <= Limit;
        }

        private bool ValidateProperty(LinkItemCollection item)
        {
            return item == null || item.Count <= Limit;
        }
    }
}
