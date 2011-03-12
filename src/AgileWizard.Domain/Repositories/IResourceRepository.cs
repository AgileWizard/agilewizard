﻿using System.Collections.Generic;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        Resource Add(Resource resource);
        Resource GetResourceById(string id);
        List<Resource> GetNextPageOfResource(long ticksOfLastCreateTime);
        List<Resource> GetResourceListByTag(string tagName);
        int GetResourcesTotalCountForTag(string tagName);
        void Save();
    }
}