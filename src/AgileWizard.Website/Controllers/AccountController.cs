using System.Web.Mvc;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Repositories;

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
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
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
            return View();
        }
    }
}
