using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetTagList();
    }
}
