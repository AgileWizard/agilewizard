using System;
using TechTalk.SpecFlow;
using Xunit;
using WatiN.Core;
using AgileWizard.AcceptanceTests.Data;
using AgileWizard.AcceptanceTests.Helper;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = "Resource/Create|Edit")]
    public class ResourceCreateEditPage : Page
    {
        public string Title
        {
            get
            {
                return Document.TextField(Find.ByName("Title")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("Title")).Value = value;
            }
        }

        public string Content
        {
            get
            {
                return Document.Frame(Find.ById("Content_ifr")).Body.GetAttributeValue("innerHTML");
            }
            set
            {
                Document.Frame(Find.ById("Content_ifr")).Body.SetAttributeValue("innerHTML", value);
            }
        }

        public string Author
        {
            get
            {
                return Document.TextField(Find.ByName("Author")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("Author")).Value = value;
            }
        }

        public string ReferenceUrl
        {
            get
            {
                return Document.TextField(Find.ByName("ReferenceUrl")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("ReferenceUrl")).Value = value;
            }
        }

        public string Tags
        {
            get
            {
                return Document.TextField(Find.ByName("Tags")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("Tags")).Value = value;
            }
        }

        public void Submit()
        {
            Button submitButton = Document.Button(Find.ById("submit_button"));
            submitButton.Click();
        }

        public void FillData(ResourceData data)
        {
            this.Title = data.Title;
            this.Author = data.Author;
            this.Content= data.Content;
            this.ReferenceUrl = data.ReferenceUrl;
            this.Tags = data.Tags; 
        }

        public void AssertPageData(ResourceData other)
        {
            Assert.Equal(this.Title, other.Title);
            Assert.Equal(this.Author, other.Author);
            Assert.Equal(this.Content, other.Author);
            Assert.Equal(this.ReferenceUrl, other.ReferenceUrl);
            Assert.Equal(this.Tags, other.Tags);
        }

    }
}
