using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Attributes;
using AgileWizard.Website.Models;
using AutoMapper;
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
            ResourceList resourceList = GetResourceList();
            return View(resourceList);
        }

        private ResourceList GetResourceList()
        {
            var resources = ResourceService.GetResourceList();
            var resourceList = new ResourceList(resources)
                                   {
                                       TotalCount = ResourceService.GetResourcesTotalCount()
                                   };
            return resourceList;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceDetailViewModel detailViewModel)
        {
            var resource = Mapper.Map<ResourceDetailViewModel, Resource>(detailViewModel);
            resource = ResourceService.AddResource(resource);

            return RedirectToAction("Details", new { id = resource.Id.Substring(10) });
        }

        [RequireAuthentication]
        public ActionResult Create()
        {
            var viewModel = new ResourceDetailViewModel();

            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = ResourceService.GetResourceById(id);

            var resourceDetailieViewModel = Mapper.Map<Resource, ResourceDetailViewModel>(resource);

            return View(resourceDetailieViewModel);
        }

        [RequireAuthentication]
        public ActionResult Edit(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            var resourceDetailieViewModel = Mapper.Map<Resource, ResourceDetailViewModel>(resource);
            return View(resourceDetailieViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, ResourceDetailViewModel detailViewModel)
        {
            var resource = Mapper.Map<ResourceDetailViewModel, Resource>(detailViewModel);
            ResourceService.UpdateResource(id, resource);

            return RedirectToAction("Details", new { id });
        }

        public ActionResult ResourceList()
        {
            ResourceList resourceList = GetResourceList();
            return PartialView("ResourceList", resourceList);
        }

        [HttpPost]
        public ActionResult Like(string id)
        {
            ResourceService.LikeThisResource(id, Request.UserHostAddress);
            return Json(null);
        }

        [HttpPost]
        public ActionResult Dislike(string id)
        {
            ResourceService.DislikeThisResource(id, Request.UserHostAddress);
            return Json(null);
        }

        public ActionResult ListByTag(string tagName)
        {
            ResourceList resourceList = GetResourceListByTag(tagName);
            return View(resourceList);
        }

        private ResourceList GetResourceListByTag(string tagName)
        {
            var resources = ResourceService.GetResourceListByTag(tagName);
            var resourceList = new ResourceList(resources)
            {
                TotalCount = ResourceService.GetResourcesTotalCountForTag(tagName)
            };
            return resourceList;
        }
    }
}
