namespace Knowit.EpiserverFramework.Models
{
    /// <summary>
    /// String constants used in project Models
    /// </summary>
    public static class ModelsConstants
    {
        /// <summary>
        /// Group names for Content types
        /// </summary>
        public static class ContentTypeGroupNames
        {
            public const string Default = "default";

            // Block
            public const string Block = "block";
            public const string LocalBlock = "localblock";

            // Page types
            public const string Admin = "admintype";
            public const string Events = "events";
            public const string PageType = "pagetype";
            public const string MeetInNykg = "meetinnykg";
            public const string Special = "special";
            public const string System = "system";
        }

        /// <summary>
        /// These roles are used to set base acces to content types
        /// </summary>
        public static class ContentTypeAccessControl
        {
            public const string Administrators = "CmsAdmins, Administrators";
            public const string Editors = "CmsEditors, Administrators";
        }
    }
}
