namespace AgileWizard.Domain
{
    public interface IUerAuthenticationService
    {
        bool IsMatch(string userName, string password);
    }

    public class UerAuthenticationService : IUerAuthenticationService
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
