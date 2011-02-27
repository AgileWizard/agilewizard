using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileWizard.Domain.Models
{
    public class Tag
    {
        public string Name { get; set; }

        public int TotalCount { get; set; }

        public long LastUpdateTicks { get; set; }
    }
}
