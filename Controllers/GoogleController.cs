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
    public class GoogleController : Controller {

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public GoogleController(IOrchardServices _services) {
            Services = _services;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index() {
            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tags Settings")))
                return new HttpUnauthorizedResult();

            var googleTagsSettings = Services.WorkContext.CurrentSite.As<AuthorshipMetaTagsSettingsPart>();

            GoogleIndexViewModel model = new GoogleIndexViewModel();
            model.AuthorRelTagEnabled = googleTagsSettings.AuthorRelTagEnabled;
            model.AuthorRelTagRequired = googleTagsSettings.AuthorRelTagRequired;
            model.PublisherRelTagEnabled = googleTagsSettings.PublisherRelTagEnabled;
            model.PublisherRelTagRequired = googleTagsSettings.PublisherRelTagRequired;
            model.PublisherRelTagAllowOverWrite = googleTagsSettings.PublisherRelTagAllowOverWrite;
            model.PublisherRelTagPageUrl = googleTagsSettings.PublisherRelTagPageUrl;

            return View(model);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(GoogleIndexViewModel model) {
            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tags Settings")))
                return new HttpUnauthorizedResult();

            if (model.PublisherRelTagRequired && String.IsNullOrWhiteSpace(model.PublisherRelTagPageUrl)
                        && !model.PublisherRelTagAllowOverWrite) {
                ModelState.AddModelError("_FORM", T("Publisher Url is required as user can not overwrite.").Text);
            }

            if (!String.IsNullOrWhiteSpace(model.PublisherRelTagPageUrl)) {
                if (!model.PublisherRelTagPageUrl.StartsWith("http"))
                    ModelState.AddModelError("_FORM", T("Url must be in valid format").Text);
            }

            if (ModelState.IsValid) {
                if (TryUpdateModel(model)) {
                    var googleTagsSettings = Services.WorkContext.CurrentSite.As<AuthorshipMetaTagsSettingsPart>();
                    googleTagsSettings.AuthorRelTagEnabled = model.AuthorRelTagEnabled;
                    googleTagsSettings.AuthorRelTagRequired = model.AuthorRelTagRequired;
                    googleTagsSettings.PublisherRelTagEnabled = model.PublisherRelTagEnabled;
                    googleTagsSettings.PublisherRelTagRequired = model.PublisherRelTagRequired;
                    googleTagsSettings.PublisherRelTagAllowOverWrite = model.PublisherRelTagAllowOverWrite;
                    googleTagsSettings.PublisherRelTagPageUrl = model.PublisherRelTagPageUrl;

                    Services.Notifier.Information(T("Google Search Authorship Meta Tags settings saved successfully."));
                }
                else {
                    Services.Notifier.Information(T("Could not save Google Search Authorship Meta Tags settings"));
                }
            }
            else {
                Services.Notifier.Error(T("Validation Error."));
                return View(model);
            }

            return RedirectToAction("Index");
        }

    }
}