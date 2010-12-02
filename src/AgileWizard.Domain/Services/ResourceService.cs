using System;
using System.Collections.Generic;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        private IResourceRepository _repository;

        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public void AddResource(string title, string content)
        {
            _repository.Add(title, content);
        }

        public Resource GetResourceById(string id)
        {
            return _repository.GetResourceById(id);
        }

        public IList<Resource> GetResourceList()
        {
            return _repository.GetResourceList();
        }

        public int GetResourcesTotalCount()
        {
            return _repository.GetResourcesTotalCount();
        }
    }
}