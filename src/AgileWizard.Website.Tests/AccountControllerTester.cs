using Xunit;
using AgileWizard.Domain;
using Moq;
using AgileWizard.Website.Models;
using AgileWizard.Website.Controllers;

namespace AgileWizard.Website.Tests
{
    public class AccountControllerTester
    {
        private const string _userName = "agilewizard";
        private const string _password = "thepassword";
        private readonly Mock<IUserAuthenticationService> _userAuthenticationService;
        private readonly Mock<IFormsAuthenticationService> _formsService;
        private readonly LogOnModel _logOnModel;
        private readonly AccountController _accountControllerSUT;

        public AccountControllerTester()
        {
            _logOnModel = new LogOnModel
                              {
                                  UserName = _userName,
                                  Password = _password,
                                  RememberMe = false,
                              };

            _userAuthenticationService = new Mock<IUserAuthenticationService>();

            _formsService = new Mock<IFormsAuthenticationService>();

            _accountControllerSUT = new AccountController(_userAuthenticationService.Object, _formsService.Object);
        }

        [Fact]
        public void logon_success_should_call_formsservice_to_signin()
        {
            // arrange
            SetUpSuccessfulExpectationOnUserAuthentication();

            FromsServideSginInWillBeCalled();

            // act
            VerifyOnControllerSUTAction();
        }

        [Fact]
        public void logon_failure_should_not_call_formsservice_to_signin()
        {
            // arrange
            SetUpFailureExpectationOnUserAuthentication();

            FromsServideSginInWillNotBeCalled();

            // act
            VerifyOnControllerSUTAction();
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
            _userAuthenticationService.Setup(x => x.IsMatch(_userName, _password)).Returns(expectation);
        }

        private void FromsServideSginInWillBeCalled()
        {
            _formsService.Setup(x => x.SignIn(_userName, false)).Verifiable();
        }

        private void FromsServideSginInWillNotBeCalled()
        {
            _formsService.Verify(x => x.SignIn(_userName, false), Times.Never());
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
            _formsService.VerifyAll();
        }
    }
}
