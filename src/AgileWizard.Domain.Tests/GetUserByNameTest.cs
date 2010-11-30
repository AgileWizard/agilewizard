using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class GetUserByNameTest : RepositoryTesterBase
    {
        public GetUserByNameTest()
        {
            _dataManager.InitData();
        }

        //[Fact]
        public void when_user_exists_return_the_user()
        {
            const string userName = "agilewizard";

            var actualUser = new UserRepository(_documentSession).GetUserByName(userName);

            Assert.Equal(userName, actualUser.UserName);
        }

        [Fact]
        public void when_user_not_exists_return_empty_user()
        {
            const string userName = "non_exist_user";

            var actualUser = new UserRepository(_documentSession).GetUserByName(userName);

            var expectedEmptyUser = User.EmptyUser();

            Assert.Equal(expectedEmptyUser.UserName, actualUser.UserName);
        }
    }
}
