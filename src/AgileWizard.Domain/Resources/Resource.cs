using System;
using System.Collections.Generic;

namespace AgileWizard.Domain.Resources
{
    public class Resource
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public string SubmitUser { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
