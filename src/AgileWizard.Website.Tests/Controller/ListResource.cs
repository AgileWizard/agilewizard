using System.Linq;
using Moq;
using Xunit;
using AgileWizard.Domain.Models;

namespace AgileWizard.Website.Tests.Controller
{
    public abstract class ListResource: ResourceListBase
    {
        protected ListResource()
        {
            SetUpResourceServiceGetListExpectation();
        }

        private void SetUpResourceServiceGetListExpectation()
        {
            var resourceList = 10.CountOfResouces("").ToList();
            _resourceService.Setup(s => s.GetResourceList(It.IsAny<int>())).Returns(resourceList);
        }

        [Fact]
        public void ResourceService_GetList_ShouldBeCalled()
        {
            _resourceService.Verify(s => s.GetResourceList(It.IsAny<int>()));
        }

    }
}
