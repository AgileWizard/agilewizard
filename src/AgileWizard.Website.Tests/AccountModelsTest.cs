using System;
using System.Reflection;
using Xunit;

using AgileWizard.Website.Models;
using AgileWizard.Locale;

namespace AgileWizard.Website.Tests
{
    public class LogOnModelsTest
    {
        [Fact]
        public void should_define_username_property_with_GlobalizedDisplayNameAttribute()
        {
            var logonModelType = typeof(LogOnModel);
            var userNameProp = logonModelType.GetProperty("UserName");
            
            var attributes = userNameProp.GetCustomAttributes(typeof(GlobalizedDisplayAttribute), false);
            var globalizedDisplayNameAttr = attributes[0] as GlobalizedDisplayAttribute;

            Assert.Equal("UserName", globalizedDisplayNameAttr.Name);
        }
    }
}
