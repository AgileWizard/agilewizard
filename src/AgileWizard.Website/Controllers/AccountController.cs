using System.Web.Mvc;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using AgileWizard.Domain;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Website.Controllers
{

    [HandleError]
    public class AccountController : MvcControllerBase
    {
        private IFormsAuthenticationService FormsService { get; set; }
        private IUserAuthenticationService UserAuthenticationService { get; set; }

        public AccountController(IUserAuthenticationService uerAuthenticationService, IFormsAuthenticationService formsService, ISessionStateRepository sessionStateRepository)
            : base(sessionStateRepository)
        {
            UserAuthenticationService = uerAuthenticationService;
            FormsService = formsService;
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
                if (UserAuthenticationService.IsMatch(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);

                    this.SessionStateRepository.CurrentUser = new Domain.Users.User
                    {
                        UserName = model.UserName,
                        Password = model.Password
                    };


                    return RedirectToAction("Index", "Home");
                }
                ShowLoginError();
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void ShowLoginError()
        {
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            this.SessionStateRepository.CurrentUser = null;

            return RedirectToAction("Index", "Home");
        }
    }
}
