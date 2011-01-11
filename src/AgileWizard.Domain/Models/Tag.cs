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

        public DateTime LastUpdateTime
        {
            get
            {
                // plus 1/1/2011
                return new DateTime(2011, 1, 1).AddSeconds(ShortTicks);
            }
        }

        public int ShortTicks { get; set; }
    }
}
