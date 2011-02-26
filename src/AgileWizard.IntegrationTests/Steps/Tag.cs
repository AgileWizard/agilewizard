using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using StructureMap;
using AgileWizard.Domain.Services;
using Xunit;
using AgileWizard.Website.Helper;
using AgileWizard.IntegrationTests.Helpers;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class Tag
    {
        [Then("tag list is available")]
        public void TagListIsAvailable()
        {
            var tagService = ObjectFactory.GetInstance<ITagService>();

            var list = tagService.GetTagList(10);

            Assert.NotEqual(0, list.Count);

            foreach (var tag in list)
            {
                Console.WriteLine("[{0:yyyy/MM/dd HH:mm:ss} - {1} ({2})]", tag.LastUpdateTicks, tag.Name, tag.TotalCount);
            }
        }

        [Then(@"the tag list should contain '(.+)' tag")]
        public void TheTagListShouldContainTag(string tagName)
        {
            var tagList = TagsHelper.GetTagList(10);

            Assert.True(tagList.Contains(tagName));
        }


    }
}
