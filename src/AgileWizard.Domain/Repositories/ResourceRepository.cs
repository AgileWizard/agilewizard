﻿using System;
using System.Collections.Generic;
using AgileWizard.Domain.Entities;
using AgileWizard.Domain.QueryIndexes;
using Raven.Client;
using System.Linq;

namespace AgileWizard.Domain.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDocumentSession _documentSession;

        public ResourceRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public Resource Add(string title, string content, string author)
        {
            var resource = new Resource
                               {
                                   Title = title,
                                   Content = content,
                                   Author = author,
                                   CreateTime = DateTime.Now,
                                   LastUpdateTime = DateTime.Now
                               };

            _documentSession.Store(resource);
            return resource;

        }

        public Resource GetResourceById(string id)
        {
            return _documentSession.Load<Resource>(string.Format("resources/{0}", id));
        }

        public List<Resource> GetResourceList()
        {
            var query = (IEnumerable<Resource>)_documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name).Customize(x => x.WaitForNonStaleResults());
            return query.OrderByDescending(x => x.LastUpdateTime).Take<Resource>(100).ToList();
        }

        public int GetResourcesTotalCount()
        {
            var query = (IEnumerable<Resource>)_documentSession.Query<Resource>(typeof(ResourceIndexByTitle).Name);
            return query.Count<Resource>();
        }

        public void Save()
        {
            _documentSession.SaveChanges();
        }
    }
}