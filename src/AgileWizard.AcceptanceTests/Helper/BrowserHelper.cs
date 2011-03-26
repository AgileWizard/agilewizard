using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using WatiN.Core;
using Xunit;

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
            if (text == null) return;

            Browser.TextFields.Single(t => t.Name == field).SetAttributeValue("value", text);
        }

        public static void InputHtml(string field, string text)
        {
            if (text == null) return;

            var id = string.Format("{0}_ifr", field);
            Browser.Frame(id).Body.SetAttributeValue("innerHTML", text);
        }

        public static string ReadText(string field)
        {
            return Browser.TextFields.Single(t => t.Name == field).Value;
        }

        public static void OpenPage(string pageUrl)
        {
            var url = ConstructUrl(pageUrl);

            Browser.GoTo(url);
        }

        public static void ClickByText(string text)
        {
            Browser.Link(l => l.Text == text).Click();
        }

        public static string GetElementTextByClassName(string elementClassName)
        {
            return Browser.Element(x => x.ClassName == elementClassName).Text;
        }

        public static void AssertPageTitle(string title)
        {
            Assert.Equal(title, Browser.Title);
        }

        public static void AssertElementByIDOrName(string expected, string idOrName)
        {
            Assert.Equal(expected, Browser.Element(s => s.IdOrName == idOrName).Text.Trim());
        }

        public static void AssertElementByClassName(string expected, string elementClassName)
        {
            Assert.Equal(expected, Browser.Element(x => x.ClassName == elementClassName).Text.Trim());
        }

        public static void AssertElementByClassNameNotExist(string expected, string elementClassName)
        {
            var linkElements = from element in Browser.Elements
                               where element.ClassName == elementClassName
                               select element;
            foreach (var linkElement in linkElements)
                Assert.NotEqual(expected, linkElement.Text.Trim());
        }
    }
}
