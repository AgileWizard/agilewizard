using WatiN.Core;
using AgileWizard.AcceptanceTests.Helper;
using Xunit;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = @"(A|a)ccount/(L|l)og(O|o)n")]
    public class AccountLogonPage : Page
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

        public void Submit()
        {
            BrowserHelper.PressSubmitButton();
        }        
    }
}
