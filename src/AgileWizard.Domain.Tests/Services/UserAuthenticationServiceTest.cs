using AgileWizard.Data;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Xunit;
using System.Web.Mvc;
using AgileWizard.Locale.Resources.Views;
using System;

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
        private readonly Mock<IConfigurationRepository> _configurationRepository;

        private readonly UserAuthenticationService _userAuthenticationServiceSUT;

        public UserAuthenticationServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _formAuthenticationServiceMock = new Mock<IFormsAuthenticationService>();

            _configurationRepository = new Mock<IConfigurationRepository>();

            _userAuthenticationServiceSUT = new UserAuthenticationService(_userRepositoryMock.Object, new FakeSessoinStateRepository(), _formAuthenticationServiceMock.Object, _configurationRepository.Object);

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

        [Fact]
        public void CreateUser_would_report_error_if_user_name_is_null_or_empty()
        {
            var modelError = new ModelStateDictionary();
            _userAuthenticationServiceSUT.Create(null, _userName, modelError);

            Assert.True(modelError.ContainsKey(UserAuthenticationService.PROP_USERNAME));
            Assert.True(modelError.ContainsError(UserAuthenticationService.PROP_USERNAME, AccountString.UserNameCanNotBeNull));
        }

        [Fact]
        public void CreateUser_would_report_error_if_user_exist_already()
        {
            SetUpUserExpectationForExistingUser();

            var modelError = new ModelStateDictionary();
            _userAuthenticationServiceSUT.Create(new User { UserName = _userName }, _userName, modelError);

            Assert.True(modelError.ContainsKey(UserAuthenticationService.PROP_USERNAME));
            Assert.True(modelError.ContainsError(UserAuthenticationService.PROP_USERNAME, AccountString.UserAlreadyExist));
        }

        [Fact]
        public void CreateUser_would_report_error_if_password_not_valid()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            var modelError = new ModelStateDictionary();
            _userAuthenticationServiceSUT.Create(new User { UserName = _nonExistignUserName, Password = "222" }, _userName, modelError);

            Assert.True(modelError.ContainsKey(UserAuthenticationService.PROP_PASSWORD));
            Assert.True(modelError.ContainsError(UserAuthenticationService.PROP_PASSWORD, AccountString.NotMatchPasswordRule));
        }

        [Fact]
        public void CreateUser_should_call_repository_add_func_when_check_passed()
        {
            // setup 
            SetUpEmptyUserExpectationForCreateNewAccountWithValidConditions();

            var modelError = new ModelStateDictionary();
            var user = new User { UserName = _nonExistignUserName, Password = Guid.NewGuid().ToString() };
            _userAuthenticationServiceSUT.Create(user, _userName, modelError);

            // Assert
            Assert.True(modelError.Count == 0);
            _userRepositoryMock.Verify(a => a.Add(user));
            _userRepositoryMock.Verify(a => a.Save());
        }

        [Fact]
        public void CreateUser_would_report_error_if_the_creator_has_no_rights()
        {
            SetUpEmptyUserExpectationForCreateNewAccountWithValidConditions();

            var modelError = new ModelStateDictionary();
            _userAuthenticationServiceSUT.Create(null, _nonExistignUserName, modelError);

            Assert.True(modelError.ContainsKey(string.Empty));
            Assert.True(modelError.ContainsError(string.Empty, AccountString.CreatorLackOfRight));
        }

        private void FormsAuthenticationServiceShouldNotBeCalledWhenWrongSignIn()
        {
            _formAuthenticationServiceMock.Verify(x => x.SignIn(_nonExistignUserName), Times.Never());
        }

        private void SetUpUserExpectationForExistingUser()
        {
            _userRepositoryMock.Setup(x => x.GetUserByName(_userName)).Returns(_user);
        }

        private void SetUpEmptyUserExpectationForCreateNewAccountWithValidConditions()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            _configurationRepository.Setup(x => x.GetValue(UserAuthenticationService.CONFIG_KEY_ADMINUSER)).Returns(_userName);
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
