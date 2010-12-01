namespace AgileWizard.Domain.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static User EmptyUser()
        {
            return new User { UserName = "", Password = "" };
        }
    }
}
