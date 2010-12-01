using System;
using System.Collections.Generic;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using Moq;
using Raven.Client;

namespace AgileWizard.Domain.Tests.Services
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
            throw new NotImplementedException();
        }
    }
}