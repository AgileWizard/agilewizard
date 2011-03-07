using System.Web.Mvc;
using AgileWizard.Domain.Users;
namespace AgileWizard.Domain.Services
{
    public interface IUserAuthenticationService
    {
        bool IsAuthenticated { get; }
        bool SignIn(string userName, string password);
        void SignOut();
        User Create(User user, ModelStateDictionary stateDictionary);
    }
}