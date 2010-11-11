using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgileWizard.Website.Models
{
    public class ResourceModel
    {
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Content")]
        public string Content { get; set; }
    }
}