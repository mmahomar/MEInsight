using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    public class Language
    {
        public Language() { }
        public Language(string languageCode, string localeCode, string organizationName)
        {
            LanguageCode = languageCode;
            LocaleCode = localeCode;
            OrganizationName = organizationName;
        }

        public string LanguageCode { get; set; }
        public string LocaleCode { get; set; }
        public string OrganizationName { get; set; }
    }
}
