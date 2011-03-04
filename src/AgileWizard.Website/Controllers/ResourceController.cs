using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Attributes;
using AgileWizard.Website.Mapper;
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
            const int firstPage = 0;
            var resourceList = GetResourceList(firstPage);
            return View(resourceList);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceDetailViewModel detailViewModel)
        {
            var resource = ResourceMapper.MapFromDetailViewModelToDomain(detailViewModel);
            resource = ResourceService.AddResource(resource);
            return RedirectToAction("Details", new { id = resource.Id.Substring(10) });
        }
        #region CRUD

        [RequireAuthentication]
        public ActionResult Create()
        {
            var viewModel = new ResourceDetailViewModel();
            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            ResourceDetailViewModel resourceDetailieViewModel = ResourceMapper.MapFromDomainToDetailViewModel(resource);
            return View(resourceDetailieViewModel);
        }

        [RequireAuthentication]
        public ActionResult Edit(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            var resourceDetailieViewModel = ResourceMapper.MapFromDomainToDetailViewModel(resource);
            return View(resourceDetailieViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, ResourceDetailViewModel detailViewModel)
        {
            Resource resource = ResourceMapper.MapFromDetailViewModelToDomain(detailViewModel);
            ResourceService.UpdateResource(id, resource);

            return RedirectToAction("Details", new { id });
        }

        public ActionResult ResourceList(int currentPage)
        {
            var resourceList = GetResourceList(currentPage);
            return PartialView("ResourceList", resourceList);
        }
        #endregion

        #region Like / Dislike
        [HttpPost]
        public ActionResult Like(string id)
        {
            ResourceService.LikeThisResource(id);
            return Json(null);
        }

        [HttpPost]
        public ActionResult Dislike(string id)
        {
            ResourceService.DislikeThisResource(id);
            return Json(null);
        }
        #endregion

        #region Tag
        public ActionResult ListByTag(string tagName)
        {
            var resourceList = GetResourceListByTag(tagName);
            return View(resourceList);
        }
        #endregion

        #region Private functions

        private ResourceList GetResourceList(int currentPage)
        {
            var resources = ResourceService.GetResourceList(currentPage);
            var resourceList = new ResourceList(resources, currentPage);
            return resourceList;
        }

        private ResourceList GetResourceListByTag(string tagName)
        {
            var resources = ResourceService.GetResourceListByTag(tagName);
            var resourceList = new ResourceList(resources, 0);
            return resourceList;
        } 
        #endregion
    }
}
