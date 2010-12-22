using System.Reflection;

namespace AgileWizard.AcceptanceTests.Helper
{
    public static class RuntimeHelper
    {
        public static string GetPropertyName(this MethodBase currentMethod)
        {
            return currentMethod.Name.Substring(4);
        }
    }
}
