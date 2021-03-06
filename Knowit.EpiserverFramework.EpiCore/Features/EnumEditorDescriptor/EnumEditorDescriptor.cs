﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor
{
    public class EnumEditorDescriptor<TEnum> : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(EnumSelectionFactory<TEnum>);
            ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}