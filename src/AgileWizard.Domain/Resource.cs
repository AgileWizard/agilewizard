using System;

namespace AgileWizard.Domain
{
    public class Resource
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid Guid { get; set; }

        public string Author { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
