using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.Locale.Resources.Views;
using WatiN.Core;
using Xunit;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = @".+/Resource/Details/\d+")]
    public class ResourceDetailsPage : Page

    {
        public string Title
        {
            get
            {

                return Document.Element(Find.ById("title_field")).Text;
            }
        }

        public string Author
        {
            get
            {
                return Document.Span(Find.ById("author_field")).Text;
            }
        }

        public string Content
        {
            get
            {
                return Document.Div(Find.ById("content_field")).Text;
            }
        }

        public string ReferenceUrl
        {
            get
            {
                return Document.Span(Find.ById("referenceurl_field")).Text;
            }
        }

        public string Tags
        {
            get
            {
                return Document.Span(Find.ById("tags_field")).Text;
            }
        }

        public void AssertPageData(ResourceData data)
        {
            Assert.Equal(data.Title, Title);
            Assert.Equal(Author, data.Author);
            Assert.Equal(ReferenceUrl, data.ReferenceUrl);
            //ToDo extract tag string from resource tags
            //Assert.Equal(Tags, data.Tags);
            Assert.Equal(data.Content, Content);
         }

        public void GoToTagList(string tagName)
        {
            var browser = BrowserHelper.Browser;
            browser.Link(l => l.Text == tagName).Click();
        }
    }
}
