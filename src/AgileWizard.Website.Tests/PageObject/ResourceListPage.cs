using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using Xunit;

namespace AgileWizard.Website.Tests.PageObject
{
    public class ResourceListPage
    {
        protected string _viewName;
        protected ActionResult _actionResult;

        public ResourceListPage(ActionResult actionResult)
        {
            _actionResult = actionResult;
            _viewName = string.Empty;
        }

        public void Assert_Load()
        {
            var viewResult = (ViewResultBase) _actionResult;

            var viewModel = (IList<ResourceListViewModel>)viewResult.ViewData.Model;
            Assert.True(viewModel.First().Id.EndsWith("1"), "model ID is " + viewModel.First().Id);
        }

        public void Assert_CreateDateTimeOFLastResource_ShouldBeKept()
        {
            var viewResult = (ViewResultBase)_actionResult;
           
             var viewModel = (IList<ResourceListViewModel>)viewResult.ViewData.Model;
             long ticksOfLastCreateTime = viewModel[viewModel.Count - 1].CreateTime.Ticks;
             Assert.Equal(viewResult.ViewData["ticksOfLastCreateTime"], ticksOfLastCreateTime);
        }

        public void Assert_TicksOfZero_ShouldBeKept()
        {
            var viewResult = (ViewResultBase)_actionResult;

            const long ticksOfLastCreateTime = 0;
            Assert.Equal(viewResult.ViewData["ticksOfLastCreateTime"], ticksOfLastCreateTime);
        }
    }
}
