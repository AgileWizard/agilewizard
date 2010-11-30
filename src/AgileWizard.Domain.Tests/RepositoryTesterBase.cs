using AgileWizard.AcceptanceTests.Data;
using Raven.Client;
using Raven.Client.Document;

namespace AgileWizard.Domain.Tests
{
    public class RepositoryTesterBase
    {
        private readonly IDocumentStore _documentStore;
        protected IDocumentSession _documentSession;
        protected readonly DataManager _dataManager;

        protected RepositoryTesterBase()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            _documentStore.Initialize();

            _dataManager = new DataManager(_documentStore);
            _dataManager.ClearAllDocuments();

            _documentSession = _documentStore.OpenSession();
        }
    }
}
