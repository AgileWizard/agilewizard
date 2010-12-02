using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;

namespace AgileWizard.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDocumentSession _documentSession;

        public UserRepository(IDocumentSession session)
        {
            _documentSession = session;
        }

        public User GetUserByName(string userName)
        {
            var users = (IEnumerable<User>)(_documentSession.Query<User>(typeof(UserIndexByUserName).Name).Customize(x => x.WaitForNonStaleResults()));

            var user = users.FirstOrDefault(x => x.UserName == userName);

            return user ?? User.EmptyUser();
        }

    }
}
