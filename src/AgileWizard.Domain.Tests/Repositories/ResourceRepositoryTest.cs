using System.Linq;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using AgileWizard.Domain.Repositories;
using Moq;
using Raven.Client.Document;
using Xunit;
using Raven.Client;
using System.Collections.Generic;
using Raven.Client.Linq;
using System;

namespace AgileWizard.Domain.Tests.Repositories
{
    public class ResourceRepositoryTest
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
            _session.SetupStoreExpectation<Resource>(r => r.Title == TITLE && r.Content == CONTENT);
            _session.SetupSaveChangesCalledExpectation();
            
            //Act
            _resourceRepositorySUT.Add(TITLE, CONTENT);

            //Assert
            _session.VerifyAll();
        }

        [Fact]
        public void can_get_one_resource_with_given_id()
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
        public void can_get_a_list_of_resources()
        {
            //Arrange
            _session.SetupQueryResult<Resource>(typeof(ResourceIndexByTitle).Name, 101.CountOfResouces());
            
            //Act
            var resources = _resourceRepositorySUT.GetResourceList();

            //Assert
            Assert.Equal(resources.Count, 101);
            _session.VerifyAll();
        }

        private string DocumentId(string id)
        {
            return string.Format("resources/{0}", id);
        }
    }

    internal static class ResourcesGenerator
    {
        internal static IEnumerable<Resource> CountOfResouces(this int totalCount)
        {
            for(int i = 0;i<totalCount;i++)
                yield return new Resource { Author = "agilewizard", Content = "agilewizard blog number" + i , CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now, Title = "agilewizard", Id = "1" };
        }
    }
}


