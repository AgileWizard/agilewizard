using System.Linq;
using AgileWizard.Domain.QueryIndex;
using Raven.Client;

namespace AgileWizard.Domain
{
    public class UserRavenRepository
    {
        public static User GetUserByName(string userName, IDocumentSession documentSession)
        {
            var users = documentSession.Query<User>(typeof(UserIndexByUserName).Name);

            var resultUsers = from x in users
                              where x.UserName == userName
                              select x;

            return resultUsers.First();
        }
    }
}
