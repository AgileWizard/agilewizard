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
        static ResourceManager localeResourceManager = new ResourceManager("AgileWizard.Locale.String", System.Reflection.Assembly.GetExecutingAssembly());

        public static string GetLocaleString(string stringId)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return localeResourceManager.GetString(stringId, cultureInfo);
        }       
    }
}
