using System;

namespace AgileWizard.Domain.Entities
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
    }
}
