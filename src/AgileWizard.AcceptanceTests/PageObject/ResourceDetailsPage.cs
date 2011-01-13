using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WatiN.Core;
using Xunit;

using AgileWizard.AcceptanceTests.Helper;
using AgileWizard.AcceptanceTests.Data;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = @".+/Resource/Details/\d+")]
    public class ResourceDetailsPage : WatiN.Core.Page

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
            Assert.Equal(data.Title, this.Title);
            Assert.Equal(this.Author, data.Author);
            Assert.Equal(this.ReferenceUrl, data.ReferenceUrl);
            Assert.Equal(this.Tags, data.Tags);
            Assert.Equal(data.Content, this.Content);
         }
    }
}
