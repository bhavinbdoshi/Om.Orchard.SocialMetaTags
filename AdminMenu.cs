using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Om.Orchard.SocialMetaTags {
    [OrchardFeature("Om.Orchard.SocialMetaTags")]
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }

        public AdminMenu() {
            T = NullLocalizer.Instance;
        }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Settings"), settingsmenu => settingsmenu
                        .Add(T("Social Meta Tags"), "12",
                            menu => menu.Action("Index", "Admin", new { area = "Om.Orchard.SocialMetaTags" })
                               .Add(T("Settings Overview"), "12.1", item => Describe(item, "Index", "Admin", true))
                               .Add(T("Google Authorship Meta Tags"), "12.2", item => Describe(item, "Index", "Google", true))
                               .Add(T("Facebook Open Graph Meta Tags"), "12.3", item => Describe(item, "Index", "Facebook", true))
                               .Add(T("Twitter Summary Cards Meta Tags"), "12.4", item => Describe(item, "Index", "Twitter", true))
                    ));
        }

        static NavigationItemBuilder Describe(NavigationItemBuilder item, string actionName, string controllerName, bool localNav) {
            item = item.Action(actionName, controllerName, new { area = "Om.Orchard.SocialMetaTags" }).Permission(Permissions.ManageSocialMetaTagsSettings);
            if (localNav)
                item = item.LocalNav();
            return item;
        }
    }
}