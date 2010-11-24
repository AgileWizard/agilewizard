using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain;
using AgileWizard.Website.Models;
using Moq;
using Xunit;

namespace AgileWizard.MVC.Tests
{
    public class LogOnModelTester
    {
        [Fact]
        public void when_correct_username_password_return_true()
        {
            var logOnModel = new LogOnModel();

            var userRepositoryMock = new Mock<IUserRepository>();

            const string userName = "agilewizard";

            var user = new User {UserName = userName, Password = "agilewizard"};

            userRepositoryMock.Setup(x => x.GetUserByName(userName)).Returns(user);


            logOnModel.UserRepositoryService = userRepositoryMock.Object;

            Assert.True(logOnModel.IsMatch());
        }
    }
}
