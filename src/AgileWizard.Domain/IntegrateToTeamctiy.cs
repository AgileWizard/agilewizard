using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileWizard.Domain
{
    public class IntegrateToTeamctiy
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string GetTypeName<T>(T obj)
        {
            return obj.GetType().Name;
        }

        public object GetPropertyValue<T>(T obj, string propName)
        {
            if (obj == null) return 0;

            var type = typeof(T);
            var props = type.GetProperties();
            var firstPropValue = default(Object);

            if (props != null && props.Length > 0)
            {
                var selectProp = props.Single(p => string.Compare(p.Name, propName, StringComparison.OrdinalIgnoreCase) == 0);
                if (selectProp.CanRead) firstPropValue = selectProp.GetValue(obj, null);
            }

            return firstPropValue;
        }
    }
}
