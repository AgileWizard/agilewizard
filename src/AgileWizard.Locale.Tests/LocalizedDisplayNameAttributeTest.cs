using System;
using System.Threading;
using System.Globalization;
using Xunit;
using AgileWizard.Locale.Tests.Resources;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace AgileWizard.Locale.Tests
{
    public class LocalizedDisplayNameAttributeTest
    {
        [Fact]
        public void should_return_Chinese_translation_when_set_CN_cultureInfo()
        {
            var culture = new CultureInfo("zh-CN");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var attribute = new LocalizedDisplayNameAttribute("US_and_CN_and_Default")
            {
                NameResourceType = typeof(TempString)
            };

            Assert.Equal("US 和 CN 和 Default", attribute.DisplayName);
        }

        [Fact]
        public void should_return_English_translation_when_set_US_cultureInfo()
        {
            var culture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var attribute = new LocalizedDisplayNameAttribute("US_and_CN_and_Default")
            {
                NameResourceType = typeof(TempString)
            };

            Assert.Equal("US and CN and Default", attribute.DisplayName);
        }

        [Fact]
        public void should_return_default_translation_when_no_matched_US_resource()
        {
            var culture = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var attribute = new LocalizedDisplayNameAttribute("CN_and_Default")
            {
                NameResourceType = typeof(TempString)
            };

            Assert.Equal("_CN_and_Default_", attribute.DisplayName);
        }

        [Fact]
        public void should_return_default_translation_when_no_matched_CN_resource()
        {
            var culture = new CultureInfo("zh-CN");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var attribute = new LocalizedDisplayNameAttribute("US_and_Default")
            {
                NameResourceType = typeof(TempString)
            };

            Assert.Equal("_US_and_Default_", attribute.DisplayName);
        }
    }
}
