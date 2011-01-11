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
    }
}
