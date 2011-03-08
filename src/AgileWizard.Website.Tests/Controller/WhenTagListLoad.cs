using System.Collections.Generic;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Tests.PageObject;
using Moq;
using Xunit;

namespace AgileWizard.Website.Tests.Controller
{
    public class WhenTagListLoad : ResourceListBase
    {
        public WhenTagListLoad()
        {
            // Arrange
            SetUpResourceServiceGetListByTagExpectation();

            // Act
            _actionResult = resourceControllerSUT.ListByTag("tag") as ViewResult;

            IndexListPage = new IndexListPage(_actionResult);
        }

        [Fact]
        public void ResourceService_GetResourceListByTag_ShouldBeCalled()
        {
            _resourceService.Verify(s=>s.GetResourceListByTag(It.IsAny<string>()));
        }

        private void SetUpResourceServiceGetListByTagExpectation()
        {
            var resources = new List<Resource> { _resource };
            _resourceService.Setup(s => s.GetResourceListByTag(It.IsAny<string>())).Returns(resources);
        }
    }
}
