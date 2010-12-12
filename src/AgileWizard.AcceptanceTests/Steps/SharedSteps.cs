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
        public void WhenPressButton(string buttonText)
        {
            BrowserHelper.PressButton(buttonText);
        }

        [Given(@"login already")]
        public void GivenLoginAlready()
        {
            BrowserHelper.OpenPage("Account/LogOn");

            BrowserHelper.InputText("UserName", BrowserHelper.UserName);
            BrowserHelper.InputText("Password", BrowserHelper.Password);

            BrowserHelper.PressSubmitButton();
        }

    }
}
