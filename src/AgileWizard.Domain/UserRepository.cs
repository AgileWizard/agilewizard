using System.Linq;
using AgileWizard.Domain.QueryIndex;
using Raven.Client;

namespace AgileWizard.Domain
{
    public class UserRepository
    {
        private IDocumentSession _session;

        public UserRepository(IDocumentSession session)
        {
            this._session = session;
        }

        public User GetUserByName(string userName)
        {
            var users = _session.Query<User>(typeof(UserIndexByUserName).Name);

            var resultUsers = from x in users
                              where x.UserName == userName
                              select x;

            return resultUsers.First();
        }
    }
}
