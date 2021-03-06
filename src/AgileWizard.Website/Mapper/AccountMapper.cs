﻿using System.Collections.Generic;
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
            AutoMapper.Mapper.CreateMap<User, AccountCreateModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName));
            AutoMapper.Mapper.CreateMap<AccountCreateModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }

        public AccountCreateModel MapFromDomainToViewModel(User user)
        {
            return AutoMapper.Mapper.Map<User, AccountCreateModel>(user);
        }

        public User MapFromViewModelToDomain(AccountCreateModel model)
        {
            return AutoMapper.Mapper.Map<AccountCreateModel, User>(model);
        }
    }
}