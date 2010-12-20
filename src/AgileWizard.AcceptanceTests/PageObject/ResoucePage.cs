using System.Reflection;
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
            Author = author;
            Content = content;
        }

        public ResoucePage(string title, string author, string content, string tags)
            : this(title, author, content)
        {
            Tags = tags;
        }

        #region Properties
        public string Title
        {
            get { return GetContext(MethodBase.GetCurrentMethod().GetPropertyName()); }
            set { SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value); }
        }

        public string Content
        {
            get { return GetContext(MethodBase.GetCurrentMethod().GetPropertyName()); }
            set { SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value); }
        }

        public string Author
        {
            get { return GetContext(MethodBase.GetCurrentMethod().GetPropertyName()); }
            set { SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value); }
        }

        public string Tags
        {
            get { return GetContext(MethodBase.GetCurrentMethod().GetPropertyName()); }
            set { SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value); }
        }

        public string ReferenceUrl
        {
            get { return GetContext(MethodBase.GetCurrentMethod().GetPropertyName()); }
            set { SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value); }
        }

        #endregion

        private const string SubmitUserText = "SubmitUser";

        public void AssertPage()
        {
            Assert.Equal(Title, BrowserHelper.Browser.Title);
            Assert.Equal(Title, BrowserHelper.Browser.Element(e => e.ClassName == "Title").Text);
            Assert.Equal(Content, BrowserHelper.Browser.Element(e => e.ClassName == "Content").Text);
            Assert.Equal(BrowserHelper.UserName, BrowserHelper.Browser.Element(e => e.ClassName == SubmitUserText).Text);
            Assert.Equal(Author, BrowserHelper.Browser.Element(e => e.ClassName == "Author").Text);
            Assert.Equal(ReferenceUrl, BrowserHelper.Browser.Element(e => e.ClassName == "ReferenceUrl").Text);
            
        }

        #region CommonMethod
        private string GetContext(string key)
        {
            return ScenarioContext.Current[key].ToString();
        }

        private void SetContext(string key, string value)
        {
            ScenarioContext.Current[key] = value;
            BrowserHelper.InputText(key, value);
        }
        #endregion

    }



}
