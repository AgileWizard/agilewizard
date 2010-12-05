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
        private IResourceService _resourceService { get; set; }

        public ResourceController(IDocumentSession documentSession, IResourceService resourceService)
        {
            _documentSession = documentSession;
            _resourceService = resourceService;
        }

        public ActionResult Index()
        {
            var resources = _resourceService.GetResourceList();
            ResourceList resourceList = new ResourceList();

            var t = from c in resources
                    select new ResourceModel
                        {
                            Id = c.Id.Substring(10),
                            Title = c.Title,
                            Content = c.Content
                        };
            resourceList.AddRange(t);
            resourceList.TotalCount = _resourceService.GetResourcesTotalCount();
            return View(resourceList);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceModel model)
        {
            _resourceService.AddResource(model.Title, model.Content);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = _resourceService.GetResourceById(id);
            return View(new ResourceModel
                            {
                                Id = resource.Id,
                                Title = resource.Title,
                                Content = resource.Content,
                                Author = resource.Author,
                                CreateTime = resource.CreateTime
                            });
        }
    }
}
