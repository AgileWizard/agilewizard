using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Repositories
{
    public interface ISessionStateRepository
    {
        User CurrentUser { get; set; }

        object this[string name] { get; set; }
    }
}