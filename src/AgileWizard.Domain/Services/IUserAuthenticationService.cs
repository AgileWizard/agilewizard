namespace AgileWizard.Domain.Services
{
    public interface IUserAuthenticationService
    {
        bool IsAuthenticated { get; }
        bool SignIn(string userName, string password, bool rememberMe);
        void SignOut();
    }
}