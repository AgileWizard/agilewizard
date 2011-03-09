using AgileWizard.Website.Mapper;
using TechTalk.SpecFlow;
using Raven.Client.Document;
using AgileWizard.Data;
using StructureMap;
using AgileWizard.Domain;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;

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

            new IndexRegister().RegisterAt(documentStore);

            ObjectFactory.Configure(x =>
            {
                x.AddRegistry(new FakeControllerRegistry());
                x.AddRegistry(new DomainRegistry());
            });
            ObjectFactory.Configure(x => x.For<IDocumentStore>().Use(documentStore));

            ResourceMapper.ConfigAutoMapper();
            AccountMapper.ConfigAutoMapper();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
            var documentSession = documentStore.OpenSession();
            ObjectFactory.Configure(x => x.For<IDocumentSession>().Use(documentSession));

            var dataManager = new DataManager(documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            var documentSession = ObjectFactory.GetInstance<IDocumentSession>();
            documentSession.Dispose();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
            var dataManager = new DataManager(documentStore);
            dataManager.ClearAllDocuments();

            documentStore.Dispose();
        }
    }
}
