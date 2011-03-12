using System.Web.Mvc;

namespace AgileWizard.Domain.Tests
{
    public static class ModelErrorCollectionExtension
    {
        public static bool ContainsError(this ModelStateDictionary stateDictionary, string key, string error)
        {
            var contains = false;
            if (stateDictionary.ContainsKey(key))
            {
                var errors = stateDictionary[key].Errors;

                foreach (var errorItem in errors)
                {
                    if (string.Compare(errorItem.ErrorMessage, error) == 0)
                    {
                        contains = true;
                        break;
                    }
                }
            }

            return contains;
        }
    }
}
