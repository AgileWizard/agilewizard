using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Website.Models;
using Xunit;

namespace AgileWizard.Website.Tests.PageObject
{
    public class OneResourcePageBase
    {
        private static string _loadViewName = string.Empty;
        protected ActionResult _actionResult;

        protected OneResourcePageBase(ActionResult actionResult)
        {
            _actionResult = actionResult;
        }

        public void Assert_Load()
        {
            Assert.IsType<ViewResult>(_actionResult);
            var viewResult = (ViewResultBase)_actionResult;
            Assert.Equal(_loadViewName, viewResult.ViewName);

            var _viewResult = (ViewResultBase)_actionResult;
            var viewModel = (ResourceDetailViewModel)_viewResult.ViewData.Model;
            Assert.Equal(Resource.DefaultResource().Title, viewModel.Title);
        }
    }
}
