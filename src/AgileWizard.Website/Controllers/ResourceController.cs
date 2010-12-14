using System.Linq;
using System.Web.Mvc;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Models;
using Raven.Client;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : MvcControllerBase
    {
        private IResourceService ResourceService { get; set; }
        private IDocumentSession DocumentSession { get; set; }

        public ResourceController(IResourceService resourceService, IDocumentSession documentSession, ISessionStateRepository sessionStateRepository)
            : base(sessionStateRepository)
        {
            ResourceService = resourceService;
            DocumentSession = documentSession;
        }

        public ActionResult Index()
        {
            var resources = ResourceService.GetResourceList();
            var resourceList = new ResourceList();

            var t = from c in resources
                    select new ResourceModel
                        {
                            Id = c.Id.Substring(10),
                            Title = c.Title,
                            Content = c.Content
                        };
            resourceList.AddRange(t);
            resourceList.TotalCount = ResourceService.GetResourcesTotalCount();
            return View(resourceList);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceModel model)
        {
            var resource = ResourceService.AddResource(model.Title, model.Content, model.Author, SessionStateRepository.CurrentUser.UserName);

            return RedirectToAction("Details", new { id = resource.Id.Substring(10) });
        }

        [RequireAuthentication]
        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            return View(new ResourceModel
                            {
                                Id = resource.Id,
                                Title = resource.Title,
                                Content = resource.Content,
                                Author = resource.Author,
                                CreateTime = resource.CreateTime,
                                SubmitUser = resource.SubmitUser
                            });
        }

        [RequireAuthentication]
        public ActionResult Edit(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            return View(new ResourceModel
            {
                Id = resource.Id,
                Title = resource.Title,
                Content = resource.Content,
                Author = resource.Author,
                CreateTime = resource.CreateTime
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, ResourceModel model)
        {
            ResourceService.UpdateResource(id, new Resource { Title = model.Title, Content = model.Content });
            return RedirectToAction("Details", new { id });
        }
    }
}
