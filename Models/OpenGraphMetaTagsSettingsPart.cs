using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Models {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class OpenGraphMetaTagsSettingsPart : ContentPart {
        public bool OgTitleTagEnabled {
            get { return this.Retrieve(x => x.OgTitleTagEnabled); }
            set { this.Store(x => x.OgTitleTagEnabled, value); }
        }

        public bool OgTitleTagRequired {
            get { return this.Retrieve(x => x.OgTitleTagRequired); }
            set { this.Store(x => x.OgTitleTagRequired, value); }
        }

        public bool OgTypeTagEnabled {
            get { return this.Retrieve(x => x.OgTypeTagEnabled); }
            set { this.Store(x => x.OgTypeTagEnabled, value); }
        }

        public bool OgTypeTagRequired {
            get { return this.Retrieve(x => x.OgTypeTagRequired); }
            set { this.Store(x => x.OgTypeTagRequired, value); }
        }

        public bool OgImageTagEnabled {
            get { return this.Retrieve(x => x.OgImageTagEnabled); }
            set { this.Store(x => x.OgImageTagEnabled, value); }
        }

        public bool OgImageTagRequired {
            get { return this.Retrieve(x => x.OgImageTagRequired); }
            set { this.Store(x => x.OgImageTagRequired, value); }
        }

        public bool OgUrlTagEnabled {
            get { return this.Retrieve(x => x.OgUrlTagEnabled); }
            set { this.Store(x => x.OgUrlTagEnabled, value); }
        }

        public bool OgUrlTagRequired {
            get { return this.Retrieve(x => x.OgUrlTagRequired); }
            set { this.Store(x => x.OgUrlTagRequired, value); }
        }

        public bool OgDescriptionTagEnabled {
            get { return this.Retrieve(x => x.OgDescriptionTagEnabled); }
            set { this.Store(x => x.OgDescriptionTagEnabled, value); }
        }

        public bool OgDescriptionTagRequired {
            get { return this.Retrieve(x => x.OgDescriptionTagRequired); }
            set { this.Store(x => x.OgDescriptionTagRequired, value); }
        }

        public bool OgLocaleTagEnabled {
            get { return this.Retrieve(x => x.OgLocaleTagEnabled); }
            set { this.Store(x => x.OgLocaleTagEnabled, value); }
        }

        public bool OgLocaleTagRequired {
            get { return this.Retrieve(x => x.OgLocaleTagRequired); }
            set { this.Store(x => x.OgLocaleTagRequired, value); }
        }

        public string OgLocaleTagValue {
            get { return this.Retrieve(x => x.OgLocaleTagValue); }
            set { this.Store(x => x.OgLocaleTagValue, value); }
        }

        public bool OgLocaleTagAllowOverwrite {
            get { return this.Retrieve(x => x.OgLocaleTagAllowOverwrite); }
            set { this.Store(x => x.OgLocaleTagAllowOverwrite, value); }
        }

        public bool OgSiteNameTagEnabled {
            get { return this.Retrieve(x => x.OgSiteNameTagEnabled); }
            set { this.Store(x => x.OgSiteNameTagEnabled, value); }
        }

        public bool OgSiteNameTagRequired {
            get { return this.Retrieve(x => x.OgSiteNameTagRequired); }
            set { this.Store(x => x.OgSiteNameTagRequired, value); }
        }

        public string OgSiteNameTagValue {
            get { return this.Retrieve(x => x.OgSiteNameTagValue); }
            set { this.Store(x => x.OgSiteNameTagValue, value); }
        }

        public bool OgSiteNameTagAllowOverwrite {
            get { return this.Retrieve(x => x.OgSiteNameTagAllowOverwrite); }
            set { this.Store(x => x.OgSiteNameTagAllowOverwrite, value); }
        }

        public bool FbAdminTagEnabled {
            get { return this.Retrieve(x => x.FbAdminTagEnabled); }
            set { this.Store(x => x.FbAdminTagEnabled, value); }
        }

        public bool FbAdminTagRequired {
            get { return this.Retrieve(x => x.FbAdminTagRequired); }
            set { this.Store(x => x.FbAdminTagRequired, value); }
        }

        public string FbAdminTagValue {
            get { return this.Retrieve(x => x.FbAdminTagValue); }
            set { this.Store(x => x.FbAdminTagValue, value); }
        }

        public bool FbAdminTagAllowOverwrite {
            get { return this.Retrieve(x => x.FbAdminTagAllowOverwrite); }
            set { this.Store(x => x.FbAdminTagAllowOverwrite, value); }
        }

        public bool RenderOutput {
            get {
                return OgTitleTagEnabled || OgTypeTagEnabled ||
                    OgImageTagEnabled || OgUrlTagEnabled || OgDescriptionTagEnabled || OgLocaleTagEnabled ||
                    OgSiteNameTagEnabled || FbAdminTagEnabled;
            }
        }
    }
}