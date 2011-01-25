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

        public int ShortTicks
        {
            get
            {
                // substract 1/1/2011
                return (int)LastUpdateTime.Subtract(new DateTime(2011, 1, 1)).TotalSeconds;
            }
        }

        public string SubmitUser { get; set; }

        public List<ResourceTag> Tags { get; set; }

        public int PageView { get; set; }

        public class ResourceTag
        {
            public string Name { get; set; }
        }

    }
}
