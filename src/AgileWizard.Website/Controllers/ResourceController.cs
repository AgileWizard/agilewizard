using System.Linq;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using Raven.Client;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : Controller
    {
        private IDocumentSession _documentSession { get; set; }
        private IResourceRepository _resourceRepository { get; set; }

        public ResourceController(IDocumentSession documentSession, IResourceRepository resourceRepository)
        {
            _documentSession = documentSession;
            _resourceRepository = resourceRepository;
        }

        public ActionResult Index()
        {
            var albums = _documentSession.LuceneQuery<Resource>().ToArray();

            return View(from c in albums
                        select new ResourceModel
                        {
                            Title = c.Title,
                            Content = c.Content
                        });
        }

        [HttpPost]
        public ActionResult Create(ResourceModel model)
        {
            _resourceRepository.Add(model.Title, model.Content);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

    }
}
