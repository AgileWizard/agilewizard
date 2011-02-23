namespace AgileWizard.Domain.Services
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName);
        void SignOut();
    }
}
