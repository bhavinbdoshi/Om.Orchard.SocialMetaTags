using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Om.Orchard.SocialMetaTags
{
    public class Globals {
        public static readonly string OpenGraphMetaTagsPartName = "OpenGraphMetaTagsPart";

        public struct  OpenGraphMetaTagsPartSettings {
            public static readonly string Name = "OpenGraphMetaTagsPartSettings";
            public static readonly string DefaultTitleName = Name + ".OgDefaultTitle";
            public static readonly string DefaultTypeName = Name + ".OgDefaultType";
            public static readonly string DefaultImageName = Name + ".OgDefaultImage";
            public static readonly string DefaultUrlName = Name + ".OgDefaultUrl";
            public static readonly string DefaultDescriptionName = Name + ".OgDefaultDescription";
        }

    }
}