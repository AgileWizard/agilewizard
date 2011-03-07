using AgileWizard.Domain.Users;

namespace AgileWizard.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);

        User Add(User user);
    }
}