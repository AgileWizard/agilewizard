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
        [LocalizedDisplayName("UserName", NameResourceType = typeof(AccountName))]
        public virtual string UserName { get; set; }

        [LocalizedRequiredAttribute]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password", NameResourceType = typeof(AccountName))]
        public string Password { get; set; }
    }
    #endregion

    #region AccountCreateModel
    public class AccountCreateModel
    {
        const string EMAIL = "agilewizard@gmail.com";
        const string PASSWORD = "agilewizard";

        internal static AccountCreateModel DefaultModel()
        {
            return new AccountCreateModel
            {
                Email = EMAIL,
                Password = PASSWORD
            };
        }

        [LocalizedRequiredAttribute]
        [Required(ErrorMessageResourceName = "EmailIsRequired", ErrorMessageResourceType = typeof(ValidationString))]
        [LocalizedDisplayName("Email", NameResourceType = typeof(AccountName))]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessageResourceName = "EmailIncorrectFormat", ErrorMessageResourceType=typeof(ValidationString))]
        public string Email { get; set; }

        [LocalizedRequiredAttribute]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password", NameResourceType = typeof(AccountName))]
        [Required(ErrorMessageResourceName = "PasswordIsRequired", ErrorMessageResourceType = typeof(ValidationString))]
        public string Password { get; set; }
    }
    #endregion

    #region Services


    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName)
        {
            Contract.Requires(String.IsNullOrEmpty(userName));

            FormsAuthentication.SetAuthCookie(userName, false);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion
}
