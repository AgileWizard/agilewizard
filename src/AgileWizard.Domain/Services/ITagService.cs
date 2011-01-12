using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Services
{
    public interface ITagService
    {
        List<Tag> GetTagList(int maxCount);
    }
}
