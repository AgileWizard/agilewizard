namespace AgileWizard.Domain.Helper
{
    public class Gravatar: IAvatar
    {
        private readonly IHash _hash;

        public Gravatar(IHash hash)
        {
            this._hash = hash;
        }

        private string EnsureEmailIsLowerCase(string email)
        {
            return email.ToLower();
        }

        private string GetHashCode(string email)
        {
            return _hash.MD5(email); 
        }

        public string GetAvatarUrl(string email)
        {
            email = EnsureEmailIsLowerCase(email);
            var hashCode = GetHashCode(email);
            return string.Format("http://gravatar.com/avatar/{0}?d=mm", hashCode);
        }
    }
}