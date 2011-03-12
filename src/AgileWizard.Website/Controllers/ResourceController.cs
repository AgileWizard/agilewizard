using System;
using System.Collections.Generic;
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
        private const string TICKSOFCREATETIME = "ticksOfLastCreateTime";
        private IResourceService ResourceService { get; set; }
        private IDocumentSession DocumentSession { get; set; }
        public IResourceMapper ResourceMapper { get; set; }
        public IResourceListViewService ResourceListViewService { get; set; }

        public ResourceController(IResourceService resourceService, 
            IDocumentSession documentSession, 
            ISessionStateRepository sessionStateRepository, 
            IResourceMapper resourceMapper,
            IResourceListViewService resourceListViewService)
            : base(sessionStateRepository)
        {
            ResourceService = resourceService;
            DocumentSession = documentSession;
            ResourceMapper = resourceMapper;
            ResourceListViewService = resourceListViewService;
        }

        public ActionResult Index()
        {
            var resourceListViewModel = GetNextPageOfResource(DateTime.Now.Ticks);
            return View(resourceListViewModel);
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

        public ActionResult ResourceList(long ticksOfLastCreateTime)
        {
            var resourceList = GetNextPageOfResource(ticksOfLastCreateTime);
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

        public IList<ResourceListViewModel> GetNextPageOfResource(long ticksOfLastCreateTime)
        {
            var resourceListViewModel = ResourceListViewService.GetNextPageOfResource(ticksOfLastCreateTime);
            long ticksOfCreateTime = resourceListViewModel.Count > 0 ? resourceListViewModel[resourceListViewModel.Count - 1].CreateTime.Ticks : 0;
            ViewData[TICKSOFCREATETIME] = ticksOfCreateTime;
            return resourceListViewModel;
        }

        private IList<ResourceListViewModel> GetResourceListByTag(string tagName)
        {
            var resources = ResourceService.GetResourceListByTag(tagName);
            var resourceListViewModel = ResourceMapper.MapFromDomainListToListViewModel(resources);
            return resourceListViewModel;
        } 
        #endregion
    }
}
