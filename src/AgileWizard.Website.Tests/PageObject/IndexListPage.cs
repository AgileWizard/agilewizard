using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using Xunit;

namespace AgileWizard.Website.Tests.PageObject
{
    public class IndexListPage
    {
        protected string _viewName;
        protected ActionResult _actionResult;

        public IndexListPage(ActionResult actionResult)
        {
            _actionResult = actionResult;
            _viewName = string.Empty;
        }

        public void Assert_Load()
        {
            var viewResult = (ViewResultBase) _actionResult;
            Assert.Equal(_viewName, viewResult.ViewName);

            var viewModel = (IList<ResourceListViewModel>)viewResult.ViewData.Model;
            Assert.True(viewModel.First().Id.EndsWith("1"), "model ID is " + viewModel.First().Id);
        }
    }
}
