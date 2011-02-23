namespace AgileWizard.Domain.Users
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        internal static User DefaultUser()
        {
            return new User { UserName = "agilewizard", Password = "agilewizard" };
        }

        internal static User EmptyUser()
        {
            return new User { UserName = "", Password = "" };
        }
    }
}
