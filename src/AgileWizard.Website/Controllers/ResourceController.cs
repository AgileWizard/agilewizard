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
        public ActionResult Create(ResourceModel model)
        {
            var resource = ResourceService.AddResource(new Resource
                {
                    Title = model.Title,
                    Content = model.Content,
                    Author = model.Author,
                    SubmitUser = SessionStateRepository.CurrentUser.UserName,
                    Tags = model.Tags.ToTagList(),
                    ReferenceUrl = model.ReferenceUrl
                });

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
                                SubmitUser = resource.SubmitUser,
                                Tags = resource.Tags.ToTagString(),
                                ReferenceUrl = resource.ReferenceUrl
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
                CreateTime = resource.CreateTime,
                ReferenceUrl = resource.ReferenceUrl,
                Tags = resource.Tags == null ? string.Empty : resource.Tags.ToTagString()
            });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, ResourceModel model)
        {
            ResourceService.UpdateResource(id, new Resource
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                SubmitUser = SessionStateRepository.CurrentUser.UserName,
                ReferenceUrl = model.ReferenceUrl,
                Tags = model.Tags.ToTagList()
            });

            return RedirectToAction("Details", new { id });
        }

        public ActionResult ResourceList()
        {
            ResourceList resourceList = GetResourceList();
            return PartialView("ResourceList", resourceList);
        }
    }
}
