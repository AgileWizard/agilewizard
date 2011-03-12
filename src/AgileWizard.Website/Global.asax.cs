using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Website.Mapper;
using Raven.Client.Document;
using Raven.Client;
using AgileWizard.Website.Controllers;
using StructureMap;
using StructureMap.Configuration.DSL;
using AgileWizard.Domain;
using AgileWizard.Domain.Users;
using AgileWizard.Website.Models;

namespace AgileWizard.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private const string RavenSessionKey = "Raven.Session";
        private static DocumentStore _documentStore;

        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                var documentSession = _documentStore.OpenSession();

                HttpContext.Current.Items[RavenSessionKey] = documentSession;

                ObjectFactory.Configure(x =>
                {
                    x.For<IDocumentSession>().HttpContextScoped().Use(documentSession);
                    x.For<IDocumentStore>().HttpContextScoped().Use(_documentStore);
                }
                );
            };

            EndRequest += (o, eventArgs) =>
            {
                var disposable = HttpContext.Current.Items[RavenSessionKey] as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            };
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            _documentStore.Initialize();

            new IndexRegister().RegisterAt(_documentStore);

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            RegisterIoC();

            ResourceMapper.ConfigAutoMapper();
            AccountMapper.ConfigAutoMapper();
        }

        private static void RegisterIoC()
        {
            ObjectFactory.Configure(x =>
            {
                x.AddRegistry(new ControllerRegistry());
                x.AddRegistry(new DomainRegistry());
            });


            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        public static IDocumentSession CurrentSession
        {
            get { return (IDocumentSession)HttpContext.Current.Items[RavenSessionKey]; }
        }

    }
}