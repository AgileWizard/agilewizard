using System.Collections.Generic;
using System.Linq;
using StructureMap;
using StructureMap.Attributes;
using StructureMap.Pipeline;

namespace AgileWizard.Domain.Helper
{
    public class GravatarHelper
    {
        private string _email;
        [SetterProperty]
        public IHash Hash { get; set; }

        public GravatarHelper(string email)
        {
            this._email = email;
        }

        private string HashCode
        {
            get { return this.Hash.MD5(_email.ToLower()); }
        }

        public string Url
        {
            get
            {
                return string.Format("http://gravatar.com/avatar/{0}?d=mm", HashCode);
            }
        }

        public static string AvatarUrl(string email)
        {
            var args = new ExplicitArguments(new Dictionary<string, object>{{"email", email}});
            var gravatar = ObjectFactory.GetInstance<GravatarHelper>(args);
            return gravatar.Url;
        }
    }
}