using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Xunit;
using System.Threading;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class UserRepositoryTest : RepositoryTestBase
    {
        const string userName = "agilewizard";
        public UserRepositoryTest()
        {
        }

        [Fact]
        public void when_user_exists_return_the_user()
        {
            var indexName = typeof(UserIndexByUserName).Name;
            var initUser = CreateAgileWizardUserForTest();

            this.PrepareData<User>(initUser, indexName);

            var actualUser = new UserRepository(_documentSession).GetUserByName(userName);

            Assert.Equal(userName, actualUser.UserName);
            Assert.Equal(userName, actualUser.Password);

        }

        [Fact]
        public void when_user_not_exists_return_empty_user()
        {
            const string userName = "non_exist_user";

            var actualUser = new UserRepository(_documentSession).GetUserByName(userName);

            var expectedEmptyUser = User.EmptyUser();

            Assert.Equal(expectedEmptyUser.UserName, actualUser.UserName);
        }

        private User CreateAgileWizardUserForTest()
        {
            return new User { UserName = userName, Password = userName };
        }
    }
}
