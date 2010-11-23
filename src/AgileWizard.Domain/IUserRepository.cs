namespace AgileWizard.Domain
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
    }
}