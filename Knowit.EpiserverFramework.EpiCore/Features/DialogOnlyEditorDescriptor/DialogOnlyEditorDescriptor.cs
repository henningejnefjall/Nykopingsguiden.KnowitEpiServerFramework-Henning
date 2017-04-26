using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Knowit.EpiserverFramework.EpiCore.Features.DialogOnlyEditorDescriptor
{
    [EditorDescriptorRegistration(TargetType = typeof(ContentArea), UIHint = "DialogOnly")]
    public class DialogOnlyEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);
            ClientEditingClass = "epi.cms.contentediting.editors.ContentAreaEditor";
            metadata.CustomEditorSettings["uiWrapperType"] = "flyout";
        }
    }
}
