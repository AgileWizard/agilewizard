using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        internal const string PAGE_VIEW_COUNTER_NAME = "PageView";
        private IResourceRepository _repository;

        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public Resource AddResource(Resource resource)
        {
            resource.CreateTime = DateTime.Now;
            resource.LastUpdateTime = DateTime.Now;
            resource = _repository.Add(resource);
            _repository.Save();
            return resource;
        }

        public Resource GetResourceById(string id)
        {
            var resource = _repository.GetResourceById(id);
            resource.PageView++;
            _repository.Save();
            return resource;
        }

        public IList<Resource> GetResourceList()
        {
            return _repository.GetResourceList();
        }

        public void UpdateResource(string id, Resource resource)
        {
            var resourceUpdate = _repository.GetResourceById(id);
            resourceUpdate.Title = resource.Title;
            resourceUpdate.Content = resource.Content;
            resourceUpdate.LastUpdateTime = DateTime.Now;
            resourceUpdate.Author = resource.Author;
            resourceUpdate.SubmitUser = resource.SubmitUser;
            resourceUpdate.ReferenceUrl = resource.ReferenceUrl;
            resourceUpdate.Tags = resource.Tags;
            _repository.Save();

        }

        public void LikeThisResource(string resourceId)
        {
            var resource = _repository.GetResourceById(resourceId);
            resource.Like++;
            _repository.Save();
        }

        public void DislikeThisResource(string resourceId)
        {
            var resource = _repository.GetResourceById(resourceId);
            resource.Dislike++;
            _repository.Save();
        }

        public List<Resource> GetResourceListByTag(string tagName)
        {
            return _repository.GetResourceListByTag(tagName);
        }

        public int GetResourcesTotalCountForTag(string tagName)
        {
            return _repository.GetResourcesTotalCountForTag(tagName);
        }
    }
}