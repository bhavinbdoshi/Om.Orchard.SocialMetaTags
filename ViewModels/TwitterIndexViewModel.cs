
namespace Om.Orchard.SocialMetaTags.ViewModels {
    public class TwitterIndexViewModel {
        public bool CardTypeTagEnabled { get; set; }
        public bool CardTypeTagRequired { get; set; }
        public bool CardTitleTagEnabled { get; set; }
        public bool CardTitleTagRequired { get; set; }
        public bool CardDescriptionTagEnabled { get; set; }
        public bool CardDescriptionTagRequired { get; set; }
        public bool CardImageTagEnabled { get; set; }
        public bool CardImageTagRequired { get; set; }
        public bool CardCreatorTagEnabled { get; set; }
        public bool CardCreatorTagRequired { get; set; }
        public bool CardSiteTagEnabled { get; set; }
        public bool CardSiteTagRequired { get; set; }
        public bool CardSiteTagAllowOverwrite { get; set; }
        public string CardSiteTagValue { get; set; }
    }
}