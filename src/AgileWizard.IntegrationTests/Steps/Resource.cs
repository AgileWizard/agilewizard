using System;
using System.Web.Mvc;
using AgileWizard.Domain.Repositories;
using AgileWizard.Website.Controllers;
using AgileWizard.Website.Models;
using StructureMap;
using TechTalk.SpecFlow;
using Xunit;
using Moq;

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
            private Mock<ISessionStateRepository> _sessionStateRepository;

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

                var resources = resourceRepository.GetResourceList();

                const int firstIndex = 0;
                Assert.Equal(resources[firstIndex].Title, _resourceModel.Title);
                Assert.Equal(resources[firstIndex].Content, _resourceModel.Content);
                Assert.Equal(resources[firstIndex].Author, _resourceModel.Author);
                Assert.Equal(resources[firstIndex].SubmitUser, SubmitUser);

            }
        }
     }
}
