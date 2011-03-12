using System;
using Xunit;

namespace AgileWizard.AcceptanceTests.Helper
{
    public static class AssertHelper
    {
        public static void EqualOrIgnore<T>(T expected, T actual)
        {
            if (expected != null)
                Assert.Equal<T>(expected, actual);
        }

        public static void EqualOrIgnore(string expected, string actual, StringComparer comparer)
        {
            if (expected != null)
                Assert.Equal(expected, actual, comparer);
        }
    }
}
