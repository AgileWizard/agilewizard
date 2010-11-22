using AgileWizard.AcceptanceTests.Data;
using Raven.Client;
using Raven.Client.Document;
using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class UserRavenRepositoryTester
    {
        private IDocumentStore _documentStore;
        private IDocumentSession _documentSession;

        public UserRavenRepositoryTester()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            _documentStore.Initialize();

            var dataManager = new DataManager(_documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();

            _documentSession = _documentStore.OpenSession();
        }

        [Fact]
        public void get_user_by_name_when_user_exists_return_the_user()
        {
            const string userName = "agilewizard";

           var user = UserRavenRepository.GetUserByName(userName, _documentSession);

            Assert.Equal(userName,user.UserName);
        }
    }
}
