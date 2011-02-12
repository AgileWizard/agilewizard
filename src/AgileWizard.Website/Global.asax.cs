using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AgileWizard.Domain.Helper;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Website.Helper;
using AgileWizard.Website.Models;
using AutoMapper;
using Raven.Client.Document;
using Raven.Client;
using AgileWizard.Website.Controllers;
using StructureMap;
using AgileWizard.Domain;

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
            ConfigAutoMapper();
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

        public static void ConfigAutoMapper()
        {
            Mapper.CreateMap<Resource, ResourceListViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Utils.ExcerptContent(src.Content, 200)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Utils.FetchFirstImageUrl(src.Content)));

            Mapper.CreateMap<ResourceDetailViewModel, Resource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.Format("resources/{0}", src.Id)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToTagList()));

            Mapper.CreateMap<Resource, ResourceDetailViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Substring(10)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.ToTagString()));
        }

        public static IDocumentSession CurrentSession
        {
            get { return (IDocumentSession)HttpContext.Current.Items[RavenSessionKey]; }
        }

    }
}