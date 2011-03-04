using Moq;
using Raven.Client;

namespace AgileWizard.Domain.Tests.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected Mock<IDocumentSession> _session;

        protected RepositoryTestBase()
        {
            _session = new Mock<IDocumentSession>();
        }

    }
}
