﻿using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Repositories;
using AgileWizard.IntegrationTests.PageObject;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;
using StructureMap;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using AgileWizard.Domain.Models;
using Raven.Client;
using AgileWizard.Data;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public partial class ResourceSteps
    {
        private readonly IResourceRepository _repository;
        private readonly IResourceMapper _resourceMapper;

        public ResourceSteps()
        {
            _repository = ObjectFactory.GetInstance<IResourceRepository>();
            _resourceMapper = ObjectFactory.GetInstance<IResourceMapper>();
        }

        private static ResourceController Controller
        {
            get
            {
                return ObjectFactory.GetInstance<ResourceController>();
            }
        }

        #region Add Resource
        [Given(@"new resource with  title - (.+) and content - (.+) and author - (.+) and tags - (.+) and reference url - (\b\w*://[-A-z0-9+&@#/%?=~_|!:,.;]*[-A-z0-9+&@#/%=~_|])")]
        public void GivenNewResourceWithTitleAndContentAndAuthorAndTagsAndReferenceUrl(string title, string content, string author, string tags, string referenceurl)
        {
            var resourceModel = new ResourceDetailViewModel
            {
                Tags = tags,
                Title = title,
                Author = author,
                Content = content,
                ReferenceUrl = referenceurl,
            };

            PendingSubmittedResourceDetailViewModel = resourceModel;
        }

        [When(@"submit resource to system")]
        public void WhenSubmitResourceToSystem()
        {
            CreateResource();
        }

        [Then(@"navigate to edit page")]
        public void ThenNavigateToEditPage()
        {
            var actionResult = ActionResult as ViewResult;
            Assert.Empty(actionResult.ViewName);
        }

        [Then(@"navigate to details page")]
        public void ThenNavigateToDetailsPage()
        {
            var resourceDetail = new ResourceDetail();

            resourceDetail.AssertAction(ActionResult as RedirectToRouteResult);
        }

        #endregion

        #region Edit Resource
        [Given(@"there is a resource")]
        public void GivenThereIsAResource(Table table)
        {
            var newResource = GetResource(table);
            ExistingResource = _repository.Add(newResource);
            _repository.Save();
        }

        [When(@"open the resource to edit")]
        public void WhenOpenTheResourceToEdit()
        {
            string id = GetExistingResourceID();

            ActionResult = Controller.Edit(id);
        }

        [Then(@"show edit for the title, content, author and tags")]
        public void ThenShowEditForTheTitleContentAuthorAndTags()
        {
            var actualResource = (ActionResult as ViewResult).ViewData.Model as ResourceDetailViewModel;

            AssertResource(ExistingResource, actualResource);
        }

         [When(@"modify the resource")]
         public void WhenModifyTheResource(Table table)
         {
             SubmittedResourceDetailViewModel = GetResourceDetailViewModel(table);

             var id = GetExistingResourceID();
             
             ActionResult = Controller.Edit(id, SubmittedResourceDetailViewModel);
         }

         [Then(@"navigate to details page with id")]
         public void ThenNavigateToDetailsPageWithId()
         {
             var resourceDetail = new ResourceDetail();
             var id = GetExistingResourceID();

             resourceDetail.AssertAction(ActionResult as RedirectToRouteResult, id);
         }

        #endregion 

         #region View resource
         [When(@"view the resource")]
         public void WhenViewTheResource()
         {
             var id = GetExistingResourceID();

             ActionResult = Controller.Details(id);
         }

         [Then(@"display the title, content, author and submit user and tags")]
         public void ThenDisplayDetailInformation()
         {
             var actualResource = GetResourceDetailViewModelFromActionResult();

             AssertResource(ExistingResource, actualResource);
         }

         [Then(@"page view number should be (\d)")]
         public void ThenPageViewNumberShouldBeIncremented(int pageView)
         {
             var actualResource = GetResourceDetailViewModelFromActionResult();

             Assert.Equal(pageView, actualResource.PageView);
         }
         #endregion

        #region Like/Dislike resource
        [Then(@"like number is (\d)")]
        public void ThenLikeNumberIs(int likeCount)
        {
            var id = GetExistingResourceID();
            var repository = ObjectFactory.GetInstance<IResourceRepository>();
            var resource = repository.GetResourceById(id);
            Assert.Equal(likeCount, resource.Like);
        }

        [When(@"like the resource")]
        public void WhenLikeTheResource()
        {
            var id = GetExistingResourceID();

            ActionResult = Controller.Like(id);
        }

        [Then(@"dislike number is (\d)")]
        public void ThenDislikeNumberIs(int dislikeCount)
        {
            var id = GetExistingResourceID();
            var resource = _repository.GetResourceById(id);
            Assert.Equal(dislikeCount, resource.Dislike);
        }

        [When(@"dislike the resource")]
        public void WhenDislikeTheResource()
        {
            var id = GetExistingResourceID();

            ActionResult = Controller.Dislike(id);
        }
        #endregion

        #region Resoure List
        [Given(@"there are (\d+) pages of resources")]
        public void GivenThereArePagesOfResources(int totalPages)
        {
            var totalResources = 20*totalPages - 19;
            var resources = totalResources.CountOfResouces("Agile");
            foreach (var resource in resources)
            {
                _repository.Add(resource);
                _repository.Save();
            }
        }

        [When(@"I see Index page")]
        public void WhenISeeIndexPage()
        {
            ActionResult = Controller.Index() as ViewResult;
            TagName = string.Empty;
        }

        [Then(@"there will be (\d+) resources on the page")]
        public void ThenThereWillBeResourcesOnThePage(int countOfResources)
        {
            AssertCountOfResourceList(countOfResources, ActionResult as ViewResultBase);
        }

        [Then(@"there will be (\d+) more resources on the page")]
        public void ThenThereWillBeMoreResourcesOnThePage(int numberOfResources)
        {
            long ticksOfLastCreateTime = GetTicksOfLastCreateTime();

            ActionResult = Controller.ResourceListOfNextPage(ticksOfLastCreateTime, TagName);
            AssertCountOfResourceList(numberOfResources, ActionResult as ViewResultBase);
        }
        #endregion

        #region Tag
        [When(@"I wait for non-stale data")]
        public void WhenIWaitForNonStaleData()
        {
            var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
            var documentSession = ObjectFactory.GetInstance<IDocumentSession>();

            new DataManager(documentStore).WaitForNonStaleResults(documentSession);
        }

        [Then(@"resource list of tag '(.+)' should have (\d+) item")]
        public void ResourceListOfTagShouldHaveItem(string tagName, int count)
        {
            ActionResult = Controller.ListByTag(tagName) as ViewResult;
            TagName = tagName;
            AssertCountOfResourceList(count, ActionResult as ViewResultBase);
        }
        #endregion

        #region Resource list at home page
        [When(@"I see top like resources")]
        public void WhenISeeTopLikeResources()
        {
            ActionResult = Controller.GetLikeList() as ViewResultBase;
        }

        [Then(@"order by like desc")]
        public void ThenOrderByLikeDesc()
        {
            AssertResourceListViewModelOrderedByLike();
        }

        [When(@"I see top hit resources")]
        public void WhenISeeTopHitResources()
        {
            ActionResult = Controller.GetHitList() as ViewResultBase;
        }

        [Then(@"order by hit desc")]
        public void ThenOrderByHitDesc()
        {
            AssertResourceListViewModelOrderedByHit();
        }

        [When(@"I see the latest resources")]
        public void WhenISeeTheLatestResources()
        {
            ActionResult = Controller.GetLatestList() as ViewResultBase;
        }

        [Then(@"order by create time desc")]
        public void ThenOrderByCreateTimeDesc()
        {
            AssertResourceListViewModelOrderedByCreatTime();
        }

        #endregion

        #region Private Resource Procedures
        private void CreateResource()
        {
            ActionResult = Controller.Create(PendingSubmittedResourceDetailViewModel);
        }

        private Resource GetResource(Table table)
        {
            var resource = table.CreateInstance<Resource>();
            ProcessResourceTag(table, resource);
            return resource;
        }
       
        private ResourceDetailViewModel GetResourceDetailViewModel(Table table)
        {
            var resource = table.CreateInstance<Resource>();
            ProcessResourceTag(table, resource);
            var resourceDetailModel = _resourceMapper.MapFromDomainToDetailViewModel(resource);
            return resourceDetailModel;
        }

        private void ProcessResourceTag(Table table, Resource resource)
        {
            foreach (var row in table.Rows)
            {
                if (row["Field"] == "Tags")
                {
                    resource.Tags = row["Value"].ToTagList();
                }
            }
        }

        private void AssertResource(Resource resource, ResourceDetailViewModel resourceDetailViewModel)
        {
            Assert.Equal(resource.Title, resourceDetailViewModel.Title);
            Assert.Equal(resource.Content, resourceDetailViewModel.Content);
            Assert.Equal(resource.Author, resourceDetailViewModel.Author);
            Assert.Equal(resource.ReferenceUrl, resourceDetailViewModel.ReferenceUrl);
            Assert.Equal(resource.Tags.Count, resourceDetailViewModel.Tags.ToTagList().Count);
        }

        private ResourceDetailViewModel GetResourceDetailViewModelFromActionResult()
        {
            var actionResult = ActionResult as ViewResult;
            return actionResult.ViewData.Model as ResourceDetailViewModel;
        }

        private string GetExistingResourceID()
        {
            return ExistingResource.Id.Substring(10);
        }

        private void AssertCountOfResourceList(int count, ViewResultBase viewResult)
        {
            Assert.Equal(count, (viewResult.ViewData.Model as IList<ResourceListViewModel>).Count);
        }

        private long GetTicksOfLastCreateTime()
        {
            var _viewResult = ActionResult as ViewResultBase;
            return (long)_viewResult.ViewData["ticksOfLastCreateTime"];
        }

        private void AssertResourceListViewModelOrderedByLike()
        {
            var resourceListViewModels =
                ((ViewResultBase)ActionResult).ViewData.Model as IList<ResourceListViewModel>;

            Assert.True(resourceListViewModels[0].Like > resourceListViewModels[1].Like);
            Assert.True(resourceListViewModels[1].Like > resourceListViewModels[2].Like);
        }

        private void AssertResourceListViewModelOrderedByHit()
        {
            var resourceListViewModels =
                ((ViewResultBase)ActionResult).ViewData.Model as IList<ResourceListViewModel>;

            Assert.True(resourceListViewModels[0].PageView > resourceListViewModels[1].PageView);
            Assert.True(resourceListViewModels[1].PageView > resourceListViewModels[2].PageView);
        }

        private void AssertResourceListViewModelOrderedByCreatTime()
        {
            var resourceListViewModels =
               ((ViewResultBase)ActionResult).ViewData.Model as IList<ResourceListViewModel>;

            Assert.True(resourceListViewModels[0].CreateTime > resourceListViewModels[1].CreateTime);
            Assert.True(resourceListViewModels[1].CreateTime > resourceListViewModels[2].CreateTime);
        }

        #endregion
    }
}
