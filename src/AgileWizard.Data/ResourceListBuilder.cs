using System.Collections.Generic;
using AgileWizard.Domain.Models;
using Raven.Client.Document;

namespace AgileWizard.Data
{
    public class ResourceListBuilder
    {
        private int _countOfPage = 1;
        private int _pageSize = 20;
        private bool _differentCreateTime;
        private bool _persistable;
        private string _tagName = "tag";

        public static ResourceListBuilder AnResourceList()
        {
            return new ResourceListBuilder();
        }

        public IList<Resource> Build()
        {
            var countOfResource = _countOfPage*_pageSize - (_pageSize - 1);
            var resources = new List<Resource>();

            for (int i = 0; i < countOfResource; i++)
            {
                var resourceBuilder = ResourceBuilder.AnResource().WithTag(_tagName);

                if (_differentCreateTime )
                {
                    resourceBuilder = resourceBuilder.WithCreateUpdateTime(i);
                }

                resources.Add(resourceBuilder.Build(i));

            }

            if (_persistable)
            {
                var documentStore = new DocumentStore { Url = "http://localhost:8080/" };
                documentStore.Initialize();
                var documentSession = documentStore.OpenSession();

                foreach(var resource in resources)
                {
                    documentSession.Store(resource);
                }

                documentSession.SaveChanges();

                new DataManager(documentStore).WaitForNonStaleResults(documentSession);
            }

            return resources;
        }

        public ResourceListBuilder OfPage(int countOfPage)
        {
            _countOfPage = countOfPage;
            return this;
        }

        public ResourceListBuilder WithDifferentCreateUpdateTime()
        {
            _differentCreateTime = true;
            return this;
        }

        public ResourceListBuilder PersistIntoRepository()
        {
            _persistable = true;
            return this;
        }

        public ResourceListBuilder WithTag(string tagName)
        {
            _tagName = tagName;
            return this;
        }
    }
}
