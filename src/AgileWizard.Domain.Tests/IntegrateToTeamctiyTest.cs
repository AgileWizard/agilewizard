using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Sdk;
using Xunit;

namespace AgileWizard.Domain.Tests
{
    public class IntegrateToTeamctiyTest
    {
        [Fact]
        public void Add_TwoSimleNumber_ReturnSummaryOfThem()
        {
            var a = 5555;
            var b = 3333;
            var s = 8888;

            var t = new IntegrateToTeamctiy();

            Assert.Equal(s, t.Add(a, b));
        }

        [Fact]
        public void GetTypeName_NullValuePassedIn_ThrowNullReferenceException()
        {
            var t = new IntegrateToTeamctiy();

            Assert.Throws<NullReferenceException>(() => t.GetTypeName<string>(default(string)));
        }

        [Fact]
        public void GetFirstPropertyValue_JustForCodeCoverageTest()
        {
            var t = new IntegrateToTeamctiy();

            var testObject = "agile";

            var propetyValue = t.GetPropertyValue<string>(testObject, "length");
            Assert.NotSame(5, propetyValue);
            Assert.True(int.Parse(propetyValue.ToString()) == 5);
        }
    }
}
