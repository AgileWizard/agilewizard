using System.Web.Mvc;
using System.Web.Routing;
using AgileWizard.Website.Models;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IUserRepository UserRepository { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            FormsService = new FormsAuthenticationService(); 
            UserRepository = new UserRepository(MvcApplication.CurrentSession);

            base.Initialize(requestContext);
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
                var user = UserRepository.GetUserByName(model.UserName);

                if(user.Password == model.Password)
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
