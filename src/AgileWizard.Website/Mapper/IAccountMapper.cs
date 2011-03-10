using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Users;

namespace AgileWizard.Website.Mapper
{
    public interface IAccountMapper
    {
        AccountCreateModel MapFromDomainToViewModel(User user);
        User MapFromViewModelToDomain(AccountCreateModel user);
    }
}