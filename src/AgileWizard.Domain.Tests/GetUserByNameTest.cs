using AgileWizard.AcceptanceTests.Data;
using Raven.Client;
using Raven.Client.Document;
using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class GetUserByNameTest
    {
        private IDocumentStore _documentStore;
        private IDocumentSession _documentSession;

        public GetUserByNameTest()
        {
            _documentStore = new DocumentStore { Url = "http://localhost:8080/" };
            _documentStore.Initialize();

            var dataManager = new DataManager(_documentStore);
            dataManager.ClearAllDocuments();
            dataManager.InitData();

            _documentSession = _documentStore.OpenSession();
        }

        //[Fact]
        public void when_user_exists_return_the_user()
        {
            const string userName = "agilewizard";

            var user = new UserRepository(_documentSession).GetUserByName(userName);

            Assert.Equal(userName, user.UserName);
        }

        [Fact]
        public void when_user_not_exists_return_empty_user()
        {
            const string userName = "non_exist_user";

            var user = new UserRepository(_documentSession).GetUserByName(userName);

            var expectedEmptyUser = User.EmptyUser();

            Assert.Equal(expectedEmptyUser.UserName, user.UserName);
        }
    }
}
