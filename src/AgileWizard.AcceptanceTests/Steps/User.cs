using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AgileWizard.AcceptanceTests.Steps {
    [Binding]
    public class User {
        [Given(@"I open login page")]
        public void GivenIOpenLoginPage() {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I enter username - 'agilewizard' and password - 'agilewizard'")]
        public void GivenIEnterUsername_AgilewizardAndPassword_Agilewizard() {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press login")]
        public void WhenIPressLogin() {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I should be redirected to main page")]
        public void ThenIShouldBeRedirectedToMainPage() {
            ScenarioContext.Current.Pending();
        }

    }
}
