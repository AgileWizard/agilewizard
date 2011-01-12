using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using AgileWizard.Domain.Models;
using AgileWizard.Domain.QueryIndexes;

namespace AgileWizard.Domain.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IDocumentSession _documentSession;

        public TagRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public List<Tag> GetTagList(int maxCount)
        {
            var query = _documentSession.Query<Tag>(typeof(TagAggregateIndex).Name);
            return query.Take(maxCount).ToList();
        }
    }
}
