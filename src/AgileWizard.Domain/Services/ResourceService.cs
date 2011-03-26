using System;
using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Expression;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Domain.Services
{
    public class ResourceService : IResourceService
    {
        internal const string PAGE_VIEW_COUNTER_NAME = "PageView";
        private readonly IResourceRepository _repository;

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

        public IList<Resource> GetLikeList()
        {
            return _repository.GetList(QueryExpressionBuilder.BuildTopLikeResourceList_QueryExperssion()).ToList();
        }

        public IList<Resource> GetHitList()
        {
            return _repository.GetList(QueryExpressionBuilder.BuildTopHitResourceList_QueryExperssion()).ToList();
        }

        public IList<Resource> GetFirstPage_OfResource()
        {
            return GetResourceList(DateTime.Now.Ticks, string.Empty);
        }

        public IList<Resource> GetFirstPage_OfTagResource(string tagName)
        {
            return GetResourceList(DateTime.Now.Ticks, tagName);
        }

        public IList<Resource> GetLatestList()
        {
            return _repository.GetList(QueryExpressionBuilder.BuildTopLatestResourceList_QueryExperssion()).ToList();            
        }

        public int GetResourcesTotalCountForTag(string tagName)
        {
            return _repository.GetResourcesTotalCountForTag(tagName);
        }

        public IList<Resource> GetResourceList(long ticksOfCreateTime, string tagName)
        {
            if (tagName == string.Empty)
            {
                return
                    _repository.GetList(QueryExpressionBuilder.BuildResourceList_QueryExpression(ticksOfCreateTime)).
                        ToList();
            }
            return _repository.GetList(QueryExpressionBuilder.BuildTagResourceList_QueryExpression(ticksOfCreateTime, tagName)).ToList();
        }

        public IList<Resource> GetResourceListByTag(long ticksOfCreateTime, string tagName)
        {
            return _repository.GetList(QueryExpressionBuilder.BuildTagResourceList_QueryExpression(ticksOfCreateTime, tagName)).ToList();
        }

    }
}