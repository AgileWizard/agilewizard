using Xunit;
using AgileWizard.Domain;
using Moq;
using AgileWizard.Website.Models;
using AgileWizard.Website.Controllers;

namespace AgileWizard.Website.Tests
{
    public class AccountControllerTest
    {
        private string _userName = "agilewizard";
        private string _password = "thepassword";
        private Mock<IUerAuthenticationService> _userAuthenticationService;
        private Mock<IFormsAuthenticationService> _formsService;
        private LogOnModel _logOnModel;
        private AccountController _accountControllerSUT;

        public AccountControllerTest()
        {
            _logOnModel = new LogOnModel
                              {
                                  UserName = _userName,
                                  Password = _password,
                                  RememberMe = false,
                              };

            _userAuthenticationService = new Mock<IUerAuthenticationService>();

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
            VerifyOnControllerSUBAction();
        }

        [Fact]
        public void logon_failure_should_not_call_formsservice_to_signin()
        {
            // arrange
            SetUpFailureExpectationOnUserAuthentication();

            FromsServideSginInWillNotBeCalled();

            // act
            VerifyOnControllerSUBAction();
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

        private void VerifyOnControllerSUBAction()
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
