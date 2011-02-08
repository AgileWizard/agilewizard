using System.Web.Mvc;
using AgileWizard.Domain.Repositories;
using AgileWizard.IntegrationTests.PageObject;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using StructureMap;
using TechTalk.SpecFlow;
using Xunit;
using AgileWizard.Website.Helper;
using TechTalk.SpecFlow.Assist;
using AgileWizard.Domain.Models;
using Raven.Client;
using AgileWizard.Data;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public partial class ResourceSteps
    {
        private string SubmitUser;

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
        #endregion

        #region Edit Resource
        [Given(@"there is a resource")]
        public void GivenThereIsAResource(Table table)
        {
            var resource = GetResource(table);
            var repository = ObjectFactory.GetInstance<IResourceRepository>();
            resource = repository.Add(resource);
            repository.Save();
            ExistingResource = resource;
        }

        [When(@"open the resource to edit")]
        public void WhenOpenTheResourceToEdit()
        {
            var controller = ObjectFactory.GetInstance<ResourceController>();
            var resource = ExistingResource;
            var id = resource.Id.Substring(10);
            var actionResult = controller.Edit(id);
            ActionResult = actionResult;
        }

         [Then(@"show edit for the title, content, author and tags")]
        public void ThenShowEditForTheTitleContentAuthorAndTags()
        {
            var actionResult = ActionResult as ViewResult;
            ObjectFactory.GetInstance<IResourceRepository>();
            var actualResource = actionResult.ViewData.Model as ResourceDetailViewModel;

            AssertResource(ExistingResource, actualResource);
        }

         [When(@"modify the resource")]
         public void WhenModifyTheResource(Table table)
         {
             var resourceModel = table.CreateInstance<ResourceDetailViewModel>();
             var resource = ExistingResource;
             var id = resource.Id.Substring(10);
             var controller = ObjectFactory.GetInstance<ResourceController>();
             var actionResult = controller.Edit(id, resourceModel);
             SubmittedResourceDetailViewModel = resourceModel;
             ActionResult = actionResult;
         }

         [Then(@"navigate to details page")]
         public void ThenNavigateToDetailsPage()
         {
             var resourceDetail = new ResourceDetail();
             var actionResult = ActionResult;
             resourceDetail.AssertAction(actionResult as RedirectToRouteResult);
         }

         [Then(@"display the title, content, author and submit user and tags")]
         public void ThenDisplayDetailInformation()
         {
             var actionResult = ActionResult as RedirectToRouteResult;
             var resourceRepository = ObjectFactory.GetInstance<IResourceRepository>();
             var resourceId = actionResult.RouteValues["id"].ToString();
             var actualResource = resourceRepository.GetResourceById(resourceId);
             var submittedResourceModel = SubmittedResourceDetailViewModel;

             AssertResource(actualResource, submittedResourceModel);
         }
        #endregion 

        
        [When(@"I wait for non-stale data")]
        public void WhenIWaitForNonStaleData()
        {
            var documentSession = ObjectFactory.GetInstance<IDocumentSession>();

            DataManager.WaitForNonStaleResults(documentSession);
        }

        [Then(@"resource list of tag '(.+)' should have (\d+) item")]
        public void ResourceListOfTagShouldHaveItem(string tagName, int count)
        {
            var controller = ObjectFactory.GetInstance<ResourceController>();

            var viewResult = controller.ListByTag(tagName) as ViewResult;

            Assert.Equal(count, (viewResult.ViewData.Model as ResourceList).Count);
        }

        private void CreateResource()
        {
            var resourceController = ObjectFactory.GetInstance<ResourceController>();
            var pendingSubmittedResourceModel = PendingSubmittedResourceDetailViewModel;

            ActionResult = resourceController.Create(pendingSubmittedResourceModel);
        }

        private ScenarioContext CurrentScenario 
        {
            get 
            {
                return ScenarioContext.Current; 
            } 
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

        private void AssertResource(Resource actualResource, ResourceDetailViewModel submittedResourceModel)
        {
            Assert.Equal(actualResource.Title, submittedResourceModel.Title);
            Assert.Equal(actualResource.Content, submittedResourceModel.Content);
            Assert.Equal(actualResource.Author, submittedResourceModel.Author);
            Assert.Equal(actualResource.SubmitUser, SubmitUser);
            Assert.Equal(actualResource.ReferenceUrl, submittedResourceModel.ReferenceUrl);
            Assert.Equal(actualResource.Tags.Count, submittedResourceModel.Tags.ToTagList().Count);
        }
    }
}
