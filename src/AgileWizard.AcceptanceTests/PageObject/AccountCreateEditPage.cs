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
        public string UserName
        {
            get
            {
                return Document.TextField(Find.ByName("UserName")).Value;
            }
            set
            {
                Document.TextField(Find.ByName("UserName")).Value = value;
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


        public void FillData(AccountData data)
        {
            this.UserName = data.UserName;
            this.Password = data.Password;
        }

        public void Submit()
        {
            BrowserHelper.PressSubmitButton();
        }
    }
}
