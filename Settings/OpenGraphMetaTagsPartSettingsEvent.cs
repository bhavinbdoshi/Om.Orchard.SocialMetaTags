using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Om.Orchard.SocialMetaTags.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;
using Orchard.Localization;

namespace Om.Orchard.SocialMetaTags.Settings
{
    public class OpenGraphMetaTagsPartSettingsEvent : ContentDefinitionEditorEventsBase {
        private readonly IWorkContextAccessor _workContextAccessor;
        public OpenGraphMetaTagsPartSettingsEvent(IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }

        public Localizer T { get; set; }

        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition)
        {
            if (definition.PartDefinition.Name != Globals.OpenGraphMetaTagsPartName)
                yield break;

            var settings = definition.Settings.GetModel<OpenGraphMetaTagsPartSettings>();
            settings.OpenGraphTagsSettings = _workContextAccessor.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>();

            yield return DefinitionTemplate(settings);
        }

        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel)
        {
            if (builder.Name != Globals.OpenGraphMetaTagsPartName)
                yield break;

            var settings = new OpenGraphMetaTagsPartSettings {OpenGraphTagsSettings = _workContextAccessor.GetContext().CurrentSite.As<OpenGraphMetaTagsSettingsPart>()};

            if (updateModel.TryUpdateModel(settings, Globals.OpenGraphMetaTagsPartSettings.Name, null, null)) {
                builder.WithSetting(Globals.OpenGraphMetaTagsPartSettings.DefaultTitleName, settings.OgDefaultTitle);
                builder.WithSetting(Globals.OpenGraphMetaTagsPartSettings.DefaultDescriptionName, settings.OgDefaultDescription);
                builder.WithSetting(Globals.OpenGraphMetaTagsPartSettings.DefaultImageName, settings.OgDefaultImage);
                builder.WithSetting(Globals.OpenGraphMetaTagsPartSettings.DefaultTypeName, settings.OgDefaultType);
                builder.WithSetting(Globals.OpenGraphMetaTagsPartSettings.DefaultUrlName, settings.OgDefaultUrl);
            }

            yield return DefinitionTemplate(settings);
        }

    }
}