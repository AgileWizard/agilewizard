﻿using System;
using Xunit;
using WatiN.Core;
using AgileWizard.AcceptanceTests.Data;
using System.Diagnostics;

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
                return SafetyGetFrame("Content_ifr").Body.GetAttributeValue("innerHTML");
            }
            set
            {
                SafetyGetFrame("Content_ifr").Body.SetAttributeValue("innerHTML", value);
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

        public void AssertPageData(ResourceData data)
        {
            Assert.Equal(this.Title, data.Title);
            Assert.Equal(this.Author, data.Author);
            Assert.Equal(this.Content, data.Author);
            Assert.Equal(this.ReferenceUrl, data.ReferenceUrl);
            Assert.Equal(this.Tags, data.Tags);
        }

        private Frame SafetyGetFrame(string id)
        {
            Document.DomContainer.WaitForComplete();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!Document.Frames.Exists(x => x.Id == id))
            {
                if (stopwatch.ElapsedMilliseconds > 30 * 1000)
                    throw new Exception(string.Format("Could not find frame '{0}'", id));
            }

            var frame = Document.Frame(id);
            frame.DomContainer.WaitForComplete();

            return frame;
        }

    }
}
