using Raven.Client;
using Raven.Client.Document;
using Raven.Database.Data;
using System;

namespace AgileWizard.Domain.Tests.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected readonly IDocumentStore _documentStore;
        protected IDocumentSession _documentSession;

        protected RepositoryTestBase()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            _documentStore.Initialize();

            _documentSession = _documentStore.OpenSession();
        }

        protected void PrepareData<T>(T entity, string indexName)
        {
            _documentSession.Store(entity);
            _documentSession.SaveChanges();

            _documentSession.Query<T>(indexName).Customize(x => x.WaitForNonStaleResults());
            //_documentSession.Query<T>(indexName).Customize(x => x.WaitForNonStaleResultsAsOfNow(TimeSpan.FromSeconds(10)));
        }

        protected void DeleteDataByIndex(string indexName)
        {
            _documentStore.DatabaseCommands.DeleteByIndex(indexName, new IndexQuery(), true);

        }

    }
}
