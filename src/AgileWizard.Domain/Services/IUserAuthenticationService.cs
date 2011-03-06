namespace AgileWizard.Domain.Services
{
    public interface IUserAuthenticationService
    {
        bool IsAuthenticated { get; }
        bool SignIn(string userName, string password);
        void SignOut();

        bool ExistUser(string userName);

        bool MatchPasswordRule(string password);
    }
}