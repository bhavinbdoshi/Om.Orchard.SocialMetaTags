using System.Web.Mvc;
using Orchard;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;

namespace Om.Orchard.SocialMetaTags.Controllers {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    [Themed, Admin]
    public class AdminController : Controller {
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public AdminController(IOrchardServices _services) {
            Services = _services;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index() {
            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tags Settings")))
                return new HttpUnauthorizedResult();
            return View();
        }
    }
}