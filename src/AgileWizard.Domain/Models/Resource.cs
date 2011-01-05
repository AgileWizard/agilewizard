using System;
using System.Collections.Generic;

namespace AgileWizard.Domain.Models
{
    public class Resource
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
       
        public string ReferenceUrl { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public string SubmitUser { get; set; }

        public List<ResourceTag> Tags { get; set; }

        public class ResourceTag
        {
            public string Name { get; set; }
        }

    }
}
