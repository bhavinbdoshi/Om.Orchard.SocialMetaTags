using Om.Orchard.SocialMetaTags.Models;
using Om.Orchard.SocialMetaTags.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.UI.Resources;
using Om.Orchard.SocialMetaTags.Helpers;
using System;
using System.Collections.Generic;
using Om.Orchard.SocialMetaTags.Settings;
using Orchard.Localization;
using Orchard.Tokens;

namespace Om.Orchard.SocialMetaTags.Drivers {
    public class OpenGraphMetaTagsPartDriver : ContentPartDriver<OpenGraphMetaTagsPart> {
        private readonly IWorkContextAccessor _wca;
        private readonly ITokenizer _tokenizer;

        public Localizer T { get; set; }

        public OpenGraphMetaTagsPartDriver(
            IWorkContextAccessor wca, 
            ITokenizer tokenizer) {
            _wca = wca;
            _tokenizer = tokenizer;
            T = NullLocalizer.Instance;
        }

        protected override string Prefix {
            get {
                return "ogmetatags";
            }
        }

        protected override DriverResult Display(OpenGraphMetaTagsPart part, string displayType, dynamic shapeHelper) {
            if (displayType != "Detail") 
                return null;

            var resourceManager = _wca.GetContext().Resolve<IResourceManager>();
            var openGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();
            var contentItem = part.ContentItem;
            var dict = new Dictionary<string, object> {{"Content", contentItem}};
            var defaultSettings = part.TypePartDefinition.Settings.GetModel<OpenGraphMetaTagsPartSettings>();

            if (openGraphTagsSettings.RenderOutput) {
                if (openGraphTagsSettings.OgTitleTagEnabled && !String.IsNullOrWhiteSpace(GetValue(part.OgTitle, defaultSettings.OgDefaultTitle)))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogtitlekey", "og:title", _tokenizer.Replace(GetValue(part.OgTitle, defaultSettings.OgDefaultTitle), dict)));

                if (openGraphTagsSettings.OgTypeTagEnabled && part.OgType != "select" && defaultSettings.OgDefaultType != "select")
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogtypekey", "og:type", _tokenizer.Replace(GetValue(part.OgType, defaultSettings.OgDefaultType), dict)));

                if (openGraphTagsSettings.OgImageTagEnabled && !String.IsNullOrWhiteSpace(GetValue(part.OgImage, defaultSettings.OgDefaultImage)))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogimagekey", "og:image", _tokenizer.Replace(GetValue(part.OgImage, defaultSettings.OgDefaultImage), dict)));

                if (openGraphTagsSettings.OgUrlTagEnabled && !String.IsNullOrWhiteSpace(GetValue(part.OgUrl, defaultSettings.OgDefaultUrl)))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogurlkey", "og:url", _tokenizer.Replace(GetValue(part.OgUrl, defaultSettings.OgDefaultUrl), dict)));

                if (openGraphTagsSettings.OgDescriptionTagEnabled && !String.IsNullOrWhiteSpace(GetValue(part.OgDescription, defaultSettings.OgDefaultDescription)))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogdesckey", "og:description", _tokenizer.Replace(GetValue(part.OgDescription, defaultSettings.OgDefaultDescription), dict)));

                if (openGraphTagsSettings.OgLocaleTagEnabled && !String.IsNullOrWhiteSpace(part.OgLocale))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("oglocalekey", "og:locale", part.OgLocale));

                if (openGraphTagsSettings.OgSiteNameTagEnabled && !String.IsNullOrWhiteSpace(part.OgSiteName))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogsitenamekey", "og:site_name", part.OgSiteName));

                if (openGraphTagsSettings.FbAdminTagEnabled && !String.IsNullOrWhiteSpace(part.FBAdmins))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("fbadminskey", "fb:admins", part.FBAdmins));
            }
            return null;
        }

        protected override DriverResult Editor(OpenGraphMetaTagsPart part, dynamic shapeHelper) {
            part.OpenGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();
            part.DefaultSettings = part.TypePartDefinition.Settings.GetModel<OpenGraphMetaTagsPartSettings>();
            return ContentShape("Parts_OpenGraphMetaTags_Edit",
                    () => shapeHelper.EditorTemplate(
                        TemplateName: "Parts/OpenGraphMetaTags",
                        Model: part,
                        Prefix: Prefix));
        }

        protected override DriverResult Editor(OpenGraphMetaTagsPart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                part.OpenGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();
                part.DefaultSettings = part.TypePartDefinition.Settings.GetModel<OpenGraphMetaTagsPartSettings>();

                //Validation as per selections
                if (part.OpenGraphTagsSettings.OgTitleTagEnabled && part.OpenGraphTagsSettings.OgTitleTagRequired
                    && String.IsNullOrWhiteSpace(part.OgTitle))
                    updater.AddModelError("_FORM", T("Open Graph Title field is required"));

                if (part.OpenGraphTagsSettings.OgTypeTagEnabled && part.OpenGraphTagsSettings.OgTypeTagRequired
                    && part.OgType == "select")
                    updater.AddModelError("_FORM", T("Open Grpah Type field is required"));

                if (part.OpenGraphTagsSettings.OgImageTagEnabled && part.OpenGraphTagsSettings.OgImageTagRequired
                    && String.IsNullOrWhiteSpace(part.OgImage))
                    updater.AddModelError("_FORM", T("Open Graph Image field is required"));

                if (part.OpenGraphTagsSettings.OgUrlTagEnabled && part.OpenGraphTagsSettings.OgUrlTagRequired
                    && String.IsNullOrWhiteSpace(part.OgUrl))
                    updater.AddModelError("_FORM", T("Open Graph Url field is required"));

                if (part.OpenGraphTagsSettings.OgDescriptionTagEnabled && part.OpenGraphTagsSettings.OgDescriptionTagRequired
                    && String.IsNullOrWhiteSpace(part.OgDescription))
                    updater.AddModelError("_FORM", T("Open Graph Description field is required"));

                if (part.OpenGraphTagsSettings.OgLocaleTagEnabled && part.OpenGraphTagsSettings.OgLocaleTagRequired
                    && String.IsNullOrWhiteSpace(part.OgLocale))
                    updater.AddModelError("_FORM", T("Open Graph Locale field is required"));

                if (part.OpenGraphTagsSettings.OgSiteNameTagEnabled && part.OpenGraphTagsSettings.OgSiteNameTagRequired
                    && String.IsNullOrWhiteSpace(part.OgSiteName))
                    updater.AddModelError("_FORM", T("Open Graph Site Name field is required"));

                if (part.OpenGraphTagsSettings.FbAdminTagEnabled && part.OpenGraphTagsSettings.FbAdminTagRequired
                    && String.IsNullOrWhiteSpace(part.FBAdmins))
                    updater.AddModelError("_FORM", T("FB Admins field is required"));

            }
            return Editor(part, shapeHelper);
        }


        private string GetValue(string userInput, string defaultValue) {
            if(string.IsNullOrWhiteSpace(userInput))
                return defaultValue;
            return userInput;
        }
    }
}