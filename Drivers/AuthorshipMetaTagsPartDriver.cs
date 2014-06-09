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
    public class AuthorshipMetaTagsPartDriver : ContentPartDriver<AuthorshipMetaTagsPart> {
        private readonly IWorkContextAccessor _wca;

        public Localizer T { get; set; }

        public AuthorshipMetaTagsPartDriver(IWorkContextAccessor workContextAccessor) {
            _wca = workContextAccessor;
            T = NullLocalizer.Instance;
        }

        protected override string Prefix {
            get {
                return "socialmetatags";
            }
        }

        protected override DriverResult Display(AuthorshipMetaTagsPart part, string displayType, dynamic shapeHelper) {
            if (displayType != "Detail") return null;

            var resourceManager = _wca.GetContext().Resolve<IResourceManager>();
            var googleTagsSettings = _wca.GetContext().CurrentSite.As<AuthorshipMetaTagsSettingsPart>();

            if (googleTagsSettings.RenderOutput) {
                if (googleTagsSettings.AuthorRelTagEnabled && !String.IsNullOrWhiteSpace(part.GPAuthorProfileUrl)) {
                    resourceManager.RegisterLink(SocialMetaTagsHelpers.BuildLinkEntry("author", part.GPAuthorProfileUrl));
                }
                if (googleTagsSettings.PublisherRelTagEnabled && !String.IsNullOrWhiteSpace(part.GPPublisherProfileUrl)) {
                    resourceManager.RegisterLink(SocialMetaTagsHelpers.BuildLinkEntry("publisher", part.GPPublisherProfileUrl));
                }
            }
            return null;
        }

        //Get
        protected override DriverResult Editor(AuthorshipMetaTagsPart part, dynamic shapeHelper) {
            part.GoogleTagsSettings = _wca.GetContext().CurrentSite.As<AuthorshipMetaTagsSettingsPart>();
            return ContentShape("Parts_AuthorshipMetaTags_Edit",
                    () => shapeHelper.EditorTemplate(
                        TemplateName: "Parts/AuthorshipMetaTags",
                        Model: part,
                        Prefix: Prefix));
        }

        //Post
        protected override DriverResult Editor(AuthorshipMetaTagsPart part, IUpdateModel updater, dynamic shapeHelper) {
            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                part.GoogleTagsSettings = _wca.GetContext().CurrentSite.As<AuthorshipMetaTagsSettingsPart>();

                if (part.GoogleTagsSettings.AuthorRelTagEnabled && part.GoogleTagsSettings.AuthorRelTagRequired
                    && String.IsNullOrWhiteSpace(part.GPAuthorProfileUrl))
                    updater.AddModelError("_FORM", T("Google+ Profile Url is required"));
                if (part.GoogleTagsSettings.PublisherRelTagEnabled && part.GoogleTagsSettings.PublisherRelTagRequired
                   && String.IsNullOrWhiteSpace(part.GPPublisherProfileUrl))
                    updater.AddModelError("_FORM", T("Google+ Business page Url is required"));

            }
            return Editor(part, shapeHelper);
        }
    }
}