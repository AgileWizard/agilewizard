using AgileWizard.Domain.Users;
using Xunit;

namespace AgileWizard.Domain.Tests.Entities
{
    public class UserTester
    {
        [Fact]
        public void empty_user_object_test()
        {
            var emptyUser = User.EmptyUser();

            Assert.Equal("", emptyUser.UserName);
        }
    }
}
