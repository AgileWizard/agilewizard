using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Web.Security;
using AgileWizard.Domain;

namespace AgileWizard.Website.Models
{

    #region Models
   public class LogOnModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }

       public IUserRepository UserRepository { get; set; }

       public bool IsMatch()
       {
            var user = UserRepository.GetUserByName(UserName);

           return user.Password == Password;
       }
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
