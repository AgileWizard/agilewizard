using WatiN.Core;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = @"(A|a)ccount/(L|l)og(O|o)n")]
    public class AccountPage : Page
    {
        public string UserName
        {
            get
            {
                return Document.TextField(Find.ById("username_field")).Value;
            }
            set
            {
                Document.TextField(Find.ById("username_field")).Value = value;
            }
        }

        public string Password
        {
            get
            {
                return Document.TextField(Find.ById("password_field")).Value;
            }
            set
            {
                Document.TextField(Find.ById("password_field")).Value = value;
            }
        }

        private Button SubmitButton
        {
            get
            {
                return Document.Button(Find.ById("submit_button"));
            }
        }

        public void Submit()
        {
            this.SubmitButton.Click();
        }
        
        //private const string accountLogonUrl = "Account/Logon";

        //public static void AssertUrl()
        //{
        //    var currentUrl = BrowserHelper.Browser.Url;
        //    Assert.True(currentUrl.EndsWith(accountLogonUrl));
        //}
    }
}
