using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Models {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class OpenGraphMetaTagsPart : ContentPart {
        public OpenGraphMetaTagsSettingsPart OpenGraphTagsSettings { get; set; }

        public string OgTitle {
            get { return this.Retrieve(x => x.OgTitle, "", true); }
            set { this.Store(x => x.OgTitle, value, true); }
        }

        public string OgType {
            get { return this.Retrieve(x => x.OgType, "", true); }
            set { this.Store(x => x.OgType, value, true); }
        }

        public string OgImage {
            get { return this.Retrieve(x => x.OgImage, "", true); }
            set { this.Store(x => x.OgImage, value, true); }
        }

        public string OgUrl {
            get { return this.Retrieve(x => x.OgUrl, "", true); }
            set { this.Store(x => x.OgUrl, value, true); }
        }

        public string OgDescription {
            get { return this.Retrieve(x => x.OgDescription, "", true); }
            set { this.Store(x => x.OgDescription, value, true); }
        }

        public string OgLocale {
            get { return this.Retrieve(x => x.OgLocale, "", true); }
            set { this.Store(x => x.OgLocale, value, true); }
        }

        public string OgSiteName {
            get { return this.Retrieve(x => x.OgSiteName, "", true); }
            set { this.Store(x => x.OgSiteName, value, true); }
        }

        public string FBAdmins {
            get { return this.Retrieve(x => x.FBAdmins, "", true); }
            set { this.Store(x => x.FBAdmins, value, true); }
        }

    }
}