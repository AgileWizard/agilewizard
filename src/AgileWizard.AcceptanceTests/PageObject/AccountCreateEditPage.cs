using System;
using TechTalk.SpecFlow;
using Xunit;
using WatiN.Core;
using AgileWizard.AcceptanceTests.Data;
using AgileWizard.AcceptanceTests.Helper;
using System.Diagnostics;

namespace AgileWizard.AcceptanceTests.PageObject
{
    [Page(UrlRegex = "Account/Create|Edit")]
    public class AccountCreateEditPage : Page
    {
        public string Email
        {
            get
            {
                return Document.TextField(Find.ByName("Email")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("Email")).Value = value;
            }
        }

        public string Password
        {
            get
            {
                return Document.TextField(Find.ByName("Password")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("Password")).Value = value;
            }
        }


        public void FillData(AccountCreatData data)
        {
            this.Email = data.Email;
            this.Password = data.Password;
        }

        public void Submit()
        {
            BrowserHelper.PressSubmitButton();
        }
    }
}
