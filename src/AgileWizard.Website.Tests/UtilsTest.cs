using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Website.Helper;
using Xunit;

namespace AgileWizard.Website.Tests
{
    public class UtilsTest
    {
        [Fact]
        public void Strip_html_in_null_string_should_return_empty_string()
        {
            string nullString = null;

            var result = Utils.StripHtml(nullString);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Strip_html_in_empty_string_should_return_empty_string()
        {
            var emptyString = string.Empty;

            var result = Utils.StripHtml(emptyString);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Strip_html_in_a_string_containing_only_white_space_should_return_empty_string()
        {
            const string whiteSpaceString = "         ";

            var result = Utils.StripHtml(whiteSpaceString);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Strip_html_in_a_string_containing_html_should_return_a_string_without_any_html_tags()
        {
            const string html = "<span class='a'>Test </span><div id='b'>html <p>string</p></div>";

            var result = Utils.StripHtml(html);

            Assert.Equal("Test html string", result);
        }

        [Fact]
        public void Excerpt_content_in_html_format_should_return_a_string_without_any_html_tags()
        {
            const string html = "<span class='a'>Test </span><div id='b'>html <p>string</p></div>";

            var result = Utils.ExcerptContent(html, 100);

            Assert.Equal("Test html string", result);
        }

        [Fact]
        public void Excerpt_content_longer_than_specified_length_should_return_a_string_with_specified_length()
        {
            const string content = "<span class='a'>Test </span><div id='b'>html <p>string</p></div>";

            var result = Utils.ExcerptContent(content, 10);

            Assert.Equal("Test html ", result);
        }

        [Fact]
        public void Should_get_first_img_src_in_content()
        {
            const string content = @"<img style=""margin-top: 5px; margin-right: 0px; margin-bottom: 5px; margin-left: 0px; max-width: 500px; padding: 0px; border: 0px initial initial;"" title=""CES 2011 3M弯曲屏幕触摸机"" src=""http://pic.yupoo.com/jdvip/ALzag2Bf/medium.jpg"" alt=""http://jandan.net/"" /><br style=""padding: 0px; margin: 0px;"" />还是来自三星的东东，";

            var result = Utils.FetchFirstImageUrl(content);

            Assert.Equal("http://pic.yupoo.com/jdvip/ALzag2Bf/medium.jpg", result);
        }
    }
}
