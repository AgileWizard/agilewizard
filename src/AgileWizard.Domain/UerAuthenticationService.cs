namespace AgileWizard.Domain
{
    public interface IUserAuthenticationService
    {
        bool IsMatch(string userName, string password);
    }

    public class UerAuthenticationService : IUserAuthenticationService
    {
        public IUserRepository UserRepository { get; set; }

        public UerAuthenticationService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public bool IsMatch(string userName, string password)
        {
            var user = UserRepository.GetUserByName(userName);

            return user.Password == password;
        }
    }
}
