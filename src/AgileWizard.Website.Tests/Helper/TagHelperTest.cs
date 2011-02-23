using AgileWizard.Domain.Helper;
using Xunit;

namespace AgileWizard.Domain.Tests.Helper
{
    public class TagHelperTest
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
    }
}
