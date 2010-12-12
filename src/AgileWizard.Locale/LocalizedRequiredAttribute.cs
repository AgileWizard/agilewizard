using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileWizard.Locale
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            this.ErrorMessageResourceType = typeof(Resources.Models.ValidationString);
            this.ErrorMessageResourceName = "Required";
        }
    }
}
