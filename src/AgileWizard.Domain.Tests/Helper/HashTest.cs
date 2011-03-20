using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Helper;
using Xunit;

namespace AgileWizard.Domain.Tests.Helper
{
    public class HashTest
    {
        [Fact]
        public void Get_hashcode_by_MD5()
        {
            const string EMAIL = "zbcjackson@gmail.com";
            const string HASH_CODE = "7b687090ba257bb1205c73e7e03b0527";
            var hash = new Hash();

            var hashCode = hash.MD5(EMAIL);

            Assert.Equal(HASH_CODE, hashCode);
        }
    }
}
