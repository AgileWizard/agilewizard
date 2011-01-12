using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace AgileWizard.Domain.Services
{
    public static class ServiceGateway
    {
        public static IResourceService ResourceService
        {
            get
            {
                return GetService<IResourceService>();
            }
        }

        public static ITagService TagService
        {
            get
            {
                return GetService<ITagService>();
            }
        }

        private static T GetService<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
