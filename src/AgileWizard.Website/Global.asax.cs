﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;
using Raven.Client;

namespace AgileWizard.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private const string RavenSessionKey = "Raven.Session";
        private static DocumentStore _documentStore;

        public MvcApplication() {
            BeginRequest += (sender, args) => HttpContext.Current.Items[RavenSessionKey] = _documentStore.OpenSession();
            EndRequest += (o, eventArgs) =>
            {
                var disposable = HttpContext.Current.Items[RavenSessionKey] as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            };
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
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

            new AgileWizard.Domain.QueryIndex.IndexRegister().RegisterAt(_documentStore);

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        public static IDocumentSession CurrentSession {
            get { return (IDocumentSession)HttpContext.Current.Items[RavenSessionKey]; }
        }

    }
}