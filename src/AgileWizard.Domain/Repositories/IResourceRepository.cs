﻿using System.Collections.Generic;
using AgileWizard.Domain.Entities;

namespace AgileWizard.Domain.Repositories
{
    public interface IResourceRepository
    {
        void Add(string title, string content);
        Resource GetResourceById(string id);
        List<Resource> GetResourceList();
    }
}