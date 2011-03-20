using System;
using System.Collections.Generic;
using System.Text;
using AgileWizard.Domain.Helper;
using Moq;
using Xunit;

namespace AgileWizard.Domain.Tests.Helper
{
    public class GravatarHelperTest
    {
        private const string EMAIL = "ZBCJackson@Gmail.com";
        private const string HASH_CODE = "7b687090ba257bb1205c73e7e03b0527";
        private const string EXPECTED_URL_PREFIX = "http://gravatar.com/avatar/";
        private const string EXPECTED_URL = "http://gravatar.com/avatar/7b687090ba257bb1205c73e7e03b0527?d=mm";

        private Mock<IHash> _hash;
        private IAvatar _gravatar;

        public GravatarHelperTest()
        {
            _hash = new Mock<IHash>();
            _gravatar = new Gravatar(_hash.Object);
        }

        [Fact]
        public void can_get_image_url_for_email()
        {
            _hash.Setup(h => h.MD5(It.IsAny<string>())).Returns(HASH_CODE);

            var url = _gravatar.GetAvatarUrl(EMAIL);

            Assert.Equal(EXPECTED_URL_PREFIX, url.Substring(0, 27));
            Assert.Equal(HASH_CODE, url.Substring(27, 32));
        }

        [Fact]
        public void Can_set_default_image_for_email()
        {
            _hash.Setup(h => h.MD5(It.IsAny<string>())).Returns(HASH_CODE);

            var url = _gravatar.GetAvatarUrl(EMAIL);

            Assert.Equal("?d=mm", url.Substring(59));
        }

        [Fact]
        public void Get_hash_code_should_base_on_lowercase()
        {
            var url = _gravatar.GetAvatarUrl(EMAIL);

            _hash.Verify(h => h.MD5(It.Is<string>(s => s == EMAIL.ToLower())));
        }
    }
}
