using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using AgileWizard.Website.Models;
using AgileWizard.Domain;
using AgileWizard.Domain.QueryIndex;

namespace AgileWizard.Website.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }

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
                var userRepository = new UserRepository(MvcApplication.CurrentSession);

                var user = userRepository.GetUserByName(model.UserName);

                if(user.Password == model.Password)
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                   
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
