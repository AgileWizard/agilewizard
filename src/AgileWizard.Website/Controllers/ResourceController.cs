using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Services;
using AgileWizard.Website.Attributes;
using AgileWizard.Website.Models;
using AutoMapper;
using Raven.Client;
using AgileWizard.Website.Helper;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : MvcControllerBase
    {
        private IResourceService ResourceService { get; set; }
        private IDocumentSession DocumentSession { get; set; }
        private static readonly object pageViewLock = new object();

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
            var resource = ResourceService.AddResource(new Resource
                {
                    Title = detailViewModel.Title,
                    Content = detailViewModel.Content,
                    Author = detailViewModel.Author,
                    SubmitUser = SessionStateRepository.CurrentUser.UserName,
                    Tags = detailViewModel.Tags.ToTagList(),
                    ReferenceUrl = detailViewModel.ReferenceUrl
                });

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

            ResourceService.AddOnePageView(id, Request.UserHostAddress);

            return View(new ResourceDetailViewModel
                            {
                                Id = resource.Id.Substring(10),
                                Title = resource.Title,
                                Content = resource.Content,
                                Author = resource.Author,
                                CreateTime = resource.CreateTime,
                                SubmitUser = resource.SubmitUser,
                                Tags = resource.Tags.ToTagString(),
                                ReferenceUrl = resource.ReferenceUrl,
                                PageView = resource.PageView
                            });
        }

        [RequireAuthentication]
        public ActionResult Edit(string id)
        {
            var resource = ResourceService.GetResourceById(id);
            return View(new ResourceDetailViewModel
            {
                Id = resource.Id,
                Title = resource.Title,
                Content = resource.Content,
                Author = resource.Author,
                CreateTime = resource.CreateTime,
                ReferenceUrl = resource.ReferenceUrl,
                Tags = resource.Tags == null ? string.Empty : resource.Tags.ToTagString()
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, ResourceDetailViewModel detailViewModel)
        {
            ResourceService.UpdateResource(id, new Resource
            {
                Title = detailViewModel.Title,
                Content = detailViewModel.Content,
                Author = detailViewModel.Author,
                SubmitUser = SessionStateRepository.CurrentUser.UserName,
                ReferenceUrl = detailViewModel.ReferenceUrl,
                Tags = detailViewModel.Tags.ToTagList()
            });

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

        // id = tagName
        public ActionResult ListByTag(string id)
        {
            ResourceList resourceList = GetResourceListByTag(id);
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
