using System.Web.Mvc;
using AgileWizard.Website.Models;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        private IFormsAuthenticationService FormsService { get; set; }
        private IUserRepository UserRepository { get; set; }


        public AccountController(IUserRepository userRepository, IFormsAuthenticationService formsService)
        {
            UserRepository = userRepository;
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
                model.UserRepository = UserRepository;

                if(model.IsMatch())
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                   
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

            return RedirectToAction("Index", "Home");
        }
    }
}
