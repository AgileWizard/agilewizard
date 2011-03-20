using AgileWizard.Website.Mapper;
using Xunit;
using AgileWizard.Domain.Users;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Tests.Model
{
    public class AccountMapperTest
    {
        private readonly AccountMapper _resourceMapperSUT;

        public AccountMapperTest()
        {
            _resourceMapperSUT = new AccountMapper();
            AccountMapper.ConfigAutoMapper();
        }

        [Fact]
        public void User_MapTo_ModelView()
        {
            var user = User.DefaultUser();
            var model = _resourceMapperSUT.MapFromDomainToViewModel(user);

            Assert.Equal(user.UserName, model.Email);
            Assert.Equal(user.Password, model.Password);
        }

        [Fact]
        public void ModelView_MapTo_User()
        {
            var user = AccountCreateModel.DefaultModel();
            var model = _resourceMapperSUT.MapFromViewModelToDomain(user);

            Assert.Equal(user.Email, model.UserName);
            Assert.Equal(user.Password, model.Password);
        }
    }
}
