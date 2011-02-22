using AgileWizard.Data;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Services
{
    public class UserAuthenticationServiceTest
    {
        private const string _userName = "agilewizard";
        private const string _password = "agilewizard";
        private const string _nonExistignUserName = "non_existing";
        private readonly User _user = new User { UserName = "agilewizard", Password = "agilewizard" };
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IFormsAuthenticationService> _formAuthenticationServiceMock;

        private readonly UserAuthenticationService _userAuthenticationServiceSUT;

        public UserAuthenticationServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _formAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();

            _userAuthenticationServiceSUT = new UserAuthenticationService(_userRepositoryMock.Object, new FakeSessoinStateRepository(), _formAuthenticationServiceMock.Object);
        }

        [Fact]
        public void sign_in_with_correct_username_password_ok()
        {
            SetUpUserExpectationForExistingUser();

            Assert.True(_userAuthenticationServiceSUT.SignIn(_userName, _password));
        }

        [Fact]
        public void sign_in_with_non_exist_username_return_false()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            Assert.False(_userAuthenticationServiceSUT.SignIn(_nonExistignUserName, _password));
        }

        [Fact]
        public void sign_in_with_wrong_password_return_false()
        {
            const string wrongPassword = "wrong_password";

            SetUpUserExpectationForExistingUser();

            Assert.False(_userAuthenticationServiceSUT.SignIn(_userName, wrongPassword));
        }

        [Fact]
        public void successful_signin_should_signin_to_form()
        {
            SetUpUserExpectationForExistingUser();

            FormsAuthenticationServiceShouldBeCalledWhenSuccessfulSignIn();

            _userAuthenticationServiceSUT.SignIn(_userName, _password);

            _formAuthenticationServiceMock.Verify();
        }

        [Fact]
        public void failure_signin_should_NOT_signin_to_form()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            FormsAuthenticationServiceShouldNotBeCalledWhenWrongSignIn();

            _userAuthenticationServiceSUT.SignIn(_nonExistignUserName, _password);

            _formAuthenticationServiceMock.VerifyAll();
        }

        [Fact]
        public void not_authenticated_when_failure_signin()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            _userAuthenticationServiceSUT.SignIn(_nonExistignUserName, _password);

            Assert.False(_userAuthenticationServiceSUT.IsAuthenticated);
        }

        [Fact]
        public void authenticated_when_successful_signin()
        {
            SetUpUserExpectationForExistingUser();

            _userAuthenticationServiceSUT.SignIn(_userName, _password);

            Assert.True(_userAuthenticationServiceSUT.IsAuthenticated);
        }

        [Fact]
        public void signout_to_form_when_signout()
        {
            FormsAuthenticationServiceSignOutShouldBeCalledWhenSignOut();

            _userAuthenticationServiceSUT.SignOut();

            _formAuthenticationServiceMock.VerifyAll();
        }

        [Fact]
        public void not_authenticated_when_signout()
        {
            SetUpUserExpectationForExistingUser();

            FormsAuthenticationServiceShouldBeCalledWhenSuccessfulSignIn();

            _userAuthenticationServiceSUT.SignIn(_userName, _password);

            _userAuthenticationServiceSUT.SignOut();

            Assert.False(_userAuthenticationServiceSUT.IsAuthenticated);
        }

        private void FormsAuthenticationServiceShouldNotBeCalledWhenWrongSignIn()
        {
            _formAuthenticationServiceMock.Verify(x => x.SignIn(_nonExistignUserName), Times.Never());
        }

        private void SetUpUserExpectationForExistingUser()
        {
            _userRepositoryMock.Setup(x => x.GetUserByName(_userName)).Returns(_user);
        }

        private void SetUpEmptyUserExpectationForNonExistingUser()
        {
            var emptyUser = User.EmptyUser();

            _userRepositoryMock.Setup(x => x.GetUserByName(_nonExistignUserName)).Returns(emptyUser);
        }

        private void FormsAuthenticationServiceShouldBeCalledWhenSuccessfulSignIn()
        {
            _formAuthenticationServiceMock.Setup(x => x.SignIn(_userName)).Verifiable();
        }

        private void FormsAuthenticationServiceSignOutShouldBeCalledWhenSignOut()
        {
            _formAuthenticationServiceMock.Setup(x => x.SignOut()).Verifiable();
        }
       
    }
}
