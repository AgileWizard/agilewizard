using AgileWizard.Domain.Services;
using Xunit;
using Moq;
using AgileWizard.Website.Models;
using AgileWizard.Website.Controllers;
using AgileWizard.Domain.Repositories;

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
                                  RememberMe = false,
                              };

            _userAuthenticationService = new Mock<IUserAuthenticationService>();
            _sessionStateRepository = new Mock<ISessionStateRepository>();

            _accountControllerSUT = new AccountController(_userAuthenticationService.Object, _sessionStateRepository.Object);
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
            _userAuthenticationService.Setup(x=>x.SignOut()).Verifiable();

            _accountControllerSUT.LogOff();

            _userAuthenticationService.VerifyAll();
        }

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
            _userAuthenticationService.Setup(x => x.SignIn(_userName, _password, _rememberMe)).Returns(expectation);
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
