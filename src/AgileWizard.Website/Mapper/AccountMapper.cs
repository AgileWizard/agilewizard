using System.Collections.Generic;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Users;

namespace AgileWizard.Website.Mapper
{
    public class AccountMapper : IAccountMapper
    {
        public static void ConfigAutoMapper()
        {
            AutoMapper.Mapper.CreateMap<User, AccountCreateModel>();

            AutoMapper.Mapper.CreateMap<AccountCreateModel, User>();
        }

    }
}