using System;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Attributes;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Mapper;
using AgileWizard.Website.Models;
using Raven.Client;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : MvcControllerBase
    {
        private IResourceService ResourceService { get; set; }
        private IDocumentSession DocumentSession { get; set; }
        public IResourceMapper ResourceMapper { get; set; }
        public IResourceListViewProcessor ResourceListViewProcessor { get; set; }

        public ResourceController(IResourceService resourceService, 
            IDocumentSession documentSession, 
            ISessionStateRepository sessionStateRepository, 
            IResourceMapper resourceMapper,
            IResourceListViewProcessor resourceListViewProcessor)
            : base(sessionStateRepository)
        {
            ResourceService = resourceService;
            DocumentSession = documentSession;
            ResourceMapper = resourceMapper;
            ResourceListViewProcessor = resourceListViewProcessor;
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

        public ActionResult Index()
        {
            var resources = ResourceService.GetResourceList(DateTime.Now.Ticks);
            var resourceListViewModel = ResourceListViewProcessor.Process(resources, ViewData);
            return View(resourceListViewModel);
        }

        public ActionResult ResourceList(long ticksOfLastCreateTime)
        {
            var resources = ResourceService.GetResourceList(ticksOfLastCreateTime);
            var resourceListViewModel = ResourceListViewProcessor.Process(resources, ViewData);
            return PartialView("ResourceList", resourceListViewModel);
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
            var resources = ResourceService.GetResourceListByTag(DateTime.Now.Ticks, tagName);
            var resourceListViewModel = ResourceListViewProcessor.Process(resources, ViewData);
            return View(resourceListViewModel);
        }
        #endregion

        public ActionResult GetLikeList()
        {
            var resources = ResourceService.GetLikeList();
            var resourceListViewModel = ResourceListViewProcessor.Process(resources, ViewData);
            return PartialView("ResourceRecommendationList", resourceListViewModel);
        }
    }
}
