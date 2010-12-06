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
            string localeName = "en-US";
            string stringId = "UI_UserName";

            string expectedLabelName = "User Name";
            string actualLabelName = LocaleHelper.GetLocaleString(stringId, localeName);
            Assert.Equal(expectedLabelName, actualLabelName);
        }

        [Fact]
        public void choose_China_should_display_username_label_in_Chinese()
        {
            string localeName = "zh-CN";
            string stringId = "UI_UserName";

            string expectedLabelName = "用户名";
            string actualLabelName = LocaleHelper.GetLocaleString(stringId, localeName);
            Assert.Equal(expectedLabelName, actualLabelName);
        }
    }
}
