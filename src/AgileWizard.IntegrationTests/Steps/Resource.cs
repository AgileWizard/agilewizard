using System;
using System.Web.Mvc;
using AgileWizard.Domain.Repositories;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using StructureMap;
using TechTalk.SpecFlow;
using Xunit;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class Resource
    {
        [Binding]
        public class StepDefinitions
        {
            private ResourceModel _resourceModel;
            private ResourceController _resourceController;
            private RedirectToRouteResult _actionResult;

            const string SubmitUser = "agilewizard";

            [Given(@"new resource with  title - '([\w\s]+)' and content - '([\w\s]+)' and author - '([\w\s]+)'")]
            public void GivenNewResourceWithTitleAndContentAndAuthor(string title, string content, string author)
            {
                _resourceModel = new ResourceModel
                                     {
                                         Title = title,
                                         Content = content,
                                         Author = author,
                                         SubmitUser = SubmitUser
                                     };

                _resourceController = ObjectFactory.GetInstance<ResourceController>();
            }

            [When(@"submit resource to system")]
            public void WhenSubmitResourceToSystem()
            {
                _actionResult = _resourceController.Create(_resourceModel) as RedirectToRouteResult;
            }

            [Then(@"navigate to details page")]
            public void ThenNavigateToDetailsPage()
            {
                Assert.Equal("details", (string)_actionResult.RouteValues["action"], StringComparer.OrdinalIgnoreCase);
            }

            [Then(@"display the title, content, author and submit user")]
            public void ThenDisplayDetailInformation()
            {
                var resourceRepository = ObjectFactory.GetInstance<IResourceRepository>();

                var resourceId = _actionResult.RouteValues["id"].ToString();

                var actualResource = resourceRepository.GetResourceById(resourceId);

                Assert.Equal(actualResource.Title, _resourceModel.Title);
                Assert.Equal(actualResource.Content, _resourceModel.Content);
                Assert.Equal(actualResource.Author, _resourceModel.Author);
                Assert.Equal(actualResource.SubmitUser, SubmitUser);

            }
        }
     }
}
