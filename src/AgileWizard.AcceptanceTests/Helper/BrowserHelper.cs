using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace AgileWizard.AcceptanceTests.Helper
{
    public class BrowserHelper
    {
        public static string WebsiteUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebsiteUrl"];
            }
        }

        public static string UserName
        {
            get { return ConfigurationManager.AppSettings["UserName"]; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings["Password"]; }
        }

        public static string ConstructUrl(string relativeUrl)
        {
            return WebsiteUrl + relativeUrl;
        }

        public static IE Browser
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("Browser") ||
                    ScenarioContext.Current["Browser"] == null)
                    ScenarioContext.Current["Browser"] = new IE();
                return (IE)ScenarioContext.Current["Browser"];
            }
            set
            {
                ScenarioContext.Current["Browser"] = value;
            }
        }

        public static IE OpenBrowser()
        {
            Browser.GoTo(WebsiteUrl);

            return Browser;
        }

        internal static void CloseBrowser()
        {
            if (Browser != null)
            {
                Browser.Close();

                Browser = null;
            }
        }

        public static void PressButton(string buttonText)
        {
            Browser.Button(x => x.Value == buttonText).Click();
        }

        public static void PressSubmitButton()
        {
            Browser.Buttons.First(x => x.GetAttributeValue("type") == "submit").Click();
        }

        public static void InputText(string field, string text)
        {
            Browser.TextFields.Single(t => t.Name == field).TypeText(text);
        }

        public static void OpenPage(string pageUrl)
        {
            var url = ConstructUrl(pageUrl);

            Browser.GoTo(url);
        }

    }
}
