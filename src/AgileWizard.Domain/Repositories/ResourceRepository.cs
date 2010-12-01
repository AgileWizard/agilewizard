using System;
using AgileWizard.Domain.Entities;
using Raven.Client;

namespace AgileWizard.Domain.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDocumentSession _documentSession;

        public ResourceRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Add(string title, string content)
        {
            var resource = new Resource
                               {
                                   Title = title,
                                   Content = content,
                                   CreateTime = DateTime.Now,
                                   LastUpdateTime = DateTime.Now
                               };

            _documentSession.Store(resource);
            _documentSession.SaveChanges();

        }

        public Resource GetResourceById(string id)
        {
            return _documentSession.Load<Resource>(string.Format("resources/{0}", id));
        }

    }
}