using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Globalization;
using System.ComponentModel;

namespace AgileWizard.Locale
{
    public class GlobalizedDisplayAttribute : DisplayNameAttribute
    {
        public string Name
        {
            get;
            set;
        }

        public override string DisplayName
        {
            get
            {
                return LocaleHelper.GetLocaleString(Name);
            }
        }
    }
}
