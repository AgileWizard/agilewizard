using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using AgileWizard.Domain;
using Moq;
using AgileWizard.Website.Models;
using AgileWizard.Website.Controllers;

namespace AgileWizard.Website.Tests
{
    public class AccountControllerTest
    {
        [Fact]
        public void LogOn_Success_Should_Call_FormsService_To_SignIn()
        {
            // arrange
            var userName = "agilewizard";
            var password = "thepassword";

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetUserByName(userName)).Returns(
                new User
                {
                    UserName = userName,
                    Password = password,
                }
            );

            var formsService = new Mock<IFormsAuthenticationService>();
            formsService.Setup(x => x.SignIn(userName, false)).Verifiable();

            var accountController = new AccountController(userRepository.Object, formsService.Object);
            
            var model = new LogOnModel
            {
                UserName = userName,
                Password = password,
                RememberMe = false,
            };

            // act
            accountController.LogOn(model);

            // assert
            userRepository.VerifyAll();
            formsService.VerifyAll();
        }
    }
}
