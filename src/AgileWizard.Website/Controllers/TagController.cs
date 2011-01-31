using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileWizard.Domain.Services;
using Raven.Client;

namespace AgileWizard.Website.Controllers
{
    public class TagController : Controller
    {
        private ITagService TagService { get; set; }
        private IDocumentSession DocumentSession { get; set; }

        public TagController(ITagService tagService, IDocumentSession documentSession)
        {
            this.TagService = tagService;
        }

        public ActionResult ShortList()
        {
            return View();
        }

    }
}
