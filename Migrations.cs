using Om.Orchard.SocialMetaTags.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Om.Orchard.SocialMetaTags.Migrations {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition(
                typeof(AuthorshipMetaTagsPart).Name,
                cfg => cfg
                    .Attachable()
                    .WithDescription("Allows author to input Google Search Results Authorship related Meta Tags.")
                );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(OpenGraphMetaTagsPart).Name,
                cfg => cfg
                    .Attachable()
                    .WithDescription("Allows author to input Open Graph (Facebook/Google/Twitter) related Social Share Meta Tags.")
                );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(SummaryCardsMetaTagsPart).Name,
                cfg => cfg
                    .Attachable()
                    .WithDescription("Allows author to input Twitter Summary Cards related Social Share Meta Tags.")
                );

            return 1;
        }
    }


    



}