using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
    }
}