using AgileWizard.AcceptanceTests.Helper;
using TechTalk.SpecFlow;
using Xunit;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class ResourcePage
    {
        public ResourcePage(ResourceData data)
        {
            this.Title = data.Title;
            this.Content = data.Content;
            this.Author = data.Author;
            this.ReferenceUrl = data.ReferenceUrl;
            this.Tags = data.Tags;
        }

        #region Properties
        private const string TitleText = "Title";
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

        private const string ContentText = "Content";
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

        private const string AuthorText = "Author";
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
        private const string TagsText = "Tags";
        public string Tags
        {
            get
            {
                return ScenarioContext.Current[TagsText].ToString();
            }
            private set
            {
                ScenarioContext.Current[TagsText] = value;
                BrowserHelper.InputText(TagsText, value);
            }
        }

        private const string ReferenceUrlText = "ReferenceUrl";
        public string ReferenceUrl
        {
            get
            {
                return ScenarioContext.Current[ReferenceUrlText].ToString();
            }
            private set
            {
                ScenarioContext.Current[ReferenceUrlText] = value;
                BrowserHelper.InputText(ReferenceUrlText, value);
            }
        }

        private const string SubmitUserText = "SubmitUser";
        #endregion

        public void AssertPage()
        {
            Assert.Equal(Title, BrowserHelper.Browser.Title);
            BrowserHelper.AssertElementByClassName(Title, TitleText);
            BrowserHelper.AssertElementByClassName(Content, ContentText);
            BrowserHelper.AssertElementByClassName(BrowserHelper.UserName, SubmitUserText);
            BrowserHelper.AssertElementByClassName(Author, AuthorText);
        }

        public static void GoToCreate()
        {
            const string resourceCreateUrl = "Resource/Create";
            BrowserHelper.OpenPage(resourceCreateUrl);
        }

        public static void Submit()
        {
            BrowserHelper.PressSubmitButton();
        }
    }
}
