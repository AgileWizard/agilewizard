using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Users;

namespace AgileWizard.Domain.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private User _user;
        public IUserRepository UserRepository { get; set; }
        private ISessionStateRepository SessionStateRepository { get; set; }
        private IFormsAuthenticationService FormsAuthenticationService { get; set; }

        public bool IsAuthenticated
        {
            get { return SessionStateRepository.CurrentUser != null; }
        }

        public UserAuthenticationService(IUserRepository userRepository, ISessionStateRepository sessionStateRepository, IFormsAuthenticationService formsAuthenticationService)
        {
            UserRepository = userRepository;
            SessionStateRepository = sessionStateRepository;
            FormsAuthenticationService = formsAuthenticationService;
        }

        public bool SignIn(string userName, string password)
        {
            bool match = IsMatch(userName, password);
            if (match)
            {
                FormsAuthenticationService.SignIn(userName);

                SessionStateRepository.CurrentUser = _user;
            }
            return match;
        }

        public void SignOut()
        {
            FormsAuthenticationService.SignOut();

            SessionStateRepository.CurrentUser = null;
        }

        public bool ExistUser(string userName)
        {
            var user = UserRepository.GetUserByName(userName);

            var exist = false;
            if (string.Compare(user.UserName, userName, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                exist = true;
            }

            return exist;
        }

        private bool IsMatch(string userName, string password)
        {
            _user = UserRepository.GetUserByName(userName);

            return _user.Password == password;
        }


        public bool MatchPasswordRule(string password)
        {
            var valid = true;
            if (string.IsNullOrEmpty(password)) valid = false;

            if (password.Length < 6) valid = false;

            return valid;
        }
    }
}
