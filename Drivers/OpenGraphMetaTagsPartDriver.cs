using Om.Orchard.SocialMetaTags.Models;
using Om.Orchard.SocialMetaTags.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.UI.Resources;
using Om.Orchard.SocialMetaTags.Helpers;
using System;
using Orchard.Localization;

namespace Om.Orchard.SocialMetaTags.Drivers {
    public class OpenGraphMetaTagsPartDriver : ContentPartDriver<OpenGraphMetaTagsPart> {
        private readonly IWorkContextAccessor _wca;

        public Localizer T { get; set; }

        public OpenGraphMetaTagsPartDriver(IWorkContextAccessor wca) {
            _wca = wca;
            T = NullLocalizer.Instance;
        }

        protected override string Prefix {
            get {
                return "ogmetatags";
            }
        }

        protected override DriverResult Display(OpenGraphMetaTagsPart part, string displayType, dynamic shapeHelper) {
            if (displayType != "Detail") return null;

            var resourceManager = _wca.GetContext().Resolve<IResourceManager>();
            var OpenGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();

            if (OpenGraphTagsSettings.RenderOutput) {
                if (OpenGraphTagsSettings.OgTitleTagEnabled && !String.IsNullOrWhiteSpace(part.OgTitle))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogtitlekey", "og:title", part.OgTitle));

                if (OpenGraphTagsSettings.OgTypeTagEnabled && part.OgType != "select")
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogtypekey", "og:type", part.OgType));

                if (OpenGraphTagsSettings.OgImageTagEnabled && !String.IsNullOrWhiteSpace(part.OgImage))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogimagekey", "og:image", part.OgImage));

                if (OpenGraphTagsSettings.OgUrlTagEnabled && !String.IsNullOrWhiteSpace(part.OgUrl))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogurlkey", "og:url", part.OgUrl));

                if (OpenGraphTagsSettings.OgDescriptionTagEnabled && !String.IsNullOrWhiteSpace(part.OgDescription))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogdesckey", "og:description", part.OgDescription));

                if (OpenGraphTagsSettings.OgLocaleTagEnabled && !String.IsNullOrWhiteSpace(part.OgLocale))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("oglocalekey", "og:locale", part.OgLocale));

                if (OpenGraphTagsSettings.OgSiteNameTagEnabled && !String.IsNullOrWhiteSpace(part.OgSiteName))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("ogsitenamekey", "og:site_name", part.OgSiteName));

                if (OpenGraphTagsSettings.FbAdminTagEnabled && !String.IsNullOrWhiteSpace(part.FBAdmins))
                    resourceManager.SetMeta(SocialMetaTagsHelpers.BuildPropertyMetaTag("fbadminskey", "fb:admins", part.FBAdmins));
            }
            return null;
        }

        protected override DriverResult Editor(OpenGraphMetaTagsPart part, dynamic shapeHelper) {
            part.OpenGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();
            return ContentShape("Parts_OpenGraphMetaTags_Edit",
                    () => shapeHelper.EditorTemplate(
                        TemplateName: "Parts/OpenGraphMetaTags",
                        Model: part,
                        Prefix: Prefix));
        }

        protected override DriverResult Editor(OpenGraphMetaTagsPart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                part.OpenGraphTagsSettings = _wca.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();

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
    }
}