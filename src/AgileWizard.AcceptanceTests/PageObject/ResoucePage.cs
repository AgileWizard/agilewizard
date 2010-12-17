using AgileWizard.AcceptanceTests.Helper;
using TechTalk.SpecFlow;
using Xunit;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class ResoucePage
    {
        public ResoucePage(string title, string author, string content)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public const string TitleText = "Title";

        public string Title
        {
            get
            {
                return ScenarioContext.Current[TitleText].ToString();
            }
            private set
            {
                ScenarioContext.Current[TitleText] = value;
                BrowserHelper.InputText(TitleText, value);
            }
        }

        public const string ContentText = "Content";

        public string Content
        {
            get
            {
                return ScenarioContext.Current[ContentText].ToString();
            }
            private set
            {
                ScenarioContext.Current[ContentText] = value;
                BrowserHelper.InputText(ContentText, value);
            }
        }

        public const string AuthorText = "Author";

        public string Author
        {
            get
            {
                return ScenarioContext.Current[AuthorText].ToString();
            }
            private set
            {
                ScenarioContext.Current[AuthorText] = value;
                BrowserHelper.InputText(AuthorText, value);
            }
        }

        private const string SubmitUserText = "SubmitUser";

        public void AssertPage()
        {
            Assert.Equal(Title, BrowserHelper.Browser.Title);
            Assert.Equal(Title, BrowserHelper.Browser.Element(e => e.ClassName == TitleText).Text);
            Assert.Equal(Content, BrowserHelper.Browser.Element(e => e.ClassName == ContentText).Text);
            Assert.Equal(BrowserHelper.UserName, BrowserHelper.Browser.Element(e => e.ClassName == SubmitUserText).Text);
            Assert.Equal(Author, BrowserHelper.Browser.Element(e => e.ClassName == AuthorText).Text);
        }
    }

}
