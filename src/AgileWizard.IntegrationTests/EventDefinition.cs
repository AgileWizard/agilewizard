using TechTalk.SpecFlow;
using Raven.Client.Document;
using AgileWizard.Data;
using StructureMap;
using AgileWizard.Domain;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using AgileWizard.Website;
using AgileWizard.Website.Models;

namespace AgileWizard.IntegrationTests
{
    [Binding]
    public class EventDefinition
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            documentStore.Initialize();

            var dataManager = new DataManager(documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();

            new IndexRegister().RegisterAt(documentStore);

            ObjectFactory.Configure(x =>
            {
                x.AddRegistry(new FakeControllerRegistry());
                x.AddRegistry(new DomainRegistry());
            });

            var documentSession = documentStore.OpenSession();
            ObjectFactory.Configure(x =>
            {
                x.For<IDocumentSession>().Use(documentSession);
            }
            );

            MvcApplication.ConfigAutoMapper();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }
    }
}
