using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Services
{
    public class TagService : ITagService
    {
        private ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public List<Tag> GetTagList(int maxCount)
        {
            return _repository.GetTagList(maxCount);
        }
    }
}
