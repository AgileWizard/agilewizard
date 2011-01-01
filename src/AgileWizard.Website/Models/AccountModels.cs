using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Web.Security;
using AgileWizard.Domain.Services;
using AgileWizard.Locale;
using AgileWizard.Locale.Resources.Models;

namespace AgileWizard.Website.Models
{

    #region Models
    public class LogOnModel
    {
        [LocalizedRequiredAttribute]
        [LocalizedDisplayName("UserName", NameResourceType=typeof(AccountName))]
        public string UserName { get; set; }

        [LocalizedRequiredAttribute]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password", NameResourceType = typeof(AccountName))]
        public string Password { get; set; }

        [LocalizedDisplayName("RememberMe", NameResourceType = typeof(AccountName))]
        public bool RememberMe { get; set; }
    }
    #endregion

    #region Services
    

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            Contract.Requires(String.IsNullOrEmpty(userName));

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion
}
