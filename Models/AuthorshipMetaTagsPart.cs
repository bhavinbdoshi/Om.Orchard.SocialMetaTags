using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Models {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class AuthorshipMetaTagsPart : ContentPart{
        public AuthorshipMetaTagsSettingsPart GoogleTagsSettings { get; set; }

        public string GPAuthorProfileUrl {
            get { return this.Retrieve(x => x.GPAuthorProfileUrl, "", true); }
            set { this.Store(x => x.GPAuthorProfileUrl, value, true); }
        }

        public string GPPublisherProfileUrl {
            get { return this.Retrieve(x => x.GPPublisherProfileUrl, "", true); }
            set { this.Store(x => x.GPPublisherProfileUrl, value, true); }
        }

    }
}