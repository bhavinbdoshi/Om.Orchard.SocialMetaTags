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
    public class TwitterController : Controller {

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public TwitterController(IOrchardServices services) {
            Services = services;
            T = NullLocalizer.Instance;
        }

        // GET: /Twitter/
        public ActionResult Index() {
            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tag Settings")))
                return new HttpUnauthorizedResult();

            var twitterIndexViewModel = GetViewModel(Services.WorkContext.CurrentSite.As<SummaryCardsMetaTagsSettingsPart>());
            return View(twitterIndexViewModel);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(TwitterIndexViewModel model) {

            if (!Services.Authorizer.Authorize(Permissions.ManageSocialMetaTagsSettings, T("Can't manage Social Media Tags Settings")))
                return new HttpUnauthorizedResult();

            if (model.CardSiteTagEnabled && model.CardSiteTagRequired
                && !model.CardSiteTagAllowOverwrite && String.IsNullOrWhiteSpace(model.CardSiteTagValue))
                ModelState.AddModelError("_FORM", T("Site Twitter Handle is required as per your selection.").Text);

            if (ModelState.IsValid) {
                if (TryUpdateModel(model)) {
                    SetTwitterCardSettings(model);
                    Services.Notifier.Information(T("Twitter Summary Card Meta Tags settings saved successfully."));
                }
                else {
                    Services.Notifier.Information(T("Could not save Twitter Summary Card Meta Tags settings."));
                }
            }
            else {
                Services.Notifier.Error(T("Validation error"));
                return View(model);
            }
            return RedirectToAction("Index");
        }

        private TwitterIndexViewModel GetViewModel(SummaryCardsMetaTagsSettingsPart _scSettingsPart) {
            var twitterIndexViewModel = new TwitterIndexViewModel();
            twitterIndexViewModel.CardTypeTagEnabled = _scSettingsPart.CardTypeTagEnabled;
            twitterIndexViewModel.CardTypeTagRequired = _scSettingsPart.CardTypeTagRequired;
            twitterIndexViewModel.CardTitleTagEnabled = _scSettingsPart.CardTitleTagEnabled;
            twitterIndexViewModel.CardTitleTagRequired = _scSettingsPart.CardTitleTagRequired;
            twitterIndexViewModel.CardDescriptionTagEnabled = _scSettingsPart.CardDescriptionTagEnabled;
            twitterIndexViewModel.CardDescriptionTagRequired = _scSettingsPart.CardDescriptionTagRequired;
            twitterIndexViewModel.CardImageTagEnabled = _scSettingsPart.CardImageTagEnabled;
            twitterIndexViewModel.CardImageTagRequired = _scSettingsPart.CardImageTagRequired;
            twitterIndexViewModel.CardCreatorTagEnabled = _scSettingsPart.CardCreatorTagEnabled;
            twitterIndexViewModel.CardCreatorTagRequired = _scSettingsPart.CardCreatorTagRequired;
            twitterIndexViewModel.CardSiteTagEnabled = _scSettingsPart.CardSiteTagEnabled;
            twitterIndexViewModel.CardSiteTagRequired = _scSettingsPart.CardSiteTagRequired;
            twitterIndexViewModel.CardSiteTagAllowOverwrite = _scSettingsPart.CardSiteTagAllowOverwrite;
            twitterIndexViewModel.CardSiteTagValue = _scSettingsPart.CardSiteTagValue;
            return twitterIndexViewModel;
        }

        private void SetTwitterCardSettings(TwitterIndexViewModel _twitterIndexViewModel) {
            var scMetaTagsSettingsPart = Services.WorkContext.CurrentSite.As<SummaryCardsMetaTagsSettingsPart>();
            scMetaTagsSettingsPart.CardTypeTagEnabled = _twitterIndexViewModel.CardTypeTagEnabled;
            scMetaTagsSettingsPart.CardTypeTagRequired = _twitterIndexViewModel.CardTypeTagRequired;
            scMetaTagsSettingsPart.CardTitleTagEnabled = _twitterIndexViewModel.CardTitleTagEnabled;
            scMetaTagsSettingsPart.CardTitleTagRequired = _twitterIndexViewModel.CardTitleTagRequired;
            scMetaTagsSettingsPart.CardDescriptionTagEnabled = _twitterIndexViewModel.CardDescriptionTagEnabled;
            scMetaTagsSettingsPart.CardDescriptionTagRequired = _twitterIndexViewModel.CardDescriptionTagRequired;
            scMetaTagsSettingsPart.CardImageTagEnabled = _twitterIndexViewModel.CardImageTagEnabled;
            scMetaTagsSettingsPart.CardImageTagRequired = _twitterIndexViewModel.CardImageTagRequired;
            scMetaTagsSettingsPart.CardCreatorTagEnabled = _twitterIndexViewModel.CardCreatorTagEnabled;
            scMetaTagsSettingsPart.CardCreatorTagRequired = _twitterIndexViewModel.CardCreatorTagRequired;
            scMetaTagsSettingsPart.CardSiteTagEnabled = _twitterIndexViewModel.CardSiteTagEnabled;
            scMetaTagsSettingsPart.CardSiteTagRequired = _twitterIndexViewModel.CardSiteTagRequired;
            scMetaTagsSettingsPart.CardSiteTagAllowOverwrite = _twitterIndexViewModel.CardSiteTagAllowOverwrite;
            scMetaTagsSettingsPart.CardSiteTagValue = _twitterIndexViewModel.CardSiteTagValue;
        }
    }
}