using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AgileWizard.Locale.Tests
{
    public class LocaleHelperTest
    {
        [Fact]
        public void choose_US_should_display_username_label_in_English()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string stringId = "UserName";

            string expectedLabelName = "User Name";
            string actualLabelName = LocaleHelper.GetLocaleString(stringId);
            Assert.Equal(expectedLabelName, actualLabelName);
        }

        [Fact]
        public void choose_China_should_display_username_label_in_Chinese()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            string stringId = "UserName";

            string expectedLabelName = "用户名";
            string actualLabelName = LocaleHelper.GetLocaleString(stringId);
            Assert.Equal(expectedLabelName, actualLabelName);
        }
    }
}
