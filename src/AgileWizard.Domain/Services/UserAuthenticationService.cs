using System.Linq;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Users;
using System.Web.Mvc;
using AgileWizard.Locale.Resources.Views;
using System.Collections.Generic;
using System;

namespace AgileWizard.Domain.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private User _user;
        public IUserRepository UserRepository { get; set; }
        private ISessionStateRepository SessionStateRepository { get; set; }
        private IFormsAuthenticationService FormsAuthenticationService { get; set; }
        private IConfigurationRepository ConfigurationRepository { get; set; }

        internal const string PROP_USERNAME = "UserName";
        internal const string PROP_PASSWORD = "Password";
        internal const string CONFIG_KEY_ADMINUSER = "AdminUser";

        public bool IsAuthenticated
        {
            get { return SessionStateRepository.CurrentUser != null; }
        }

        public UserAuthenticationService(IUserRepository userRepository, ISessionStateRepository sessionStateRepository, IFormsAuthenticationService formsAuthenticationService, IConfigurationRepository configurationRepository)
        {
            UserRepository = userRepository;
            SessionStateRepository = sessionStateRepository;
            FormsAuthenticationService = formsAuthenticationService;
            ConfigurationRepository = configurationRepository;
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


        public User Create(User user, string creator, ModelStateDictionary stateDictionary)
        {
            if (user == null) user = new User();

            var createdUser = default(User);

            CheckCreatorHasRights(creator, stateDictionary);
            CheckUserNameCanNotBeNull(user, stateDictionary);
            CheckUserExist(user, stateDictionary);
            CheckPasswordRuleMatched(user, stateDictionary);

            if (stateDictionary.IsValid)
            {
                createdUser = UserRepository.Add(user);

                UserRepository.Save();
            }

            return createdUser;
        }

        #region Create user private methods

        private void CheckCreatorHasRights(string creator, ModelStateDictionary modelErrors)
        {
            const char SPLIT = ',';
            var value = this.ConfigurationRepository.GetValue(CONFIG_KEY_ADMINUSER);
            if (string.IsNullOrEmpty(value) == false)
            {
                var adminUsers = value.ToLower().Split(SPLIT).ToList<string>();
                if (adminUsers.Contains(creator.ToLower()) == false)
                {
                    modelErrors.AddModelError(string.Empty, AccountString.CreatorLackOfRight);
                }
            }
        }

        private static void CheckUserNameCanNotBeNull(User user, ModelStateDictionary modelErrors)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                modelErrors.AddModelError(PROP_USERNAME, AccountString.UserNameCanNotBeNull);
            }
        }

        private void CheckUserExist(User user, ModelStateDictionary modelErrors)
        {
            var existedUser = UserRepository.GetUserByName(user.UserName);

            if (existedUser != null && string.Compare(existedUser.UserName, user.UserName, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                modelErrors.AddModelError(PROP_USERNAME, AccountString.UserAlreadyExist);
            }
        }

        private static void CheckPasswordRuleMatched(User user, ModelStateDictionary modelErrors)
        {
            var valid = true;
            var password = user.Password;
            if (string.IsNullOrEmpty(password)) valid = false;

            if (string.IsNullOrEmpty(password) || password.Length < 6) valid = false;

            if (valid == false)
            {
                modelErrors.AddModelError(PROP_PASSWORD, AccountString.NotMatchPasswordRule);
            }
        }
        #endregion

        private bool IsMatch(string userName, string password)
        {
            _user = UserRepository.GetUserByName(userName);

            return _user.Password == password;
        }


    }
}
