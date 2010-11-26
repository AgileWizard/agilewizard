using AgileWizard.Domain;
using AgileWizard.Website.Models;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class LogOnModelTester
    {
        private const string _userName = "agilewizard";
        private readonly User _user = new User { UserName = "agilewizard", Password = "agilewizard" };
        private readonly LogOnModel _logOnModelSUT = new LogOnModel { UserName = "agilewizard", Password = "agilewizard" };
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public LogOnModelTester()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _logOnModelSUT.UserRepository = _userRepositoryMock.Object;
        }

        [Fact]
        public void when_correct_username_password_return_true()
        {
            SetUpUserExpectationForExistingUser();

            Assert.True(_logOnModelSUT.IsMatch());
        }

        [Fact]
        public void when_wrong_username_return_false()
        {
            _logOnModelSUT.UserName = "non_existing";
            
            SetUpEmptyUserExpectationForNonExistingUser();

            Assert.False(_logOnModelSUT.IsMatch());
        }

        [Fact]
        public void when_wrong_password_return_false()
        {
            _logOnModelSUT.Password = "wrong_password";

            SetUpUserExpectationForExistingUser();

            Assert.False(_logOnModelSUT.IsMatch());
        }

        private void SetUpUserExpectationForExistingUser()
        {
            _userRepositoryMock.Setup(x => x.GetUserByName(_userName)).Returns(_user);
        }

        private void SetUpEmptyUserExpectationForNonExistingUser()
        {
            var emptyUser = User.EmptyUser();

            _userRepositoryMock.Setup(x => x.GetUserByName(_logOnModelSUT.UserName)).Returns(emptyUser);
        }
    }
}
