using System;
using Raven.Client;

namespace AgileWizard.Domain
{
    public interface IResourceRepository
    {
        void Add(string title, string content);
    }

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
                                   Guid = new Guid(),
                                   Title = title,
                                   Content = content,
                                   CreateTime = DateTime.Now,
                                   LastUpdateTime = DateTime.Now
                               };

            _documentSession.Store(resource);
            _documentSession.SaveChanges();

        }
    }
}