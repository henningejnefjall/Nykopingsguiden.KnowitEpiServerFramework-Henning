#Content type thumbnail

Icons are locacated in the following folder
..\Knowit.EpiserverFramework.Web\ClientResources\Images\Icons\ContentTypeThumbnails

File location is stored on ContentTypeThumbnailConstants

The feature is implemented by decorating Block- and PageTypes with the attribute 
Further example, for a specific page type only

```
[SiteContentType]
[ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
public class SettingsPage : PageData
{
```

