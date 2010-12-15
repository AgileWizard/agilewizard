﻿using AgileWizard.Domain.Users;
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

        private readonly UserAuthenticationService _userAuthenticationServiceSUT;

        public UserAuthenticationServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _userAuthenticationServiceSUT = new UserAuthenticationService(_userRepositoryMock.Object);
        }

        [Fact]
        public void when_correct_username_password_return_true()
        {
            SetUpUserExpectationForExistingUser();

            Assert.True(_userAuthenticationServiceSUT.IsMatch(_userName, _password));
        }

        [Fact]
        public void when_wrong_username_return_false()
        {
            SetUpEmptyUserExpectationForNonExistingUser();

            Assert.False(_userAuthenticationServiceSUT.IsMatch(_nonExistignUserName, _password));
        }

        [Fact]
        public void when_wrong_password_return_false()
        {
            const string wrongPassword = "wrong_password";

            SetUpUserExpectationForExistingUser();

            Assert.False(_userAuthenticationServiceSUT.IsMatch(_userName, wrongPassword));
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
    }
}
