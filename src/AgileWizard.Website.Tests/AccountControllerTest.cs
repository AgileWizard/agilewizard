using AgileWizard.Domain.Services;
using Xunit;
using Moq;
using AgileWizard.Website.Models;
using AgileWizard.Website.Controllers;
using AgileWizard.Domain.Repositories;
using System;
using System.Web.Mvc;
using AgileWizard.Domain.Users;

namespace AgileWizard.Website.Tests
{
    public class AccountControllerTest
    {
        private const string _userName = "agilewizard";
        private const string _password = "thepassword";
        private readonly Mock<IUserAuthenticationService> _userAuthenticationService;
        private readonly Mock<ISessionStateRepository> _sessionStateRepository;
        private readonly LogOnModel _logOnModel;
        private readonly AccountController _accountControllerSUT;
        private const bool _rememberMe = false;

        public AccountControllerTest()
        {
            _logOnModel = new LogOnModel
                              {
                                  UserName = _userName,
                                  Password = _password,
                              };

            _userAuthenticationService = new Mock<IUserAuthenticationService>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();

            _accountControllerSUT = new AccountController(_userAuthenticationService.Object, _sessionStateRepository.Object);

            MvcApplication.ConfigAutoMapper();
        }

        [Fact]
        public void call_userauthenticationservice_when_signin()
        {
            // arrange
            SetUpSuccessfulExpectationOnUserAuthentication();

            // act
            VerifyOnControllerSUTAction();
        }

        [Fact]
        public void logon_failure_should_not_call_formsservice_to_signin()
        {
            // arrange
            SetUpFailureExpectationOnUserAuthentication();

            // act
            VerifyOnControllerSUTAction();
        }

        [Fact]
        public void logoff_should_call_userauthentication_to_signout()
        {
            _userAuthenticationService.Setup(x => x.SignOut()).Verifiable();

            _accountControllerSUT.LogOff();

            _userAuthenticationService.VerifyAll();
        }

        #region Create user tests
        [Fact]
        public void create_new_account_should_call_repository_add_method()
        {
            _userAuthenticationService.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<ModelStateDictionary>())).Returns(default(User)).Verifiable();

            var actionResult = TryToCreateUser(_userName, _password);

            _userAuthenticationService.VerifyAll();
        }

        [Fact]
        public void create_new_account_fail_should_redirect_itself()
        {
            _userAuthenticationService.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<ModelStateDictionary>())).Returns(default(User)).Verifiable();

            var actionResult = TryToCreateUser(_userName, _password);

            ShouldShowCurrentViewWithModel(actionResult);

            _userAuthenticationService.VerifyAll();
        }

        private void ShouldShowCurrentViewWithModel(ActionResult actionResult)
        {
            Assert.IsType<ViewResult>(actionResult);
            var viewResult = (ViewResult)actionResult;

            Assert.Empty(viewResult.ViewName);
            Assert.IsAssignableFrom<AccountCreateModel>(viewResult.ViewData.Model);
        }

        private ActionResult TryToCreateUser(string userName, string password)
        {
            var result = _accountControllerSUT.Create(new AccountCreateModel
            {
                UserName = userName,
                Password = password
            });

            return result;
        }

        [Fact]
        public void create_new_account_success_should_redirect_to_complete_page()
        {
            _userAuthenticationService.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<ModelStateDictionary>())).Returns(new User()).Verifiable();
            var result = TryToCreateUser(_userName, _password);

            ShouldRedirectToCreateComplete(result);

            VerifyServiceExpectations();
        }

        private void ShouldRedirectToCreateComplete(ActionResult result)
        {
            Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("CreateComplete", ((RedirectToRouteResult)result).RouteValues["action"].ToString());
        }

        #endregion

        private void SetUpSuccessfulExpectationOnUserAuthentication()
        {
            SetUpExpectationOnUserAuthentication(true);
        }

        private void SetUpFailureExpectationOnUserAuthentication()
        {
            SetUpExpectationOnUserAuthentication(false);
        }

        private void SetUpExpectationOnUserAuthentication(bool expectation)
        {
            _userAuthenticationService.Setup(x => x.SignIn(_userName, _password)).Returns(expectation);
        }

        private void VerifyOnControllerSUTAction()
        {
            _accountControllerSUT.LogOn(_logOnModel);

            // assert
            VerifyServiceExpectations();
        }

        private void VerifyServiceExpectations()
        {
            _userAuthenticationService.VerifyAll();
        }
    }
}
