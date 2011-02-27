using System;
using System.Collections.Generic;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        internal const string PAGE_VIEW_COUNTER_NAME = "PageView";
        private const string LIKE_COUNTER_NAME = "Like";
        private const string DISLIKE_COUNTER_NAME = "Dislike";
        private IResourceRepository _repository;

        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public Resource AddResource(Resource source)
        {
            var resource = _repository.Add(source);
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

        public int GetResourcesTotalCount()
        {
            return _repository.GetResourcesTotalCount();
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

        public void DislikeThisResource(string resourceId, string userIP)
        {
            WriteLogForResourceCounter(DISLIKE_COUNTER_NAME, resourceId, userIP);
        }

        public int GetLikesCount(string resourceId)
        {
            return GetResourceCounter(resourceId, LIKE_COUNTER_NAME);
        }

        public int GetDislikesCount(string resourceId)
        {
            return GetResourceCounter(resourceId, DISLIKE_COUNTER_NAME);
        }

        public int GetPageViewsCount(string resourceId)
        {
            return GetResourceCounter(resourceId, PAGE_VIEW_COUNTER_NAME);
        }

        private void WriteLogForResourceCounter(string counterName, string resourceId, string userIP)
        {
            var pageViewLog = new ResourceLog { IP = userIP, Name = counterName, ResourceId = resourceId };
            _repository.InsertResourceLog(pageViewLog);
        }

        private int GetResourceCounter(string resourceId, string counterName)
        {
            var counter = _repository.GetResourceCounter(resourceId, counterName);
            return counter == null ? 0 : counter.Count;
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