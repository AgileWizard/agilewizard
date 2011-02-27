using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Raven.Client;
using Raven.Client.Linq;

namespace AgileWizard.Domain.Tests
{
    public static class RavenDBHelper
    {
        public static Mock<IDocumentSession> SetupQueryResult<T>(this Mock<IDocumentSession> documentSession, string indexName, IEnumerable<T> result) 
        {
            EnsureSession(ref documentSession);

            var ravenQueryableMock = new Mock<IRavenQueryable<T>>();
            ravenQueryableMock.Setup(x => x.GetEnumerator()).Returns(()=>result.GetEnumerator());
            ravenQueryableMock.Setup(x => x.Customize(It.IsAny<Action<Object>>()).GetEnumerator()).Returns(() => result.GetEnumerator());
            
            documentSession.Setup(s => s.Query<T>(indexName)).Returns(ravenQueryableMock.Object).Verifiable();
            
            return documentSession;
        }

        public static Mock<IDocumentSession> SetupLuceneQueryResult<T>(this Mock<IDocumentSession> documentSession, string indexName, IEnumerable<T> result)
        {
            EnsureSession(ref documentSession);

            var documentQueryMock = new Mock<IDocumentQuery<T>>();
            documentQueryMock.Setup(x => x.GetEnumerator()).Returns(() => result.GetEnumerator());
            //documentQueryMock.Setup(x => x.Customize(It.IsAny<Action<Object>>()).GetEnumerator()).Returns(() => result.GetEnumerator());

            documentSession.Setup(s => s.Advanced.LuceneQuery<T>(indexName)).Returns(documentQueryMock.Object).Verifiable();

            return documentSession;
        }


        public static Mock<IDocumentSession> SetupStoreExpectation<T>(this Mock<IDocumentSession> documentSession, Expression<Func<T, bool>> match)
        {
            EnsureSession(ref documentSession);
            documentSession.Setup(s => s.Store(It.Is<T>(match))).Verifiable();
            return documentSession;
        }

        public static Mock<IDocumentSession> SetupSaveChangesCalledExpectation(this Mock<IDocumentSession> documentSession)
        {
            EnsureSession(ref documentSession);
            documentSession.Setup(s => s.SaveChanges()).Verifiable();
            return documentSession;
        }

        private static Mock<IDocumentSession> EnsureSession(ref Mock<IDocumentSession> documentSession)
        {
            if (documentSession == null)
                documentSession = new Mock<IDocumentSession>();
            return documentSession;
        }
    }
}
