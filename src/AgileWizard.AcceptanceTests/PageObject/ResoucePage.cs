using AgileWizard.AcceptanceTests.Helper;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection;
using System;

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

        public string Title
        {
            get
            {
                return GetContext(MethodBase.GetCurrentMethod().GetPropertyName());
            }
            private set
            {
                SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value);
            }
        }

        public string Content
        {
            get
            {
                return GetContext(MethodBase.GetCurrentMethod().GetPropertyName());
            }
            private set
            {
                SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value);
            }
        }

        public string Author
        {
            get
            {
                return GetContext(MethodBase.GetCurrentMethod().GetPropertyName());
            }
            private set
            {
                SetContext(MethodBase.GetCurrentMethod().GetPropertyName(), value);
            }
        }

        private const string SubmitUserText = "SubmitUser";

        public void AssertPage()
        {
            Assert.Equal(Title, BrowserHelper.Browser.Title);
            Assert.Equal(Title, BrowserHelper.Browser.Element(e => e.ClassName == "Title").Text);
            Assert.Equal(Content, BrowserHelper.Browser.Element(e => e.ClassName == "Content").Text);
            Assert.Equal(BrowserHelper.UserName, BrowserHelper.Browser.Element(e => e.ClassName == SubmitUserText).Text);
            Assert.Equal(Author, BrowserHelper.Browser.Element(e => e.ClassName == "Author").Text);
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
