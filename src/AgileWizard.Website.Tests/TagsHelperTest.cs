using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Helper;
using Xunit;
using AgileWizard.Website.Helper;
using AgileWizard.Domain.Models;

namespace AgileWizard.Website.Tests
{
    public class TagsHelperTest
    {
        [Fact]
        public void can_convert_comma_separated_string_to_tagList()
        {
            string COMMA_SEPARATED_STRING = "Agile, Shanghai , Wen";
            var tags = COMMA_SEPARATED_STRING.ToTagList();
            Assert.Equal(3, tags.Count);
            Assert.Equal("Agile", tags[0].Name);
            Assert.Equal("Shanghai", tags[1].Name);
            Assert.Equal("Wen", tags[2].Name);
        }

        [Fact]
        public void can_convert_tagList_to_comma_separated_string()
        {
            var tagList = new List<Resource.ResourceTag> { new Resource.ResourceTag { Name = "Agile" }, new Resource.ResourceTag { Name = "Shanghai" }, new Resource.ResourceTag { Name = "Wen" } };
            var tagString = tagList.ToTagString();
            Assert.Equal("Agile,Shanghai,Wen", tagString);
        }

        [Fact]
        public void ToTagString_ShouldRemoveDuplicated_WhenHasSameTagValue()
        {
            var tagList = new List<Resource.ResourceTag> { new Resource.ResourceTag { Name = "Agile" }, new Resource.ResourceTag { Name = "agile" }, new Resource.ResourceTag { Name = "Wen" } };
            var tagString = tagList.ToTagString();
            Assert.Equal("Agile,Wen", tagString);
        }
    }
}
