using System.Linq;
using AgileWizard.Domain.QueryIndex;
using Raven.Client;

namespace AgileWizard.Domain
{
    public class UserRepository
    {
        private readonly IDocumentSession _session;

        public UserRepository(IDocumentSession session)
        {
            _session = session;
        }

        public User GetUserByName(string userName)
        {
            var users = _session.Query<User>(typeof(UserIndexByUserName).Name);

            var resultUsers = from x in users
                              where x.UserName == userName
                              select x;

            if (resultUsers.Count() > 0)
                return resultUsers.First();
            return User.EmptyUser();
        }
    }
}
