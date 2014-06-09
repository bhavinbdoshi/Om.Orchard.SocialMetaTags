
namespace Om.Orchard.SocialMetaTags.ViewModels {
    public class FacebookIndexViewModel {
        public bool OgTitleTagEnabled { get; set; }
        public bool OgTitleTagRequired { get; set; }
        public bool OgTypeTagEnabled { get; set; }
        public bool OgTypeTagRequired { get; set; }
        public bool OgImageTagEnabled { get; set; }
        public bool OgImageTagRequired { get; set; }
        public bool OgUrlTagEnabled { get; set; }
        public bool OgUrlTagRequired { get; set; }
        public bool OgDescriptionTagEnabled { get; set; }
        public bool OgDescriptionTagRequired { get; set; }
        public bool OgLocaleTagEnabled { get; set; }
        public bool OgLocaleTagRequired { get; set; }
        public string OgLocaleTagValue { get; set; }
        public bool OgLocaleTagAllowOverwrite { get; set; }
        public bool OgSiteNameTagEnabled { get; set; }
        public bool OgSiteNameTagRequired { get; set; }
        public string OgSiteNameTagValue { get; set; }
        public bool OgSiteNameTagAllowOverwrite { get; set; }
        public bool FbAdminTagEnabled { get; set; }
        public bool FbAdminTagRequired { get; set; }
        public string FbAdminTagValue { get; set; }
        public bool FbAdminTagAllowOverwrite { get; set;}

        public string CurrentSiteName { get; set; }
        public string CurrentCulture { get; set; }
    }
}