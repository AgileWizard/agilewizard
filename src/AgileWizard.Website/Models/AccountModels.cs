using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Web.Security;

using AgileWizard.Domain;
using AgileWizard.Domain.Repositories;
using AgileWizard.Locale;

namespace AgileWizard.Website.Models
{

    #region Models
    public class LogOnModel
    {
        [Required]
        [GlobalizedDisplay(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [GlobalizedDisplay(Name = "Password")]
        public string Password { get; set; }

        [GlobalizedDisplay(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
    #endregion

    #region Services
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

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
