using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArestedDevelopment.Tests
{
    [TestFixture]
    class TestFactory
    {
        [Test]
        public void TestSimpleFactory()
        {
            var arDev = ArDeveloperFactory.SingleFileInOut(@"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\simple.txt", @"C:\Projects\Other\ARestedDevelopment\ARested.Tests\SampleFiles\gen\singlefileoutput\simple.cs");

            arDev.Develop();

        }
    }
}
