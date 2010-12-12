using System;
using System.Reflection;
using Xunit;

using AgileWizard.Website.Models;
using AgileWizard.Locale;

namespace AgileWizard.Website.Tests
{
    public class LogOnModelsTest
    {
        private string GetNameValueOfGlobalizedDisplayNameAttribute(string propertyName)
        {
            var logonModelType = typeof(LogOnModel);
            var userNameProp = logonModelType.GetProperty(propertyName);

            var attributes = userNameProp.GetCustomAttributes(typeof(LocalizedDisplayNameAttribute), false);
            var localizedDisplayNameAttr = attributes[0] as LocalizedDisplayNameAttribute;

            return localizedDisplayNameAttr.DisplayNameKey;
        }

        [Fact]
        public void should_define_username_property_with_GlobalizedDisplayNameAttribute()
        {
            Assert.Equal("UserName", GetNameValueOfGlobalizedDisplayNameAttribute("UserName"));
        }

        [Fact]
        public void should_define_password_property_with_GlobalizedDisplayNameAttribute()
        {
            Assert.Equal("Password", GetNameValueOfGlobalizedDisplayNameAttribute("Password"));
        }

        [Fact]
        public void should_define_rememberme_property_with_GlobalizedDisplayNameAttribute()
        {
            Assert.Equal("RememberMe", GetNameValueOfGlobalizedDisplayNameAttribute("RememberMe"));
        }
    }
}
