using AgileWizard.AcceptanceTests.Helper;
using TechTalk.SpecFlow;
using Xunit;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class ResourcePage
    {
        public ResourcePage() { }

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
                return BrowserHelper.ReadText(TitleText);
            }
            private set
            {
                BrowserHelper.InputText(TitleText, value);
            }
        }

        private const string ContentText = "Content";
        public string Content
        {
            get
            {
                return BrowserHelper.ReadText(ContentText);
            }
            private set
            {
                BrowserHelper.InputText(ContentText, value);
            }
        }

        private const string AuthorText = "Author";
        public string Author
        {
            get
            {
                return BrowserHelper.ReadText(AuthorText);
            }
            private set
            {
                BrowserHelper.InputText(AuthorText, value);
            }
        }
        private const string TagsText = "Tags";
        public string Tags
        {
            get
            {
                return BrowserHelper.ReadText(TagsText);
            }
            private set
            {
                BrowserHelper.InputText(TagsText, value);
            }
        }

        private const string ReferenceUrlText = "ReferenceUrl";
        public string ReferenceUrl
        {
            get
            {
                return BrowserHelper.ReadText(ReferenceUrlText);
            }
            private set
            {
                BrowserHelper.InputText(ReferenceUrlText, value);
            }
        }

        private const string SubmitUserText = "SubmitUser";
        #endregion

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
