using System.Collections.Generic;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Xunit;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class UserRepositoryTest : RepositoryTestBase
    {
        private readonly UserRepository _userRepositorySUT;

        public UserRepositoryTest()
        {
            _userRepositorySUT = new UserRepository(_session.Object);
        }

        [Fact]
        public void when_user_exists_return_the_user()
        {
            const string userName = "agilewizard";
            _session.SetupQueryResult<User>(typeof(UserIndexByUserName).Name, new List<User> { new User { UserName = userName, Password = userName } });

            var actualUser = _userRepositorySUT.GetUserByName(userName);

            Assert.Equal(userName, actualUser.UserName);
            Assert.Equal(userName, actualUser.Password);
            _session.VerifyAll();
        }

        [Fact]
        public void when_user_not_exists_return_empty_user()
        {
            const string userName = "non_exist_user";

            _session.SetupQueryResult<User>(typeof(UserIndexByUserName).Name, new List<User>());

            var actualUser = _userRepositorySUT.GetUserByName(userName);
            var emptyUser = User.EmptyUser();

            Assert.Equal(emptyUser.UserName, actualUser.UserName);
            Assert.Equal(emptyUser.Password, actualUser.Password);
            _session.VerifyAll();

        }


        [Fact]
        public void add_user()
        {
            //Arrange
            var user = User.DefaultUser();

            //Act
            var actualUser = _userRepositorySUT.Add(user);

            //Assert
            _session.Verify(r => r.Store(user));
        }
    }
}
