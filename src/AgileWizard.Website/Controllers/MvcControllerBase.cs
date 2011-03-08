using System.Web.Mvc;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Website.Controllers
{
    public abstract class MvcControllerBase : Controller
    {
        protected ISessionStateRepository SessionStateRepository { get; set; }

        public MvcControllerBase( ISessionStateRepository sessionStateRepository)
        {
            this.SessionStateRepository = sessionStateRepository;
        }
    }
}