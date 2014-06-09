using Om.Orchard.SocialMetaTags.Models;
using Orchard.ContentManagement.Handlers;

namespace Om.Orchard.SocialMetaTags.Handlers {
    public class SummaryCardsMetaTagsSettingsPartHandler : ContentHandler {
        public SummaryCardsMetaTagsSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<SummaryCardsMetaTagsSettingsPart>("Site"));

            // initializing selections
            OnInitializing<SummaryCardsMetaTagsSettingsPart>((context, part) => {
                part.CardTitleTagEnabled = true;
                part.CardTitleTagRequired = true;
                part.CardTypeTagEnabled = true;
                part.CardTypeTagRequired = true;
                part.CardDescriptionTagEnabled = true;
                part.CardDescriptionTagRequired = true;
                part.CardCreatorTagEnabled = true;
                part.CardCreatorTagRequired = true;
            });
        }
    }
}