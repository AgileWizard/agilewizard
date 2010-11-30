using System;
using System.Linq;
using System.Web.Mvc;
using AgileWizard.Website.Models;
using Raven.Client;
using AgileWizard.Domain;

namespace AgileWizard.Website.Controllers
{
    public class ResourceController : Controller
    {
        private IDocumentSession _session = MvcApplication.CurrentSession;

        public ActionResult Index()
        {
            var albums = _session.LuceneQuery<Resource>().ToArray();

            return View(from c in albums
                        select new ResourceModel
                        {
                            Id = c.Id.Substring(10),
                            Title = c.Title,
                            Content = c.Content
                        });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ResourceModel model)
        {
            var resource = new Resource
            {
                Title = model.Title,
                Content = model.Content,
                CreateTime = DateTime.Now,
                LastUpdateTime = DateTime.Now
            };

            _session.Store(resource);
            _session.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var viewModel = new ResourceModel();

            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var resource = _session.Load<Resource>(string.Format("resources/{0}", id));
            return View(new ResourceModel
                            {
                                Id = resource.Id,
                                Title = resource.Title,
                                Content = resource.Content
                            });
        }

    }
}
