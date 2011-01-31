using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileWizard.Domain.Models;

namespace AgileWizard.IntegrationTests.Helpers
{
    public static class TagExtension
    {
        public static bool Contains(this List<Tag> tagList, string tagName)
        {
            foreach (var x in tagList)
            {
                if (x.Name == tagName.ToLower())
                    return true;
            }

            return false;
        }
    }
}
