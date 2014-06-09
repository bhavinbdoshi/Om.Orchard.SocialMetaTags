using System;
using System.Web.Mvc;
using Om.Orchard.SocialMetaTags.Models;
using Om.Orchard.SocialMetaTags.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;

namespace Om.Orchard.SocialMetaTags.Controllers {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    [Themed, Admin]
    public class FacebookController : Controller {

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public FacebookController(IOrchardServices _services) {
            Services = _services;
            T = NullLocalizer.Instance;
        }

        // GET: /Facebook/
        public ActionResult Index() {
            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tag Settings")))
                return new HttpUnauthorizedResult();

            var fbIndexViewModel = GetViewModel(Services.WorkContext.CurrentSite.As<OpenGraphMetaTagsSettingsPart>());
            fbIndexViewModel.CurrentCulture = Services.WorkContext.CurrentSite.SiteCulture;
            fbIndexViewModel.CurrentSiteName = Services.WorkContext.CurrentSite.SiteName;

            return View(fbIndexViewModel);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(FacebookIndexViewModel model) {

            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tags Settings")))
                return new HttpUnauthorizedResult();

            if (model.OgLocaleTagEnabled && model.OgLocaleTagRequired && !model.OgLocaleTagAllowOverwrite && String.IsNullOrWhiteSpace(model.OgLocaleTagValue))
                ModelState.AddModelError("_FORM", T("Locale value is required as per your selection.").Text);

            if (model.OgSiteNameTagEnabled && model.OgSiteNameTagRequired && !model.OgSiteNameTagAllowOverwrite && String.IsNullOrWhiteSpace(model.OgSiteNameTagValue))
                ModelState.AddModelError("_FORM", T("Site Name value is required as per your selection.").Text);

            if (model.FbAdminTagEnabled && model.FbAdminTagRequired && !model.FbAdminTagAllowOverwrite && String.IsNullOrWhiteSpace(model.FbAdminTagValue))
                ModelState.AddModelError("_FORM", T("fb admins value is required as per your selection.").Text);

            if (ModelState.IsValid) {
                if (TryUpdateModel(model)) {
                    SetOgSettingsPart(model);
                    Services.Notifier.Information(T("Open Graph Meta Tags settings saved successfully."));
                }
                else {
                    Services.Notifier.Information(T("Could not save Open Graph Meta Tags settings."));
                }
            }
            else {
                Services.Notifier.Error(T("Validation error"));
                return View(model);
            }

            return RedirectToAction("Index");
        }

        private FacebookIndexViewModel GetViewModel(OpenGraphMetaTagsSettingsPart _ogSettingsPart) {
            var fbIndexViewModel = new FacebookIndexViewModel();
            fbIndexViewModel.OgTitleTagEnabled = _ogSettingsPart.OgTitleTagEnabled;
            fbIndexViewModel.OgTitleTagRequired = _ogSettingsPart.OgTitleTagRequired;
            fbIndexViewModel.OgTypeTagEnabled = _ogSettingsPart.OgTypeTagEnabled;
            fbIndexViewModel.OgTypeTagRequired = _ogSettingsPart.OgTypeTagRequired;
            fbIndexViewModel.OgImageTagEnabled = _ogSettingsPart.OgImageTagEnabled;
            fbIndexViewModel.OgImageTagRequired = _ogSettingsPart.OgImageTagRequired;
            fbIndexViewModel.OgUrlTagEnabled = _ogSettingsPart.OgUrlTagEnabled;
            fbIndexViewModel.OgUrlTagRequired = _ogSettingsPart.OgUrlTagRequired;
            fbIndexViewModel.OgDescriptionTagEnabled = _ogSettingsPart.OgDescriptionTagEnabled;
            fbIndexViewModel.OgDescriptionTagRequired = _ogSettingsPart.OgDescriptionTagRequired;
            fbIndexViewModel.OgLocaleTagEnabled = _ogSettingsPart.OgLocaleTagEnabled;
            fbIndexViewModel.OgLocaleTagRequired = _ogSettingsPart.OgLocaleTagRequired;
            fbIndexViewModel.OgLocaleTagValue = _ogSettingsPart.OgLocaleTagValue;
            fbIndexViewModel.OgLocaleTagAllowOverwrite = _ogSettingsPart.OgLocaleTagAllowOverwrite;
            fbIndexViewModel.OgSiteNameTagEnabled = _ogSettingsPart.OgSiteNameTagEnabled;
            fbIndexViewModel.OgSiteNameTagRequired = _ogSettingsPart.OgSiteNameTagRequired;
            fbIndexViewModel.OgSiteNameTagValue = _ogSettingsPart.OgSiteNameTagValue;
            fbIndexViewModel.OgSiteNameTagAllowOverwrite = _ogSettingsPart.OgSiteNameTagAllowOverwrite;
            fbIndexViewModel.FbAdminTagEnabled = _ogSettingsPart.FbAdminTagEnabled;
            fbIndexViewModel.FbAdminTagRequired = _ogSettingsPart.FbAdminTagRequired;
            fbIndexViewModel.FbAdminTagValue = _ogSettingsPart.FbAdminTagValue;

            return fbIndexViewModel;
        }

        private void SetOgSettingsPart(FacebookIndexViewModel _fbIndexViewModel) {
            var ogSettingsPart = Services.WorkContext.CurrentSite.As<OpenGraphMetaTagsSettingsPart>();
            ogSettingsPart.OgTitleTagEnabled = _fbIndexViewModel.OgTitleTagEnabled;
            ogSettingsPart.OgTitleTagRequired = _fbIndexViewModel.OgTitleTagRequired;
            ogSettingsPart.OgTypeTagEnabled = _fbIndexViewModel.OgTypeTagEnabled;
            ogSettingsPart.OgTypeTagRequired = _fbIndexViewModel.OgTypeTagRequired;
            ogSettingsPart.OgImageTagEnabled = _fbIndexViewModel.OgImageTagEnabled;
            ogSettingsPart.OgImageTagRequired = _fbIndexViewModel.OgImageTagRequired;
            ogSettingsPart.OgUrlTagEnabled = _fbIndexViewModel.OgUrlTagEnabled;
            ogSettingsPart.OgUrlTagRequired = _fbIndexViewModel.OgUrlTagRequired;
            ogSettingsPart.OgDescriptionTagEnabled = _fbIndexViewModel.OgDescriptionTagEnabled;
            ogSettingsPart.OgDescriptionTagRequired = _fbIndexViewModel.OgDescriptionTagRequired;
            ogSettingsPart.OgLocaleTagEnabled = _fbIndexViewModel.OgLocaleTagEnabled;
            ogSettingsPart.OgLocaleTagRequired = _fbIndexViewModel.OgLocaleTagRequired;
            ogSettingsPart.OgLocaleTagValue = _fbIndexViewModel.OgLocaleTagValue;
            ogSettingsPart.OgLocaleTagAllowOverwrite = _fbIndexViewModel.OgLocaleTagAllowOverwrite;
            ogSettingsPart.OgSiteNameTagEnabled = _fbIndexViewModel.OgSiteNameTagEnabled;
            ogSettingsPart.OgSiteNameTagRequired = _fbIndexViewModel.OgSiteNameTagRequired;
            ogSettingsPart.OgSiteNameTagValue = _fbIndexViewModel.OgSiteNameTagValue;
            ogSettingsPart.OgSiteNameTagAllowOverwrite = _fbIndexViewModel.OgSiteNameTagAllowOverwrite;
            ogSettingsPart.FbAdminTagEnabled = _fbIndexViewModel.FbAdminTagEnabled;
            ogSettingsPart.FbAdminTagRequired = _fbIndexViewModel.FbAdminTagRequired;
            ogSettingsPart.FbAdminTagValue = _fbIndexViewModel.FbAdminTagValue;

        }




    }
}