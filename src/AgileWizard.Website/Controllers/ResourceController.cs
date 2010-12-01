using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using Raven.Client;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : Controller
    {
        private IDocumentSession _documentSession { get; set; }
        private IResourceService _resourceRepository { get; set; }

        public ResourceController(IDocumentSession documentSession, IResourceService resourceRepository)
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
                            Id = c.Id.Substring(10),
                            Title = c.Title,
                            Content = c.Content
                        });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceModel model)
        {
            _resourceRepository.AddResource(model.Title, model.Content);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = _resourceRepository.GetResourceById(id);
            return View(new ResourceModel
                            {
                                Id = resource.Id,
                                Title = resource.Title,
                                Content = resource.Content
                            });
        }
    }
}
