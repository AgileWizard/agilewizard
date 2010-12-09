using System;
using System.Threading;
using System.Globalization;
using Xunit;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace AgileWizard.Locale.Tests
{
    public class GlobalizedDisplayNameAttributeTest
    {
        [Fact]
        public void should_return_Chinese_lable_when_set_CN_cultureInfo()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            
            var attribute = new GlobalizedDisplayAttribute { Name = "UserName" };
            var lable = attribute.DisplayName;
            
            Assert.Equal("用户名", lable);
        }

        [Fact]
        public void should_return_English_lable_when_set_US_cultureInfo()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            
            var attribute = new GlobalizedDisplayAttribute { Name = "UserName" };
            var lable = attribute.DisplayName;
            
            Assert.Equal("User Name", lable);
        }

        
    }
}
