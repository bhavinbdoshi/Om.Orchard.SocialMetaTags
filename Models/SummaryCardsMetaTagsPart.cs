using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Models {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class SummaryCardsMetaTagsPart : ContentPart {
        public SummaryCardsMetaTagsSettingsPart SummaryCardsTagsSettings { get; set; }

        public string CardType {
            get { return this.Retrieve(x => x.CardType, "", true); }
            set { this.Store(x => x.CardType, value, true); }
        }

        public string CardTitle {
            get { return this.Retrieve(x => x.CardTitle, "", true); }
            set { this.Store(x => x.CardTitle, value, true); }
        }

        public string CardDescription {
            get { return this.Retrieve(x => x.CardDescription, "", true); }
            set { this.Store(x => x.CardDescription, value, true); }
        }

        public string CardImage {
            get { return this.Retrieve(x => x.CardImage, "", true); }
            set { this.Store(x => x.CardImage, value, true); }
        }

        public string CardCreator {
            get { return this.Retrieve(x => x.CardCreator, "", true); }
            set { this.Store(x => x.CardCreator, value, true); }
        }

        public string CardSite {
            get { return this.Retrieve(x => x.CardSite, "", true); }
            set { this.Store(x => x.CardSite, value, true); }
        }
    }
}