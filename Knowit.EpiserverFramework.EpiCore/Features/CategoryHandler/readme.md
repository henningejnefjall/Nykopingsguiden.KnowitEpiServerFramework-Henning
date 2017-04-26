#Category handler

Use the attribute on an property override on CategoryList on a page type

##Hide the category property in the settingstab
```
[HideCategory]
public override CategoryList Category { get; set; }
```

##Remove the category
```
[RemoveCategory]
public override CategoryList Category { get; set; }
```

##Further example, for a specific page type only
```
// using EPiServer.Cms.Shell.UI.ObjectEditing;
//
// How to retrieve an page type
// var contentMetadata = (ContentDataMetadata)metadata;
// var ownerContent = contentMetadata.OwnerContent;

// if (ownerContent is GeneralPage)
// {
//    metadata.GroupName = SystemTabNames.Settings;
// }
```