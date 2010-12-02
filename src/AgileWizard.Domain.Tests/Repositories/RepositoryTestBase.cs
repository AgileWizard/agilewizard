using Moq;
using Raven.Client;

namespace AgileWizard.Domain.Tests.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected Mock<IDocumentSession> _session;
        
        protected RepositoryTestBase()
        {
            //_documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            //_documentStore.Initialize();
            _session = new Mock<IDocumentSession>();

            //_documentSession = _documentStore.OpenSession();
        }

    }
}
