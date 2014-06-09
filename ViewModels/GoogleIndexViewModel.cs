
namespace Om.Orchard.SocialMetaTags.ViewModels {
    public class GoogleIndexViewModel {
        public bool AuthorRelTagEnabled { get; set; }
        public bool AuthorRelTagRequired { get; set; }
        public bool PublisherRelTagEnabled { get; set; }
        public bool PublisherRelTagRequired { get; set; }
        public string PublisherRelTagPageUrl { get; set; }
        public bool PublisherRelTagAllowOverWrite { get; set; }
    }
}