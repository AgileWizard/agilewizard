using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class UserTest
    {
        [Fact]
        public void empty_user_object_test()
        {
            var emptyUser = User.EmptyUser();

            Assert.Equal("", emptyUser.UserName);
        }
    }
}
