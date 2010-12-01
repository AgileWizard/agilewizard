using System.Linq;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Moq;
using Raven.Client.Document;
using Xunit;
using Raven.Client;
using System.Collections.Generic;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class ResourceRepositoryTest : RepositoryTestBase
    {
        private readonly ResourceRepository _resourceRepositorySUT;
        private Mock<IDocumentSession> _session;

        public ResourceRepositoryTest()
        {
            _session = new Mock<IDocumentSession>();
            _resourceRepositorySUT = new ResourceRepository(_session.Object);
        }

        [Fact]
        public void add_resource()
        {
            //Arrange
            const string TITLE = "title";
            const string CONTENT = "content";
            _session.Setup(s => s.Store(It.Is<Resource>(r => r.Title == TITLE && r.Content == CONTENT))).Verifiable();
            _session.Setup(s => s.SaveChanges()).Verifiable();
            
            //Act
            _resourceRepositorySUT.Add(TITLE, CONTENT);

            //Assert
            _session.VerifyAll();
        }

        [Fact]
        public void Given_an_id_should_return_a_resource()
        {
            //Arrange
            const string ID = "1";
            _session.Setup(s => s.Load<Resource>(DocumentId(ID))).Verifiable();

            //Act
            _resourceRepositorySUT.GetResourceById(ID);

            //Assert
            _session.VerifyAll();
        }

        [Fact]
        public void Can_get_a_list_of_resources()
        {
            //Arrange
            var resourceQuery = new Mock<IDocumentQuery<Resource>>();
            var enumerator = (new List<Resource>()).GetEnumerator();
            resourceQuery.Setup(q => q.GetEnumerator()).Returns(enumerator);
            _session.Setup(s => s.LuceneQuery<Resource>(typeof(ResourceIndexByTitle).Name)).Returns(resourceQuery.Object);

            //Act
            _resourceRepositorySUT.GetResourceList();

            //Assert
            _session.VerifyAll();
        }

        private string DocumentId(string id)
        {
            return string.Format("resources/{0}", id);
        }
    }

}
