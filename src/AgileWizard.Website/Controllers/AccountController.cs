using System.Web.Mvc;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Locale.Resources.Views;
using AgileWizard.Domain.Users;

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

                user = UserAuthenticationService.Create(user, this.ModelState);
            }

            if (user != null)
            {
                return RedirectToAction("CreateComplete");
            }

            return View(accountCreateModel);
        }

        //private void CheckUserExistOrNot(AccountCreateModel accountCreateModel)
        //{
        //    if (UserAuthenticationService.ExistUser(accountCreateModel.UserName))
        //    {
        //        ModelState.AddModelError("UserName", AccountString.UserAlreadyExist);
        //    }
        //}

        //private void CheckPasswordStrategy(AccountCreateModel accountCreateModel)
        //{
        //    if (UserAuthenticationService.MatchPasswordRule(accountCreateModel.Password) == false)
        //    {
        //        ModelState.AddModelError("Password", AccountString.NotMatchPasswordRule);
        //    }
        //}

    }
}
