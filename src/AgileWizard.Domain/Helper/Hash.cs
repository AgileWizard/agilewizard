using System.Linq;

namespace AgileWizard.Domain.Helper
{
    public class Hash: IHash
    {
        public string MD5(string s)
        {
            var md5Obj = new System.Security.Cryptography.MD5CryptoServiceProvider();

            var bytesToHash = System.Text.Encoding.ASCII.GetBytes(s);

            bytesToHash = md5Obj.ComputeHash(bytesToHash);

            return bytesToHash.Aggregate("", (current, b) => current + b.ToString("x2"));

        }
    }
}
