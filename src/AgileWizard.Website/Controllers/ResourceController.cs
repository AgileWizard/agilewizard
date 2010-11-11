using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using Raven.Client;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : Controller
    {
        private IDocumentSession session = MvcApplication.CurrentSession;

        //
        // GET: /Resource/

        public ActionResult Index()
        {
            var albums = session.LuceneQuery<Resource>().ToArray();

            return View(from c in albums
                        select new ResourceModel
                        {
                            Title = c.Title,
                            Content = c.Content
                        });
        }

        [HttpPost]
        public ActionResult Create(ResourceModel model)
        {
            var resource = new Resource
            {
                Guid = new Guid(),
                Title = model.Title,
                Content = model.Content,
                CreateTime = DateTime.Now,
                LastUpdateTime = DateTime.Now
            };

            session.Store(resource);
            session.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

    }
}
