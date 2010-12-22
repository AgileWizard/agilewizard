using AgileWizard.AcceptanceTests.Helper;
using Xunit;

namespace AgileWizard.AcceptanceTests.PageObject
{
    public class AccountPage
    {
        private const string accountLogonUrl = "Account/Logon";

        public static void AssertUrl()
        {
            var currentUrl = BrowserHelper.Browser.Url;
            Assert.True(currentUrl.EndsWith(accountLogonUrl));
        }
    }
}
