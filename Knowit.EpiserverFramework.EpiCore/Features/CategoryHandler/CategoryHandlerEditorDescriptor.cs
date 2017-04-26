using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Knowit.EpiserverFramework.EpiCore.Features.CategoryHandler
{
    /// <summary>
    /// Category handler editor descriptor
    /// </summary>
    [EditorDescriptorRegistration(TargetType = typeof(CategoryList))]
    public class HideCategoryEditorDescriptor : EditorDescriptor
    {
        private const string IcategorizableCategory = "icategorizable_category";

        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            if (metadata.PropertyName != IcategorizableCategory)
            {
                return;
            }

            var categoryAttribute = metadata.Attributes.FirstOrDefault(a => typeof(HideCategoryAttribute) == a.GetType() || typeof(RemoveCategoryAttribute) == a.GetType());

            if (categoryAttribute as RemoveCategoryAttribute != null)
            {
                metadata.ShowForEdit = false;

                return;
            }

            if ((categoryAttribute as HideCategoryAttribute) != null)
            {
                metadata.GroupName = SystemTabNames.Settings;
            }
        }
    }
}
