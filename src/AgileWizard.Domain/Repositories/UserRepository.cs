using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;

namespace AgileWizard.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDocumentSession _session;
        private IEnumerable<User> _resultUsers;

        public UserRepository(IDocumentSession session)
        {
            _session = session;
        }

        public User GetUserByName(string userName)
        {
            GetUsersByName(userName);

            return HasMatchedUser() ? FirstUser() : User.EmptyUser();
        }

        private void GetUsersByName(string userName)
        {
            var users = _session.Query<User>(typeof(UserIndexByUserName).Name);

            _resultUsers = from x in users
                   where x.UserName == userName
                   select x;
        }
        
        private bool HasMatchedUser()
        {
            return _resultUsers.Any();
        }

        private User FirstUser()
        {
            return _resultUsers.First();
        }
    }
}
