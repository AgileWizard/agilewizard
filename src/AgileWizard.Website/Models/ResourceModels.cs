using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace AgileWizard.Website.Models
{
    public class ResourceModel
    {
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("CreateTime")]
        public DateTime CreateTime { get; set; }

        [DisplayName("Author")]
        public string Author { get; set; }
    }

    public class ResourceList : List<ResourceModel>
    {
        public int TotalCount { set; get; }

    }
}