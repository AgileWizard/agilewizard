using System.Collections.Generic;
using System.Linq;
using AgileWizard.Domain.Models;

namespace AgileWizard.Domain.Services
{
    internal class ResourceFilter
    {
        private const int _maxItemsInList = 20;

        public IEnumerable<Resource> Filter(IEnumerable<Resource> query, long ticksOfLastCreateTime)
        {
            return query.Where(x => x.CreateTime.Ticks < ticksOfLastCreateTime).OrderByDescending(x => x.CreateTime).Take(_maxItemsInList); 
        }
    }
}
