using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Models {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class AuthorshipMetaTagsSettingsPart : ContentPart {

        public bool AuthorRelTagEnabled {
            get { return this.Retrieve(x => x.AuthorRelTagEnabled); }
            set { this.Store(x => x.AuthorRelTagEnabled, value); }
        }

        public bool AuthorRelTagRequired {
            get { return this.Retrieve(x => x.AuthorRelTagRequired); }
            set { this.Store(x => x.AuthorRelTagRequired, value); }
        }
        
        public bool PublisherRelTagEnabled {
            get { return this.Retrieve(x => x.PublisherRelTagEnabled); }
            set { this.Store(x => x.PublisherRelTagEnabled, value); }
        }

        public bool PublisherRelTagRequired {
            get { return this.Retrieve(x => x.PublisherRelTagRequired); }
            set { this.Store(x => x.PublisherRelTagRequired, value); }
        }

        public string PublisherRelTagPageUrl {
            get { return this.Retrieve(x => x.PublisherRelTagPageUrl); }
            set { this.Store(x => x.PublisherRelTagPageUrl, value); }
        }

        public bool PublisherRelTagAllowOverWrite {
            get { return this.Retrieve(x => x.PublisherRelTagAllowOverWrite); }
            set { this.Store(x => x.PublisherRelTagAllowOverWrite, value); }
        }

        public bool RenderOutput {
            get { return AuthorRelTagEnabled || PublisherRelTagEnabled; }
        }

    }
}