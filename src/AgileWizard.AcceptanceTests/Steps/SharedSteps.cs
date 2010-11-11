using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AgileWizard.AcceptanceTests.Helper;

namespace AgileWizard.AcceptanceTests.Steps
{
    [Binding]
    public class SharedSteps
    {
        [When(@"press button - '([\w\s]+)'")]
        public void WhenPressButton(string butttonText)
        {
            var browser = BrowserHelper.Browser;

            browser.Button(x => x.Value == butttonText).Click();
        }

        public static void OpenPage(string pageUrl)
        {
            var browser = BrowserHelper.Browser;
            var url = BrowserHelper.ConstructUrl(pageUrl);

            browser.GoTo(url);
        }

    }
}
