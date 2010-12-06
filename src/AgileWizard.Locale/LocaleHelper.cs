using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Globalization;

namespace AgileWizard.Locale
{
    public static class LocaleHelper
    {
        static ResourceManager localeResourceManager = new ResourceManager("AgileWizard.Locale.String", System.Reflection.Assembly.GetCallingAssembly());

        public static string GetLocaleString(string stringId, string localeName)
        {
            CultureInfo cultureInfo = new CultureInfo(localeName);
            return localeResourceManager.GetString(stringId, cultureInfo);
        }       
    }
}
