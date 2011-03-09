using System.Web.Mvc;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Domain.Users;
using AgileWizard.Locale.Resources.Views;
using AgileWizard.Website.Models;

namespace AgileWizard.Website.Controllers
{

    [HandleError]
    public class AccountController : MvcControllerBase
    {
        private IUserAuthenticationService UserAuthenticationService { get; set; }

        public AccountController(IUserAuthenticationService uerAuthenticationService, ISessionStateRepository sessionStateRepository)
            : base(sessionStateRepository)
        {
            UserAuthenticationService = uerAuthenticationService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserAuthenticationService.SignIn(model.UserName, model.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                ShowLoginError();
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void ShowLoginError()
        {
            ModelState.AddModelError("", AccountString.UserOrPasswordIsIncorrect);
        }

        public ActionResult LogOff()
        {
            UserAuthenticationService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AccountCreateModel accountCreateModel)
        {
            var user = default(User);

            if (ModelState.IsValid)
            {
                user = AutoMapper.Mapper.Map<AccountCreateModel, User>(accountCreateModel);

                var currentUser = SessionStateRepository.CurrentUser == null ? string.Empty : SessionStateRepository.CurrentUser.UserName;
                user = UserAuthenticationService.Create(user, currentUser, this.ModelState);
            }

            if (user != null)
            {
                return RedirectToAction("CreateComplete", "Account");
            }

            return View(accountCreateModel);
        }

        public ActionResult CreateComplete()
        {
            return View();
        }
    }
}
