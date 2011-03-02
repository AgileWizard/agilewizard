using System.Web.Mvc;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Repositories;
using AgileWizard.IntegrationTests.PageObject;
using AgileWizard.Website.Controllers;
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
        private ResourceController Controller
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
            var repository = ObjectFactory.GetInstance<IResourceRepository>();
            ExistingResource = repository.Add(newResource);
            repository.Save();
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
            var viewResult = Controller.ListByTag(tagName) as ViewResult;

            Assert.Equal(count, (viewResult.ViewData.Model as ResourceList).Count);
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
            var repository = ObjectFactory.GetInstance<IResourceRepository>();
            var resource = repository.GetResourceById(id);
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
        [Given(@"there are (\d+) resources")]
        public void GivenThereAreResources(int numberOfResources)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there will be (\d+) resources on the page")]
        public void ThenThereWillBeResourcesOnThePage(int numberOfResources)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"next page")]
        public void WhenNextPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"no more page")]
        public void ThenNoMorePage()
        {
            ScenarioContext.Current.Pending();
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

        private ResourceDetailViewModel GetResourceDetailViewModel(Table table)
        {
            var resource = table.CreateInstance<ResourceDetailViewModel>();
            ProcessResourceDetailViewModelTag(table, resource);
            return resource;
        }

        private void ProcessResourceDetailViewModelTag(Table table, ResourceDetailViewModel resource)
        {
            foreach (var row in table.Rows)
            {
                if (row["Field"] == "Tags")
                {
                    resource.Tags = row["Value"];
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
        #endregion
    }
}
