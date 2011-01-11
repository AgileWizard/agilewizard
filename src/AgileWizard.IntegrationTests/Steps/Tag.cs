using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using StructureMap;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.IntegrationTests.Steps
{
    [Binding]
    public class Tag
    {
        [Then("tag list is available")]
        public void TagListIsAvailable()
        {
            var tagRepository = ObjectFactory.GetInstance<ITagRepository>();

            var list = tagRepository.GetTagList();

            foreach (var tag in list)
            {
                Console.WriteLine("[{0:yyyy/MM/dd HH:mm:ss} - {1} ({2})]", tag.LastUpdateTime, tag.Name, tag.TotalCount);
            }
        }
    }
}
