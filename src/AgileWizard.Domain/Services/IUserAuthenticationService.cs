namespace AgileWizard.Domain.Services
{
    public interface IUserAuthenticationService
    {
        bool IsMatch(string userName, string password);
    }
}