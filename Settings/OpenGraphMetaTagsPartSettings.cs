using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Om.Orchard.SocialMetaTags.Models;

namespace Om.Orchard.SocialMetaTags.Settings
{
    public class OpenGraphMetaTagsPartSettings
    {
        public OpenGraphMetaTagsSettingsPart OpenGraphTagsSettings { get; set; }
        public string OgDefaultTitle { get; set; }
        public string OgDefaultType { get; set; }
        public string OgDefaultImage { get; set; }
        public string OgDefaultUrl { get; set; }
        public string OgDefaultDescription { get; set; }
    }
}